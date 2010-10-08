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
        // private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static bool isExist(string sCodeNumber)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            bool bResult = mpdb.PacificCodes.Where(p => p.CodeNumber.Trim() == sCodeNumber.Trim()).Any();
            mpdb.Connection.Close();
            return bResult;

        }

        internal static PacificCode getPacificCode(string sCodeNumber)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            PacificCode oPacificCode = mpdb.PacificCodes.Where(p => p.CodeNumber == sCodeNumber).Single<PacificCode>();
            mpdb.Connection.Close();
            return oPacificCode;
        }

        internal static void addNew(PacificCode newPacificCode)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            mpdb.PacificCodes.InsertOnSubmit(newPacificCode);
            mpdb.SubmitChanges();
            mpdb.Connection.Close();
        }
    }
}