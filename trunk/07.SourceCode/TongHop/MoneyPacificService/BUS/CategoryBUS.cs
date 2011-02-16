using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;

namespace MoneyPacificService.BUS
{
    public class CategoryBUS
    {
        internal static bool IsValidAmount(int amountBuy)
        {
            return CategoryDAO.IsExist(amountBuy);
        }
    }
}