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
    }
}