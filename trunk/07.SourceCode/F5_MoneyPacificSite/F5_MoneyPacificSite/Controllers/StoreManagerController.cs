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

        /// <summary>
        /// Giải thuật: Lưu 
        /// </summary>
        /// <returns></returns>

        public ActionResult Security()
        {
            // Lấy thông tin StoreManager đăng nhập
            int storeManagerId = 5;            
            try
            {
                // Load tất cả thông tin lên
                List<TimeDayView> lstTimeDay = new List<TimeDayView>();
                for (int i = 0; i < 7; i++)
                {
                    // Lay thong tin từng ngày
                    TimeDayView newItem = new TimeDayView();

                    // Lay ra 24giờ trong ngày
                    newItem.dateName = GetDay(i + 1);
                    newItem.lstTimeTable = TimeTableBUS.GetArray(GetDay(i + 1), storeManagerId);

                    if (newItem.lstTimeTable.Count != 24)
                    {
                        throw (new Exception());
                    }

                    lstTimeDay.Add(newItem);
                }

                foreach (TimeDayView dayItem in lstTimeDay)
                {
                    dayItem.lstTimeTable.Sort(
                        delegate(TimeTable itemTable01, TimeTable timeTable02)
                        {
                            return Comparer<int>.Default.Compare
                               (itemTable01.TimeItem.Hour, timeTable02.TimeItem.Hour);
                        }
                    );
                }

                var model = new SecurityViewModel()
                {
                    managerId = storeManagerId,
                    storeManagerName = StoreManagerBUS.GetItem(storeManagerId).Name,
                    lstSecurityTimeDay = lstTimeDay
                };
                return View(model);
            }
            catch(Exception ex)
            {
                /// --------------------------------------------
                /// Chi goi khi chua co du lieu, tránh lỗi do 
                /// chưa có dữ liệu
                TimeItemBUS.AddIfNotExists(storeManagerId);
                ViewData["message"] = "Lỗi: " + ex.Message;
                return RedirectToAction("Index", "Store");
                /// --------------------------------------------
            }
        }

        [HttpPost]
        public ActionResult Security(SecurityViewModel obj)
        {
            ViewData["message"] = "Lưu thành công!...";
            int managerId = obj.managerId;
            List<TimeTable> lstTimeTable = new List<TimeTable>();

            foreach (TimeDayView timeDayView in obj.lstSecurityTimeDay)
            {
                foreach (TimeTable item in timeDayView.lstTimeTable)
                {
                    lstTimeTable.Add(item);
                }
            }

            TimeTableBUS.Update(managerId, lstTimeTable);

            // Lấy thông tin dữ liệu
            return View(obj);
        }

        #region PRIVATE
        private static string GetDay(int id)
        {
            string result = "";
            switch (id)
            {
                case 1:
                    result = "Sunday";
                    break;
                case 2:
                    result = "Monday";
                    break;
                case 3:
                    result = "Tueday";
                    break;
                case 4:
                    result = "Wednesday";
                    break;
                case 5:
                    result = "Thursday";
                    break;
                case 6:
                    result = "Friday";
                    break;
                case 7:
                    result = "Saturday";
                    break;
            }
            return result;
        }

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
