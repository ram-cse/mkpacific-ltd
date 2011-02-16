using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;

namespace MoneyPacificService.BUS
{
    public class CustomerBUS
    {
        internal static bool isInBlackList(string phoneNumber)
        {
            if (!CustomerDAO.IsExist(phoneNumber))
            {
                return false;
            }
            else
            {
                Customer existCustomer = CustomerDAO.GetObject(phoneNumber);
                //string sStatus = CustomerStateDAO.getCode(existCustomer.StatusID).Trim();
                string sStatus = CustomerStateDAO.GetObject((int)existCustomer.StatusId).Code.Trim();
                if (sStatus.Substring(1, 2) == "98")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

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

        internal static string makeSuspicion(Guid customerUserId)
        {
            // Tra ra chuoi canh bao
            Customer existCustomer = CustomerDAO.GetObject(customerUserId);

            string sWarning = "0*NOT_EXIST_STATUS";

            string customerStatus = CustomerStateDAO.GetObject((int)existCustomer.StatusId).Code;

            string yz = customerStatus.Substring(1, 2); // XYZ => get YZ)
            char x = customerStatus[0];
            string sPhone = existCustomer.PhoneNumber.Trim();

            switch (yz)
            {
                case "31":
                    CustomerDAO.SetStatus(existCustomer.UserId, "x32");
                    sWarning = sPhone + "*" + MessageManager.GetValue("NOT_EXIST_PACIFICCODE");
                    break;
                case "32":
                    CustomerDAO.SetStatus(existCustomer.UserId, "x33");
                    sWarning = sPhone + "*" + MessageManager.GetValue("WILL_BE_LOCKED");
                    break;
                case "33":
                    CustomerDAO.SetStatus(existCustomer.UserId, "x93");
                    sWarning = sPhone + "*" + MessageManager.GetValue("BE_LOCKED");
                    break;
            }


            // 0 - 30
            if (int.Parse(yz) < 31 && int.Parse(yz) >= 0)
            {
                CustomerDAO.SetStatus(existCustomer.UserId, "x31");
                sWarning = existCustomer.PhoneNumber + "*" + MessageManager.GetValue("NOT_EXIST_PACIFICCODE");
            }

            return sWarning;
        }

        internal static void MoveToBlackList(string phoneNumber)
        {
            Customer existCustomer = CustomerDAO.GetObject(phoneNumber);

            string status = CustomerStateDAO.GetObject((int)existCustomer.StatusId).Code;
            status = status[0] + "98";

            CustomerDAO.SetStatus(existCustomer.UserId, status);

        }
    }
}