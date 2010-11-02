using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P4_MoneyPacificSite.ViewModels;
using P4_MoneyPacificSite.Models;
using P4_MoneyPacificSite.Models.DAO;
using P4_MoneyPacificSite.Models.BUS;

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
            StoreViewModel testObj = new StoreViewModel();
            testObj.Name = "thanhdungit";
            testObj.NameOfCompany = "Tim Kiem Nha Dat . Ltd";
            testObj.Email = "thanhdungit@gmail.com";
            testObj.NumberOfShop = 10;
            testObj.Phone = "0932130483";
            testObj.Address = "Quận 12";


            return View(testObj);
        }
        [HttpPost]
        public ActionResult Register(StoreViewModel model )
        {
            try
            {
                bool result = StoreManagerBUS.AskTobeParnerStore(model);
                ViewData["Message"] = "Successful..";
            }
            catch
            {
                ViewData["Message"] = "Error!..";
            }
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
            var viewModel = StoreUserDAO._GetTestStoreUser();
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
