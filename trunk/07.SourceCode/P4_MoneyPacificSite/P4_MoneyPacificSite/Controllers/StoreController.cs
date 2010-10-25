using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P4_MoneyPacificSite.ViewModels;
using P4_MoneyPacificSite.Models;
using P4_MoneyPacificSite.Models.DAO;

namespace P4_MoneyPacificSite.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(StoreViewModel model )
        {
            ViewData["Message"] = "Đăng ký thành công";
            return View();
        }

        public ActionResult Dashboard()
        {
            var viewModel = new StoreDashboarshViewModel()
            {
                Status = "Enable",
                LastTransactions = 25,
                AmountFromCustomer = 4000000,
                LastCollectDate = DateTime.Now
            };
            
            return View(viewModel);
        }

        public ActionResult Information()
        {
            var viewModel = StoreDAO.getTestStore();
            return View(viewModel);
        }
        public ActionResult Security()
        {
            var viewModel = new StoreSecurityViewModel();            
            return View(viewModel);
        }
        public ActionResult PacificMail()
        {
            return View();
        }
    }
}
