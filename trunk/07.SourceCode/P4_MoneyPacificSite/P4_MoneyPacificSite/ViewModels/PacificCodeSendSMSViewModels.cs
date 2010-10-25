using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace P4_MoneyPacificSite.ViewModels
{
    #region MODEL
    public class PacificCodeSendSMSViewModel
    {
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
    #endregion 
    #region SERVICES
    #endregion
    #region VALIDATORS
    #endregion
}