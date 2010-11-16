using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificSrv.DTO;
using MoneyPacificSrv.DAO;

namespace MoneyPacificSrv.BUS
{
    public class StoreUserBUS
    {
        internal static bool IsExist(StoreUser senderStore)
        {
            return StoreUserDAO.IsExist(senderStore);
        }

        internal static bool checkPassword(StoreUser senderStore)
        {
            return StoreUserDAO.CheckPassword(senderStore);
        }

        internal static StoreUser getStoreUser(string storePhone, string pinStore)
        {
            return StoreUserDAO.GetStoreUser(storePhone, pinStore);
        }

        internal static StoreUser[] GetArray(int managerId)
        {
            return StoreUserDAO.GetArray(managerId);
        }

        internal static bool IsExist(string sPhone)
        {
            return StoreUserDAO.IsExist(sPhone);
        }

        internal static bool Validate(string sPhone, string sPINStore)
        {
            /// TODO
            /// CHƯA kiểm tra cả ENABLE & STATUS             

            bool bResult = true;
            if(StoreUserDAO.IsExist(sPhone))
            {
                StoreUser existStore = StoreUserDAO.GetItem(sPhone);
                bResult = bResult & (existStore.PINStore == sPINStore);
                bResult = bResult & (bool)existStore.Enable;

                return bResult;
            }
            else
            {
                return false;
            }            
        }

        internal static StoreUser GetItem(string sPhone)
        {
            return (StoreUserDAO.GetItem(sPhone));
        }

        internal static int GetTotalTransaction(int storeId)
        {            
            return PacificCodeDAO.CountTransaction(storeId);            
        }

        internal static bool IsEnable(int storeId)
        {
            StoreUser existStore = StoreUserDAO.GetItem(storeId);
            
            StoreManager existStoreManager = StoreManagerBUS.GetItem((int)existStore.ManagerId);

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
    }
}