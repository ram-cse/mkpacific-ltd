﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;
using MoneyPacificSrv.DAO;
using MoneyPacificSrv.XAO;

namespace MoneyPacificSrv.BUS
{
    public class PacificCodeBUS
    {
        // TODO: Shout get from from CONFIG file
        
        private static void AddNew(PacificCode newPacificCode)
        {
            StoreDAO.UpdateAfterInsertNewCode(newPacificCode);
            CustomerDAO.UpdateAfterInsertNewCode(newPacificCode);
        }

        internal static PacificCode getNewPacificCode(int storeId, int customerId, int amountBuy)
        {
            PacificCode newPacificCode = new PacificCode();

            // Generate NewCode from XML File
            
            bool bGetNewPacificCode = false;
            do
            {
                newPacificCode = PacificCodeBUS.GenerateNewCode();
                bGetNewPacificCode = !PacificCodeBUS.isExist(newPacificCode.CodeNumber);
            } while (bGetNewPacificCode == false);

            // Add information

            newPacificCode.StoreID = storeId;
            newPacificCode.CustomerID = customerId;
            newPacificCode.InitialAmount = amountBuy;
            newPacificCode.Date = DateTime.Now;

            int iYear = DateTime.Now.Year + 1;
            int iMonth = DateTime.Now.Month;
            int iDay = DateTime.Now.Day;

            newPacificCode.ExpireDate = new DateTime(iYear, iMonth, iDay);
            
            // Submit for save & update (store, customer)
            // Update Action on STORE & CUSTOMER should be done by
            // Trigger or CLR Trigger in Database

            PacificCodeBUS.AddNew(newPacificCode);

            return newPacificCode;
        }
                
        private static PacificCode GenerateNewCode()
        {
            return PacificCodeXAO.GenerateNewCode();
        }
        
        internal static PacificCode getPacificCode(string sCodeNumber)
        {
            return PacificCodeDAO.getPacificCode(sCodeNumber);
        }

        internal static bool isExist(string sCodeNumber)
        {
            return PacificCodeDAO.isExist(sCodeNumber);
        }
    }
}