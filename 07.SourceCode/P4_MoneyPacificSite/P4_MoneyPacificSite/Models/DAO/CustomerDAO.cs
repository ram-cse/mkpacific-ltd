using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using P4_MoneyPacificSite.Models.BUS;

namespace P4_MoneyPacificSite.Models.DAO
{
    public class CustomerDAO
    {
        internal static bool isExist(string sPhone)
        {
            MoneyPacificEntities mpdb = new MoneyPacificEntities();
            bool bResult = mpdb.Customers.Where(c => c.Phone == sPhone).Any();
            mpdb.Connection.Close();
            
            return bResult;
        }

        internal static Customer getCustomer(string sPhone)
        {
            MoneyPacificEntities mpdb = new MoneyPacificEntities();
            Customer oCustomer = mpdb.Customers.Where(c => c.Phone == sPhone).Single<Customer>();
            mpdb.Connection.Close();
            return oCustomer;
        }

        internal static Customer addNew(string sPhone)
        {
            MoneyPacificEntities mpdb = new MoneyPacificEntities();

            Customer newCustomer = new Customer();

            newCustomer.Phone = sPhone;
            // Default: Customer.status = "001" (normal customer & not yet buy)

            newCustomer.StatusID = CustomerStateBUS.getId("001");

            mpdb.Customers.AddObject(newCustomer);
            mpdb.SaveChanges();

            mpdb.Connection.Close();
            return newCustomer;
        }
    
    }
}