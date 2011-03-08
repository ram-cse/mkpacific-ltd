using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merchant.Models;
using System.IO;
using System.Web.Routing;
using System.Configuration;

namespace Merchant.Controllers
{
    
    public class problemController : Controller
    {
        //
        // GET: /problem/
        public MPWebmasterEntities db = new MPWebmasterEntities();
        public IFormsAuthenticationService FormsService { get; set; }
        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }

            base.Initialize(requestContext);
        }


        [MPAccess(Roles = "Webmaster")]
        public ActionResult Index()
        {
            string userlogin = User.Identity.Name;
            var checkit = from c in db.Webmasters
                          where c.Username == userlogin
                          select c;
            if (checkit.Count() == 1)
            {
                var listproblem = from l in db.WebsiteOrders
                                  where ( (l.Status == 421 || l.Status == 422 || l.Status == 423) &&(l.Website.Webmaster.Username == userlogin))
                                  orderby l.Date descending
                                  select l;

                OrderNewViewModel model = new OrderNewViewModel() { list = listproblem.ToList() };
                TransactionLogViewModel.AddLog("Webmaster: "+userlogin+" has just gone to Problem Manager!", DateTime.Now);
                return View(model);
            }
            else
                return RedirectToAction("login", "Account");
        }
        [MPAccess(Roles = "ProblemUser")]
        public ActionResult submit()
        {
            TransactionLogViewModel.AddLog("Customer has just requested to submit the problem!", DateTime.Now);
            return View();

        }

        [HttpPost]
        [MPAccess(Roles = "ProblemUser")]
        public ActionResult submit(FormCollection form)
        {
            int reason=0;
            string description = "", buyingcode = "";

            buyingcode = User.Identity.Name;

            foreach (var key in form.AllKeys)
            {
               
                if (key == "description")
                    description = form[key];
                else if (key == "reason")
                    reason = int.Parse(form[key]);


            }
            if (buyingcode != "")
            {
                var buyer = from b in db.BuyCustomers
                            where b.BuyingId == buyingcode
                            select b;
                string lydoreport = "";
                if (reason == 421)
                {
                    lydoreport = "Delivery with low qulity";
                }
                else if (reason == 422)
                {
                    lydoreport = "Delivery broken";
                }
                else if (reason == 423)
                {
                    lydoreport = "Not delivery";
                }


                if (buyer.Count() == 1) // buyingcode ton tai
                {
                                       
                    //check order da duoc 20 ngay hay chua, sau 20 ngay order moi duocj report
                    var webordercheck = db.WebsiteOrders.Single(w=>w.BuyingId == buyingcode);

                    DateTime orderDate = webordercheck.Date;
                    if (orderDate.AddDays(20) < DateTime.Now && orderDate.AddDays(30) > DateTime.Now)
                    {

                        var weborder = db.WebsiteOrders.Single(w => w.BuyingId == buyingcode);
                        weborder.Status = reason;

                        //send email to webmaster
                        string emailcontent = "Hi!<br/><br/>";
                        emailcontent += "Your customer report the problem on the order.<br/><br/>";
                        emailcontent += "<b>BuyingID:</b>" + buyingcode + "<br/>";
                        emailcontent += "<b>Reason:</b> " + lydoreport + "<br/>";
                        emailcontent += "<b>Comment:</b>" + description + "<br/><br/>";
                        emailcontent += "See you on Money Pacific. Com";

                        var webmaster = db.Webmasters.Single(w => w.Id == weborder.Website.WebmasterId);

                        if (!string.IsNullOrEmpty(webmaster.NotificationNewProblem))
                        {
                            try
                            {
                                MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], webmaster.NotificationNewProblem, "", "", "Report Problem", emailcontent);
                            }
                            catch (Exception e)
                            { }

                        }
                        else
                            try
                            {
                                MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], webmaster.Email, "", "", "Report Problem", emailcontent);
                            }
                            catch (Exception e)
                            { }




                        Message m = new Message();
                        m.Message1 = description;
                        m.ToCustomer = true;
                        m.ToWebmaster = true;
                        m.IsClose = false;
                        if (reason == 423)
                        {
                            m.ToMPAdmin = true;
                        }
                        else
                            m.ToMPAdmin = false;
                        m.UserId = buyingcode;
                        m.DateSend = DateTime.Now;
                        m.Reason = lydoreport;
                        m.Sender = 0;//0 la customer, 1: webmaster, 2: money pacific


                        db.Messages.AddObject(m);

                        db.SaveChanges();

                        TransactionLogViewModel.AddLog("Customer: " + buyingcode + " has just submited the Problem FOR REASON: " + lydoreport + " successfully!", DateTime.Now);

                        return RedirectToAction("ReportDone");
                    }
                    else
                    {
                        TransactionLogViewModel.AddLog("Customer: " + buyingcode + " submited the problem FOR REASON: " + lydoreport + " BECAUSE: The Order not enough time to Report!  ", DateTime.Now);
                        return View("TimeNotAvailable");
                    }
                }
                else
                    return View("invalidBuyingCode");
            }

            return View();

        }
        [MPAccess(Roles = "ProblemUser")]
        public ActionResult ReportDone()
        {
            return View();
          
        }
       
        [MPAccess(Roles = "Webmaster, ProblemUser, Admin")]
        public ActionResult follow(string id)
        {
            var message = from p in db.Messages
                          where (p.UserId == id)
                          orderby p.DateSend descending
                          select p;

            MessageViewModel model = new MessageViewModel() { msgList = message.ToList() };
            ViewData["code"] = id;

            var checkStatus = db.WebsiteOrders.Single(m => m.BuyingId == id);
            ViewData["status"] = checkStatus.Status;
            TransactionLogViewModel.AddLog(User.Identity.Name +" has just followed the Order: "+id , DateTime.Now);
            return View(model);
            
           
            
           
        }

        [MPAccess(Roles = "Webmaster, ProblemUser, Admin")]
        public ActionResult postmessage(string message, string buyingcode, string[] webmaster, string[] moneypacific, string[] customer)
        {
            string userlogin = User.Identity.Name;

            var checkit1 = from c in db.BuyCustomers
                           where c.BuyingId == userlogin
                           select c;

            var checkit2 = from b in db.Webmasters
                           where b.Username == userlogin
                           select b;
            var checkit3 = from a in db.MPAdmins
                           where a.Username == userlogin
                           select a;


            if (!string.IsNullOrEmpty(message))
            {
                Message p = new Message();
                HttpPostedFileBase _file = Request.Files["file"];
                if (_file.FileName != "")
                {
                    if (_file.ContentLength > 0)
                    {
                        string filename = _file.FileName.Replace(" ", "_");
                        string filePath = Path.Combine(HttpContext.Server.MapPath("/Content/File/"), Path.GetFileName(filename));

                        _file.SaveAs(filePath);

                        p.AttachFile = "/Content/File/" + _file.FileName.Replace(" ", "_");

                    }

                }
                p.Message1 = message;
                WebsiteOrder weborder = new WebsiteOrder();
                Webmaster master = new Webmaster();

                if (checkit1.Count() == 1)
                {
                    p.Sender = 0; // Khach hang post
                    //gui email cho webmaster.
                    weborder = db.WebsiteOrders.Single(w => w.BuyingId == buyingcode);
                    master = db.Webmasters.Single(w=>w.Id == weborder.Website.WebmasterId);
                    
                    //send email to webmaster
                    string emailcontent = "Hi!<br/><br/>";
                    emailcontent += "The customer sent you the message.<br/><br/>";
                    emailcontent += "<b>Content:</b>"+message+"<br/><br/>";
                    emailcontent += "See you on Money Pacific. Com";

                    

                    if (!string.IsNullOrEmpty(master.NotificationNewMessage))
                    {
                        try
                        {
                            MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], master.NotificationNewMessage, "", "", "New Message from Customer", emailcontent);
                        }
                        catch (Exception e)
                        { }

                    }
                    else
                        try
                        {
                            MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], master.Email, "", "", "New Message from Customer", emailcontent);
                        }
                        catch (Exception e)
                        { }





                }
                else if (checkit2.Count() == 1)
                {
                    p.Sender = 1;// webmaster post

                }
                else if (checkit3.Count() == 1)//admin post
                {
                    p.Sender = 2;
 
                }
                
                p.DateSend = DateTime.Now;

                p.UserId = buyingcode;
                p.IsClose = false;
                string postTo = "";
                if (customer != null)
                {
                    p.ToCustomer = true;
                    postTo = buyingcode+" ";
                }
                else
                {
                    p.ToCustomer = false;
                   
                }
                if (webmaster != null)
                {
                    p.ToWebmaster = true;
                    postTo += master.Username + " ";

                    
                }
                else p.ToWebmaster = false;

                if (moneypacific != null)
                {
                    p.ToMPAdmin = true;
                    postTo += "Money Pacific Admin";
                }
                else
                    p.ToMPAdmin = false;



                db.Messages.AddObject(p);
                db.SaveChanges();
               

                TransactionLogViewModel.AddLog(userlogin +" has just posted the message to:"+postTo+" on Pacific Manager!", DateTime.Now);

            }
          
            return RedirectToAction("follow", new { id=buyingcode});

 
        }

        public ActionResult only423()
        {
            string userlogin = User.Identity.Name;

            var list423 = from l in db.WebsiteOrders
                          where ((l.Status == 423) && (l.Website.Webmaster.Username == userlogin))
                          select l;
            return View(list423.ToList());
 
        }
      

        
        


    }
}