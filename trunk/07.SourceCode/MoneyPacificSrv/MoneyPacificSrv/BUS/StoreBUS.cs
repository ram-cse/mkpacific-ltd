using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificSrv.DTO;
using MoneyPacificSrv.DAO;

namespace MoneyPacificSrv.BUS
{
    public class StoreBUS
    {
        internal static bool checkExist(Store senderStore)
        {
            return StoreDAO.checkExist(senderStore);
        }

        internal static bool checkPassword(Store senderStore)
        {
            return StoreDAO.checkPassword(senderStore);
        }

        internal static Store getStore(string storePhone, string passStore)
        {
            return StoreDAO.getStore(storePhone, passStore);
        }
    }
}