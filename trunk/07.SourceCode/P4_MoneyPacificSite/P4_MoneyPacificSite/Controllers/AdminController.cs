using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P4_MoneyPacificSite.Models.BUS;
using P4_MoneyPacificSite.Models;

namespace P4_MoneyPacificSite.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            //return BrowseStores();
            return View();
        }
            
        public ActionResult BrowseStores()
        {
            var model = StoreManagerBUS.GetList();            
            return View(model);
        }

        public ActionResult DetailStore(int Id)
        {
            var model = StoreManagerBUS.GetItem(Id);
            return View(model);
        }

        public ActionResult EditStore(int Id)
        {
            var model = StoreManagerBUS.GetItem(Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditStore(StoreManager model)
        {
            StoreManagerBUS.UpdateStore(model);
            return View();
        }
        //[Htt

    }
}
