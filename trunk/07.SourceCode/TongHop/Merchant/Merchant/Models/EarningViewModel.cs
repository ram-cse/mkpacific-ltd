using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Models
{
    public class EarningViewModel
    {
        public Payment payment { get; set; }
        public Earning earning { get; set; }
    }
}