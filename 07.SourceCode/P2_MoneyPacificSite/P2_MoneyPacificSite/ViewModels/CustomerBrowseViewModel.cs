using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using P2_MoneyPacificSite.Models;


namespace P2_MoneyPacificSite.ViewModels
{
    public class CustomerBrowseViewModel
    {
        public int NumberOfPacificCode { get; set; }
        public List<PacificCode> PacificCodes { get; set; }
    }
}