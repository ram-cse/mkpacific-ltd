using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class UserDAO
    {
        public static User GetObject(Guid userId)
        {
            throw new Exception("chua lam!...");
        }

        public static bool AddNew(User entity)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            mpdb.Users.InsertOnSubmit(entity);
            mpdb.SubmitChanges();
            mpdb.Connection.Close();
            return true;
        }

        public static bool Update(User entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Remove(Guid id)
        {
            throw new Exception("chua lam!...");
        }

        public static List<User> GetList()
        {
            throw new Exception("chua lam!...");
        }

        public static List<User> GetList(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static User[] GetArray()
        {
            throw new Exception("chua lam!...");
        }

        public static User[] GetArray(bool condition)
        {
            throw new Exception("chua lam!...");
        }
    }

}
