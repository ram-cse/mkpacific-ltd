using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Models
{
    public class MessengerIndexViewModel
    {
       // public List<WebsiteOrder> Orderlist { get; set; }
        public List<Message> MessageList { get; set; }
        public List<ChatBox> chatbox { get; set; }
    }
}