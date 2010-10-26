using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class TransactionDAO
    {
        // internal static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
        internal static void AddNew(DTO.PacificCode newSuccessPacificCode)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

            Transaction newTransaction = new Transaction();

            newTransaction.CreateDate = newSuccessPacificCode.Date;
            newTransaction.CustomerId = newSuccessPacificCode.CustomerID;
            newTransaction.StoreId = newSuccessPacificCode.StoreID;
            newTransaction.Amount = newSuccessPacificCode.InitialAmount;
            newTransaction.Origine = "Buy MP";
            //newTranSaction.StatusID = 1; // StatusID = 1 : Status = '11'

            mpdb.Transactions.InsertOnSubmit(newTransaction);
            mpdb.SubmitChanges();

            mpdb.Connection.Close();
        }
    }
}