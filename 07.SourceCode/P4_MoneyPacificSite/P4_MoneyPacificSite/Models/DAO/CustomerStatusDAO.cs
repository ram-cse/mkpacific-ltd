using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P4_MoneyPacificSite.Models.DAO
{
    public class CustomerStatusDAO
    {
        internal static int getId(string customerStatus)
        {
            MoneyPacificEntities mpdb = new MoneyPacificEntities();
            int iResult = (mpdb.CustomerStatuses.Where(c =>
                c.Value == customerStatus).Single<CustomerStatus>()).ID;
            mpdb.Connection.Close();
            return iResult;
        }

        internal static string getValue(int? iId)
        {
            MoneyPacificEntities mpdb = new MoneyPacificEntities();
            if (iId == null) iId = 1; // Default            
            string sResult = mpdb.CustomerStatuses.Where(c => c.ID == iId).Single<CustomerStatus>().Value;            
            mpdb.Connection.Close();
            return sResult;
        }

    }
}