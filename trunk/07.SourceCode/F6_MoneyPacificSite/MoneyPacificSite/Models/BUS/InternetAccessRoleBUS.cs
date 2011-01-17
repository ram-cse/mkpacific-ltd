using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSite.Models.DAO;

namespace MoneyPacificSite.Models.BUS
{
    public class InternetAccessRoleBUS
    {
        internal static InternetAccessRole[] GetArray()
        {
            return InternetAccessRoleDAO.GetArray();
        }
    }
}