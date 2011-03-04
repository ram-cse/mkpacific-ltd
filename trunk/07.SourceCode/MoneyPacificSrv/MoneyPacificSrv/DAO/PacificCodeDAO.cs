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

        internal static int getActualAmount(string sCodeNumber)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            
            PacificCode pCode = mpdb.PacificCodes.Where
                (p => p.CodeNumber.Trim() == sCodeNumber.Trim()).Single<PacificCode>();
            
            int iResult = (int)pCode.ActualAmount;
            mpdb.Connection.Close();
            
            return iResult;
        }

        internal static int getMoneyForPayMent(string sCodeNumber, int Amount)
        {
            try
            {
                DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
                
                PacificCode pCode = mpdb.PacificCodes.Where
                    (p => p.CodeNumber.Trim() == sCodeNumber.Trim()).Single<PacificCode>();
                
                int iMin = Utility.Min((int)pCode.ActualAmount, Amount);

                pCode.ActualAmount = pCode.ActualAmount - iMin;
                Amount = Amount - iMin;

                mpdb.SubmitChanges();
                mpdb.Connection.Close();
                return iMin;
            }
            catch
            {
                return 0;
            }
        }

        public static List<PacificCode> GetList(int storeId)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            List<PacificCode> lstPacificCode = mpdb.PacificCodes.Where(p => p.StoreId == storeId).ToList<PacificCode>();
            mpdb.Connection.Close();
            return lstPacificCode;
        }

        internal static int CountTransaction(int storeId)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            int iCount = mpdb.PacificCodes.Where(p => p.StoreId == storeId).Count();
            mpdb.Connection.Close();
            return iCount;
        }
    }
}