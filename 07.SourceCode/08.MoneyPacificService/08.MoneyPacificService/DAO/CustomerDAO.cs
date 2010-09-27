using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService.DTO;

namespace _08.MoneyPacificService.DAO
{
    public class CustomerDAO
    {
        internal static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();        
        
        internal static int AddNew(string sPhoneNumber)
        {
            // Kiểm tra tồn tại duy nhất
            // throw new NotImplementedException();
            Customer newCustomer = new Customer();
            newCustomer.Phone = sPhoneNumber;
            
            mpdb.Customers.InsertOnSubmit(newCustomer);
            mpdb.SubmitChanges();
            return newCustomer.ID;
        }

        internal static bool checkExist(string sPhoneNumber)
        {
            bool bResult;            
            bResult = mpdb.Customers.Where(l => l.Phone == sPhoneNumber).Any();            
            return bResult;
        }

        internal static Customer getCustomer(string sPhoneNumber)
        {
            if (checkExist(sPhoneNumber))
            {
                Customer[] existCustomer = mpdb.Customers.Where(c => c.Phone == sPhoneNumber).ToArray();
                return existCustomer[0];
            }
            else
            {
                int newID = CustomerDAO.AddNew(sPhoneNumber);
                Customer newCustomer = mpdb.Customers.Single(c => c.ID == newID);
                return newCustomer;
            }
        }

        internal static void UpdateAfterInsertNewPCode(PacificCode newPacificCode)
        {
            Customer existCustomer = mpdb.Customers.Where(c => c.ID == newPacificCode.CustomerID).Single();

            // NumberTransaction
            if (existCustomer.NumberTransaction == null)
            {
                existCustomer.NumberTransaction = 1;
            }
            else
            {
                existCustomer.NumberTransaction++;
            }

            // TotalAmount
            if (existCustomer.TotalAmount == null)
            {
                existCustomer.TotalAmount = newPacificCode.ActualAmount;
            }
            else
            {
                existCustomer.TotalAmount += newPacificCode.ActualAmount;
            }            

            // Xác nhận lưu 
            mpdb.SubmitChanges();
        }
    }
