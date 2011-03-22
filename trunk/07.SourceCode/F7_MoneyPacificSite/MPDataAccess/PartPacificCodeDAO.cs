using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace MPDataAccess
{
    public class PartPacificCodeDAO
    {
        public static PartPacificCode GetObject(Guid id)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            PartPacificCode result = mpdb.PartPacificCodes
                .Where(p => p.Id.Equals(id))
                .Single<PartPacificCode>();
            mpdb.Connection.Close();
            return result;
        }

        public static PartPacificCode GetObject(string partCodeNumber)
        {
            partCodeNumber = partCodeNumber.Substring(0, 12);
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            PartPacificCode result = mpdb.PartPacificCodes
                .Where(p => p.PartCodeNumber.Equals(partCodeNumber))
                .Single<PartPacificCode>();
            mpdb.Connection.Close();
            return result;
        }

        public static bool AddNew(PartPacificCode entity)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            mpdb.PartPacificCodes.InsertOnSubmit(entity);
            mpdb.SubmitChanges();
            mpdb.Connection.Close();
            return true;
        }

        public static bool Update(PartPacificCode entity)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            PartPacificCode existPPC = mpdb.PartPacificCodes
                .Where(p => p.Id.Equals(entity.Id))
                .Single<PartPacificCode>();
            existPPC.CopyFrom(entity);
            mpdb.SubmitChanges();
            mpdb.Connection.Close();
            return true;
        }

        public static bool Remove(Guid id)
        {
            throw new Exception("chua lam!...");
        }

        public static List<PartPacificCode> GetList()
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            List<PartPacificCode> lstResult = mpdb.PartPacificCodes.ToList<PartPacificCode>();
            mpdb.Connection.Close();
            return lstResult;            
        }

        public static List<PartPacificCode> GetList(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static PartPacificCode[] GetArray()
        {
            throw new Exception("chua lam!...");
        }

        public static PartPacificCode[] GetArray(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static bool IsExist(string partCodeNumber)
        {
            partCodeNumber = partCodeNumber.Substring(0, 12);
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            bool result = mpdb.PartPacificCodes
                .Where(p => p.PartCodeNumber.Substring(0, 12).Equals(partCodeNumber))
                .Any();
            mpdb.Connection.Close();
            return result;            
        }

        public static string[] GetArray(Guid customerUserId)
        {
            List<string> lstResult = new List<string>();
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            PartPacificCode[] arrPC = mpdb.PartPacificCodes
                .Where(p => p.CustomerId.Equals(customerUserId)).ToArray();

            for (int i = 0; i < arrPC.Count(); i++)
            {
                lstResult.Add(arrPC[i].PartCodeNumber);
            }
                
            mpdb.Connection.Close();
            return lstResult.ToArray();
        }

        public static List<PartPacificCode> GetList(Guid userId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();            

            // TODO: Sửa theo MoneyPacificSrv cho chính xác
            List<PartPacificCode> lstPPC = mpdb.PartPacificCodes
                .Where(p => p.StoreUserId.Equals(userId))
                .ToList<PartPacificCode>();

            return lstPPC;        }
    }

}
