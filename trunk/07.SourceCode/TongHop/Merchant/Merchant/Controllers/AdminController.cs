using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merchant.Models;
using System.Web.Routing;
using System.Text;
using System.Configuration;
using MoneyPacificSite.ViewModels;


namespace Merchant.Controllers
{
    [MPAccess(Roles="Admin")]
    public class AdminController : Controller
    {
        
        // GET: /Admin/
        public MPWebmasterEntities db = new MPWebmasterEntities();
        public ActionResult Index()
        {
            // 10 of newest order


            //10 of newest problem


            //10 of newest webmaster


            // 10 of newest added websites
            var order = from o in db.WebsiteOrders
                        orderby o.Date descending
                        select o;

            var webmaster = (from w in db.Webmasters
                             orderby w.Id descending
                             select w).Take(10);

            var website = (from ws in db.Websites
                           orderby ws.DateJoin descending
                           select ws).Take(10);


            // list of all message

            List<MessageView> msglist = new List<MessageView>();

            var message = (from msg in db.Messages
                           where msg.ToMPAdmin == true
                            orderby msg.DateSend descending
                            select msg).Take(5);

            foreach(var temp in message)
            {
                MessageView l = new MessageView();
                l.date = temp.DateSend;
                l.TextDisplay = temp.Message1;
                l.reference = temp.UserId; // this is userid to follow the chat

                msglist.Add(l);


            }
            var chatbox = (from chat in db.ChatBoxes
                           orderby chat.DateSend descending
                           select chat).Take(5);

            foreach (var temp in chatbox)
            {
                MessageView l = new MessageView();
                l.date = temp.DateSend.Value;
                l.reference = temp.WebmasterId.ToString();// truong hop gui cho webmaster
                l.TextDisplay = temp.Message;

                msglist.Add(l);
            }
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just go to Money Pacific Admin - Home!", DateTime.Now);
            AdminIndexViewModel model = new AdminIndexViewModel() { listOrder = order.ToList(), listWebmaster = webmaster.ToList(), listWebsite = website.ToList(),listMessage = msglist};
            return View(model);
        }

        public ActionResult userdetail(string id)
        {
            var check = db.Webmasters.Single(m => m.Username == id);
            int accType = int.Parse(check.AccountType.ToString());

            if (accType == 0) // personal account
            {
                RegisterModel model = new RegisterModel()
                {
                    UserName = check.Username,
                  //  Name = check.Name,
                    Email = check.Email,
                    Phone = check.Phone,
                    City = check.City,
                    ATM = check.ATM,
                    Bank = check.Bank,
                  //  Street = check.Street,
                  //  Ward = check.Ward,
                    AccountType = accType,
                };
                TransactionLogViewModel.AddLog(User.Identity.Name + " has just viewed details of Webmaster: "+id, DateTime.Now);
                return View(model);
            }
            else
            { // bussiness account

                RegisterModel model = new RegisterModel()
                {
                    UserName = check.Username,
                //    Name = check.CompanyName,
                    CompanyName = check.CompanyName,
                    TaxCode = check.TaxCode,
                    AccountType = accType,
                    Email = check.Email,
                    Phone = check.Phone,
                    City = check.City,
                    ATM = check.ATM,
                    Bank = check.Bank,
               //     Street = check.Street,
              //      Ward = check.Ward,
                };
                TransactionLogViewModel.AddLog(User.Identity.Name + " has just viewed details of Webmaster: " + id, DateTime.Now);
                return View(model);
            }




            
        }


        public ActionResult orderReport()
        {
            var websiteOrder = from w in db.WebsiteOrders
                               orderby w.Date descending
                               select w;
            var webmaster = from webm in db.Webmasters
                            select webm;
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just viewed Order Report", DateTime.Now);
            AdminOrderReportViewModel model = new AdminOrderReportViewModel() { listOrder = websiteOrder.ToList(), listWebmaster = webmaster.ToList() };
            return View(model);
 
        }

        public ActionResult ViewURL(int id)//id is username
        {
            var website = from m in db.Websites
                          where m.WebmasterId == id
                          select m;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<option value=\"\" selected>----select----</option>");
            if (website.Any())
            {
                foreach (var key in website)
                {
                    sb.AppendFormat("<option value=\"" + key.Id + "\">" + key.URL + "</option>");
                }
            }
            else
                sb.AppendFormat("<span style=\"color:red\">No entry found</span>");

            Response.Write(sb.ToString());


            return null;

        }

        public ActionResult showdetaildata(string id)
        {
            string[] temp = id.Split(new char[]{'_'},StringSplitOptions.None);
            int webmasterId = int.Parse(temp[0]);
            int websiteId = int.Parse(temp[1]);

           var order = from o in db.WebsiteOrders
                       where o.WebsiteId == websiteId && o.Website.WebmasterId == webmasterId
                       orderby o.Date descending
                       select o;

            StringBuilder sb = new StringBuilder();
            if (order.Any())
            {
                foreach (var key in order)
                {
                    sb.AppendFormat("<li><a href=\"/order/details/{0}\">{1}</a> - {2} VND - {3}VND</li>",key.Id, key.BuyingId, key.Amount.ToString("n0"), key.Date);
                }
            }
            else
                sb.AppendFormat("<span style=\"color:red\">No entry found</span>");

            Response.Write(sb.ToString());
            return null;
        }


        public ActionResult paymentReport()
        {
          //  oo.Date.AddDays(30) <= DateTime.Today && (oo.Status == 411 || oo.Status==412 )

            var webOrder = from o in db.WebsiteOrders
                           where o.MoneyStatus == 1
                           select o;
            var webmaster = from webmas in db.Webmasters
                            select webmas;

            AdminPaymentReportViewModel model = new AdminPaymentReportViewModel() { listOrder = webOrder.ToList(), listwebmaster = webmaster.ToList()};
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just viewed Payment Report", DateTime.Now);
            return View(model);
        }
        public ActionResult ViewPaymentDetails(string id)
        {
            string[] temp = id.Split(new char[] { '_' }, StringSplitOptions.None);
            int webmasterId = int.Parse(temp[0]);
            int websiteId = int.Parse(temp[1]);
            int total = 0;

            var order = from o in db.WebsiteOrders
                        where o.WebsiteId == websiteId && o.Website.WebmasterId == webmasterId && o.MoneyStatus == 1
                        orderby o.Date descending
                        select o;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<ul>");
            if (order.Any())
            {
                foreach (var key in order)
                {
                    total += key.Amount;
                    sb.AppendFormat("<li><a href=\"/order/details/{0}\">{1}</a> - {2} VND - {3}VND</li>", key.Id, key.BuyingId, key.Amount.ToString("n0"), key.Date);
                }
            }
            else
                sb.AppendFormat("<span style=\"color:red\">No entry found</span>");

            sb.AppendFormat("</ul><b>Total: {0} VND</b>",total.ToString("n0"));
            Response.Write(sb.ToString());
            return null;
            
        }

        public ActionResult messenger()
        {
            // list of all message

            List<MessageView> msglist = new List<MessageView>();

            var message = (from msg in db.Messages
                           where msg.ToMPAdmin == true
                           orderby msg.DateSend descending
                           select msg);

            foreach (var temp in message)
            {
                MessageView l = new MessageView();
                l.date = temp.DateSend;
                l.TextDisplay = temp.Message1;
                l.reference = temp.UserId; // this is userid to follow the chat

                msglist.Add(l);


            }
            var chatbox = (from chat in db.ChatBoxes
                           orderby chat.DateSend descending
                           select chat);

            foreach (var temp in chatbox)
            {
                MessageView l = new MessageView();
                l.date = temp.DateSend.Value;
                l.reference = temp.WebmasterId.ToString();// truong hop gui cho webmaster
                l.TextDisplay = temp.Message;

                msglist.Add(l);
            }
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just go to Pacific Messenger!" , DateTime.Now);
            AdminIndexViewModel model = new AdminIndexViewModel() {listMessage = msglist };
            return View(model);

        }
        public ActionResult webmasterManager()
        {
            var webmaster = from web in db.Webmasters
                            orderby web.DateJoin descending
                            select web;
            ViewData["total"] = webmaster.Count();
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just go to Webmaster Manager!", DateTime.Now);
            return View(webmaster.ToList());
        }
        public ActionResult disableWebmaster(int id)
        {
            var webmaster = db.Webmasters.Single(w=>w.Id == id);
            webmaster.Status = -1;//disable webmaster
            db.SaveChanges();
            StringBuilder sb = new StringBuilder();
           
            sb.AppendFormat("<a href=\"javascript:void()\" onclick=\"Enable('{0}');\"> Enable Now</a> ",id);

            Response.Write(sb);
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just disabled Webmaster: "+webmaster.Username, DateTime.Now);
            return null;
        }
        
        public ActionResult EnableWebmaster(int id)
        {
            var webmaster = db.Webmasters.Single(w => w.Id == id);
            webmaster.Status = 1;//enable webmaster
            db.SaveChanges();
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<a href=\"javascript:void()\" onclick=\"Disable('{0}');\"> Disable Now</a> ", id);
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just enabled Webmaster: " + webmaster.Username, DateTime.Now);
            Response.Write(sb);

            return null;
        }

        public ActionResult paymentinfo(int id)
        {
            Webmaster webmaster = db.Webmasters.Single(w=>w.Id==id);
            Earning earning = db.Earnings.Single(e=>e.WebmasterId == id);
            Payment payment = db.Payments.Single(p=>p.WebmasterId == id);
            
            PaymentInfoViewModel model = new PaymentInfoViewModel() { earning = earning,payment = payment,webmaster = webmaster};
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just view Payment Information of Webmaster: "+webmaster.Username, DateTime.Now);
            return View(model);
        }
        public ActionResult websiteManager()
        {
            var website = from webs in db.Websites
                          orderby webs.DateJoin descending
                          select webs;
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just go to Website Manager", DateTime.Now);
            return View(website.ToList());
        }
        public ActionResult ValidateWebsite(int id)
        {
            var website = db.Websites.Single(w => w.Id == id);
            website.Status = 1;
            db.SaveChanges();
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just validated the website: "+website.URL, DateTime.Now);
            return null;

 
        }

        public ActionResult disableFollow(string id)
        {
            var message = from temp in db.Messages
                          where temp.UserId == id
                          select temp;
            foreach (var key in message)
            {
                key.IsClose = true;
            }
            db.SaveChanges();
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just closed the Folow Order: "+id, DateTime.Now);
            return null;
 
        }

        public ActionResult ValidateProof(string id)
        {
            var websiteOrder = db.WebsiteOrders.Single(o=>o.BuyingId == id);
            websiteOrder.ProofValidate = true;
            websiteOrder.Status = 432;//ket thuc transaction, proof da duoc validate and cong tien cho webmaster
            websiteOrder.MoneyStatus = 1;//money cho webmaster
            websiteOrder.Date = DateTime.Now;
            

            //gui email cho webmaster 
            var webmaster = db.Webmasters.Single(w=>w.Id == websiteOrder.Website.WebmasterId);
            string emailContent = "heelo!<br/><br/>";
            emailContent += "Money Pacific Admins have just validate the proof and the money is transfered to your account!";
            
            if(!string.IsNullOrEmpty(webmaster.Email))
                MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], webmaster.Email, "", "", "The Proof validated!", emailContent);
            
            //gui email cho khasch hang
            string emailcontent1 = "hello!";
            emailcontent1 += "The Website Admin have the Proof of your order and you are already receive the product.";
            var BuyCustomer = db.BuyCustomers.Single(o=>o.BuyingId == id);
            if(!string.IsNullOrEmpty(BuyCustomer.Email))
                MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], BuyCustomer.Email, "", "", "The Proof validated!", emailcontent1);
           
            db.SaveChanges();
            TransactionLogViewModel.AddLog(User.Identity.Name + " has just validated the Proof for Webmaster:"+ webmaster.Username+" ,orderID: "+id, DateTime.Now);
            return null;
        }

        public ActionResult DontValidateProof(string id)
        {
            var websiteOrder = db.WebsiteOrders.Single(o => o.BuyingId == id);
            websiteOrder.ProofValidate = false;
            websiteOrder.Status = 433;//ket thuc transaction, proof khong da duoc validate and genarate the new pacific code for the customer
            websiteOrder.MoneyStatus = 0;//money cho webmaster
            websiteOrder.Date = DateTime.Now;

            //gui email cho webmaster 
            var webmaster = db.Webmasters.Single(w => w.Id == websiteOrder.Website.WebmasterId);
            string emailContent = "heelo!<br/><br/>";
            emailContent += "Money Pacific Admins don't validate the proof of the order and we must genarate a new Pacific code for customer.";

            if (!string.IsNullOrEmpty(webmaster.Email))
                MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], webmaster.Email, "", "", "The Proof don't validate!", emailContent);

            //gui email cho khasch hang
            string emailcontent1 = "hello!";
            emailcontent1 += "We're sorry about problem with your order and we will genarate a new Pacific code for you. <br/><br/>";
            emailcontent1 += "<b>Reason:</b> Website You buy don't send the order for you.<br/><br/>";
            emailcontent1 += "Here is new Pacific Code:";
            var BuyCustomer = db.BuyCustomers.Single(o => o.BuyingId == id);
            
            if (!string.IsNullOrEmpty(BuyCustomer.Email))
                MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], BuyCustomer.Email, "", "", "Your order failed! New Pacific Code", emailcontent1);

            db.SaveChanges();
            TransactionLogViewModel.AddLog(User.Identity.Name + " don't validate the Proof for Webmaster:" + webmaster.Username + " ,orderID: " + id, DateTime.Now);
            return null;
        }


        public ActionResult setWithDraw()
        {
            var para = db.Parameters.Single(p => p.Name == "MinWithDraw");
            ViewData["Amount"] = int.Parse(para.Value).ToString("n0");
            return View();
        }


        [ActionName("setWithDraw")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult setWithDrawNow(string Amount)
        {
            var para = db.Parameters.Single(p => p.Name == "MinWithDraw");
            Amount = Amount.Replace(",","");
            Amount = Amount.Replace(" ","");
            para.Value = Amount;
            db.SaveChanges();
            return View("SetWithDrawDone");
        }










        #region LE THANH DUNG

        public ActionResult CollectProcessing()
        {
            return View();
        }

        public ActionResult CollectedList()
        {
            return View();
        }

        public ActionResult ListAmount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListAmount(AdminListAmountViewModel obj)
        {
            return View();
        }

        public ActionResult EditStoreManager(int id)
        {
            return View();
        }

        public ActionResult EditStoreManager(StoreManagerViewModel obj)
        {
            return View();
        }

        public ActionResult RequestList()
        {
            return View();
        }

        public ActionResult BrowseStoreManager()
        {
            return View();
        }

        #endregion






    }
}
