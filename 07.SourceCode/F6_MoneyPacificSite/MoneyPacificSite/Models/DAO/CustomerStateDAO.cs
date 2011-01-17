using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSite.Models.DAO
{
    public class CustomerStateDAO
    {
        internal static int getId(string customerStatus)
        {
            MoneyPacificEntities mpdb = new MoneyPacificEntities();
            int iResult = (mpdb.CustomerStates.Where(c =>
                c.Code == customerStatus).Single<CustomerState>()).Id;
            mpdb.Connection.Close();
            return iResult;
        }

        internal static string getCode(int? iId)
        {
            MoneyPacificEntities mpdb = new MoneyPacificEntities();
            if (iId == null) iId = 1; // Default            
            string sResult = mpdb.CustomerStates.Where(c => c.Id == iId).Single<CustomerState>().Code;
            mpdb.Connection.Close();
            return sResult;
        }


        internal static string GetPhone(int? customerId)
        {
            MoneyPacificEntities mpdb = new MoneyPacificEntities();
            string result = mpdb.Customers.Where
                (c => c.Id == customerId).Single<Customer>().Phone;
            mpdb.Connection.Close();
            return result;
        }
    }
}