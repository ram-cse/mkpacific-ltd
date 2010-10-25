using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace P4_MoneyPacificSite.Models
{
    public class Mail
    {
        public string Subject { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }

        public Mail()
        {
            Subject = "";
            To = "";
            From = "";
            Body = "";
        }
    }
}