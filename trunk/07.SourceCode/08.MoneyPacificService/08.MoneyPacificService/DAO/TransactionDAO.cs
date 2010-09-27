using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService.DTO;

namespace _08.MoneyPacificService.DAO
{
    public class TransactionDAO
    {
        internal static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
        
        public int AddNew(Transaction newTransaction)
        {
            return 0;
        }

        internal static void AddNew(PacificCode newSuccessPacificCode)
        {
            Transaction newTranSaction = new Transaction();
            
            newTranSaction.CreateDate = newSuccessPacificCode.Date;
            newTranSaction.CustomerID = newSuccessPacificCode.CustomerID;
            newTranSaction.StoreID = newSuccessPacificCode.StoreID;
            newTranSaction.Amount = newSuccessPacificCode.InitialAmount;
            newTranSaction.Origine = "Buy MP";
            //newTranSaction.StatusID = 1; // StatusID = 1 : Status = '11'

            mpdb.Transactions.InsertOnSubmit(newTranSaction);
            mpdb.SubmitChanges();

        }
    }
}