using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificBlackBox.DAO
{
    public class PacificCodeDAO
    {
        internal static bool AddNew(PacificCode entity)
        {
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            db.PacificCodes.InsertOnSubmit(entity);
            db.SubmitChanges();
            return true;
        }

        internal static bool Update(PacificCode entity)
        {
            // TODO:(không sử dụng)
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            if (!IsExist(entity.Id))
            {
                return false;
            }

            PacificCode existPacificCode = db.PacificCodes
                .Where(p => p.Id == entity.Id).Single<PacificCode>();

            existPacificCode.CopyFrom(entity);
            db.SubmitChanges();

            return true;
        }

        internal static bool Remove(Guid id)
        {
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            if (!IsExist(id))
            {
                return false;
            }
            PacificCode existPacificCode = db.PacificCodes.Where(p => p.Id == id).Single<PacificCode>();
            db.PacificCodes.DeleteOnSubmit(existPacificCode);
            db.SubmitChanges();
            return true;
        }

        internal static bool IsExist(Guid id)
        {
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            return db.PacificCodes.Where(p => p.Id == id).Any();
        }

        internal static bool IsExist(string codeNumber)
        {
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            return db.PacificCodes.Where
                (p => p.CodeNumber.Trim() == codeNumber.Trim())
                .Any();            
        }


        internal static List<PacificCode> GetList()
        {
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            return db.PacificCodes.ToList<PacificCode>();
        }

        internal static List<PacificCode> GetList(bool condition)
        {
            // TODO:
            throw new NotImplementedException();
        }

        internal static PacificCode[] GetArray()
        {
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            return db.PacificCodes.ToArray<PacificCode>();
        }

        internal static PacificCode[] GetArray(bool condition)
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}