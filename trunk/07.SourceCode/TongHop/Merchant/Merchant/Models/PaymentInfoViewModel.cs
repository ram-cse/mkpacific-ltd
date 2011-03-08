using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Models
{
    public class PaymentInfoViewModel
    {
        public Webmaster webmaster { get; set; }
        public Earning earning { get; set; }
        public Payment payment { get; set; }
    }
}