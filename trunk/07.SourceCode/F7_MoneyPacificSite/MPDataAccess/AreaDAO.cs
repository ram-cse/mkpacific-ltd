using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class AreaDAO
    {
        public static Area GetObject(int id)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            Area result = mpdb.Areas
                .Where(a => a.Id.Equals(id))
                .Single<Area>();
            mpdb.Connection.Close();
            return result;
        }

        public static bool AddNew(Area entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Update(Area entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Remove(Area entity)
        {
            throw new Exception("chua lam!...");
        }

        public static List<Area> GetList()
        {
            throw new Exception("chua lam!...");
        }

        public static List<Area> GetList(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static Area[] GetArray()
        {
            throw new Exception("chua lam!...");
        }

        public static Area[] GetArray(bool condition)
        {
            throw new Exception("chua lam!...");
        }
    }
}
