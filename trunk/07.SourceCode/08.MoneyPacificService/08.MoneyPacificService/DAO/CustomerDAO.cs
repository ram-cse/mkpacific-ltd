using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService.DTO;

namespace _08.MoneyPacificService.DAO
{
    public class CustomerDAO
    {
        internal static DBMoneyPacificDataContext mpDb = new DBMoneyPacificDataContext();        
        
        internal static int AddNew(string sPhoneNumber)
        {
            // Kiểm tra tồn tại duy nhất
            // throw new NotImplementedException();
            Customer newCustomer = new Customer();
            newCustomer.Phone = sPhoneNumber;
            mpDb.Customers.InsertOnSubmit(newCustomer);
            mpDb.SubmitChanges();
            return newCustomer.ID;
        }

        internal static bool checkExist(string sPhoneNumber)
        {
            bool bResult;            
            bResult = mpDb.Customers.Where(l => l.Phone == sPhoneNumber).Any();            
            return bResult;
        }

        internal static Customer getCustomer(string sPhoneNumber)
        {
            if (checkExist(sPhoneNumber))
            {
                Customer[] existCustomer = mpDb.Customers.Where(c => c.Phone == sPhoneNumber).ToArray();
                return existCustomer[0];
            }
            else
            {
                int newID = CustomerDAO.AddNew(sPhoneNumber);
                Customer newCustomer = mpDb.Customers.Single(c => c.ID == newID);
                return newCustomer;
            }
        }
    }
}