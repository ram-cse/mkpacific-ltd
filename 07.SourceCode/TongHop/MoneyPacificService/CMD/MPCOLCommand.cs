using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;
using MoneyPacificService.BUS;
using MoneyPacificService.Util;

namespace MoneyPacificService.CMD
{
    internal class MPCOLCommand : AMPCommand
    {
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
        internal override string Execute()
        {
            string sPhone = args[0].Trim();
            string collectNumber = args[2].Trim();

            string sReceivePhone = sPhone;
            string sContentSMS = "";

            StoreManager existStoreManager = null;
            Collection existCollection = null;
            Agent existAgent = null;

            // B1. Neu khong phải là SM đồng thời cũng khong phải là SU
            if (!StoreManagerDAO.IsExist(sPhone) && !StoreUserDAO.IsExist(sPhone))
            {
                // TODO: LOCK ACCOUNT IF GET THIS FAULT 3 TIMES
                sContentSMS = MessageManager.GetValue("MPCOL_NO_PERMISSION");
            }
            else
            {
                // B2. Kiem tra CollectCode ton tai va thuoc so huu
                existStoreManager = GetStoreManager(sPhone);

                existCollection = CollectionDAO.GetObject(collectNumber);
                if (existCollection == null)
                {
                    // TODO: LOCK ACCOUNT IF GET THIS FAULT 3 TIMES
                    sContentSMS = MessageManager.GetValue("MPCOL_WRONG_COLLECT_NUMBER");
                }
                else
                {
                    existAgent = AgentDAO.GetObject((Guid)existCollection.AgentId);
                    User userInfo = UserDAO.GetObject((Guid)existCollection.AgentId);

                    if (existCollection.StoreManagerId != existStoreManager.UserId)
                    {
                        // TODO: LOCK ACCOUNT IF GET THIS FAULT 3 TIMES
                        sContentSMS = MessageManager.GetValue("MPCOL_WRONG_COLLECT_NUMBER");
                    }
                    else
                    {
                        // B3: Kiem tra thuoc tinh CollectCode
                        if (existCollection.StatusId == CollectionStateBUS.GetId("Collected"))
                        { 
                            sContentSMS = MessageManager.GetValue("MPCOL_COLLECTED"
                                ,existCollection.CollectNumber.Trim()
                                ,Utility.formatMoney((int)existCollection.Amount)
                                ,existCollection.CollectDate.Value.ToShortDateString()
                                ,userInfo.Firstname.Trim() + "." + userInfo.Lastname.Trim()
                                ,existAgent.Phone);
                        }
                        else if (existCollection.StatusId == CollectionStateBUS.GetId("Processing")
                            && existCollection.ExpireDate.Value.Date < DateTime.Today.Date)
                        {
                            sContentSMS = MessageManager.GetValue("MPCOL_WRONG_COLLECT_NUMBER") + "..."; 
                            //... de danh dau fake message
                        }
                        else if (existCollection.StatusId == CollectionStateBUS.GetId("Processing")
                            && existCollection.ExpireDate.Value.Date >= DateTime.Today.Date)
                        {
                            // Thực hiện thanh toán
                            int iTotalAmount = StoreManagerBUS.GetTotalAmount(existStoreManager.UserId);
                            int iCollectedAmount = StoreManagerBUS.GetTotalCollectedAmount(existStoreManager.UserId);
                            int iAmount = iTotalAmount - iCollectedAmount;

                            existCollection = CollectionDAO.GetObject(collectNumber);

                            // Thanh toán
                            if (iAmount > 0)
                            {
                                bool bSuccess = CollectionBUS.CollectAmountMoney(collectNumber, iAmount);
                                // Lay lại thông tin vừa cập nhật để thông báo về..
                                existCollection = CollectionDAO.GetObject(collectNumber);

                                // Tra ra thong bao
                                sContentSMS = MessageManager.GetValue("MPCOL_SUCCESSFULL"
                                    , Utility.formatMoney((int)existCollection.Amount)
                                    , userInfo.Firstname.Trim() + "." + userInfo.Lastname.Trim()
                                    , existAgent.Phone);
                                // ---> Cần thay existAgent bằng ID, không phải bằng Phone
                            }
                            else
                            {
                                sContentSMS = MessageManager.GetValue("MPCOL_WRONG_COLLECT_NUMBER") + "... ..."; 
                            }
                            
                        }
                        else
                        {
                            sContentSMS = "MP: CollectCode co thuoc tinh khong xac dinh!..";
                        }
                    }
                }            
            }

            // B4: Trả ra kết quả
            return sReceivePhone + "*" + sContentSMS;
        }

        // Lấy đối tượng StoreManager khi nhập vào số phone của SU hoặc SM
        private StoreManager GetStoreManager(string sPhone)
        {
            StoreManager existStoreManager = null;
            if (StoreManagerDAO.IsExist(sPhone))
            {
                existStoreManager = StoreManagerDAO.GetObject(sPhone);
            }
            else if (StoreUserDAO.IsExist(sPhone))
            {
                StoreUser existStoreUser = StoreUserDAO.GetObject(sPhone);
                existStoreManager = StoreManagerDAO.GetObject((Guid)existStoreUser.ManagerId);
            }
            return existStoreManager;
        }
    }
}