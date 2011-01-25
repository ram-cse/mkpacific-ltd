using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class TimeTableDAO
    {
        public static TimeTable GetObject(Guid id)
        {
            throw new Exception("chua lam!...");
        }

        public static TimeTable GetObject(string partCodeNumber)
        {
            throw new Exception("chua lam!...");
        }

        public static bool AddNew(TimeTable entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Update(TimeTable entity)
        {
            throw new Exception("chua lam!...");
        }


        public static bool Update(Guid managerId, int timeItemId, bool enabled)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            
            TimeTable existItem = mpdb.TimeTables
                .Where(t => (t.TimeItemId == timeItemId && t.ManagerId == managerId))
                .SingleOrDefault();
            existItem.Enabled = enabled;
            mpdb.SubmitChanges();

            mpdb.Connection.Close();
            return true;
        }

        public static bool Remove(Guid id)
        {
            throw new Exception("chua lam!...");
        }

        public static List<TimeTable> GetList()
        {
            throw new Exception("chua lam!...");
        }

        public static List<TimeTable> GetList(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static TimeTable[] GetArray()
        {
            throw new Exception("chua lam!...");
        }

        public static TimeTable[] GetArray(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static List<TimeTable> GetList(string dayName, Guid managerId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();           
            
            List<TimeTable> result = mpdb.TimeTables
                .Where(t => t.TimeItem.Day.Trim() == dayName && t.ManagerId == managerId)
                .ToList<TimeTable>();
            mpdb.Connection.Close();
            return result;


        }

        public static TimeTable GetObject(int timeItemId, Guid managerId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            TimeTable result = mpdb.TimeTables
                .Where(t => (t.TimeItemId == timeItemId && t.ManagerId == managerId))
                .SingleOrDefault();
            mpdb.Connection.Close();
            return result;                    
        }
    }
}
