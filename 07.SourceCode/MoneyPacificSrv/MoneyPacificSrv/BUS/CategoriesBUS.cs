using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DAO;

namespace MoneyPacificSrv.BUS
{
    public class CategoriesBUS
    {
        internal static bool isValidAmount(int amountBuy)
        {
            return CategoriesDAO.isValidAmount(amountBuy);
        }
    }
}