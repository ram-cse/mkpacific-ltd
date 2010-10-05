using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class CustomerStatusDAO
    {
        private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static int getId(string customerStatus)
        {
            return (mpdb.CustomerStatus.Where(c => 
                c.Value == customerStatus).Single<CustomerStatus>()).ID;
        }

        internal static string getValue(int? iId)
        {
            return mpdb.CustomerStatus.Where(c => c.ID == iId).Single<CustomerStatus>().Value;
        }
    }
}