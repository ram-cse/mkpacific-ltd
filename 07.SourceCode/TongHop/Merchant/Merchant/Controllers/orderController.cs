using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merchant.Models;
using System.Configuration;
namespace Merchant.Controllers
{
    [MPAccess(Roles="Webmaster, Admin")]
    public class orderController : Controller
    {
        //
        // GET: /order/
        public MPWebmasterEntities StoreDb = new MPWebmasterEntities();

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /order/Details/5

        public ActionResult Details(int id)//id cua website order
        {
            var Order = StoreDb.WebsiteOrders.Single(o=>o.Id == id);
            var BuyCustomer = StoreDb.BuyCustomers.Single(b=>b.BuyingId == Order.BuyingId);
            OrderDetailsViewModel model = new OrderDetailsViewModel() { 
            BuyCustomer = BuyCustomer,
            Order = Order
            };
            TransactionLogViewModel.AddLog(User.Identity.Name+" has just viewed the details of OrderId: "+BuyCustomer.BuyingId , DateTime.Now);
            return View(model);
        }

        [HttpPost]
        public ActionResult details(FormCollection form)
        {
            string company = "";
            string trackingId="";
            string DateSend="";
            string Note="";
            string BuyingId="";
            int orderId=0;

            foreach(var key in form.AllKeys)
            {
                if (key == "company")
                    company = form[key];
                else if (key == "trackingId")
                    trackingId = form[key];
                else if (key == "date")
                    DateSend = form[key];
                else if (key == "note")
                    Note = form[key];
                else if (key == "buyingId")
                    BuyingId = form[key];
                else if (key == "id")
                    orderId = int.Parse(form[key]);

            }

            var buyingId = StoreDb.BuyCustomers.Single(b=>b.BuyingId == BuyingId);
            buyingId.Note = Note;
            buyingId.TrackingNumber = trackingId;
            buyingId.DateSend = DateSend;
            buyingId.DeliveryCompany = company;

            var webOrder = StoreDb.WebsiteOrders.Single(w=>w.Id==orderId);
            webOrder.Status = 412;
            StoreDb.SaveChanges();


            //send email to customer
            if (buyingId.Email != "")
            {
                string customerMailConent = "Hello!<br/><br/>";
                customerMailConent += "Your product is being shipped now! Please wait for a few days to receive your order.<br/><br/>";
                customerMailConent += "Your buying code is " + BuyingId + "<br/><br/>";
                customerMailConent += "See you on http://wwww.money-pacific.com.";
                MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], buyingId.Email, "", "", "You've bought with Money Pacific", customerMailConent);
            }

            //send email to webmaster
            string loginid = User.Identity.Name;
            var webmaster = StoreDb.Webmasters.Single(ww => ww.Username == loginid);

            if (webmaster.Email != "")
            {
                string webmasterMailContent = "Hello!";
                webmasterMailContent += "You've just set the product sent! Please finish the transaction by going to Order Manager--> End Transaction <br/><br/>";
                webmasterMailContent += "See you on http://www.money-pacific.com.";
                MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], webmaster.Email, "", "", "You've new order!", webmasterMailContent);
            }

            TransactionLogViewModel.AddLog(User.Identity.Name + " has just set the on delivery of OrderId: " +buyingId.BuyingId, DateTime.Now);
            return RedirectToAction("newview");

        }



        public ActionResult newview()
        {
            string loginid = User.Identity.Name;
            var website = from w in StoreDb.Websites
                          where (w.Webmaster.Username == loginid)
                          select w;

            List<WebsiteOrder>list = new List<WebsiteOrder>();
            foreach (var x in website)
            {
                var oder = from o in StoreDb.WebsiteOrders
                           where (o.WebsiteId == x.Id && o.Status == 411)
                           orderby o.Date descending
                           select o;
                foreach (var oo in oder)
                {
                    list.Add(oo);
                }
            }
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just viewed the list of new orders ", DateTime.Now);
            OrderNewViewModel model = new OrderNewViewModel() { list = list};

            return View(model);
        }
        public ActionResult Ondelivery()
        {
            string loginid = User.Identity.Name;
            var website = from w in StoreDb.Websites
                          where (w.Webmaster.Username == loginid)
                          select w;

            List<WebsiteOrder> list = new List<WebsiteOrder>();
            foreach (var x in website)
            {
                var oder = from o in StoreDb.WebsiteOrders
                           where (o.WebsiteId == x.Id && o.Status == 412)
                           orderby o.Date descending
                           select o;
                foreach (var oo in oder)
                {
                    list.Add(oo);
                }
            }
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just viewed the list of On delivery Orders ", DateTime.Now);
            OrderNewViewModel model = new OrderNewViewModel() { list = list };

            return View(model);

        }
        public ActionResult endtran()
        {
            string loginid = User.Identity.Name;
            var website = from w in StoreDb.Websites
                          where (w.Webmaster.Username == loginid)
                          
                          select w;

            List<WebsiteOrder> list = new List<WebsiteOrder>();
            foreach (var x in website)
            {
                var oder = from o in StoreDb.WebsiteOrders
                           where (o.WebsiteId == x.Id && o.Status == 413 || o.Status == 432)  //432 la admin da validate the proof
                           orderby o.Date descending
                           select o;

                foreach (var oo in oder)
                {
                    list.Add(oo);
                }
            }
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just viewed the list of End Transaction Orders ", DateTime.Now);
            OrderNewViewModel model = new OrderNewViewModel() { list = list };

            return View(model);
        }

        public ActionResult endtranDetails(int id)
        {
            //lay thong tin cua 1 order
            var Order = StoreDb.WebsiteOrders.Single(o => o.Id == id);
            //lay thong tin Customer BUy cua order do
            var BuyCustomer = StoreDb.BuyCustomers.Single(b => b.BuyingId == Order.BuyingId);
            
            OrderDetailsViewModel model = new OrderDetailsViewModel()
            {
                BuyCustomer = BuyCustomer,
                Order = Order
            };
            return View(model);
            
        }

        public ActionResult setDelivery(int id)
        {
            var order = StoreDb.WebsiteOrders.Single(o=>o.Id == id);
            order.Status = 1;
            StoreDb.SaveChanges();

            return RedirectToAction("details", new { id=id});
        }

    }
}
