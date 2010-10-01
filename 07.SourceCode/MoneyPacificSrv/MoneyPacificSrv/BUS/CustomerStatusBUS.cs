using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DAO;
using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.BUS
{
    public class CustomerStatusBUS
    {
        internal static int getId(string customerStatus)
        {
            return CustomerStatusDAO.getId(customerStatus);
        }
    }
}