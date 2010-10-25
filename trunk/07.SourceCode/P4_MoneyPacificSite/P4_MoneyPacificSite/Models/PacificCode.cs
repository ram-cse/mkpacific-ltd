using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace P4_MoneyPacificSite.Models
{
    public partial class PacificCode
    {
        public PacificCode()
        {
            this.Date = DateTime.Now;
            this.ExpireDate = new DateTime(
                DateTime.Now.Year + 1,
                DateTime.Now.Month,
                DateTime.Now.Day
                );
            this.InitialAmount = 0;
            this.ActualAmount = 0;            
        }        
    }
}