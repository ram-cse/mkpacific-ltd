using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;

namespace MoneyPacificSite.BUS
{
    public class CustomerBUS
    {
        internal static string GetPhone(Guid? userId)
        {
            return CustomerDAO.GetObject((Guid)userId).PhoneNumber;
        }

        internal static Customer GetCustomerOrCreateNotYetBuy(string phoneNumber)
        {
            Customer existCustomer;

            if (CustomerDAO.IsExist(phoneNumber))
            {
                existCustomer = CustomerDAO.GetObject(phoneNumber);
            }
            else
            {
                /// Tạo User tương ứng
                User newUser = new User();
                newUser.Id = Guid.NewGuid();
                newUser.CreateDate = DateTime.Now;
                newUser.Username = phoneNumber;
                newUser.Password = "";
                newUser.Block = false;
                UserDAO.AddNew(newUser);


                ///Khởi tạo customer & gán status
                Customer newCustomer = new Customer();
                newCustomer.UserId = newUser.Id;
                newCustomer.PhoneNumber = phoneNumber;
                newCustomer.StatusId = CustomerStateDAO.GetObject("001").Id;

                CustomerDAO.AddNew(newCustomer);
                existCustomer = CustomerDAO.GetObject(phoneNumber);
            }
            return existCustomer;
        }
    }
}