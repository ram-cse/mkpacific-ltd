using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class CollectionDAO
    {
        public static Collection GetObject()
        {
            throw new Exception("chua lam!...");
        }

        public static Collection GetObject(string collectNumber)
        {
            MoneyPacificDataContext mpdp = new MoneyPacificDataContext();
            Collection existCollection = mpdp.Collections
                .Where(c => c.CollectNumber.Trim() == collectNumber.Trim())
                .SingleOrDefault<Collection>();
            mpdp.Connection.Close();
            return existCollection;
        }

        public static List<Collection> GetList(int statusId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            List<Collection> lstResult = mpdb.Collections
                .Where(p => (p.StatusId == statusId))
                .ToList<Collection>();
            mpdb.Connection.Close();
            return lstResult;
        }

        public static Collection GetObject(Guid smId, int iStatusId, DateTime expireDate)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            Collection existObj = mpdb.Collections
                .Where(p => (p.StoreManagerId == smId
                    && p.StatusId == iStatusId
                    && p.ExpireDate > expireDate))
                .ToList().FirstOrDefault<Collection>();
            mpdb.Connection.Close();
            return existObj;
        }

        public static bool IsExist(string collectNumber)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            bool result = mpdb.Collections
                .Where(p => p.CollectNumber.Trim() == collectNumber.Trim())
                .Any();
            return result;
        }

        public static bool AddNew(Collection entity)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            mpdb.Collections.InsertOnSubmit(entity);
            mpdb.SubmitChanges();
            return true;
        }

        public static bool Update(Collection entity)
        {
            /// Update như cách này chưa tối ưu
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            Collection existCollection = mpdb.Collections
                .Where(c => c.Id == entity.Id)
                .Single<Collection>();

            existCollection.CollectNumber = entity.CollectNumber;
            existCollection.AgentId = entity.AgentId;

            existCollection.CreateDate = entity.CreateDate;
            existCollection.ExpireDate = entity.ExpireDate;

            existCollection.CollectDate = entity.CollectDate;
            existCollection.Amount = entity.Amount;
            existCollection.StatusId = entity.StatusId;

            mpdb.SubmitChanges();
            mpdb.Connection.Close();

            return true;
        }

        public static bool Update(Collection entity, Guid agentId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            Collection existCollection = mpdb.Collections
                .Where(c => c.Id == entity.Id)
                .Single<Collection>();

            existCollection.CollectNumber = entity.CollectNumber;
            existCollection.AgentId = agentId;

            existCollection.CreateDate = entity.CreateDate;
            existCollection.ExpireDate = entity.ExpireDate;
            
            existCollection.CollectDate = entity.CollectDate;
            existCollection.Amount = entity.Amount;
            existCollection.StatusId = entity.StatusId;

            mpdb.SubmitChanges();
            mpdb.Connection.Close();

            return true;
        }

        public static List<Collection> GetList(Guid storeManagerId, int iStatusId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            List<Collection> lstResult = mpdb.Collections
                .Where(c => c.StoreManagerId == storeManagerId && c.StatusId == iStatusId)
                .ToList<Collection>();
            mpdb.Connection.Close();
            return lstResult;
        }

        //public static bool AddNew(Collection entity)
        //{
        //    throw new Exception("chua lam!...");
        //}

        //public static bool Update(Collection entity)
        //{
        //    throw new Exception("chua lam!...");
        //}
                
        public static bool Remove(Collection entity)
        {
            throw new Exception("chua lam!...");
        }

        public static List<Collection> GetList()
        {
            throw new Exception("chua lam!...");
        }

        public static List<Collection> GetList(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static Collection[] GetArray()
        {
            throw new Exception("chua lam!...");
        }

        public static Collection[] GetArray(bool condition)
        {
            throw new Exception("chua lam!...");
        }        
    }
}
