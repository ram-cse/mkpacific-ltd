using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F5_MoneyPacificSite.Models.DAO
{
    public class PacificCodeDAO
    {
        internal static bool IsExist(string codeNumber)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            bool result = db.PacificCodes.
                Where(p => p.CodeNumber.Trim() == codeNumber).Any();
            db.Connection.Close();
            return result;
        }

        internal static PacificCode GetItem(string codeNumber)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            PacificCode result = db.PacificCodes.
                Where(p => p.CodeNumber.Trim() == codeNumber).Single<PacificCode>();
            db.Connection.Close();
            return result;
        }
    }
}