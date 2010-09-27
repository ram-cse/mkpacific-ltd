using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;

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
    }
}