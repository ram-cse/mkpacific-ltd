using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MPDataAccess;
using MoneyPacificSite.ViewModels;
using MoneyPacificSite.BUS;

namespace MoneyPacificSite.Controllers
{
    public class StoreManagerController : Controller
    {

        #region ACTION       
        
        public ActionResult AskToBePartner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AskToBePartner(StoreManager model)
        {
            return View();
        }


        public ActionResult Dashboard()
        {
            StoreManagerDashboardViewModel model = new StoreManagerDashboardViewModel();
            // Lấy ID của StoreManager đang đăng nhập
            Guid managerId = new Guid("0999f3dd-88ce-4cf5-9371-702b4058c46a");
            StoreManager curSM = StoreManagerBUS.GetObject(managerId);

            model = SetDashBoardModel(curSM);

            if (curSM.IsLocked == null) curSM.IsLocked = true;
            model.IsLocked = (bool)curSM.IsLocked;
            return View(model);
        }

        [HttpPost]
        public ActionResult Dashboard(StoreManagerDashboardViewModel model)
        {
            Guid Id = model.Id;            
            StoreManager curSM = StoreManagerBUS.GetObject(Id);
            model = SetDashBoardModel(curSM);
            model.IsLocked = StoreManagerBUS.ChangeLocked(Id);
            return View(model);
        }

        public ActionResult Information()
        {
            StoreManagerInformationViewModel model = new StoreManagerInformationViewModel();

            /// TODO:            
            // Lấy ID của StoreManager đang đăng nhập
            Guid managerId = new Guid("0999f3dd-88ce-4cf5-9371-702b4058c46a");

            StoreManager curSM = StoreManagerBUS.GetObject(managerId);
            model = SetInformationModel(curSM);

            return View(model);
        }

        public ActionResult Security()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Security(SecurityViewModel obj)
        {
            return View();
        }

        #endregion

        #region SERVICES

        private StoreManagerDashboardViewModel SetDashBoardModel(StoreManager curSM)
        {
            StoreManagerDashboardViewModel model = new StoreManagerDashboardViewModel();
            User userInfo = UserBUS.GetObject(curSM.UserId);

            model.Id = curSM.UserId;
            model.Name = userInfo.Username;
            model.Status = StoreManagerStateBUS.GetObject((int)curSM.StatusId).Code; //.GetCode((int)curSM.StatusId);
            model.TotalLastMonthAmount = StoreManagerBUS.GetTotalLastMonthAmount(curSM.UserId);
            model.TotalTransaction = StoreManagerBUS.GetTotalLastMonthTransaction(curSM.UserId);

            if (curSM.LastCollectDate != null)
            {
                model.LastCollectDate = (DateTime)curSM.LastCollectDate;
            }
            return model;
        }

        private StoreManagerInformationViewModel SetInformationModel(StoreManager curSM)
        {
            StoreManagerInformationViewModel model = new StoreManagerInformationViewModel();
            User userInfo = UserDAO.GetObject(curSM.UserId);

            // Manager Information
            model.Manager = new ManagerInformation();

            model.Manager.Name = userInfo.Firstname + " " + userInfo.Lastname;

            model.Manager.Username = userInfo.Username;
            model.Manager.Password = userInfo.Password;

            model.Manager.NameOfStore = curSM.NameOfStore;
            model.Manager.ManagerPhone = curSM.ManagerPhone;

            model.Manager.Address = curSM.Address;
            model.Manager.Address2 = curSM.Address2;

            model.Manager.Phone = curSM.Phone;
            model.Manager.Phone2 = curSM.Phone2;

            //model.Manager.City = AreaBUS.GetObject(curSM.AreaId).Name;
            //model.Manager.Area = AreaBUS.GetObject((int)curSM.AreaId).Name;
            model.Manager.Area = "HC1 (tmp)";
            model.Manager.Country = curSM.Country;

            model.Manager.EmailAlert = userInfo.Email; // mail lay thong bao
            model.Manager.EmailBill = curSM.EmailBill;

            model.Manager.NameOfCompany = curSM.NameOfCompany;
            model.Manager.VATNumber = curSM.VATNumber;

            // List StoreUser Information
            StoreUser[] arrStoreUser = StoreUserBUS.GetArray(curSM.UserId);
            List<UserInformation> lstUser = new List<UserInformation>();

            foreach (StoreUser store in arrStoreUser)
            {
                User storeUserInfo = UserBUS.GetObject(store.UserId);

                UserInformation newUserPhone = new UserInformation();

                newUserPhone.Email = storeUserInfo.Email;
                newUserPhone.Name = storeUserInfo.Username;
                newUserPhone.Password = storeUserInfo.Password;

                newUserPhone.LastTransaction = "...";

                newUserPhone.Phone = store.Phone;
                newUserPhone.PINStore = store.PINStore;

                //newUserPhone.Status = store.StoreUserState.Code + " - " + store.StoreUserState.Description;                
                StoreUserState storeUserState = StoreUserStateBUS.GetObject((int)store.StatusId);
                newUserPhone.Status = storeUserState.Code + " - " + storeUserState.Description;

                lstUser.Add(newUserPhone);
            }

            model.ArrUser = lstUser.ToArray();

            return model;
        }
        #endregion
    }
}
