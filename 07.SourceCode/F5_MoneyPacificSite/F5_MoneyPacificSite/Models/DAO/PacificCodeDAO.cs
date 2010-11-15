using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GeneratorPacificCode;

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

        internal static string ChangeCode(string codeNumber)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            string result="";

            PacificCode pCode = db.PacificCodes.Where
                    (p => p.CodeNumber.Trim() == codeNumber.Trim()).SingleOrDefault<PacificCode>();
            bool bExist;
            do
            {
                pCode.CodeNumber = Generator.getNewCode();
                bExist = (db.PacificCodes.Where
                    (p => p.CodeNumber.Trim() == pCode.CodeNumber.Trim()).Any());
            } while (bExist);
            result = pCode.CodeNumber;
            db.SaveChanges();
            db.Connection.Close();
            return result;            
        }

        internal static void UpdateAmount(PacificCode pacificCode, int actualAmount)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            PacificCode existPacificCode = PacificCodeDAO.GetItem(pacificCode.CodeNumber);
            existPacificCode.ActualAmount = actualAmount;
            db.SaveChanges();
            db.Connection.Close();            
        }

        internal static void AddItem(PacificCode newPacificCode)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            db.PacificCodes.AddObject(newPacificCode);
            db.SaveChanges();
            db.Connection.Close();            
        }

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

        internal static PacificCode[] GetList()
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            PacificCode[] result = db.PacificCodes
                .Include("Customer").Include("StoreUser")
                .ToArray();;
            db.Connection.Close();
            return result;
        }

        internal static PacificCode[] GetArray(int storeUserId)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            PacificCode[] result = db.PacificCodes
                .Where(p => p.StoreId == storeUserId)
                .ToArray(); ;
            db.Connection.Close();
            return result;
        }
    }
}