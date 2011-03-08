using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merchant.Models;
using System.Web.Routing;
namespace Merchant.Controllers
{
    [MPAccess(Roles="Admin")]
    public class AdminController : Controller
    {
        
        // GET: /Admin/
        public MPWebmasterEntities db = new MPWebmasterEntities();
        public ActionResult Index()
        {
            return View();
        }
        
    }
}
