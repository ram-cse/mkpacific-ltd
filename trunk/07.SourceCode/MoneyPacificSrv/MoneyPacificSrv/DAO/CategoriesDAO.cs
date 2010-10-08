using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class CategoriesDAO
    {
        
        internal static bool isValidAmount(int amountBuy)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();            
            bool bResult =  (mpdb.Categories.Where(c => c.Value == amountBuy && c.Active == true).Any());
            mpdb.Connection.Close();
            return bResult;
        }
    }
}