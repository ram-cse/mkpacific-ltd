using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace F5_MoneyPacificSite.ViewModels
{

    public class StoreManagerAskToBePartnerViewModel
    {   
        /// Main information
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Name Of Store")]
        public string NameOfStore { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Address 02")]
        public string Address2 { get; set; }
        [DisplayName("Zip Code")]
        public string Zip { get; set; }
        [DisplayName("Town")]
        public string Town { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }
        [Required]
        [DisplayName("Phone")]
        public string Phone { get; set; }
        [DisplayName("Phone 02")]
        public string Phone2 { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Web Site")]
        public string WebSite { get; set; }

        /// More Infomation
        [DisplayName("What product do you sell in your shop?")]
        public string Product { get; set; }
        [DisplayName("What the size of your shop? (<1m2, <5m2, <20m2.., >200m2)")]
        public string ShopSize { get; set; }
        [DisplayName("How many shop do you have?")]
        public string NumOfShop { get; set; }

        /// Company Information
        [DisplayName("- Legal Structure")]
        public string LegalStructure { get; set; }
        [DisplayName("- Name of the company")]
        public string NameOfCompany { get; set; }
        [DisplayName("- VAT Number")]
        public string VATNumer { get; set; }
    }

    public class StoreManagerDashboardViewModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int TotalTransaction { get; set; }
        public int TotalLastMonthAmount { get; set; }
        public DateTime LastCollectDate { get; set; }
        public bool IsLocked { get; set; }

        public int Id { get; set; }
    }

    public class StoreManagerInformationViewModel
    {
        public UserInformation[] ArrUser { get; set; }
        public ManagerInformation Manager { get; set; }
        
    }

    public class ManagerInformation
    {

        public string Name { get; set; }

        [DisplayName("Username (for web)")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        public string NameOfStore { get; set; }        
        public string ManagerPhone { get; set; }

        public string Address { get; set; }
        public string Address2 { get; set; }

        public string Phone { get; set; }
        public string Phone2 { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        public string EmailAlert { get; set; }
        public string EmailBill { get; set; }

        public string NameOfCompany { get; set; }
        public string VATNumber { get; set; }
    }

    public class UserInformation
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string PINStore { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string LastTransaction { get; set; }
    }    
}