using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using F5_MoneyPacificSite.Models.DAO;

namespace F5_MoneyPacificSite.Models.BUS
{
    public class CustomerBUS
    {
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

        internal static Customer getCustomer(string sPhone)
        {
            if (CustomerDAO.isExist(sPhone))
            {
                return CustomerDAO.getCustomer(sPhone);
            }
            else
            {
                return null;
            }

        }

        internal static string GetPhone(int? customerId)
        {
            return CustomerStateDAO.GetPhone(customerId);
        }
    }
}