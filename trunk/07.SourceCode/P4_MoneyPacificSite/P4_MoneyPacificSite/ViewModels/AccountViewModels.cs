using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace P4_MoneyPacificSite.ViewModels
{
    #region MODELS
    #endregion
    public class AccountLoginViewModel
    {
        [Required]
        [DisplayName("User name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Remember me?")]        
        public bool RememberMe { get; set; }
    }

    #region SEVICES
    #endregion

    #region VALIDATORS
    #endregion

}