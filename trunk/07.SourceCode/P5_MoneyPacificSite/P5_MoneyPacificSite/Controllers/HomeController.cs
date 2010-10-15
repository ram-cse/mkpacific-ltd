using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P5_MoneyPacificSite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewData["Message"] = "Money Pacicific Customer Site";
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

    }
}
