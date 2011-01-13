using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificBlackBox.DAO;

namespace MoneyPacificBlackBox.BUS
{
    internal class TransactionBUS
    {
        internal void AddNew(Transaction entity)
        {
            TransactionDAO.AddNew(entity);
        }
    }
}