using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P4_MoneyPacificSite.Models.DAO
{
    public class PacificCodeDAO
    {
        internal static PacificCode GetLastPacificCode(int customerId)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            PacificCode lastPacificCode = null;
            
            bool bExist = db.PacificCodes.Where(p => p.CustomerId == customerId).Any();
            if (bExist)
            {
                
                lastPacificCode = db.PacificCodes
                    .Where(p => p.CustomerId == customerId)
                    .OrderByDescending(p => p.Date)
                    .First<PacificCode>();
            }

            db.Connection.Close();
            return lastPacificCode;
        }

        internal static PacificCode[] GetList(int storeUserId)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            PacificCode[] arrResult = db.PacificCodes.Where(p => p.StoreId == storeUserId).ToArray();
            db.Connection.Close();
            return arrResult;
        }
    }
}