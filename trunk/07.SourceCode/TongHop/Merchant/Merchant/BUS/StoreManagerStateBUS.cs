using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MPDataAccess;

namespace MoneyPacificSite.BUS
{
    public class StoreManagerStateBUS
    {
        internal static StoreManagerState GetObject(int id)
        {
            return StoreManagerStateDAO.GetObject(id);
        }
    }
}