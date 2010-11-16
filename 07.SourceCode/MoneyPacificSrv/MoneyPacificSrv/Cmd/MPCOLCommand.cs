using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificSrv.DTO;
using MoneyPacificSrv.BUS;

namespace MoneyPacificSrv.Cmd
{
    public class MPCOLCommand : IMPCommand
    {
        #region IMPCommand Members

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
        
        public string Execute(string[] args)
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

        #endregion
    }
}