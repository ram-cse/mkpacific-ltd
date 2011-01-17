using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MoneyPacificSite.Models;
using MoneyPacificSite.Models.BUS;
using MoneyPacificSite.ViewModels;

namespace MoneyPacificSite.Controllers
{
    public class AdminController : Controller
    {

        #region ACTIONS
        public ActionResult Index()
        {
            ViewData["message"] = "Admin Panel";
            return View();
        }

        public ActionResult CollectProcessing()
        {
            int statusId = CollectStateBUS.GetId("Processing");
            var model = new List<CollectMoneyView>();

            List<CollectMoney> lstCollectMoney = CollectMoneyBUS.GetListStatusId(statusId);
            foreach (CollectMoney cm in lstCollectMoney)
            {
                model.Add(new CollectMoneyView
                {
                    ManagerName = cm.StoreManager.Name,
                    ManagerPhone = cm.StoreManager.ManagerPhone,

                    Id = cm.Id,
                    CollectNumber = cm.CollectNumber,
                    IdShop = cm.StoreManager.IdShop,
                    Address = cm.StoreManager.Address,
                    Amount = cm.Amount.ToString(),
                    Agent = cm.Agent.Id + " - " + cm.Agent.FistName + cm.Agent.LastName,
                    Status = cm.CollectState.Name,
                    CreateDate = (DateTime)cm.CreateDate,
                    ExprireDate = (DateTime)cm.ExpireDate                    
                });
            }
            
            return View(model);
        }

        public ActionResult CollectedList()
        {
            int statusId = CollectStateBUS.GetId("Collected");
            var model = new List<CollectMoneyView>();

            List<CollectMoney> lstCollectMoney = CollectMoneyBUS.GetListStatusId(statusId);
            foreach (CollectMoney cm in lstCollectMoney)
            {
                model.Add(new CollectMoneyView
                {
                    ManagerName = cm.StoreManager.Name,
                    ManagerPhone = cm.StoreManager.ManagerPhone,

                    Id = cm.Id,
                    CollectNumber = cm.CollectNumber,
                    IdShop = cm.StoreManager.IdShop,
                    Address = cm.StoreManager.Address,
                    Amount = cm.Amount.ToString(),
                    Agent = cm.Agent.Id + " - " + cm.Agent.FistName + cm.Agent.LastName,
                    Status = cm.CollectState.Name,
                    CreateDate = (DateTime)cm.CreateDate,
                    ExprireDate = (DateTime)cm.ExpireDate,
                    CollectedDate = (DateTime)cm.CollecteDate
                });
            }

            return View(model);
        }
        public ActionResult ListAmount()
        {            

            List<StoreManager> storeManagers = StoreManagerBUS.GetList();
            List<StoreManagerBalanceSelect> lstObj = new List<StoreManagerBalanceSelect>();
            foreach (StoreManager sm in storeManagers)
            {
                lstObj.Add(new StoreManagerBalanceSelect
                {
                    ManagerName = sm.Name,
                    ManagerPhone = sm.ManagerPhone,

                    Id = sm.Id,
                    Area = sm.City.Name,
                    IdShop = sm.IdShop,
                    Address = sm.Address,
                    Balance = StoreManagerBUS.GetTotalLastMonthAmount(sm.Id),
                    Selected = false
                });
            }

            var model = new AdminListAmountViewModel {                                 
                StoreManagers = lstObj
            };

            model = SetAgents(model);
            

            return View(model);
        }

        private AdminListAmountViewModel SetAgents(AdminListAmountViewModel obj)
        {
            List<Agent> agents = AgentBUS.GetList();
            agents.Add(new Agent
            {
                Id = 0,
                Username = "<not yet select>",
                FistName = "",
                LastName = ""
            });
            obj.Agents = agents;
            return obj;
        }
        [HttpPost]
        public ActionResult ListAmount(AdminListAmountViewModel obj)
        {
            /// Tạo danh sách Collect Number

            bool bSuccess = true;
            foreach(StoreManagerBalanceSelect sm in obj.StoreManagers)
            {
                if (sm.Selected == true && (StoreManagerBUS.GetTotalLastMonthAmount(sm.Id)>0))
                {
                    int iStatusId = CollectStateBUS.GetId("Processing");
                    CollectMoney existCollectMoney  = 
                        CollectMoneyBUS.GetItem(sm.Id, iStatusId, DateTime.Today.Date);
                    
                    // Neu chua ton tai thi tao mới
                    if (existCollectMoney == null)
                    {
                        bSuccess = bSuccess & CollectMoneyBUS.CreateNew(sm.Id, obj.AgentIdSelected);
                    }
                    // Neu da ton tai: Processing & ExpireDate > DateTime.Now 
                    // => Edit, update
                    // Vì chỉ cho phép duy nhất 1 thành viên tạo
                    else
                    {
                        bSuccess = bSuccess & CollectMoneyBUS.Update(existCollectMoney, obj.AgentIdSelected);
                    }
                    
                }
            }

            return RedirectToAction("CollectProcessing");
            

            /// ------------------------------

            obj = SetAgents(obj);

            List<StoreManager> storeManagers = StoreManagerBUS.GetList();

            List<StoreManagerBalanceSelect> lstObj = new List<StoreManagerBalanceSelect>();

            for (int i = 0; i < storeManagers.Count; i++)
            {
                lstObj.Add(new StoreManagerBalanceSelect
                {
                    Id = storeManagers[i].Id,
                    Area = storeManagers[i].City.Name,
                    IdShop = storeManagers[i].IdShop,
                    Address = storeManagers[i].Address,
                    Balance = StoreManagerBUS.GetTotalLastMonthAmount(storeManagers[i].Id),
                    // 
                    Selected = obj.StoreManagers[i].Selected
                });
            }

            obj.StoreManagers = lstObj;            

            return View(obj);
        }

        /// <summary>
        /// Accept, denied the Store's request
        /// </summary>
        public ActionResult EditStoreManager(int id)
        {
            List<object> lstNewRoles = new List<object>();
            List<object> lstNewState = new List<object>();

            List<InternetAccessRole> lstRoles = InternetAccessRoleBUS.GetArray().ToList();
            List<StoreManagerState> lstState = StoreManagerStateBUS.GetArray().ToList();
            

            foreach( var m in lstState)
            {
                lstNewState.Add(new
                {
                    Id = m.Id,
                    Code = m.Code.Trim() + " - " + m.Name
                });
            }

            foreach (var m in lstRoles)
            {
                lstNewRoles.Add(new
                {
                    Id = m.Id,
                    Code = m.Code.Trim() + " - " + m.Name
                });
            }

            var model = new StoreManagerViewModel
            {
                storeManager = SetManagerBaseInfo(StoreManagerBUS.GetItem(id)),
                internetAccessRoles = lstNewRoles,
                storeManagerStates = lstNewState
            };          
            
            return View(model);
        }
        [HttpPost]
        public ActionResult EditStoreManager(StoreManagerViewModel obj)
        {
            StoreManager editStoreManager = SetInformation(obj.storeManager);
            bool bUpdate = StoreManagerBUS.Update(editStoreManager);
            if (bUpdate)
            {
                ViewData["message"] = "Lưu thành công!...";
                return RedirectToAction("RequestList", "Admin");                
            }
            else
            {
                ViewData["message"] = "Có lỗi xảy ra!...";
            }
            
            /// =====================
            List<object> lstNewRoles = new List<object>();
            List<object> lstNewState = new List<object>();

            List<InternetAccessRole> lstRoles = InternetAccessRoleBUS.GetArray().ToList();
            List<StoreManagerState> lstState = StoreManagerStateBUS.GetArray().ToList();


            foreach (var m in lstState)
            {
                lstNewState.Add(new
                {
                    Id = m.Id,
                    Code = m.Code.Trim() + " - " + m.Name
                });
            }

            foreach (var m in lstRoles)
            {
                lstNewRoles.Add(new
                {
                    Id = m.Id,
                    Code = m.Code.Trim() + " - " + m.Name
                });
            }

            obj.storeManagerStates = lstNewState;
            obj.internetAccessRoles = lstNewRoles;
            return View(obj);
            
        }
        
        public ActionResult RequestList()
        {
            string statusCode = "09"; // requesting
            StoreManager[] arrStoreManager = StoreManagerBUS.GetList(statusCode);
            StoreManagerBaseViewModel[] model = SetArrayManagerBaseInfo(arrStoreManager);
            return View(model);
        }

        /// <summary>
        /// Browse all the store
        /// </summary>
        public ActionResult BrowseStoreManager()
        {
            StoreManager[] arrStoreManager = StoreManagerBUS.GetList().ToArray();
            StoreManagerBaseViewModel[] model = SetArrayManagerBaseInfo(arrStoreManager);
            return View(model);
        }

        #endregion ACTIONS

        #region SERVICES
        private StoreManagerBaseViewModel SetManagerBaseInfo(StoreManager sm)
        {
            StoreManagerBaseViewModel smbase = new StoreManagerBaseViewModel();

            smbase.Id = sm.Id;
            smbase.Name = sm.Name;
            smbase.NameOfStore = sm.NameOfStore;
            smbase.Address = sm.Address;
            smbase.Town = sm.Town;
            smbase.Phone = sm.Phone;
            smbase.ManagerPhone = sm.ManagerPhone;
            smbase.Email = sm.EmailAlert;
            smbase.WebSite = sm.WebSite;

            smbase.Status = sm.StoreManagerState.Code.Trim() + " - " + sm.StoreManagerState.Name;
            smbase.StoreInternetAccessId = (int)sm.StoreInternetAccessId;//sm.InternetAccessRole.Code.Trim() + " - " + sm.InternetAccessRole.Name;
            
            if (sm.CreateDate == null) sm.CreateDate = new DateTime();
            smbase.CreateDate = (DateTime)sm.CreateDate;

            return smbase;
        }

        private StoreManagerBaseViewModel[] SetArrayManagerBaseInfo(StoreManager[] arrStoreManager)
        {
            List<StoreManagerBaseViewModel> model = new List<StoreManagerBaseViewModel>();
            foreach (StoreManager sm in arrStoreManager)
            {
                StoreManagerBaseViewModel smbase = SetManagerBaseInfo(sm);          
                model.Add(smbase);                
            }
            return model.ToArray();
        }

        private StoreManager SetInformation(StoreManagerBaseViewModel baseSM)
        {
            StoreManager sm = StoreManagerBUS.GetItem(baseSM.Id);
            
            /// UPDATE INFORMATION
            /// Username, Name, ShopID, Create Date
            /// is not allowed to changed
            
            //sm.NameOfStore = baseSM.NameOfStore;

            sm.Password = baseSM.Password;
            sm.Address = baseSM.Address;
            sm.ManagerPhone = baseSM.ManagerPhone;
            sm.EmailAlert =baseSM.Email;
            sm.WebSite = baseSM.WebSite;
            sm.Town = baseSM.Town;
            sm.Phone = baseSM.Phone;

            sm.StatusId = baseSM.StatusId;
            sm.StoreInternetAccessId = baseSM.StoreInternetAccessId;

            return sm;
        }
        #endregion SERVICES

    }
}
