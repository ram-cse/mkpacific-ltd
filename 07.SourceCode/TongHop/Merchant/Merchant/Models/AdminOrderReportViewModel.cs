using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Models
{
    public class AdminOrderReportViewModel
    {
        public List<WebsiteOrder> listOrder { get; set; }
        public List<Webmaster> listWebmaster { get;set; }
    }

   
}