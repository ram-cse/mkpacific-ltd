using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;
using MoneyPacificSrv.Util;

namespace MoneyPacificSrv.DAO
{
    public class PacificCodeDAO
    {
        private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static bool isExist(string sCodeNumber)
        {
            return mpdb.PacificCodes.Where(p => p.CodeNumber.Trim() == sCodeNumber.Trim()).Any();
        }

        internal static PacificCode getPacificCode(string sCodeNumber)
        {
            return mpdb.PacificCodes.Where(p => p.CodeNumber == sCodeNumber).Single<PacificCode>();
        }

        internal static void addNew(PacificCode newPacificCode)
        {
            mpdb.PacificCodes.InsertOnSubmit(newPacificCode);
            mpdb.SubmitChanges();
        }
    }
}