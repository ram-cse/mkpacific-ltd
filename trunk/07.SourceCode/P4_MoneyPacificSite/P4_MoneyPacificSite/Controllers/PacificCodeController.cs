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
            bool bExist = db.PacificCodes.Where
                (p => p.CodeNumber == obj.CodeNumber).Any();
            PacificCode pCode;
            if (bExist)
            {
                pCode = db.PacificCodes.Where
                    (p => p.CodeNumber == obj.CodeNumber).SingleOrDefault<PacificCode>();
                return RedirectToAction("ChiTiet", new { id = pCode.ID});
            }
            else
            {
                ViewData["ErrorMessage"] = "Khong ton tai PacificCoe";
                // + Lưu thông tin để bảo mật, tránh 1 người dùng lợi dụng chức này để truy tìm PacificCode
                // + Lớp GenerateMessage
                return View();
            }
            

            
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
            MoneyPacificEntities db = new MoneyPacificEntities();
            bool bExist = db.PacificCodes.Where(p => p.CodeNumber == obj.CodeNumber).Any();
            if (bExist)
            {
                PacificCode pCode = db.PacificCodes.Where
                    (p => p.CodeNumber.Trim() == obj.CodeNumber.Trim()).SingleOrDefault<PacificCode>();
                int i = int.Parse(pCode.CodeNumber[0].ToString());
                i = (i+1) % 10;
                pCode.CodeNumber = i.ToString() + pCode.CodeNumber.Substring(1);
                db.SaveChanges();
                obj.CodeNumber = pCode.CodeNumber;
            }

            // Luu vao Transaction 
            // .. 
            ViewData["Message"] = obj.CodeNumber;
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
                CodeNumber = "1935996349268167",
                Amount = 1000,
                PhoneNumber = "0932130483",
                PhoneNumberConfirm = "0932130483"
            };

            return View(viewModel);
            // Hiển thị Hộp thoại xác nhận chắc chắn người dùng muốn thực hiện giao dịch
            // bằng JavaScript
            
        }
        [HttpPost]
        public ActionResult SendMoney(PacificCodeSendMoneyViewModel sendObject)
        {
            try
            {
                // Service


                ViewData["ErrorMessage"] = "Thực hiện giao dịch thành công!...";
                return View();
            }
            catch
            {
                ViewData["ErrorMessage"] = "Co loi xay ra!...";
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
