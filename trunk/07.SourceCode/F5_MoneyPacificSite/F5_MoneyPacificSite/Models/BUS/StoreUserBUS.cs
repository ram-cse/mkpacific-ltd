using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using F5_MoneyPacificSite.Models.DAO;

namespace F5_MoneyPacificSite.Models.BUS
{
    public class StoreUserBUS
    {
        internal static StoreUser GetItem(int Id)
        {
            return StoreUserDAO.GetItem(Id);
        }

        internal static StoreUser[] GetList(int managerId)
        {
            return StoreUserDAO.GetList(managerId);
        }
    }
}