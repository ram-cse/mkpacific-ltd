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
        //private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static void updateAfterInsertNewCode(PacificCode newPacificCode)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
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
            mpdb.Connection.Close();
        }

        internal static bool isExist(string sPhone)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            bool bResult = mpdb.Customers.Where(c=>c.Phone == sPhone).Any();
            mpdb.Connection.Close();
            return bResult;
        }

        internal static Customer getCustomer(string sPhone)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            Customer oCustomer = mpdb.Customers.Where(c => c.Phone == sPhone).Single<Customer>();
            mpdb.Connection.Close();
            return oCustomer;
        }

        internal static Customer addNew(string sPhone)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

            Customer newCustomer = new Customer();
            
            newCustomer.Phone = sPhone;
            // Default: Customer.status = "001" (normal customer & not yet buy)
            
            newCustomer.StatusID = CustomerStatusBUS.getId("001");

            mpdb.Customers.InsertOnSubmit(newCustomer);
            mpdb.SubmitChanges();

            mpdb.Connection.Close();
            return newCustomer;
        }

        internal static Customer addNew(string sPhone, bool isFirstBuy)
        {
            

            if (isFirstBuy)
            {
                DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

                Customer newCustomer = new Customer();
                
                newCustomer.Phone = sPhone;
                newCustomer.StatusID = CustomerStatusBUS.getId("101");
                
                mpdb.Customers.InsertOnSubmit(newCustomer);
                mpdb.SubmitChanges();

                mpdb.Connection.Close();
                return newCustomer;
            }
            else
            {
                return addNew(sPhone);
            }
        }



        internal static Customer getCustomer(int customerId)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            Customer oCustomer = mpdb.Customers.Where(c => c.ID == customerId).Single<Customer>();
            mpdb.Connection.Close();
            return oCustomer;
        }

        internal static void setStatus(string sPhoneNumber, string sStatus)
        {
            
            Customer existCustomer = CustomerDAO.getCustomer(sPhoneNumber);
            setStatus(existCustomer.ID, sStatus);
            
        }

        internal static void setStatus(int customerId, string sStatus)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

            // Customer existCustomer = CustomerDAO.getCustomer(customerId); // LAY từ mpdb khác sẽ ko có tác dụng nếu có xử lý
            Customer existCustomer = mpdb.Customers.Where(c => c.ID == customerId).Single<Customer>();
            
            string oldStatus = CustomerStatusDAO.getValue(existCustomer.StatusID);
            
            // VD: set Status = x32, x33...
            if (sStatus[0] == 'x')
                sStatus = oldStatus[0] + sStatus.Substring(1, sStatus.Length - 1);

            existCustomer.StatusID = CustomerStatusDAO.getId(sStatus);
            mpdb.SubmitChanges();

            mpdb.Connection.Close();
        }
    }
}