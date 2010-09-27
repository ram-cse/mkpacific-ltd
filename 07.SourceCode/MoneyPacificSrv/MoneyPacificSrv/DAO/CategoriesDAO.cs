using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class CategoriesDAO
    {
        internal static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
        
        internal static bool isValidAmount(int amountBuy)
        {   
            return (mpdb.Categories.Where(c => c.Value == amountBuy && c.Active == true).Any());
        }
    }
}