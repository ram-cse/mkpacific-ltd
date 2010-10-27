using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class CustomerStateDAO
    {
        //private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static int getId(string customerStatus)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            int iResult = (mpdb.CustomerStates.Where(c => 
                c.Code == customerStatus).Single<CustomerState>()).Id;
            mpdb.Connection.Close();
            return iResult;
        }

        internal static string getCode(int? iId)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            if (iId == null) iId = 1; // Default            
            string sResult =  mpdb.CustomerStates.Where(c => c.Id == iId).Single<CustomerState>().Code;
            mpdb.Connection.Close();
            return sResult;
        }
    }
}