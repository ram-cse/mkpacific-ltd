using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MoneyPacificSite.ViewModels
{
    #region MODEL
    public class PacificCodeSendMoneyViewModel
    {
        public string CodeNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirm { get; set; }
        public double Amount { get; set; }
    }

    public class PacificCodeSendSMSViewModel
    {
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class PacificCodeChangeCodeViewModel
    {
        public string CodeNumber { get; set; }
    }


    #endregion

    #region SERVICES
    #endregion

    #region VALIDATION
    #endregion

}