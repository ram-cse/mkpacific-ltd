using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSite.Models.DAO
{
    public class TimeTableDAO
    {
        internal static TimeTable GetItem(int timeItemId, int managerId)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            TimeTable result = db.TimeTables
                .Where(t => (t.TimeItemId == timeItemId && t.ManagerId == managerId))
                .SingleOrDefault();
            db.Connection.Close();
            return result;
        }

        internal static TimeTable[] GetArray(string dayName, int managerId)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            TimeTable[] arrResult = db.TimeTables
                .Include("TimeItem")
                .Where(t => (t.TimeItem.Day.Trim() == dayName && t.ManagerId == managerId))
                .ToArray();
            db.Connection.Close();
            return arrResult;
        }

        internal static void Update(int managerId, int timeItemId, bool enabled)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            TimeTable existItem = db.TimeTables
                .Where(t => (t.TimeItemId == timeItemId && t.ManagerId == managerId))
                .SingleOrDefault();
            existItem.Enabled = enabled;
            db.SaveChanges();
            db.Connection.Close();
        }
    }
}