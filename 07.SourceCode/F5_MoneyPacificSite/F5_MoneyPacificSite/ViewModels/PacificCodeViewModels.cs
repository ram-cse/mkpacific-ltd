using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace F5_MoneyPacificSite.ViewModels
{
    #region MODEL    
    //public class PacificCodeDetailSendViewModel
    //{
    //    public string CodeNumber { get; set; }
    //}

    public class PacificCodeDetailViewModel
    {
        [Required]
        [DisplayName("Code Number")]
        public string CodeNumber { get; set; }

        [DisplayName("Last Transaction")]
        public DateTime LastTransaction { get; set; }

        [DisplayName("Customer Phone")]
        public string CustomerPhone { get; set; }
        
        [DisplayName("Initial Amount")]
        public int InitialAmount { get; set; }
        
        [DisplayName("Actual Amount")]
        public int ActualAmount { get; set; }
        
        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }
        
        [DisplayName("Expire Date")]
        public DateTime ExpireDate { get; set; }
        
        [DisplayName("Comment")]
        public string Comment { get; set; }
        
        [DisplayName("Store Phone")]
        public string StorePhone { get; set; }
    }

    public class PacificCodeSendMoneyViewModel
    {
        public string CodeNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirm { get; set; }
        public double Amount { get; set; }        
    }

    public class PacificCodeChangeCodeViewModel
    {
        public string CodeNumber { get; set; }
    }

    public class PacificCodeSendSMSViewModel
    {
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }


    #endregion

    #region SERVICES
    #endregion

    #region VALIDATION
    #endregion
}