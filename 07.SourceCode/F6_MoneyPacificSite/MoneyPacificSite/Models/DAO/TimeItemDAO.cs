using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSite.Models.DAO
{
    public class TimeItemDAO
    {
        internal static TimeItem GetItem(string day, int hour)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            TimeItem result = db.TimeItems
                .Where(t => (t.Day == day && t.Hour == hour))
                .SingleOrDefault();
            db.Connection.Close();
            return result;
        }


        internal static void AddObject(TimeTable timeTable)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            db.TimeTables.AddObject(timeTable);
            db.SaveChanges();
            db.Connection.Close();            
        }
    }
}