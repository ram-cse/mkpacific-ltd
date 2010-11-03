using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DAO;
using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.BUS
{
    public class CustomerBUS
    {
        internal static void setStatus(string sPhoneNumber, string sStatus)
        {
            CustomerDAO.setStatus(sPhoneNumber, sStatus);
        }

        internal static bool isInBlackList(string sPhone)
        {
            if (!CustomerDAO.isExist(sPhone))
            {
                return false;
            }
            else
            {
                Customer existCustomer = CustomerDAO.getCustomer(sPhone);
                string sStatus = CustomerStateDAO.getCode(existCustomer.StatusID).Trim();
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

        internal static bool isLockedCustomer(string sPhone)
        {
            if (!CustomerDAO.isExist(sPhone))
            {
                return false;
            }
            else
            {
                Customer existCustomer = CustomerDAO.getCustomer(sPhone);
                string sStatus = CustomerStateDAO.getCode(existCustomer.StatusID).Trim();
                if (sStatus.Substring(1, 2) == "93")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static Customer getCustomerOrCreateNotYetBuy(string sPhone)
        {
            Customer existCustomer;

            if (CustomerDAO.isExist(sPhone))
            {
                existCustomer = CustomerDAO.getCustomer(sPhone);
            }
            else
            {
                existCustomer = CustomerDAO.addNew(sPhone);
            }
            return existCustomer;
        }

        internal static Customer getCustomerOrCreateFirstBuy(string sPhone)
        {
            Customer existCustomer;

            if (CustomerDAO.isExist(sPhone))
            {
                existCustomer = CustomerDAO.getCustomer(sPhone);
            }
            else
            {
                existCustomer = CustomerDAO.addNew(sPhone);
            }
            return existCustomer;
        }

        internal static string makeSuspicion(int customerId)
        {
            // Tra ra chuoi canh bao
            Customer existCustomer = CustomerDAO.getCustomer(customerId);

            string sWarning="0*NOT_EXIST_STATUS";

            string customerStatus = CustomerStateBUS.getCode(existCustomer.StatusID);
            
            string yz = customerStatus.Substring(1, 2); // XYZ => get YZ)
            char x = customerStatus[0];
            string sPhone = existCustomer.Phone.Trim();

            switch (yz)
            {   
                case "31":
                    CustomerDAO.setStatus(existCustomer.Id, "x32");
                    sWarning = sPhone + "*" + MessageManager.GetValue("NOT_EXIST_PACIFICCODE");
                    break;
                case "32":
                    CustomerDAO.setStatus(existCustomer.Id, "x33");
                    sWarning = sPhone + "*" + MessageManager.GetValue("WILL_BE_LOCKED");
                    break;
                case "33":
                    CustomerDAO.setStatus(existCustomer.Id, "x93");
                    sWarning = sPhone + "*" + MessageManager.GetValue("BE_LOCKED");
                    break;
            }


            // 0 - 30
            if (int.Parse(yz) < 31 && int.Parse(yz) >= 0)
            {
                CustomerDAO.setStatus(existCustomer.Id, "x31");
                sWarning = existCustomer.Phone + "*" + MessageManager.GetValue("NOT_EXIST_PACIFICCODE");
            }

            return sWarning;
        }

        internal static void moveToBlackList(string sPhoneNumber)
        {
            Customer existCustomer = CustomerDAO.getCustomer(sPhoneNumber);

            string sStatus = CustomerStateBUS.getCode(existCustomer.StatusID);
            sStatus = sStatus[0] + "98";

            CustomerDAO.setStatus(sPhoneNumber,sStatus);
        }
        
    }
}