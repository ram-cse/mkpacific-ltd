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
        internal static bool checkExist(StoreUser senderStore)
        {
            return StoreUserDAO.checkExist(senderStore);
        }

        internal static bool checkPassword(StoreUser senderStore)
        {
            return StoreUserDAO.checkPassword(senderStore);
        }

        internal static StoreUser getStoreUser(string storePhone, string passStore)
        {
            return StoreUserDAO.getStoreUser(storePhone, passStore);
        }
    }
}