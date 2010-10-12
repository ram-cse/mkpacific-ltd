using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P4_MoneyPacificSite.ViewModels
{
    public class PacificCodeSendMoneyViewModel
    {
        public string CodeNumber { get; set; }
        public double Amount { get; set; }
        public double AmountConfirm { get; set; }
    }
}