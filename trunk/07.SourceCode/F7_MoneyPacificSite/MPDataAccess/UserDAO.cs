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
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            User existUser = mpdb.Users
                .Where(c => c.Id.Equals(userId))
                .Single<User>();
            mpdb.Connection.Close();
            return existUser;
        }

        public static User GetObject(string username)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            User existUser = mpdb.Users
                .Where(c => c.Username.Trim().Equals(username.Trim()))
                .Single<User>();
            mpdb.Connection.Close();
            return existUser;
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
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            
            User existUser = mpdb.Users
                .Where(p => p.Id.Equals(entity.Id))
                .Single<User>();
            existUser.CopyFrom(entity);
            mpdb.SubmitChanges();

            mpdb.Connection.Close();
            return true;
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
