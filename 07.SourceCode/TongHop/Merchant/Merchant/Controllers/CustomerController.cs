using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security;
using Merchant.Models;
namespace Merchant.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public MPWebmasterEntities db = new MPWebmasterEntities();


        [MPAccess(Roles = "ProblemUser")]
        public ActionResult Index()
        {
            string Userlogin = User.Identity.Name;
            ViewData["buyingId"] = Userlogin;
            TransactionLogViewModel.AddLog("Customer: "+Userlogin +" has just gone to the Customer Home", DateTime.Now);
            return View();
        }

        [MPAccess(Roles = "ProblemUser")]
        public ActionResult vieworder()
        {
            string Userlogin = User.Identity.Name;

            var Order = db.WebsiteOrders.Single(o => o.BuyingId == Userlogin);

            var BuyCustomer = db.BuyCustomers.Single(b => b.BuyingId == Order.BuyingId);
            OrderDetailsViewModel model = new OrderDetailsViewModel()
            {
                BuyCustomer = BuyCustomer,
                Order = Order
            };
            TransactionLogViewModel.AddLog("Customer: " + Userlogin + " has just viewed the Order Detail of OrderID: "+Userlogin, DateTime.Now);
            return View(model);
            
        }



    }
}
