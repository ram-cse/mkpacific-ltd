using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class StoreManagerDAO
    {
        public static StoreManager GetObject(Guid userId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            StoreManager obj= mpdb.StoreManagers
                .Where(s => s.UserId == userId)
                .Single<StoreManager>();
            mpdb.Connection.Close();
            return obj;
        }

        public static StoreManager GetObject(string phoneNumber)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            StoreManager obj = mpdb.StoreManagers
                .Where(s => s.ManagerPhone.Trim().Equals(phoneNumber.Trim()))
                .Single<StoreManager>();
            mpdb.Connection.Close();
            return obj;
        }

        public static bool AddNew(StoreManager entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Update(StoreManager entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Remove(Guid id)
        {
            throw new Exception("chua lam!...");
        }

        public static List<StoreManager> GetList()
        {
            throw new Exception("chua lam!...");
        }

        public static List<StoreManager> GetList(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static StoreManager[] GetArray()
        {
            throw new Exception("chua lam!...");
        }

        public static StoreManager[] GetArray(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static bool IsExist(string phoneNumber)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            bool result = mpdb.StoreManagers
                .Any(s => s.ManagerPhone.Trim() == phoneNumber.Trim());
            mpdb.Connection.Close();
            return result;
        }
    }
}
