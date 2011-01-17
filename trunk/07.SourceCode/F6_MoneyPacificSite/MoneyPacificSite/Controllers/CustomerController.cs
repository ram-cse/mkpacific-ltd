using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyPacificSite.Controllers
{
    public class CustomerController : Controller
    {        
        // GET: /Customer/

        public ActionResult Index()
        {
            ViewData["message"] = "Customer Site";
            return View();
        }

    }
}
