using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;
using MoneyPacificSrv.BUS;
using MoneyPacificSrv.Util;

namespace MoneyPacificSrv.Cmd
{
    public class MPCOLCommand : IMPCommand
    {
        #region IMPCommand Members

        
        /// Giải thuật:
        /// B1. Kiểm tra là SU hoặc SM 
        /// - Nếu không là SU hoặc SM: -> "Ban ko co quyen. neu tiep tuc ban se bi khoa"
        /// - Neu la SU hoặc SM:
        ///     + Lấy thông tin SM: -> B2
        /// B2. Kiem tra Collect Code ton tai hay khong:
        /// - Neu CollectCode khong ton tai: -> "Sai Collect Code"
        /// - Neu CollectCode ton tai & không thuộc SM đó -> "Sai Collect Code"
        /// - Neu CollectCode ton tai & thuoc SM đó: -> B3
        /// B3. Kiem tra thuoc tinh Collect Code:
        /// - Neu da het han: -> "Thong bao Expire"
        /// - Neu da thanh toan (Collected): -> "CC da thanh toan {} vào ngay {} 
        ///     do Mr {} co Id la {}."
        /// - Neu chua thanh toan & còn hạn:
        ///     Thông báo: "Vui long thanh toan so tien {} VND cho Ong/Ba.{} co ID la
        ///     {}. Kiem tra ID cua nguoi nhan truoc khi thanh toan."
        /// B4. Tra ra ket qua
        /// <summary>
        /// MPCOL: Thanh toán TOÀN BỘ số tiền chưa trả cho Money PacificCode
        /// Cú Pháp: args[0]*MPCOL*args[2]
        /// args[0]: Phone của StoreUser hoặc StoreManager
        /// args[1]: MPCOL
        /// args[2]: COLLECT CODE
        /// </summary>
        public string Execute(string[] args)
        {
            string sPhone = args[0].Trim();
            string sCollectCode = args[2].Trim();
            string sReceivePhone = sPhone;
            string sContentSMS = "";
            StoreManager existStoreManager = null;
            CollectMoney existCollectMoney = null;
            Agent existAgent = null;


            // B1. Neu khong phải là SM đồng thời cũng khong phải là SU
            if (!StoreManagerBUS.IsExist(sPhone) && !StoreUserBUS.IsExist(sPhone))
            { 
                // TODO: LOCK AFTER 3 TIME
                sContentSMS = MessageManager.GetValue("MPCOL_NO_PERMISSION");
            }
            else
            {
                existStoreManager = GetStoreManager(sPhone);

                // B2. Kiem tra CollectCode ton tai va thuoc so huu
                existCollectMoney = CollectMoneyBUS.GetItem(sCollectCode);
                if (existCollectMoney == null)
                {
                    // TODO: LOCK AFTER 3 TIME
                    sContentSMS = MessageManager.GetValue("MPCOL_WRONG_COLLECT_NUMBER");
                }
                // Nguoc lai neu thuoc quyen so huu
                else
                {
                    existAgent = AgentBUS.GetItem((int)existCollectMoney.AgentId);

                    if (existCollectMoney.StoreManagerId != existStoreManager.Id)
                    {
                        // TODO: LOCK AFTER 3 TIME                        
                        sContentSMS = MessageManager.GetValue("MPCOL_WRONG_COLLECT_NUMBER");
                    }
                    else
                    {
                        // B3. Kiem tra thuoc tinh Colllect Code
                        if(existCollectMoney.StatusId == CollectStateBUS.GetId("Collected"))
                        {
                            //sContentSMS = "Collect Code nay da duoc thanh toan {}VND vao ngay {}"
                            //    + " boi ong/ba {} co ID la {}";
                            sContentSMS = MessageManager.GetValue("MPCOL_COLLECTED"
                                ,existCollectMoney.CollectNumber.Trim()
                                ,Utility.formatMoney((int)existCollectMoney.Amount)
                                ,existCollectMoney.CollecteDate.Value.ToShortDateString()
                                ,existCollectMoney.Agent.FistName.Trim() + "." + existCollectMoney.Agent.LastName.Trim()
                                ,existCollectMoney.Agent.Id.ToString());


                        }
                        else if (existCollectMoney.StatusId == CollectStateBUS.GetId("Processing")
                            && existCollectMoney.ExpireDate.Value.Date <= DateTime.Today.Date)
                        {
                            sContentSMS = MessageManager.GetValue("MPCOL_WRONG_COLLECT_NUMBER") + "..."; 
                            // Danh sau het han bang '...'
                            // sContentSMS = "CollectCode nay da het han";
                        }
                        else if(existCollectMoney.StatusId == CollectStateBUS.GetId("Processing")
                            && existCollectMoney.ExpireDate.Value.Date > DateTime.Today.Date)
                        {
                            // Thuc hien thanh toan
                            int iTotalAmount = StoreManagerBUS.GetTotalAmount(existStoreManager.Id);
                            int iCollectedAmount = StoreManagerBUS.GetTotalCollectedAmount(existStoreManager.Id);
                            int iAmount = iTotalAmount - iCollectedAmount;

                            existCollectMoney = CollectMoneyBUS.GetItem(sCollectCode);

                            // Thanh toan
                            bool bSuccess = CollectMoneyBUS.CollectAmountMoney(sCollectCode, iAmount);
                            // Lay lai thong tin vua cap nhat
                            existCollectMoney = CollectMoneyBUS.GetItem(sCollectCode);

                            sContentSMS = MessageManager.GetValue("MPCOL_SUCCESSFULL"
                                ,Utility.formatMoney((int)existCollectMoney.Amount)
                                ,existCollectMoney.Agent.FistName.Trim() + "." + existCollectMoney.Agent.LastName.Trim()
                                ,existCollectMoney.AgentId.ToString());                            
                        }
                        else
                        {
                            sContentSMS = "Collect Code co thuoc tinh khong xac dinh!.";
                        }
                    }
                }
            }
            
            
            // B4: Tra ra ket qua
            return sReceivePhone + "*" + sContentSMS;
        }

        private StoreManager GetStoreManager(string sPhone)
        {
            StoreManager existStoreManager = null;
            if (StoreManagerBUS.IsExist(sPhone))
            {
                existStoreManager = StoreManagerBUS.GetItem(sPhone);
            }
            else if(StoreUserBUS.IsExist(sPhone) )
            {
                StoreUser existStoreUser  = StoreUserBUS.GetItem(sPhone);
                existStoreManager  = StoreManagerBUS.GetItem((int)existStoreUser.ManagerId);
            }            
            return existStoreManager;
        }


        /// <summary>
        /// MPCOL: Thanh toán TOÀN BỘ số tiền chưa trả cho Money PacificCode
        /// Cú Pháp: args[0]*MPCOL*args[2]
        
        /// args[0]: Phone của StoreUser hoặc StoreManager
        /// args[1]: MPCOL
        /// args[2]: COLLECT CODE
        
        /// Giải thuật:
        /// Lấy số Phone của Store Manager
        /// Kiểm tra PINStore từ các StoreUser 
        /// Lấy iTotalAmount của SM        
        /// Lấy iCollected
        /// Amount = iTotalAmount - iCollected
        /// Kiểm tra ExpireDate & CreateDate
        /// => Chuyển status thành Collected
        /// </summary>        
        /// TODO: Cần nâng tính bảo mật của hàm này lên, 
        /// (số lần thử sai lệnh -> khóa tài khoản?)
        /// VERSION 0.1
        
        /*
        private string iExecute(string[] args)
        {
            /// DECLARE
            string sPhone = args[0].Trim();
            string sCollectCode = args[2].Trim();
            string sReceivePhone = sPhone;
            string sContentSMS = ""; 
            int iAmount;

            /// VALIDATING
            StoreManager existStoreManager = null;
            CollectMoney existCollectMoney;
            Agent existAgent = new Agent();
            
            bool isValidate = false;
            
            if (StoreUserBUS.IsExist(sPhone))
            {
                StoreUser existStore = StoreUserBUS.GetItem(sPhone);                                
                existStoreManager = StoreManagerBUS.GetItem((int)existStore.ManagerId);
                isValidate = true;
            }
            else if (StoreManagerBUS.IsExist(sPhone))
            {
                existStoreManager = StoreManagerBUS.GetItem(sPhone);
                isValidate = true;
            }
            else
            {
                // isValidate = false; // default là false rồi
            }

            isValidate = isValidate & CollectMoneyBUS.IsExistProcessing(sCollectCode);

            /// EXECUTING
            /// CHECK Correct CollectNumber & Exacly StoreManager
            /// Nếu có quyền thì sẽ kiểm tra: CollectMoney này của đúng 
            
            existCollectMoney = CollectMoneyBUS.GetItem(sCollectCode);
            if(isValidate & (existCollectMoney!=null))
            {
                existAgent = AgentBUS.GetItem((int)existCollectMoney.AgentId);                
                // PHẢI KIỂM TRA CẢ NGÀY THÁNG EXPIRE

                isValidate = isValidate 
                    & (existCollectMoney.StoreManagerId == existStoreManager.Id);

                //isValidate = isValidate
                //    & (existCollectMoney.StoreManagerId == existStoreManager.Id)
                //    & (existCollectMoney.ExpireDate.Value.Date > DateTime.Today.Date);
            }
            else
            {
                isValidate = false;
            }
            
            if (isValidate)
            {
                int iTotalAmount = StoreManagerBUS.GetTotalLastMonthAmount(existStoreManager.Id);
                int iCollectedAmount = StoreManagerBUS.GetTotalCollectedAmount(existStoreManager.Id);
                iAmount = iTotalAmount - iCollectedAmount;
                 

                bool bSuccess = CollectMoneyBUS.CollectAmountMoney(sCollectCode, iAmount);

                if (bSuccess == true)
                {
                    sContentSMS = MessageManager.GetValue("MPCOL_SUCCESSFULL",iAmount.ToString()
                        ,existAgent.LastName + "." + existAgent.FistName
                        ,existAgent.Id.ToString());
                }
                else
                {
                    sContentSMS = MessageManager.GetValue("MPCOL_GET_COLLECT_CODE_ERROR");
                }
            }
            else
            {
                sContentSMS = MessageManager.GetValue("MPCOL_GET_COLLECT_CODE_ERROR");
            }
            
            /// RETURN THE RESULT
            
            return sReceivePhone + "*" + sContentSMS;
        }
        //*/
        #endregion

        
    }
}