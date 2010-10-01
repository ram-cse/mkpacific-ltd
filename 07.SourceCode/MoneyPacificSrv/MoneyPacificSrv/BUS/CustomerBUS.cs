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
        internal static bool isValidCustomer(string p)
        {
            //throw new NotImplementedException();
            return true;
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
    }
}