using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Merchant.Models;
using System.Configuration;

namespace Merchant.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {
        public MPWebmasterEntities StoreDb = new MPWebmasterEntities(); 

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                int check = MembershipService.ValidateUser(model.UserName, model.Password);

                if (check == 1 || check == 3 || check==4)//login thanh cong
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);

                    if(check == 1) // truong hop webmaster login
                    {
                        //if (!String.IsNullOrEmpty(returnUrl))// tra lai url truoc khi login
                        //{
                        //    return Redirect(returnUrl);
                        //}
                        //else 
                            return RedirectToAction("Index", "Account");
                    }
                    else if (check == 3)// truong hop Customer login
                    {
                       
                        return RedirectToAction("Index", "Customer");
 
                    }
                    else if (check == 4)
                    {
                        return RedirectToAction("Index","Admin");
                    }

                }

                else if(check == 0) // username va password khong dung.
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
                else if(check == 2) //account chua duoc active
                {
                    ModelState.AddModelError("","Your account is not active! Please check email to active account!");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        public ActionResult logout()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
            
        }

        [MPAccess(Roles = "Webmaster")]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [MPAccess(Roles = "Webmaster")]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

       

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }




        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>


        public ActionResult Register()
        {
            return View();
        }

        public ActionResult pRegister()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }
        [HttpPost]
        public ActionResult pRegister(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.pCreateUser(model.Name, model.UserName, model.Password, model.Email, model.Phone);

                if (createStatus == MembershipCreateStatus.Success)
                {
                   // FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    var check = StoreDb.Webmasters.Single(m=>m.Username == model.UserName && m.Email == model.Email && m.Status == 0);
                    string hash = check.VerifyCode;
                    
                    // gui email cho khach hang
                    string emailContent="Welcome to Money Pacific!!!<br/><br/>";
                    emailContent += "You've just open account with Money Pacific! <br/><br/>";
                    emailContent += "<b>UserName: </b>"+model.UserName+"<br/>";
                    emailContent += "<b>Password: </b> Your password as you register.<br/><br/>";
                    emailContent += "To active your account, Please click on the link below:<br/><br/>";
                    emailContent += ConfigurationManager.AppSettings["URL"]+"/Account/Active/"+hash+"<br/><br/>";

                    string from = ConfigurationManager.AppSettings["MailSender"].ToString();

                    MPMail.SendMail(from, model.Email, "", "", "Money Pacific - Active Your Account!", emailContent);


                    return RedirectToAction("RegisterSuccess");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }
        public ActionResult bRegister()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }
        
        [HttpPost]
        public ActionResult bRegister(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.bCreateUser(model.CompanyName, model.UserName, model.Password, model.Email, model.TaxCode, model.Phone);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    // FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    var check = StoreDb.Webmasters.Single(m => m.Username == model.UserName && m.Email == model.Email && m.Status == 0);
                    string hash = check.VerifyCode;

                    string emailContent = "Welcome to Money Pacific!!!<br/><br/>";
                    emailContent += "You've just open account with Money Pacific! <br/><br/>";
                    emailContent += "<b>UserName: </b>" + model.UserName + "<br/>";
                    emailContent += "<b>Password: </b> Your password as you register.<br/><br/>";
                    emailContent += "To active your account, Please click on the link below:<br/><br/>";
                    emailContent += ConfigurationManager.AppSettings["URL"] + "/Account/Active/" + hash + "<br/><br/>";

                    string from = ConfigurationManager.AppSettings["MailSender"].ToString();

                    MPMail.SendMail(from, model.Email, "", "", "Money Pacific - Active Your Account!", emailContent);


                    return RedirectToAction("RegisterSuccess");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }
        

        public ActionResult RegisterSuccess()
        {
            return View();

        }
        public ActionResult Active(string id)
        {
            var check = from m in StoreDb.Webmasters
                        where (m.VerifyCode == id)
                        select m;
            if (check.Count() == 1)
            {
                if (check.SingleOrDefault().Status == 0)
                {
                    check.SingleOrDefault().Status = 1;
                    StoreDb.SaveChanges();
                    ViewData["message"] = "Account is active now! Click to <a href=\"/Account/login\">LOGIN NOW</a>";
                }
                else
                    ViewData["message"] = "Account is already active now!";

            }
            else
            {
                ViewData["message"] = "Account doesn't exist now! Check again!";

            }
            return View();
        }
        [MPAccess(Roles = "Webmaster")]
        public ActionResult Profile()
        {
            string IdLogin = User.Identity.Name;
            var check = StoreDb.Webmasters.Single(m=>m.Username == IdLogin);
            int accType = int.Parse(check.AccountType.ToString());

            if (accType == 0) // personal account
            {
                RegisterModel model = new RegisterModel() { 
                UserName = check.Username,
                Name = check.Name,
                Email = check.Email,
                Phone = check.Phone,
                City = check.City,
                ATM = check.ATM,
                Bank = check.Bank,
                Street = check.Street,
                Ward = check.Ward,
                AccountType =accType,
             };

                return View(model);
            }
            else { // bussiness account

                RegisterModel model = new RegisterModel()
                {
                    UserName = check.Username,
                    Name = check.CompanyName,
                    CompanyName = check.CompanyName,
                    TaxCode = check.TaxCode,
                    AccountType = accType,
                    Email = check.Email,
                    Phone = check.Phone,
                    City = check.City,
                    ATM = check.ATM,
                    Bank = check.Bank,
                    Street = check.Street,
                    Ward = check.Ward,
                };

                return View(model);
            }

            //return View();
        }

        [HttpPost]
        [MPAccess(Roles = "Webmaster")]
        public ActionResult profile(FormCollection form)
        {
            try
            {
                // TODO: Add update logic here
                string idlogin = User.Identity.Name;
                var webmaster = StoreDb.Webmasters.Single(m=>m.Username == idlogin);

                if (webmaster.AccountType == 0)
                {
                    foreach (var key in form.AllKeys)
                    {
                       if (key == "Name")
                            webmaster.Name = form[key];

                       if (key == "Email")
                           webmaster.Email = form[key];

                       if (key == "Phone")
                           webmaster.Phone = form[key];

                       if (key == "Street")
                           webmaster.Street = form[key];

                       if (key == "Ward")
                           webmaster.Ward = form[key];

                       if (key == "City")
                           webmaster.City = form[key];

                       if (key == "ATM")
                           webmaster.ATM = form[key];

                       if (key == "Bank")
                           webmaster.Bank = form[key];

                     
                    }
                    StoreDb.SaveChanges();

                }
                else
                {
                    foreach (var key in form.AllKeys)
                    {
                        if (key == "Name")
                            webmaster.Name = form[key];

                        if (key == "CompanyName")
                            webmaster.CompanyName = form[key];
                        if (key == "TaxCode")
                            webmaster.TaxCode = form[key];

                        if (key == "Email")
                            webmaster.Email = form[key];

                        if (key == "Phone")
                            webmaster.Phone = form[key];

                        if (key == "Street")
                            webmaster.Street = form[key];

                        if (key == "Ward")
                            webmaster.Ward = form[key];

                        if (key == "City")
                            webmaster.City = form[key];

                        if (key == "ATM")
                            webmaster.ATM = form[key];

                        if (key == "Bank")
                            webmaster.Bank = form[key];


                    }
                    StoreDb.SaveChanges();

                }

                return RedirectToAction("profile");
            }
            catch
            {
                return View();
            }

        }
        [MPAccess(Roles = "Webmaster")]
        public ActionResult setPayment()
        {
            try {
                var pay = StoreDb.Payments.Single(m => m.Webmaster.Username == User.Identity.Name);
                return View(pay);
                
            }
            catch(Exception e){
                Payment p = new Payment();
                return View(p);
            };
            
            

        }
        [HttpPost]
        [MPAccess(Roles = "Webmaster")]
        public ActionResult setPayment(FormCollection form)
        {
            var checkit = StoreDb.Webmasters.Single(m=>m.Username == User.Identity.Name);

            try
            {
                // TRUONG HOP DA SET RUI THI UPDATE
                var pay = StoreDb.Payments.Single(m => m.WebmasterId == checkit.Id );

                foreach (var key in form.AllKeys)
                {
                    if (key == "Name")
                        pay.Name = form[key];
                    if (key == "Email")
                        pay.Email = form[key];
                    if (key == "Phone")
                        pay.Phone = form[key];
                    if (key == "City")
                        pay.City = form[key];
                    if (key == "Ward")
                        pay.Ward = form[key];
                    if (key == "Address")
                        pay.Address = form[key];

                    if (key == "type")
                    {
                        pay.TypePayment = int.Parse(form[key]);
                    }
                }
                StoreDb.SaveChanges();
                return RedirectToAction("setpayment");

            }
            catch (Exception e)
            {
                Payment p = new Payment();

                foreach (var key in form.AllKeys)
                {
                    if (key == "Name")
                        p.Name = form[key];
                    if (key == "Email")
                        p.Email = form[key];
                    if (key == "Phone")
                        p.Phone = form[key];
                    if (key == "City")
                        p.City = form[key];
                    if (key == "Ward")
                        p.Ward = form[key];
                    if (key == "Address")
                        p.Address = form[key];

                    if (key == "type")
                    {
                        p.TypePayment = int.Parse(form[key]);
                    }
                }
                p.WebmasterId = checkit.Id;

                StoreDb.Payments.AddObject(p);
                StoreDb.SaveChanges();
                return RedirectToAction("setpayment");

            }
     
        }
        [MPAccess(Roles="Webmaster, Admin")]
        public ActionResult Index()
        {
            Webmaster webmaster = new Webmaster();
            string loginId = User.Identity.Name;
            webmaster = StoreDb.Webmasters.Single(w => w.Username == loginId);
            

            var earning = StoreDb.Earnings.Single(e => e.WebmasterId == webmaster.Id);

            

           var website = from w in StoreDb.Websites
                         where (w.Webmaster.Username == loginId)
                         select w;

            List<WebsiteOrder> list = new List<WebsiteOrder>();
            foreach (var x in website)
            {
                var oder = from o in StoreDb.WebsiteOrders
                           where (o.WebsiteId == x.Id)
                           orderby o.Date descending
                           select o;
                foreach (var oo in oder)
                {
                    if (oo.Date.AddDays(30) <= DateTime.Today && (oo.Status == 411 || oo.Status==412 ))//order sau 30 ngay se tu dong them ket thuc
                    {                                               // va + tien cho webmaster
                        oo.Status = 413;
                        earning.Amount += oo.Amount;
                        oo.MoneyStatus = 1;// money is available for webmaster
                        oo.Date = oo.Date.AddDays(30);
                    }
                    
                    list.Add(oo);
                }
            }
            StoreDb.SaveChanges();

            ViewData["AccountType"] = webmaster.AccountType;
            ViewData["Name"] = webmaster.Name;
            
            var earningNew = StoreDb.Earnings.Single(e => e.WebmasterId == webmaster.Id);

            ViewData["Earning"] = earningNew.Amount.ToString("n0");
            ViewData["Currency"] = earning.Currency;



            AccountIndexViewModel model = new AccountIndexViewModel() { listOrder = list };

            return View(model);
        }
        [MPAccess(Roles="Webmaster")]
        public ActionResult notification()
        {
            var webmaster = StoreDb.Webmasters.Single(w => w.Username == User.Identity.Name);
            return View(webmaster);
        }
        [MPAccess(Roles = "Webmaster")]
        [HttpPost]
        public ActionResult notification(FormCollection form)
        {
            string NewOrderEmail="",NewMessageEmail="",NewProblemEmail="";
            foreach (var key in form.AllKeys)
            {
                if (key == "notificationNewOrder")
                {
                    if (form[key] != "")
                        NewOrderEmail = form[key];
                }
                else if (key == "notificationNewMessage")
                {
                    if (form[key] != "")
                        NewMessageEmail = form[key];
                }
                else if (key == "notificationNewProblem")
                {
                    if (form[key] != "")
                        NewProblemEmail = form[key];
                }
            }
            var webmaster = StoreDb.Webmasters.Single(w=>w.Username == User.Identity.Name);
            webmaster.NotificationNewOrder = NewOrderEmail;
            webmaster.NotificationNewMessage = NewMessageEmail;
            webmaster.NotificationNewProblem = NewProblemEmail;

            StoreDb.SaveChanges();


            return RedirectToAction("Index");
        }


        

        




    }
}
