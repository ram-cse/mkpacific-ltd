using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class PacificCodeDAO
    {
        private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static bool checkExist(string sCodeNumber)
        {
            return mpdb.PacificCodes.Where(p => p.CodeNumber == sCodeNumber).Any();
        }
    }
}