using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P4_MoneyPacificSite.ViewModels
{
    public class StoreUserViewModel
    {
    }

    public class StoreUserInterfaceViewModel 
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