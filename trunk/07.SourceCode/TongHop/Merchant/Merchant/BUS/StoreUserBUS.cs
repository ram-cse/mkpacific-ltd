using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;

namespace MoneyPacificSite.BUS
{
    public class StoreUserBUS
    {

        internal static string GetPhone(Guid? userId)
        {
            return StoreUserDAO.GetObject((Guid)userId).Phone;
        }

        internal static StoreUser GetObject(Guid userId)
        {
            return StoreUserDAO.GetObject(userId);
        }

        internal static int GetTotalLastMonthTranSaction(Guid guid)
        {
            throw new NotImplementedException();
        }

        internal static StoreUser[] GetArray(Guid managerId)
        {
            return StoreUserDAO.GetArray(managerId);
        }
    }
}