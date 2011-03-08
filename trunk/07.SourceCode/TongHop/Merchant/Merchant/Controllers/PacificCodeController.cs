using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPDataAccess;
using MoneyPacificSite.ViewModels;
using MoneyPacificBlackBox.DTO;
using MoneyPacificSite.Util;


using MoneyPacificSite.BUS;
using Merchant.Helper;

namespace MoneyPacificSite.Controllers
{
    public class PacificCodeController : Controller
    {
        //
        // GET: /PacificCode/
        public HtmlHelper helper { get; set; }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Browse()
        {            
            List<PartPacificCode> lstPPC = PartPacificCodeBUS.GetList();

            var viewModel = GetBrowseViewModel(lstPPC);            

            return View(viewModel);
        }
                
        public ActionResult Detail(string partCodeNumber)
        {
            PartPacificCodeViewModel model = new PartPacificCodeViewModel();

            PartPacificCode existPPC = PartPacificCodeBUS.GetObject(partCodeNumber);
            PacificCodeViewModel pacificCode = PartPacificCodeBUS.GetPacificCodeViewModel(partCodeNumber);
                        
            model.PartCodeNumber = pacificCode.CodeNumber;
            model.InitialAmount = (int)pacificCode.InitialAmount;
            model.ActualAmount = (int)pacificCode.ActualAmount;
            
            model.ExpireDate = (DateTime)pacificCode.ExpireDate;
            model.CustomerPhone = CustomerBUS.GetPhone(existPPC.CustomerId);

            return View(model);
        }

        private List<PartPacificCodeViewModel> GetBrowseViewModel(List<PartPacificCode> lstPPC)
        {
            List<PartPacificCodeViewModel> lstResult = new List<PartPacificCodeViewModel>();
            for(int i = 0; i < lstPPC.Count; i++)
            {
                PartPacificCodeViewModel newItemViewModel = new PartPacificCodeViewModel();

                newItemViewModel.Id = lstPPC[i].Id;
                newItemViewModel.Stt = i + 1;
                newItemViewModel.PartCodeNumber = lstPPC[i].PartCodeNumber.Trim() + "xxxx";
                newItemViewModel.CustomerPhone = CustomerBUS.GetPhone(lstPPC[i].CustomerId);
                newItemViewModel.StorePhone = StoreUserBUS.GetPhone(lstPPC[i].StoreUserId);

                PacificCodeViewModel pacificCode = PartPacificCodeBUS.GetPacificCodeViewModel(lstPPC[i].PartCodeNumber);
                if (pacificCode != null)
                {
                    newItemViewModel.InitialAmount = pacificCode.InitialAmount;
                    newItemViewModel.ActualAmount = pacificCode.ActualAmount;
                    newItemViewModel.ExpireDate = pacificCode.ExpireDate;

                    lstResult.Add(newItemViewModel);
                }
            }

            return lstResult;
        }

        public ActionResult CheckDetail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckDetail(PacificCodeCheckDetailViewModel model)
        {
            string trimCodeNumber = "";
            foreach (char c in model.CodeNumber)
            {
                if (c != ' ')
                {
                    trimCodeNumber += c;
                }
            }
            model.CodeNumber = trimCodeNumber;

            bool isExist = PartPacificCodeBUS.IsExist(model.CodeNumber);
            if (isExist)
            {
                return RedirectToAction("Detail", new { partCodeNumber = model.CodeNumber });
            }
            else
            {
                ViewData["message"] = "Pacific Code này không tồn tại";
                return View(model);
            }
        }

        public ActionResult SendMoney()
        {
            var viewModel = new PacificCodeSendMoneyViewModel
            {
                CodeNumber = "9032397227803476",
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
                sendObject.CodeNumber = Utilator.removeSpaceChar(sendObject.CodeNumber);

                if (sendObject.PhoneNumber == sendObject.PhoneNumberConfirm)
                {
                    PacificCodeViewModel newPacificCode = PartPacificCodeBUS.SendMoney(sendObject.CodeNumber,
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

                        // Gửi mail tới người nhận
                        MPMail.SendForEmail(newMail);
                        ViewData["message"] = "Thuc hien chuyen tien thanh cong!...";
                        return View(sendObject);
                    }
                }

                ViewData["message"] = "Sai thong tin nhap...";
                return View(sendObject);
            }
            catch(Exception e)
            {
               ViewData["message"] = e.Message.ToString();
               
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
            Customer existCustomer = CustomerBUS.GetCustomerOrCreateNotYetBuy(obj.PhoneNumber);
            string sMessage = "";
            if (existCustomer != null)
            {
                PacificCodeViewModel lastPacifiCode = PartPacificCodeBUS.GetLastPacificCode(existCustomer.UserId);
                // Luôn luôn khi có KH thì đã có PacificCode ?
                // => ko can kiem tra tồn tại?
                DateTime createTime;
                if (lastPacifiCode == null)
                {
                    createTime = DateTime.MinValue;
                }
                else
                {
                    createTime = (DateTime)lastPacifiCode.CreateDate;
                }

                if (createTime.AddHours(24) > DateTime.Now)
                {
                    bool bExist = TransactionBUS.IsExist(lastPacifiCode.CodeNumber);
                    if (!bExist)
                    {
                        sMessage = "Da gui lai tin nhan";
                        Mail newMail = new Mail();
                        newMail.Body = "GSM: " + existCustomer.PhoneNumber + "<br/>"
                            + "Ban vua mua mot PacificCode: " + lastPacifiCode.CodeNumber
                            + " co gia tri  " + lastPacifiCode.ActualAmount + " VND. "
                            + "va han su dung de ngay {2}";
                        MPMail.SendForEmail(newMail);
                    }
                    else
                    {
                        sMessage = "Da co giao dich bang Pacific Code nay! khong the nhan lai SMS";
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



        public ActionResult ChangeCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeCode(PacificCodeChangeCodeViewModel obj)
        {
            string trimCodeNumber = "";
            foreach (char c in obj.CodeNumber)
            {
                if (c != ' ')
                {
                    trimCodeNumber += c;
                }
            }
            obj.CodeNumber = trimCodeNumber;

            if (PartPacificCodeBUS.IsExist(obj.CodeNumber))
            {
                string newCodeNumber = PartPacificCodeBUS.ChangeCode(obj.CodeNumber);

                if (newCodeNumber != null)
                {
                    ViewData["message"] = HtmlHelpers.insertSeparateChar(helper,
                        newCodeNumber, ' ', 4);
                }
                else
                {
                    ViewData["message"] = "Pacifice Code này ko tồn tại!....";
                }
            }
            else
            {
                ViewData["message"] = "Pacifice Code này ko tồn tại!.";
            }
            return View();
        }

    }
}
