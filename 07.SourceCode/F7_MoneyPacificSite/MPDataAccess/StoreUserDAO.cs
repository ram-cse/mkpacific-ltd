using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class StoreUserDAO
    {
        public static StoreUser GetObject(Guid userId)
        {
            return DataAccessLayer.mpdb.StoreUsers
                .Where(s => s.UserId.Equals(userId))
                .Single<StoreUser>();
        }

        public static StoreUser GetObject(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public static bool AddNew(StoreUser entity)
        {
            throw new NotImplementedException();
        }

        public static bool Update(StoreUser entity)
        {
            throw new NotImplementedException();
        }

        public static bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public static List<StoreUser> GetList()
        {
            throw new NotImplementedException();
        }

        public static List<StoreUser> GetList(bool condition)
        {
            throw new NotImplementedException();
        }

        public static StoreUser[] GetArray()
        {
            throw new NotImplementedException();
        }

        public static StoreUser[] GetArray(bool condition)
        {
            throw new NotImplementedException();
        }

        public static bool IsExist(string phoneNumber)
        {
            return DataAccessLayer.mpdb.StoreUsers
                .Any(s => s.Phone.Trim() == phoneNumber.Trim());                
            
        }
    }
}
