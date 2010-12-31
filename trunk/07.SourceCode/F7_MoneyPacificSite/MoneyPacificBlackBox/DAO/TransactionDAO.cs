using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificBlackBox.DAO
{
    internal class TransactionDAO
    {

        internal static bool AddNew(Transaction entity)
        {
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            db.Transactions.InsertOnSubmit(entity);
            db.SubmitChanges();
            return true;
        }

        internal static bool Update(Transaction entity)
        {
            // TODO:(không sử dụng)
            throw new NotImplementedException();
        }

        internal static bool Remove(int Id)
        {
            // TODO:
            throw new NotImplementedException();
        }

        internal static List<Transaction> GetList()
        {
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            return db.Transactions.ToList<Transaction>();
        }

        internal static List<Transaction> GetList(bool condition)
        {
            // TODO:
            throw new NotImplementedException();
        }

        internal static Transaction[] GetArray()
        {
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            return db.Transactions.ToArray<Transaction>();
        }

        internal static Transaction[] GetArray(bool condition)
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}