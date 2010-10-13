using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P4_MoneyPacificSite.ViewModels;

namespace P4_MoneyPacificSite.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(MessageViewViewModel requestObj)
        {
            return View(requestObj);
        }
    }
}
