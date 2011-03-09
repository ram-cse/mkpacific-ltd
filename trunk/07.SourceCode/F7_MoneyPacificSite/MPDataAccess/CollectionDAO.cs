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

        public static Collection GetObject(Guid smId, int iStatusId, DateTime expireDate)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            Collection existObj = mpdb.Collections
                .Where(p => (p.StoreManagerId == smId
                    && p.StatusId == iStatusId
                    && p.ExpireDate == expireDate))
                .SingleOrDefault();            
            mpdb.Connection.Close();
            return existObj;
        }


        public static bool AddNew(Collection entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Update(Collection entity)
        {
            throw new Exception("chua lam!...");
        }
                
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
