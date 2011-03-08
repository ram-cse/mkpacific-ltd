using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Models
{
    public class AccountIndexViewModel
    {
        public List<WebsiteOrder> listOrder { get; set; }
        public List<Message> listMessage { get; set; }
        
    }
}