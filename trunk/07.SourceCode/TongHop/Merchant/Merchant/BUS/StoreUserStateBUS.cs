using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;

namespace MoneyPacificSite.BUS
{
    public class StoreUserStateBUS
    {
        internal static StoreUserState GetObject(int id)
        {
            return StoreUserStateDAO.GetObject(id);
        }
    }
}