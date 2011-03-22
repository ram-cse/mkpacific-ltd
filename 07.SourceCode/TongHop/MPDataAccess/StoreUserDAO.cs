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
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            StoreUser existStore = mpdb.StoreUsers
                .Where(s => s.UserId.Equals(userId))
                .Single<StoreUser>();
            mpdb.Connection.Close();
            return existStore;
        }

        public static StoreUser GetObject(string phoneNumber)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            return DataAccessLayer.GetConnection.StoreUsers
                .Where(s => s.Phone.Trim().Equals(phoneNumber.Trim()))
                .Single<StoreUser>();
        }

        public static bool AddNew(StoreUser entity)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            DataAccessLayer.GetConnection.StoreUsers.InsertOnSubmit(entity);
            DataAccessLayer.GetConnection.SubmitChanges();
            return true;
        }

        public static bool Update(StoreUser entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Remove(Guid id)
        {
            throw new Exception("chua lam!...");
        }

        public static List<StoreUser> GetList()
        {
            throw new Exception("chua lam!...");
        }

        public static List<StoreUser> GetList(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static List<StoreUser> GetList(Guid managerId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            List<StoreUser> lstResult = mpdb.StoreUsers
                .Where(s => s.ManagerId == managerId)
                .ToList<StoreUser>();
            mpdb.Connection.Close();
            return lstResult;
        }

        public static StoreUser[] GetArray()
        {
            throw new Exception("chua lam!...");
        }

        public static StoreUser[] GetArray(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static bool IsExist(string phoneNumber)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();

            //List<StoreUser> lstSU = mpdb.StoreUsers.ToList<StoreUser>();
            
            bool result = mpdb.StoreUsers
                .Any(s => s.Phone.Trim() == phoneNumber.Trim());
            mpdb.Connection.Close();
            return result;
            
        }

        public static StoreUser[] GetArray(Guid managerUserId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            StoreUser[] result = mpdb.StoreUsers
                .Where(s => s.ManagerId.Equals(managerUserId)).ToArray<StoreUser>();
            mpdb.Connection.Close();
            return result;
        }

        public static bool UnLock(Guid storeUserId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            StoreUser exitStore = mpdb.StoreUsers
                .Where(l => l.UserId == storeUserId)
                .Single<StoreUser>();

            /// UNLOCK
            exitStore.Enable = true;
            ///

            mpdb.SubmitChanges();
            mpdb.Connection.Close();
            return true;

        }

        public static bool Lock(Guid storeGuid)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            StoreUser exitStore = mpdb.StoreUsers
                .Where(l => l.UserId == storeGuid)
                .Single<StoreUser>();

            /// LOCK
            exitStore.Enable = false;
            /// 

            mpdb.SubmitChanges();
            mpdb.Connection.Close();
            return true;            

        }


        
    }
}
