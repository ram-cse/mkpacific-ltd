using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P4_MoneyPacificSite.ViewModels;
using P4_MoneyPacificSite.Models;
using P4_MoneyPacificSite.Models.BUS;

namespace P4_MoneyPacificSite.Controllers
{
    public class StoreManagerController : Controller
    {
        //
        // GET: /StoreManager/

        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult Interface()
        {
            var model = new StoreManagerInterfaceViewModel();
            // Lấy ID của StoreManager đang đăng nhập
            int Id = 0;
            StoreManager curSM = StoreManagerBUS.GetItem(Id);

            model.Id = Id;
            model.Name = curSM.Name;
            model.Status = StoreManagerStateBUS.GetCode((int)curSM.StatusId);
            model.TotalLastMonthAmount = StoreManagerBUS.GetTotalLastMonthAmount(curSM.Id);
            model.TotalTransaction = StoreManagerBUS.GetTotalLastMonthTransaction(curSM.Id);

            if (curSM.LastCollectDate != null)
            {
                model.LastCollectDate = (DateTime)curSM.LastCollectDate;
            }

            if (curSM.IsLocked == null) curSM.IsLocked = true;
            model.IsLocked = (bool)curSM.IsLocked;
            return View(model);
        }

        [HttpPost]
        public ActionResult Interface(StoreManagerInterfaceViewModel model)
        {
            int Id = model.Id;
            model.IsLocked = StoreManagerBUS.ChangeLocked(Id);
            return View(model);
        }
    }
}
