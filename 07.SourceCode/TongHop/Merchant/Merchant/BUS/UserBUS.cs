using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MPDataAccess;

namespace MoneyPacificSite.BUS
{
    public class UserBUS
    {
        internal static User GetObject(Guid userId)
        {
            return UserDAO.GetObject(userId);
        }
    }
}