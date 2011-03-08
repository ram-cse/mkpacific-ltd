using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Models
{
    public class OrderDetailsViewModel
    {
        public WebsiteOrder Order { get; set; }
        public BuyCustomer BuyCustomer { get; set; }
    }
}