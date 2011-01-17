using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSite.Models.DAO;

namespace MoneyPacificSite.Models.BUS
{
    public class TimeItemBUS
    {
        internal static void AddIfNotExists(int storeManagerId)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    string dayName = GetDay(i + 1);
                    TimeItem timeItem = TimeItemDAO.GetItem(dayName, j);
                    TimeTable timeTable = TimeTableDAO.GetItem(timeItem.Id, storeManagerId);

                    if (timeTable == null)
                    {
                        timeTable = new TimeTable { 
                            TimeItemId = timeItem.Id,
                            ManagerId = storeManagerId,
                            Enabled = true
                        };
                        TimeItemDAO.AddObject(timeTable);
                    }
                }
            }

        }

        private static string GetDay(int id)
        {
            string result = "";
            switch (id)
            {
                case 1:
                    result = "Sunday";
                    break;
                case 2:
                    result = "Monday";
                    break;
                case 3:
                    result = "Tueday";
                    break;
                case 4:
                    result = "Wednesday";
                    break;
                case 5:
                    result = "Thursday";
                    break;
                case 6:
                    result = "Friday";
                    break;
                case 7:
                    result = "Saturday";
                    break;
            }
            return result;
        }
    }
}