using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MoneyPacificSite.ViewModels;
using MoneyPacificSite.Models;
using MoneyPacificSite.Models.BUS;

namespace MoneyPacificSite.Controllers
{
    public class StoreUserController : Controller
    {
        //
        // GET: /StoreUser/
        public ActionResult DashBoard()
        {
            StoreUserDashboardViewModel model = new StoreUserDashboardViewModel();
            // Lấy ID của Storeuser đang đăng nhập
            int Id = 1;
            StoreUser storeUser = StoreUserBUS.GetItem(Id);
            int ManagerId = (int)storeUser.ManagerId;
            StoreManager curSM = StoreManagerBUS.GetItem(ManagerId);

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
    }
}
