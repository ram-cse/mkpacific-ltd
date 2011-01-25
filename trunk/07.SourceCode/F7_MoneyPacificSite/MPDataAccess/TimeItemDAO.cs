using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class TimeItemDAO
    {
        public static TimeItem GetObject(Guid id)
        {
            throw new Exception("chua lam!...");
        }

        public static TimeItem GetObject(string partCodeNumber)
        {
            throw new Exception("chua lam!...");
        }

        public static bool AddNew(TimeItem entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Update(TimeItem entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Remove(Guid id)
        {
            throw new Exception("chua lam!...");
        }

        public static List<TimeItem> GetList()
        {
            throw new Exception("chua lam!...");
        }

        public static List<TimeItem> GetList(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static TimeItem[] GetArray()
        {
            throw new Exception("chua lam!...");
        }

        public static TimeItem[] GetArray(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static TimeItem GetObject(string day, int hour)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            TimeItem result = mpdb.TimeItems
                .Where(t => (t.Day == day && t.Hour == hour))
                .SingleOrDefault();
            mpdb.Connection.Close();
            return result;
        }

        public static void AddObject(TimeTable entity)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            mpdb.TimeTables.InsertOnSubmit(entity);
            mpdb.SubmitChanges();
            mpdb.Connection.Close();
        }
    }
}
