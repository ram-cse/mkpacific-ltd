using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSite.ViewModels
{
    public class StoreUserDashboardViewModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int TotalTransaction { get; set; }
        public int TotalLastMonthAmount { get; set; }
        public DateTime LastCollectDate { get; set; }
        public bool IsLocked { get; set; }

        public int Id { get; set; }

    }
}