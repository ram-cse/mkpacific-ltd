using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class CustomerStatusDAO
    {
        //private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static int getId(string customerStatus)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            int iResult = (mpdb.CustomerStatus.Where(c => 
                c.Value == customerStatus).Single<CustomerStatus>()).ID;
            mpdb.Connection.Close();
            return iResult;
        }

        internal static string getValue(int? iId)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            if (iId == null) iId = 1; // Default            
            string sResult =  mpdb.CustomerStatus.Where(c => c.ID == iId).Single<CustomerStatus>().Value;
            mpdb.Connection.Close();
            return sResult;
        }
    }
}