using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using F5_MoneyPacificSite.Models.DAO;

namespace F5_MoneyPacificSite.Models.BUS
{
    public class PacificCodeBUS
    {
        public static PacificCode GetItem(string codeNumber)        
        {
            PacificCode existPacificCode = null ;
            if (PacificCodeDAO.IsExist(codeNumber))
            {
                existPacificCode = PacificCodeDAO.GetItem(codeNumber);
            }
            return existPacificCode;
        }



        internal static bool IsExist(string codeNumber)
        {
            return PacificCodeDAO.IsExist(codeNumber);
        }
    }
}