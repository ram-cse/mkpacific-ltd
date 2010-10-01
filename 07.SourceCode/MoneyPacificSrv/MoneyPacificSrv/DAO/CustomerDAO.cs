using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;
using MoneyPacificSrv.BUS;

namespace MoneyPacificSrv.DAO
{
    public class CustomerDAO
    {
        private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static void UpdateAfterInsertNewCode(PacificCode newPacificCode)
        {

            // GET
            Customer existCustomer = mpdb.Customers.Where(c => c.ID == newPacificCode.CustomerID).Single<Customer>();
            
            // EXEC
            if (existCustomer != null)
            {
                // . NumberTransaction
                if (existCustomer.NumberTransaction == null)
                {
                    existCustomer.NumberTransaction = 1;
                }
                else
                {
                    existCustomer.NumberTransaction++;
                }

                // . Total Amount
                if (existCustomer.TotalAmount == null)
                {
                    existCustomer.TotalAmount = newPacificCode.ActualAmount;
                }
                else
                {
                    existCustomer.TotalAmount += newPacificCode.ActualAmount;
                }

            }

            // SAVE
            mpdb.SubmitChanges();
        }

        internal static bool isExist(string sPhone)
        {
            return mpdb.Customers.Where(c=>c.Phone == sPhone).Any();
        }

        internal static Customer getCustomer(string sPhone)
        {
            return mpdb.Customers.Where(c => c.Phone == sPhone).Single<Customer>();
        }

        internal static Customer addNew(string sPhone)
        {
            Customer newCustomer = new Customer();
            
            newCustomer.Phone = sPhone;
            // Default: Customer.status = "001" (normal customer & not yet buy)
            
            newCustomer.StatusID = CustomerStatusBUS.getId("001");

            mpdb.Customers.InsertOnSubmit(newCustomer);
            mpdb.SubmitChanges();

            return newCustomer;
        }

        internal static Customer addNew(string sPhone, bool isFirstBuy)
        {
            if (isFirstBuy)
            {
                Customer newCustomer = new Customer();
                
                newCustomer.Phone = sPhone;
                newCustomer.StatusID = CustomerStatusBUS.getId("101");
                
                mpdb.Customers.InsertOnSubmit(newCustomer);
                mpdb.SubmitChanges();
                
                return newCustomer;
            }
            else
            {
                return addNew(sPhone);
            }
        }


    }
}