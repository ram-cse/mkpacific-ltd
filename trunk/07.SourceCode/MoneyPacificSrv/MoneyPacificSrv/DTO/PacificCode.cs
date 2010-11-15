using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSrv.DTO
{
    public partial class PacificCode
    {
        partial void OnCreated()
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