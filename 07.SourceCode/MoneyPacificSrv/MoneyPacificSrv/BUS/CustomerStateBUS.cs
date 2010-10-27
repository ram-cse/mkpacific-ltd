using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DAO;
using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.BUS
{
    public class CustomerStateBUS
    {
        internal static int getId(string customerStatus)
        {
            return CustomerStateDAO.getId(customerStatus);
        }

        internal static string getCode(int? iNullableID)
        {
            return CustomerStateDAO.getCode(iNullableID);
        }
    }
}