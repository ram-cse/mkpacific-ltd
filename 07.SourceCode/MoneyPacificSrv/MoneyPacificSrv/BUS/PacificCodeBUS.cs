using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;
using MoneyPacificSrv.DAO;
using MoneyPacificSrv.XAO;
using MoneyPacificSrv.Util;
using GeneratorPacificCode;

namespace MoneyPacificSrv.BUS
{
    public class PacificCodeBUS
    {
        // TODO: Shout get from from CONFIG file
        
        private static void addNew(PacificCode newPacificCode)
        {
            StoreUserDAO.updateAfterInsertNewCode(newPacificCode);
            CustomerDAO.updateAfterInsertNewCode(newPacificCode);
            PacificCodeDAO.addNew(newPacificCode);
        }

        internal static PacificCode getNewPacificCode(int storeId, int customerId, int amountBuy)
        {
            PacificCode newPacificCode = new PacificCode();

            // Generate NewCode from XML File
            
            bool bGetNewPacificCode = false;
            do
            {
                newPacificCode.CodeNumber = Generator.getNewCode();
                bGetNewPacificCode = !PacificCodeBUS.isExist(newPacificCode.CodeNumber);
            } while (bGetNewPacificCode == false);

            // Add information

            newPacificCode.StoreId = storeId;
            newPacificCode.CustomerId = customerId;
            newPacificCode.InitialAmount = amountBuy;
            newPacificCode.ActualAmount = amountBuy;
            newPacificCode.Date = DateTime.Now;

            int iYear = DateTime.Now.Year + 1;
            int iMonth = DateTime.Now.Month;
            int iDay = DateTime.Now.Day;

            newPacificCode.ExpireDate = new DateTime(iYear, iMonth, iDay);
            
            // Submit for save & update (store, customer)
            // Update Action on STORE & CUSTOMER should be done by
            // Trigger or CLR Trigger in Database

            PacificCodeBUS.addNew(newPacificCode);

            return newPacificCode;
        }
                
        //private static PacificCode generateNewCode()
        //{
        //    //return PacificCodeXAO.generateNewCode();
        //    PacificCode newPacificCode = new PacificCode();
        //    newPacificCode.CodeNumber = Generator.getNewCode();
        //    return newPacificCode;
        //}
        
        internal static PacificCode getPacificCode(string sCodeNumber)
        {
            return PacificCodeDAO.getPacificCode(sCodeNumber);
        }

        internal static bool isExist(string sCodeNumber)
        {   
            return PacificCodeDAO.isExist(sCodeNumber);
        }

        internal static bool isPossibleCode(string sCodeNumber)
        {
            //return PacificCodeXAO.isPossibleCode(sCodeNumber);
            return Generator.isPossibleCode(sCodeNumber);
        }

        internal static int getActualAmount(string sCodeNumber)
        {
            return PacificCodeDAO.getActualAmount(sCodeNumber);
        }

        internal static int getMoneyForPayMent(string sCodeNumber, int Amount)
        {            
            return PacificCodeDAO.getMoneyForPayMent(sCodeNumber, Amount);
        }
    }
}