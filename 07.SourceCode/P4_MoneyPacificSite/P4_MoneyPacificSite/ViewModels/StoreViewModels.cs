using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using P4_MoneyPacificSite.Models;

namespace P4_MoneyPacificSite.ViewModels
{
    #region MODEL
    public class StoreViewModel
    {
        [Required]
        [DisplayName("User name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Name of the store")]
        public string NameOfStore { get; set; }

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Address 02")]
        public string Address02 { get; set; }

        [DisplayName("Zip Code")]
        public string Zip { get; set; }

        [DisplayName("Town")]
        public string Town { get; set; }
        [DisplayName("Country")]
        public string Coutry { get; set; }

        [Required]
        [DisplayName("Phone 01")]
        public string Phone { get; set; }
        
        [DisplayName("Phone 02")]
        public string Phone02 { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        
        [DisplayName("Web Site")]
        public string WebSite { get; set; }

        [DisplayName("What product do you sell in you shop? ")]
        public string Product { get; set; }

        [DisplayName("What the size of your shop? (<1m2, <5m2, <20m2, <200m2, >200m2)")]
        public string ShopSize { get; set; }

        [DisplayName("How many shop do you have?")]
        public int NumberOfShop { get; set; }

        [DisplayName("Legal structure")]
        public string LegalStructure { get; set; }

        [DisplayName("Name of Company")]
        public string NameOfCompany { get; set; }

        [DisplayName("VAT Number")]
        public string VATNumber { get; set; }
    }

    public class StoreDashboarshViewModel
    {
        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Transactions  of the last 30 days")]
        public int LastTransactions { get; set; }

        [DisplayName("Amount from customer")]
        public int AmountFromCustomer { get; set; }

        [DisplayName("Last Pacific collect")]
        [DataType(DataType.Date)]
        public DateTime LastCollectDate { get; set; }
    }

    public class StoreInformationViewModel
    {
        // For Manager of Store

        public Store StoreInfo { get; set; }

        [DisplayName("Initial PIN Store phone")]
        public string InitPinStorePhone { get; set; }

        [DisplayName("Shop Web Password")]
        public string ShopWebPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Manager Shop Web Password")]
        public string ManagerShopWebPassword { get; set; }
        
        [DisplayName("Payment mode (Select List)")]
        public string PaymentMode { get; set; }

    }

    public class StoreSecurityViewModel
    {
        public ScheduelWeek BuyPacificCodeSchedule = new ScheduelWeek();
        
    }


    public class StorePacificEmailViewModel
    { }   

    #endregion

    #region SERVICES
    public class ScheduelWeek
    {
        public ScheduleDay[] arrDays = new ScheduleDay[7];
        public ScheduelWeek()
        { 
            arrDays[0] = new ScheduleDay("Monday");
            arrDays[1] = new ScheduleDay("Tuesday");
            arrDays[2] = new ScheduleDay("Wednesday");
            arrDays[3] = new ScheduleDay("Thursday");
            arrDays[4] = new ScheduleDay("Friday");
            arrDays[5] = new ScheduleDay("Saturday");
            arrDays[6] = new ScheduleDay("Sunday");
        }
    }
    public class ScheduleDay
    {
        public string Name;
        public int FromAM { get; set; }
        public int ToAM { get; set; }
        public int FromPM { get; set; }
        public int ToPM { get; set; }

        public ScheduleDay()
        {
            Name = "";
            FromAM = 0;
            ToAM = 12;
            FromPM = 0;
            ToPM = 12;
        }

        public ScheduleDay(string name)
        {
            Name = name;
            FromAM = 0;
            ToAM = 12;
            FromPM = 0;
            ToPM = 12;
        }
    }

    #endregion

    #region VALIDATION

    #endregion
}