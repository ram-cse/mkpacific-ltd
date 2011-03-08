using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MoneyPacificSite.ViewModels;
using MPDataAccess;
using MoneyPacificSite.BUS;

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
            
            //int Id = 1;            
            Guid Id = new Guid("8ff652b0-d9d2-4e7a-9e85-3559c92b061f");
            
            StoreUser storeUser = StoreUserBUS.GetObject(Id);
            Guid managerId = (Guid)storeUser.ManagerId;
            StoreManager curSM = StoreManagerBUS.GetObject(managerId);

            User userInfo = UserBUS.GetObject(Id);

            model.Id = Id;
            model.Name = userInfo.Firstname + " " + userInfo.Lastname;
            model.Status = StoreManagerStateBUS.GetObject((int)curSM.StatusId).Code;
            model.TotalLastMonthAmount = StoreManagerBUS.GetTotalLastMonthAmount(curSM.UserId);
            model.TotalTransaction = StoreManagerBUS.GetTotalLastMonthTransaction(curSM.UserId);

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
