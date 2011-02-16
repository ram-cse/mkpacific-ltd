using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class StoreUserStateDAO
    {        
        public static StoreUserState GetObject(int id)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            StoreUserState result = mpdb.StoreUserStates
                .Where(s => s.Id.Equals(id))
                .Single<StoreUserState>();
            mpdb.Connection.Close();
            return result;
        }

        public static StoreUserState GetObject(string partCodeNumber)
        {
            throw new Exception("chua lam!...");
        }

        public static bool AddNew(StoreUserState entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Update(StoreUserState entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Remove(Guid id)
        {
            throw new Exception("chua lam!...");
        }

        public static List<StoreUserState> GetList()
        {
            throw new Exception("chua lam!...");
        }

        public static List<StoreUserState> GetList(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static StoreUserState[] GetArray()
        {
            throw new Exception("chua lam!...");
        }

        public static StoreUserState[] GetArray(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        
    }
}
