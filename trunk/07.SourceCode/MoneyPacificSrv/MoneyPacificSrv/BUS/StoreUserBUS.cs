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

        internal static List<StoreUser> GetList(int managerId)
        {
            return StoreUserDAO.GetList(managerId);
        }

        internal static bool IsExist(string sPhone)
        {
            return StoreUserDAO.IsExist(sPhone);
        }

        internal static bool Validate(string sPhone, string sPINStore)
        {
            if(StoreUserDAO.IsExist(sPhone))
            {
                StoreUser existStore = StoreUserDAO.GetItem(sPhone);
                return (existStore.PINStore == sPINStore);
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
    }
}