using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P4_MoneyPacificSite.Models;
using P4_MoneyPacificSite.Utilators;

namespace P4_MoneyPacificSite.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(Mail mail)
        {
            //Send Mail
            
           
            try
            {
                mail.To = "admin@moneypafic.com";
                mail.From = "storemanager@moneypacific.com"; // lấy từ thông tin đăng nhập                
                MPMail.Send(mail);                
                return RedirectToAction("/");
            }
            catch
            {
                ViewData["Message"] = "Error!...";
                return View(mail);
            }
        }
    }
}
