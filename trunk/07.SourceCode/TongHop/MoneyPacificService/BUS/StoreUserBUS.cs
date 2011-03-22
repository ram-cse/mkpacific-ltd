using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;

namespace MoneyPacificService.BUS
{
    public class StoreUserBUS
    {
        internal static bool IsExist(StoreUser senderStore)
        {
            return StoreUserDAO.IsExist(senderStore.Phone);
        }

        internal static bool IsEnable(Guid userId)
        {
            StoreUser existStore = StoreUserDAO.GetObject(userId);

            StoreManager existStoreManager = StoreManagerDAO.GetObject((Guid)existStore.ManagerId);

            if (existStoreManager.IsLocked == null) existStoreManager.IsLocked = true;
            bool bManagerIsLocked = (bool)existStoreManager.IsLocked;

            if (existStore.Enable == true && bManagerIsLocked == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static bool checkPINStore(StoreUser senderStore)
        {
            StoreUser existStore = StoreUserDAO.GetObject(senderStore.Phone);
            if (existStore.PINStore == senderStore.PINStore)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        internal static StoreUser GetObject(string phoneNumber)
        {
            return StoreUserDAO.GetObject(phoneNumber);
        }

        internal static int GetTotalAmount(Guid userId)
        {
            List<PartPacificCode> lstPPC = PartPacificCodeDAO.GetList(userId);
            
            int iAmount = 0;
            BlackBoxServiceClient clientService = new BlackBoxServiceClient();

            foreach (PartPacificCode ppc in lstPPC)
            {
                iAmount += clientService.GetValue(ppc.PartCodeNumber);
            }

            return iAmount;
        }

        internal static bool Validate(string phoneNumber, string pinStore)
        {
            // TODO:
            // Chưa kiểm tra cả ENABLE & STATUS

            bool bResult = true;
            if (StoreUserDAO.IsExist(phoneNumber))
            {
                StoreUser existStore = StoreUserDAO.GetObject(phoneNumber);
                bResult = bResult & (existStore.PINStore == pinStore);
                bResult = bResult & (bool)existStore.Enable;

                return bResult; 
            }
            else
            {
                return false;
            }
        }
    }
}