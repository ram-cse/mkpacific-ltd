using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSite.Models.DAO;

namespace MoneyPacificSite.Models.BUS
{
    public class TimeTableBUS
    {
        internal static List<TimeTable> GetArray(string dayName, int managerId)
        {
            return TimeTableDAO.GetArray(dayName, managerId).ToList();            
        }

        internal static void Update(int managerId, List<TimeTable> lstTimeTable)
        {
            foreach (TimeTable item in lstTimeTable)
            {
                TimeTableDAO.Update(managerId, item.TimeItemId, item.Enabled);
            }
        }
    }
}