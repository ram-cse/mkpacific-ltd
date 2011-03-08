using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Models
{
    public class AdminIndexViewModel
    {
        public List<WebsiteOrder> listOrder { get; set; } // new order and problem 
        public List<Webmaster> listWebmaster { get; set; }
        public List<Website> listWebsite { get; set; }
        public List<MessageView> listMessage { get; set; }
        
    }

    public class MessageView
    {
        public string TextDisplay { get; set; }
        public string reference { get; set; }
        public DateTime date { get; set; }
    }
}