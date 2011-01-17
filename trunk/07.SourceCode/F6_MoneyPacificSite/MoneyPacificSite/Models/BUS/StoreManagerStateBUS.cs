using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSite.Models.DAO;

namespace MoneyPacificSite.Models.BUS
{
    public class StoreManagerStateBUS
    {
        public static string GetCode(int Id)
        {
            return StoreManagerStateDAO.GetCode(Id);
        }

        internal static StoreManagerState[] GetArray()
        {
            return StoreManagerStateDAO.GetArray();
        }
    }
}