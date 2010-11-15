using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F5_MoneyPacificSite.Models.DAO
{
    public class InternetAccessRoleDAO
    {
        internal static InternetAccessRole[] GetArray()
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            InternetAccessRole[] result = db.InternetAccessRoles.ToArray();
            db.Connection.Close();
            return result;

        }
    }
}