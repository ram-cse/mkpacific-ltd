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
using Merchant.Helper;
//using MoneyPacificSite.Helpers;
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult login(LogOnModel model, string returnUrl)
        {

            LangText.Load(model.UserName);

            if (ModelState.IsValid)
            {
                string HashPassword = MPHash.GetPassWordMD5Hash(model.Password);
                //hash password

                int check = MembershipService.ValidateUser(model.UserName, HashPassword);

                if (check == 1 || check == 3 || check==4)//login thanh cong
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);

                    TransactionLogViewModel.AddLog(model.UserName + " has just login succesffully!",DateTime.Now);
                    
                   

                    if(check == 1) // truong hop webmaster login
                    {
                        
                        return View("redirectWebmaster");
                       
                    }
                    else if (check == 3)// truong hop Customer login
                    {
                       return View("redirectCustomer");
 
                    }
                    else if (check == 4)
                    {
                        return View("redirectAdmin");
                    }

                }

                else if(check == 0) // username va password khong dung.
                {
                    TransactionLogViewModel.AddLog(model.UserName + " login with incorrect username or password!", DateTime.Now);

                    ModelState.AddModelError("", LangText.GetText("THE_USER_NAME_OR_PASSWORD_PROVIDED_IS_INCORRECT"));
                }
                else if(check == 2) //account chua duoc active
                {
                    TransactionLogViewModel.AddLog(model.UserName + " has login with inactive account!", DateTime.Now);

                    ModelState.AddModelError("", LangText.GetText("YOUR_ACCOUNT_IS_NOT_ACTIVE!_PLEASE_CHECK_EMAIL_TO_ACTIVE_ACCOUNT"));
                }
                else if (check == 5)// account da bi Disable
                {
                    TransactionLogViewModel.AddLog(model.UserName + " has login with account is disabled by Money Pacific Admin!", DateTime.Now);
                    ModelState.AddModelError("", LangText.GetText("YOUR_ACCOUNT_IS_DISABLED_BY_MONEY_PACIFIC_ADMIN"));
                }
            }
            

            // If we got this far, something failed, redisplay form

            return View(model);
        }


        public ActionResult logout()
        {
            FormsService.SignOut();

            TransactionLogViewModel.AddLog(User.Identity.Name + " has logout successfully!", DateTime.Now);

            return RedirectToAction("Index", "vi");
            
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
                string HashPassword = MPHash.GetPassWordMD5Hash(model.OldPassword);
                //hash password
                string HashNewPassword = MPHash.GetPassWordMD5Hash(model.NewPassword);


                if (MembershipService.ChangePassword(User.Identity.Name, HashPassword, HashNewPassword))
                {
                    TransactionLogViewModel.AddLog(User.Identity.Name + " has changed the password successfully!", DateTime.Now);

                    return RedirectToAction("ChangePasswordSuccess", "Account");
                }
                else
                {
                    TransactionLogViewModel.AddLog(User.Identity.Name + " change the password unsuccessfully", DateTime.Now);
                    ModelState.AddModelError("", LangText.GetText("THE_CURRENT_PASSWORD_IS_INCORRECT_OR_THE_NEW_PASSWORD_IS_INVALID"));
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
                string HashPassword = MPHash.GetPassWordMD5Hash(model.Password);
                //hash password

                MembershipCreateStatus createStatus = MembershipService.pCreateUser(model.FirstName, model.LastName, model.UserName, HashPassword, model.Email, model.Phone);

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

                    TransactionLogViewModel.AddLog(model.FirstName +" "+ model.LastName +"has just registered as Webmaster with the email "+model.Email, DateTime.Now);

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
                string HashPassword = MPHash.GetPassWordMD5Hash(model.Password);
                //hash password

                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.bCreateUser(model.CompanyName, model.UserName, HashPassword, model.Email, model.TaxCode, model.Phone);

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

                    TransactionLogViewModel.AddLog(model.FirstName +" "+ model.LastName + "has just registered as Webmaster with the email " + model.Email, DateTime.Now);

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
            LangText.Load(User.Identity.Name);

            var check = from m in StoreDb.Webmasters
                        where (m.VerifyCode == id)
                        select m;
            if (check.Count() == 1)
            {
                if (check.SingleOrDefault().Status == 0)
                {
                    check.SingleOrDefault().Status = 1;
                    StoreDb.SaveChanges();
                    TransactionLogViewModel.AddLog(check.SingleOrDefault().Username+" has just active account successfully!", DateTime.Now);
                    ViewData["message"] = LangText.GetText("ACCOUNT_IS_ACTIVE_NOW!_CLICK_TO_LOGIN");
                }
                else
                    ViewData["message"] = LangText.GetText("ACCOUNT_IS_ALREADY_ACTIVE_NOW!");

            }
            else
            {
                ViewData["message"] = LangText.GetText("ACCOUNT_DOESNT_EXIST_NOW!_CHECK_AGAIN!");

            }
            return View();
        }
        [MPAccess(Roles = "Webmaster")]
        public ActionResult Profile()
        {
            string IdLogin = User.Identity.Name;
            var check = StoreDb.Webmasters.Single(m=>m.Username == IdLogin);
            int accType = int.Parse(check.AccountType.ToString());

            var country = StoreDb.Parameters.Single(s=>s.Name == "Country");

            if (accType == 0) // personal account
            {
                RegisterModel model = new RegisterModel() { 
                UserName = check.Username,
                FirstName = check.FirstName,
                LastName = check.LastName,
                Email = check.Email,
                Phone = check.Phone,
                City = check.City,
                ATM = check.ATM,
                Bank = check.Bank,
                Address1 = check.Address1,
                Address2 = check.Address2,
                State = check.State,
                Country = country.Value,
                ZipCode = check.ZipCode,
                AccountType =accType,
             };
             TransactionLogViewModel.AddLog(IdLogin + " view the profile!", DateTime.Now);
             ViewData["Country"] = country.Value;

            return View(model);
            }
            else { // bussiness account

                RegisterModel model = new RegisterModel()
                {
                    UserName = check.Username,
                    FirstName = check.CompanyName,
                    CompanyName = check.CompanyName,
                    TaxCode = check.TaxCode,
                    AccountType = accType,
                    Email = check.Email,
                    Phone = check.Phone,
                    City = check.City,
                    ATM = check.ATM,
                    Bank = check.Bank,
                    Address1 = check.Address1,
                    Address2 = check.Address2,
                    ZipCode = check.ZipCode,
                    State = check.State,
                    Country = country.Value

                };
                TransactionLogViewModel.AddLog(IdLogin + " view the profile!", DateTime.Now);
                ViewData["Country"] = country.Value;

                return View(model);
            }

            //return View();
        }

        [HttpPost]
        [MPAccess(Roles = "Webmaster")]
        public ActionResult profile(FormCollection form)
        {
            var country = StoreDb.Parameters.Single(s => s.Name == "Country");
            try
            {
                // TODO: Add update logic here
                string idlogin = User.Identity.Name;
                var webmaster = StoreDb.Webmasters.Single(m=>m.Username == idlogin);
                
                

                if (webmaster.AccountType == 0)
                {
                    foreach (var key in form.AllKeys)
                    {
                        if (key == "FirstName")
                            webmaster.FirstName = form[key];

                        else if (key == "LastName")
                            webmaster.LastName = form[key];

                        else if (key == "Email")
                            webmaster.Email = form[key];

                        else if (key == "Phone")
                            webmaster.Phone = form[key];

                        else if (key == "Address1")
                            webmaster.Address1 = form[key];
                        else if (key == "Address2")
                            webmaster.Address2 = form[key];
                        else if (key == "ZipCode")
                            webmaster.ZipCode = form[key];

                        else if (key == "ZipCode")
                            webmaster.ZipCode = form[key];

                        else if (key == "City")
                            webmaster.City = form[key];

                        else if (key == "ATM")
                            webmaster.ATM = form[key];

                        else if (key == "Bank")
                            webmaster.Bank = form[key];

                        else if (key == "State")
                            webmaster.State = form[key];

                        
                        webmaster.Country = country.Value;

                     
                    }
                    StoreDb.SaveChanges();

                    TransactionLogViewModel.AddLog(idlogin + " has just save/update the profile!", DateTime.Now);
                    return RedirectToAction("profile");

                }
                else
                {
                    foreach (var key in form.AllKeys)
                    {

                        if (key == "CompanyName")
                        {

                            webmaster.CompanyName = form[key];
                            webmaster.FirstName = webmaster.CompanyName;
                            webmaster.LastName = webmaster.CompanyName;
                        }

                        if (key == "TaxCode")
                            webmaster.TaxCode = form[key];

                        if (key == "Email")
                            webmaster.Email = form[key];

                        if (key == "Phone")
                            webmaster.Phone = form[key];

                        if (key == "Address1")
                            webmaster.Address1 = form[key];
                        if (key == "Address2")
                            webmaster.Address2 = form[key]; 

                        if (key == "ZipCode")
                            webmaster.ZipCode = form[key];

                        if (key == "City")
                            webmaster.City = form[key];

                        if (key == "ATM")
                            webmaster.ATM = form[key];

                        if (key == "Bank")
                            webmaster.Bank = form[key];

                        if (key == "State")
                            webmaster.State = form[key];

                        webmaster.Country = country.Value;

                    }


                    StoreDb.SaveChanges();

                    TransactionLogViewModel.AddLog(idlogin + " has just save/update the profile!", DateTime.Now);
                    return RedirectToAction("profile");

                }

            }
            catch
            {
                return RedirectToAction("profile");
            }

        }
        [MPAccess(Roles = "Webmaster")]
        public ActionResult setPayment()
        {
            var country = StoreDb.Parameters.Single(s=>s.Name == "Country");

            try {
                var pay = StoreDb.Payments.Single(m => m.Webmaster.Username == User.Identity.Name);
                TransactionLogViewModel.AddLog(User.Identity.Name + " has just save/update the setPayment!", DateTime.Now);
                ViewData["ATM"] = pay.Webmaster.ATM;
                ViewData["Bank"] = pay.Webmaster.Bank;
                ViewData["Country"] = country.Value;
                return View(pay);
                
            }
            catch(Exception e){
                Payment p = new Payment();
                TransactionLogViewModel.AddLog(User.Identity.Name + " has just save/update the setPayment!", DateTime.Now);
                ViewData["ATM"] = "";
                ViewData["Bank"] = "";
                ViewData["Country"] = country.Value;
                return View(p);
            };
            
            

        }
        [HttpPost]
        [MPAccess(Roles = "Webmaster")]
        public ActionResult setPayment(FormCollection form)
        {
            var checkit = StoreDb.Webmasters.Single(m=>m.Username == User.Identity.Name);
            string bank = "";
            string atm = "";
            try
            {
                // TRUONG HOP DA SET RUI THI UPDATE
                var pay = StoreDb.Payments.Single(m => m.WebmasterId == checkit.Id );

                foreach (var key in form.AllKeys)
                {
                    if (key == "Name")
                        pay.Name = form[key];
                    else if (key == "Email")
                        pay.Email = form[key];
                    else if (key == "Phone")
                        pay.Phone = form[key];
                    else if (key == "City")
                        pay.City = form[key];
                    else if (key == "Ward")
                        pay.Ward = form[key];
                    else if (key == "Address")
                        pay.Address = form[key];

                    else if (key == "type")
                    {
                        pay.TypePayment = int.Parse(form[key]);
                    }
                    else if (key == "Bank")
                        bank = form[key];
                    else if (key == "ATM")
                        atm = form[key];
                    else if (key == "ZipCode")
                        pay.ZipCode = form[key];
                    else if (key == "Country")
                        pay.Country = form[key];


                }
                var webmaster = StoreDb.Webmasters.Single(w=>w.Username == User.Identity.Name);
                webmaster.ATM = atm;
                webmaster.Bank = bank;

                StoreDb.SaveChanges();
                TransactionLogViewModel.AddLog(User.Identity.Name + " has just save/update the setPaymen successfullyt!", DateTime.Now);
                return View("SetPaymentDone");

            }
            catch (Exception e)
            {
                Payment p = new Payment();

                foreach (var key in form.AllKeys)
                {
                    if (key == "Name")
                        p.Name = form[key];
                    else if (key == "Email")
                        p.Email = form[key];
                    else if (key == "Phone")
                        p.Phone = form[key];
                    else if (key == "City")
                        p.City = form[key];
                    else if (key == "Ward")
                        p.Ward = form[key];
                    else if (key == "Address")
                        p.Address = form[key];

                    else if (key == "type")
                    {
                        p.TypePayment = int.Parse(form[key]);
                    }
                    else if (key == "Bank")
                        bank = form[key];
                    else if (key == "ATM")
                        atm = form[key];
                    else if (key == "ZipCode")
                        p.ZipCode = form[key];
                    else if (key == "Country")
                        p.Country = form[key];

                }
                p.WebmasterId = checkit.Id;

                var webmaster = StoreDb.Webmasters.Single(w => w.Username == User.Identity.Name);
                webmaster.ATM = atm;
                webmaster.Bank = bank;


                StoreDb.Payments.AddObject(p);
                StoreDb.SaveChanges();
                TransactionLogViewModel.AddLog(User.Identity.Name + " has just save/update the setPaymen successfully!", DateTime.Now);
                return View("SetPaymentDone");

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

           int total411 = 0, total412 = 0, total413 = 0, total423 = 0, total42x = 0;
           int number411  =0, number412 = 0, number413 = 0 , number423 = 0, number42x = 0;

           List<WebsiteOrder> list = new List<WebsiteOrder>();
            foreach (var x in website)
            {
                var oder = from o in StoreDb.WebsiteOrders
                           where (o.WebsiteId == x.Id)
                           orderby o.Date descending
                           select o;
                foreach (var oo in oder)
                {
                    //truong hop sau 30 ngay ma khong co problem
                    if (oo.Date.AddDays(30) <= DateTime.Today && (oo.Status == 411 || oo.Status==412 ) && oo.MoneyStatus == 0)//order sau 30 ngay se tu dong them ket thuc
                    {                                               // va + tien cho webmaster
                        oo.Status = 413;
                        earning.Amount += oo.Amount;
                        oo.MoneyStatus = 1;// money is available for webmaster
                        oo.Date = oo.Date.AddDays(30);
                    }
                        //truong hop amin data validate the proof
                    else if (oo.Status == 432 && oo.MoneyStatus == 0)//admin da validate the proof
                    {
                        oo.MoneyStatus = 1;
                        earning.Amount += oo.Amount;
                    }

                    //count the account and number
                    if (oo.Status == 411)
                    {
                        total411 += oo.Amount;
                        number411++;
                    }
                    if (oo.Status == 412)
                    {
                        total412 += oo.Amount;
                        number412++;
                    }
                    if (oo.Status == 413)
                    {
                        total413 += oo.Amount;
                        number413++;
                    }
                    if (oo.Status == 423)
                    {
                        total423 += oo.Amount;
                        number423++;
                    }
                    if (oo.Status == 421 || oo.Status == 422)
                    {
                        total42x += oo.Amount;
                        number42x++;
                    }

                   
                    list.Add(oo);//
                   
                    
                }
            }
            StoreDb.SaveChanges();
        
            var earningNew = StoreDb.Earnings.Single(e => e.WebmasterId == webmaster.Id);

            ViewData["Earning"] = earningNew.Amount.ToString("n0");
            ViewData["Currency"] = earning.Currency;


            TransactionLogViewModel.AddLog(loginId + " view the the Dashboard!", DateTime.Now);

            ViewData["total411"] = total411.ToString("n0");
            ViewData["total412"] = total412.ToString("n0");
            ViewData["total413"] = total413.ToString("n0");
            ViewData["total423"] = total423.ToString("n0");
            ViewData["total42x"] = total42x.ToString("n0");

            ViewData["number411"] = number411;
            ViewData["number412"] = number412;
            ViewData["number413"] = number413;
            ViewData["number423"] = number423;
            ViewData["number42x"] = number42x;

            DateTime today = DateTime.Now.Date;
            DateTime FirtDateofMonth = HtmlHelpers.GetFirstDayOfMonth(DateTime.Today);
            DateTime LastDateofMonth = HtmlHelpers.GetTheLastDayOfMonth(DateTime.Today);
            DateTime FirstDateofLastMonth = HtmlHelpers.GetFirstDayOfMonth(today.AddMonths(-1));
            DateTime LastDateofLastMonth = HtmlHelpers.GetTheLastDayOfMonth(today.AddMonths(-1));

            DateTime FirstDateofYear = new DateTime(today.Year,1,1);
            DateTime LastDateofYear = new DateTime(today.Year,12,31);

            int todayearning = 0, yesterdayearning = 0, thismonthearning = 0, lastmonthearning = 0, thisyearearning = 0;

            foreach (var order in list)
            {
                if (order.Date == today)
                {
                    todayearning += order.Amount;
                }

                if (order.Date == today.AddDays(-1))
                {
                    yesterdayearning += order.Amount;
                }
                if (order.Date >= FirtDateofMonth && order.Date <= LastDateofMonth)
                {
                    thismonthearning += order.Amount;

                }
                if (order.Date >= FirstDateofLastMonth && order.Date <= LastDateofLastMonth)
                {
                    lastmonthearning += order.Amount;
                }
                if (order.Date >= FirstDateofYear && order.Date <= LastDateofYear)
                {
                    thisyearearning += order.Amount;
                }
                    
                
                

            }
            ViewData["todayearning"] = todayearning.ToString("n0");
            ViewData["yesterdayearning"] = yesterdayearning.ToString("n0");
            ViewData["thismonthearning"] = thismonthearning.ToString("n0");
            ViewData["lastmonthearning"] = lastmonthearning.ToString("n0");
            ViewData["thisyearearning"] = thisyearearning.ToString("n0");

            var phonenumber = StoreDb.Parameters.Single(s => s.Name == "PhoneNumber").Value;
            ViewData["phone"] = phonenumber.ToString();


            return View();
        }
        [MPAccess(Roles="Webmaster")]
        public ActionResult notification()
        {
            var webmaster = StoreDb.Webmasters.Single(w => w.Username == User.Identity.Name);
            TransactionLogViewModel.AddLog(User.Identity.Name + " set the notification", DateTime.Now);
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
            TransactionLogViewModel.AddLog(User.Identity.Name + " save/update the notification", DateTime.Now);

            return View("notificationDone");
        }
        

        //forgot the password

        public ActionResult forgotpw()
        {
            return View();
        }

        public ActionResult recoverUsername(string username)
        {
            //truong hop webmaster quen mat khau
            var checkit = from c in StoreDb.Webmasters
                          where c.Username == username && c.Status == 1 //account phai duoc active moi cho recovery password
                          select c;


            //truong hop Buyer quen mat khau
            var checkit2 = from c2 in StoreDb.BuyCustomers
                           where c2.BuyingId == username
                           select c2;

            if (checkit.Any()) // account ton tai
            {
                // gui email cho webmaster
                string link = ConfigurationManager.AppSettings["URL"]+"/account/recover/"+checkit.FirstOrDefault().VerifyCode;
                string mailcontent = "Hello!<br/><br/>";
                mailcontent += "Please click on the link to get new password <br/><br/>";
                mailcontent += link+"<br/><br/>";
                mailcontent += "See you on Money Pacific";

                try {
                    MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], checkit.FirstOrDefault().Email, "", "", "Password Recovery", mailcontent);
                }
                catch (Exception)
                { }
                TransactionLogViewModel.AddLog(username + " has just recovery the password by Username!", DateTime.Now);
                return View("recovery");
            }
            else if (checkit2.Any())
            {
                string mailcontent = "Hello!<br/><br/>";
                mailcontent += "Your Username and Password: <b>"+ username+"</b><br/><br/>";

                mailcontent += "See you on Money Pacific";
                try {
                    MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], checkit2.FirstOrDefault().Email, "", "", "Password Recovery", mailcontent);
                }
                catch (Exception)
                { }

                TransactionLogViewModel.AddLog(username + " has just requested to recovery the password by Username!", DateTime.Now);
                return View("recovery");
 
            }
            else 
                return View("UserNotExist");
 
        }

        public ActionResult recoverEmail(string email)
        {
            //truong hop webmaster quen mat khau
            var checkit = from c in StoreDb.Webmasters
                          where c.Email == email && c.Status == 1 //account phai duoc active moi cho recovery password
                          select c;


            //truong hop Buyer quen mat khau
            var checkit2 = from c2 in StoreDb.BuyCustomers
                           where c2.Email == email
                           select c2;

            if (checkit.Any()) // account ton tai
            {
                // gui email cho webmaster
                string link = ConfigurationManager.AppSettings["URL"] + "/account/recover/" + checkit.FirstOrDefault().VerifyCode;
                string mailcontent = "Hello!<br/><br/>";
                mailcontent += "Please click on the link to get new password <br/><br/>";
                mailcontent += link + "<br/><br/>";
                mailcontent += "See you on Money Pacific";

                try
                {
                    MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], checkit.FirstOrDefault().Email, "", "", "Password Recovery", mailcontent);
                }
                catch (Exception)
                { }
                TransactionLogViewModel.AddLog(email + " has just requested to recovery the password by Username!", DateTime.Now);
                
                return View("recovery");
            }
            
            else
                return View("UserNotExist");
        }

        public ActionResult recover(string id)
        {
            var checkit = from w in StoreDb.Webmasters
                          where w.VerifyCode == id
                          select w;
            if (checkit.Any())
            {
                ViewData["key"] = id;
                TransactionLogViewModel.AddLog(checkit.SingleOrDefault().Username + " has just clicked on the link to recovery the password successfully!", DateTime.Now);
                return View();
            }
            else 
                return View("brokenlink");

        }
        [HttpPost]
        public ActionResult recover(FormCollection form)
        {
            string newpass = "";
            string id = "";
            foreach (var key in form.AllKeys)
            {
                if (key == "newpass")
                {
                    newpass = form[key];
                }
                else if (key == "hash")
                {
                    id=form[key];
                }
            }
            var check = StoreDb.Webmasters.Single(w=>w.VerifyCode == id);
            check.Password = MPHash.GetPassWordMD5Hash(newpass);
            StoreDb.SaveChanges();
            TransactionLogViewModel.AddLog(check.Username + " has just recoveried the password successfully!", DateTime.Now);
            return View("recoverdone");

        }
        public ActionResult setlang()
        {
            string lang = StoreDb.Settings.Single(s=>s.Webmaster.Username == User.Identity.Name).Language;
            ViewData["LANG"] = lang;
            return View();


        }
        [HttpPost]
        public ActionResult setlang(string select)
        {

            var setting = StoreDb.Settings.Single(s=>s.Webmaster.Username == User.Identity.Name);
            setting.Language = select;
            StoreDb.SaveChanges();

            return View("setLangdone");
           
           


        }
       
        

        




    }
}
