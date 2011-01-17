using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoneyPacificSite.Models;

namespace MoneyPacificSite.ViewModels
{
    public class SecurityViewModel
    {
        public List<TimeDayView> lstSecurityTimeDay { get; set; }
        public string storeManagerName { get; set; }
        public int managerId { get; set; }

        public SecurityViewModel()
        {
            lstSecurityTimeDay = new List<TimeDayView>()
            {
                new TimeDayView{dateName = "MonDay"},
                new TimeDayView{dateName = "Tueday"},
                new TimeDayView{dateName = "Wednesday"},
                new TimeDayView{dateName = "Thursday"},
                new TimeDayView{dateName = "Friday"},
                new TimeDayView{dateName = "Saturday"},
                new TimeDayView{dateName = "Sunday"}
            };
        }
    }

    public class TimeDayView
    {
        public string dateName { get; set; }
        public List<TimeTable> lstTimeTable { get; set; }
        public List<int> hourItem { get; set; }
        public List<bool> isLocked { get; set; }
    }
}
