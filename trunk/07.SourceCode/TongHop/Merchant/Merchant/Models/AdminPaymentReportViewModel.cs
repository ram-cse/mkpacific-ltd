using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Models
{
    public class AdminPaymentReportViewModel
    {
        public List<WebsiteOrder> listOrder { get; set; }
        public List<Webmaster> listwebmaster { get; set; }
    }
}