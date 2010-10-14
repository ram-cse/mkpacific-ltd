using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using P4_MoneyPacificSite.Models.DAO;

namespace P4_MoneyPacificSite.Models.BUS
{
    public class CustomerStatusBUS
    {
        internal static int getId(string customerStatus)
        {
            return CustomerStatusDAO.getId(customerStatus);
        }

        internal static string getValue(int? iNullableID)
        {
            return CustomerStatusDAO.getValue(iNullableID);
        }
    }
}