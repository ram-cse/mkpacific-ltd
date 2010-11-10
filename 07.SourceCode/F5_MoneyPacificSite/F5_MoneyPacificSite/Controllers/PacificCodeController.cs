using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using F5_MoneyPacificSite.ViewModels;
using F5_MoneyPacificSite.Models;
using F5_MoneyPacificSite.Models.BUS;
using F5_MoneyPacificSite.Helpers;
using F5_MoneyPacificSite.Utilators;

namespace F5_MoneyPacificSite.Controllers
{
    public class PacificCodeController : Controller
    {
        //
        // GET: /PacificCode/

        public HtmlHelper helper { get; set; }

        public ActionResult Browse()
        {
            PacificCode[] viewModel = PacificCodeBUS.GetList();

            foreach (PacificCode item in viewModel)
            {
                if (item.Customer == null)
                {
                    item.Customer = new Customer { Phone = "NO PHONE" };
                }

                if (item.StoreUser == null)
                {
                    item.StoreUser = new StoreUser { Phone = "NO PHONE" };
                }
            }

            return View(viewModel);
        }

        public ActionResult CheckDetail()
        {   
            return View();
        }

        [HttpPost]
        public ActionResult CheckDetail(PacificCodeCheckDetailViewModel theModel)
        {
            bool isExist = PacificCodeBUS.IsExist(theModel.CodeNumber) ;            
            if (isExist)
            {
                return RedirectToAction("Detail", new { codeNumber = theModel.CodeNumber });
            }
            else
            {
                ViewData["message"] = "Pacific Code này không tồn tại";
                return View(theModel);
            }            
        }

        // [HttpPost]
        // Lộ thông tin ng dùng? làm sao để giấu thông tin
        public ActionResult Detail(string codeNumber)
        {            
            PacificCode existPC = PacificCodeBUS.GetItem(codeNumber);
            PacificCodeDetailViewModel newModel = null;
            newModel = new PacificCodeDetailViewModel();
            newModel.CodeNumber = existPC.CodeNumber;
            newModel.InitialAmount = (int)existPC.InitialAmount;
            newModel.ActualAmount = (int)existPC.ActualAmount;
            newModel.Comment = existPC.Comment;
            newModel.CreateDate = (DateTime)existPC.Date;
            newModel.ExpireDate = (DateTime)existPC.ExpireDate;
            newModel.CustomerPhone = CustomerBUS.GetPhone(existPC.CustomerId);

            return View(newModel);
        }

        public ActionResult ChangeCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeCode(PacificCodeChangeCodeViewModel obj)
        {
            if(PacificCodeBUS.IsExist(obj.CodeNumber))
            {
                ViewData["message"] = HtmlHelpers.insertSeparateChar(helper,PacificCodeBUS.ChangeCode(obj.CodeNumber),'-',4);
            }
            else
            {
                ViewData["message"] = "Pacifice Code này ko tồn tại!.";
            }
            return View();
        }

        public ActionResult SendMoney()
        {
            var viewModel = new PacificCodeSendMoneyViewModel
            {
                CodeNumber = "1767312140506642",
                Amount = 1000,
                PhoneNumber = "0932130483",
                PhoneNumberConfirm = "0932130483"
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SendMoney(PacificCodeSendMoneyViewModel sendObject)
        {
            try
            {
                // Service

                if (sendObject.PhoneNumber == sendObject.PhoneNumberConfirm)
                {
                    PacificCode newPacificCode = PacificCodeBUS.SendMoney(sendObject.CodeNumber,
                        sendObject.PhoneNumber, sendObject.Amount);

                    if (newPacificCode != null)
                    {
                        // Nếu thành công thì gửi mail thông báo
                        Mail newMail = new Mail();
                        newMail.Subject = "Send to Customer";
                        newMail.Body = "GSM: " + sendObject.PhoneNumber + "<br/>"
                            + "Bạn vừa nhận được PacificCode: " + newPacificCode.CodeNumber + ". "
                            + "Có giá trị " + newPacificCode.ActualAmount + " và "
                            + "han su dung den ngay " + String.Format("{0:dd-MM-yyyy}", newPacificCode.ExpireDate);

                        MPMail.SendForEmail(newMail);
                        ViewData["message"] = "Thuc hien chuyen tien thanh cong!...";
                        return View(sendObject);
                    }
                }

                ViewData["message"] = "Sai thong tin nhap...";
                return View(sendObject);
            }
            catch
            {
                ViewData["message"] = "Co loi xay ra!...";
                return View(sendObject);
            }
        }

        public ActionResult SendSMS()
        {
            return View();
        }

        /*
         * Kiểm tra PhoneNumber có tồn tại
         *   + Neu ton tai thi lay PacificCode chưa có giao dịch nào 
         * Kiểm tra theo RULE (cần nhập từ XML)
         *   + Nếu CreateDate + GioiHanGioNhanSMS > Hien tai
         *   + Nếu chưa có giao dịch nào xảy ra với PacificCode này
         *   => thực hiện gửi tin nhắn 
         * */

        [HttpPost]
        public ActionResult SendSMS(PacificCodeSendSMSViewModel obj)
        {
            Customer existCustomer = CustomerBUS.getCustomer(obj.PhoneNumber);
            string sMessage = "";
            if (existCustomer != null)
            {
                PacificCode lastPacifiCode = PacificCodeBUS.GetLastPacificCode(existCustomer.Id);
                // Luôn luôn khi có KH thì đã có PacificCode ?
                // => ko can kiem tra tồn tại?
                DateTime createTime;
                if (lastPacifiCode == null)
                {
                    createTime = DateTime.MinValue;
                }
                else
                {
                    createTime = (DateTime)lastPacifiCode.Date;
                }

                if (createTime.AddHours(24) > DateTime.Now)
                {
                    bool bExist = TransactionBUS.isExist(lastPacifiCode.CodeNumber);
                    if (!bExist)
                    {
                        sMessage = "Da gui lai tin nhan";
                        Mail newMail = new Mail();
                        newMail.Body = "GSM: " + existCustomer.Phone + "<br/>"
                            + "Ban vua mua mot PacificCode: " + lastPacifiCode.CodeNumber
                            + " co gia tri  " + lastPacifiCode.ActualAmount + " VND. "
                            + "va han su dung de ngay {2}";

                        MPMail.SendForEmail(newMail);
                    }
                }
                else
                {
                    sMessage = "Da qua 24 gio tu luc PacificCode duoc tao";
                }
            }
            else
            {
                sMessage = "Khach hang " + obj.PhoneNumber + " khong ton tai.";
            }
            ViewData["message"] = sMessage;
            return View();
        }
    }
}
