using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using P4_MoneyPacificSite.Models.DAO;

namespace P4_MoneyPacificSite.Models.BUS
{
    public class StoreManagerStateBUS
    {
        public static string GetCode(int Id)
        {
            return StoreManagerStateDAO.GetCode(Id);
        }
    }
}