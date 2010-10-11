using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net.Mail;
using P2_MoneyPacificSite.Models;

namespace P2_MoneyPacificSite.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        public string Index()
        {

            return "Hello Mail Server!..";
        }

        public ActionResult SendEmailabc()
        {
            //var mail = new Mail { 
            //    Body = "Noi dung thu gui...",
            //    From = "thanhdungit@gmail.com",
            //    To = "thanhdungit@yahoo.com",
            //    Subject = "TEST MAIL ..."
            //};
            // return View(mail);
            return View();
        }

        public ActionResult SendM()
        {
            return View();
        }

        public ActionResult SendMa()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult SendEmail(Mail myMail)
        //{
        //    return View();
        //}

    }
}
