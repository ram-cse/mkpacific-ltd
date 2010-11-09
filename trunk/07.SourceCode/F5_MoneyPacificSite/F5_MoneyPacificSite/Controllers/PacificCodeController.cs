using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using F5_MoneyPacificSite.ViewModels;
using F5_MoneyPacificSite.Models;
using F5_MoneyPacificSite.Models.BUS;

namespace F5_MoneyPacificSite.Controllers
{
    public class PacificCodeController : Controller
    {
        //
        // GET: /PacificCode/

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

        public ActionResult Detail()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Detail(string codeNumber)
        {
            PacificCode existPC = PacificCodeBUS.GetItem(codeNumber);
            PacificCodeDetailViewModel newModel = null;
            newModel = new PacificCodeDetailViewModel();
            newModel.CodeNumber = existPC.CodeNumber;
            newModel.ActualAmount = (int)existPC.ActualAmount;
            newModel.Comment = existPC.Comment;
            newModel.CreateDate = (DateTime)existPC.Date;
            newModel.ExpireDate = (DateTime)existPC.ExpireDate;
            newModel.CustomerPhone = CustomerBUS.GetPhone(existPC.CustomerId);

            return View(newModel);
        }

    }
}
