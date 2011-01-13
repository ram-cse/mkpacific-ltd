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
            entity.Id = Guid.NewGuid();
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

        internal static bool IsExistPartCodeNumber(string partCodeNumber)
        {
            partCodeNumber = partCodeNumber.Substring(0, 12);
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            return db.PacificCodes.Where
                (p => p.CodeNumber.Substring(0,12) == partCodeNumber.Trim())
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

        internal static PacificCode GetObject(string partCodeNumber)
        {
            partCodeNumber = partCodeNumber.Substring(0, 12);
            // Kiem tra ton tai hay khong thi khong nam trong lop DAO, chỉ nằm trong BUS
            MoneyPacificBlackBoxDataContext db = Connection.Instance;
            
            // Test
            //List<PacificCode> lstPC = GetList();
            //foreach (PacificCode pc in lstPC)
            //{
            //    if (pc.CodeNumber.Substring(0, 12) == partCodeNumber)
            //    {
            //        pc.CodeNumber = "12345678910111";
            //    }
            //}
            // End Test

            PacificCode existPC =  db.PacificCodes.Where(p => p.CodeNumber.Substring(0, 12) == partCodeNumber).Single<PacificCode>();
            db.Connection.Close();
            return existPC;
        }
    }
}