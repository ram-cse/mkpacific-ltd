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
    public class StoreManagerController : Controller
    {
        public ActionResult AskToBePartner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AskToBePartner(StoreManager model)
        {
            return View();
        }

        public ActionResult Information()
        {
            StoreManagerInformationViewModel model = new StoreManagerInformationViewModel();
            
            /// TODO:
            /// Lấy ID của user đang đăng nhập            
            int Id = 1;

            StoreManager curSM = StoreManagerBUS.GetItem(Id);
            model = SetInformationModel(curSM);

            return View(model);
        }


        public ActionResult Dashboard()
        {
            StoreManagerDashboardViewModel model = new StoreManagerDashboardViewModel();
            // Lấy ID của StoreManager đang đăng nhập
            int Id = 0;
            StoreManager curSM = StoreManagerBUS.GetItem(Id);

            model = SetDashBoardModel(curSM);

            if (curSM.IsLocked == null) curSM.IsLocked = true;
            model.IsLocked = (bool)curSM.IsLocked;
            return View(model);
        }

        [HttpPost]
        public ActionResult Dashboard(StoreManagerDashboardViewModel model)
        {
            int Id = model.Id;
            StoreManager curSM = StoreManagerBUS.GetItem(Id);
            model = SetDashBoardModel(curSM);
            model.IsLocked = StoreManagerBUS.ChangeLocked(Id);
            return View(model);
        }

        public ActionResult Security()
        {
            List<TimeTableItem> lstTimeTableItem = new List<TimeTableItem>();
            for (int i = 0; i < 7; i++ )
            {
                TimeTableItem newItem = new TimeTableItem();
                
                newItem.dateName = "Day " + i;
                newItem.hourItem = new List<int>();
                newItem.enable = new List<bool>();
                
                for (int j = 0; j < 24; j++)
                {
                    newItem.hourItem.Add(j);
                    newItem.enable.Add(j % 2 == 0);
                }

                lstTimeTableItem.Add(newItem);
            }

            var model = new SecurityViewModel()
            {
                storeManagerName = "LTDung",
                securityTimeTable = lstTimeTableItem
            };
            return View(model);
        }

        #region PRIVATE

        private StoreManagerDashboardViewModel SetDashBoardModel(StoreManager curSM)
        {
            StoreManagerDashboardViewModel model = new StoreManagerDashboardViewModel();
            model.Id = curSM.Id;
            model.Name = curSM.Name;
            model.Status = StoreManagerStateBUS.GetCode((int)curSM.StatusId);
            model.TotalLastMonthAmount = StoreManagerBUS.GetTotalLastMonthAmount(curSM.Id);
            model.TotalTransaction = StoreManagerBUS.GetTotalLastMonthTransaction(curSM.Id);

            if (curSM.LastCollectDate != null)
            {
                model.LastCollectDate = (DateTime)curSM.LastCollectDate;
            }
            return model;
        }

        private StoreManagerInformationViewModel SetInformationModel(StoreManager curSM)
        {
            StoreManagerInformationViewModel model = new StoreManagerInformationViewModel();
            
            // Manager Information
            model.Manager = new ManagerInformation();

            model.Manager.Name = curSM.Name;

            model.Manager.Username = curSM.Username;
            model.Manager.Password = curSM.Password;

            model.Manager.NameOfStore = curSM.NameOfStore;
            model.Manager.ManagerPhone = curSM.ManagerPhone;

            model.Manager.Address = curSM.Address;
            model.Manager.Address2 = curSM.Address2;

            model.Manager.Phone = curSM.Phone;
            model.Manager.Phone2 = curSM.Phone2;

            model.Manager.City = curSM.City.Name;
            model.Manager.Country = curSM.Country;

            model.Manager.EmailAlert = curSM.EmailAlert;
            model.Manager.EmailBill = curSM.EmailBill;

            model.Manager.NameOfCompany = curSM.NameOfCompany;
            model.Manager.VATNumber = curSM.VATNumber;

            // List StoreUser Information
            StoreUser[] arrStoreUser = StoreUserBUS.GetList(curSM.Id);
            List<UserInformation> lstUser = new List<UserInformation>();

            foreach (StoreUser u in arrStoreUser)
            {
                UserInformation newUserPhone = new UserInformation();
                
                newUserPhone.Email = u.Email;
                newUserPhone.LastTransaction = "...";
                newUserPhone.Name = u.Name;
                newUserPhone.Password = u.Password;
                newUserPhone.Phone = u.Phone;
                newUserPhone.PINStore = u.PINStore;
                newUserPhone.Status = u.StoreUserState.Code + " - " + u.StoreUserState.Description;

                lstUser.Add(newUserPhone);
            }

            model.ArrUser = lstUser.ToArray();

            return model;
        }
        #endregion PRIVATE
    }
}
