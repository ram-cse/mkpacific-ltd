using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F01_MoneyPacificUserRole.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        [Authorize(Roles="Administrator")]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult TestPage()
        {
            return View();
        }
    }
}
