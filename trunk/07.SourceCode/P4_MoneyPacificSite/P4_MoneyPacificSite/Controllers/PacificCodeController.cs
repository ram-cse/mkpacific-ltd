using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P4_MoneyPacificSite.Models;
using P4_MoneyPacificSite.ViewModels;

namespace P4_MoneyPacificSite.Controllers
{
    public class PacificCodeController : Controller
    {
        //
        // GET: /PacificCode/

        public ActionResult Index()
        {
            return View();
        }

        //
        // VIEW DETAIL
        //
        public ActionResult ViewDetail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ViewDetail(PacificCodeViewDetailViewModel obj)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            bool bExist = db.PacificCodes.Where(p => p.CodeNumber == obj.CodeNumber).Any();
            if (bExist)
            { 

            }
            
            // Luu vao Transaction 
            // .. 
            return View(obj);
        }

        //
        // CHANGE CODE
        //
        public ActionResult ChangeCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeCode(PacificCodeChangeCodeViewModel obj )
        {
            return View();
        }

        //
        // SEND SMS
        //
        public ActionResult SendSMS()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendSMS(PacificCodeSendSMSViewModel obj)
        {
            return View();
        }

        //
        // SEND MONEY
        //
        public ActionResult SendMoney()
        {
            var viewModel = new PacificCodeSendMoneyViewModel
            {
                CodeNumber = "12345678901112",
                Amount = 1000,
                AmountConfirm = 1000
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult SendMoney(PacificCodeSendMoneyViewModel sendObject)
        {
            try
            {
                return RedirectToAction("View", "Message");
            }
            catch
            {
                return View(sendObject);
            }
        }

        // 
        // Xem thông tin chi tiết của PACIFIC CODE
        //
        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(string CodeNumber)
        {
            return View();
        }
        
        public ActionResult ChiTiet(int id)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            var viewModel = db.PacificCodes.Where(p => p.ID == id).Single<PacificCode>();
            return View(viewModel);
        }
     
        public ActionResult Browse()
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            var viewModel = db.PacificCodes
                .Include("Customer").Include("Store")
                .ToList<PacificCode>();

            foreach (PacificCode item in viewModel)
            {
                if (item.Customer == null)
                {
                    item.Customer = new Customer {Phone = "NO PHONE" };
                }

                if (item.Store == null)
                {
                    item.Store = new Store { Phone = "NO PHONE" };
                }
            }

            return View(viewModel);
        }
    }
}
