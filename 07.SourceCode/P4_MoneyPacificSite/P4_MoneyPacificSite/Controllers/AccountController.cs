using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P4_MoneyPacificSite.ViewModels;

namespace P4_MoneyPacificSite.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountLoginViewModel model)
        {
            ViewData["Message"] = "Submited....";
            return View(model);
        }


    }
}
