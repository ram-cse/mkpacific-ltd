using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P4_MoneyPacificSite.Models.BUS;
using P4_MoneyPacificSite.Models;
using P4_MoneyPacificSite.ViewModels;

namespace P4_MoneyPacificSite.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            //return BrowseStores();
            return View();
        }
            
        public ActionResult BrowseStores()
        {
            var model = StoreManagerBUS.GetList();            
            return View(model);
        }

        public ActionResult DetailStore(int Id)
        {
            var model = StoreManagerBUS.GetItem(Id);
            return View(model);
        }

        public ActionResult EditStore(int Id)
        {
            var model = StoreManagerBUS.GetItem(Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditStore(StoreManager model)
        {
            StoreManagerBUS.UpdateStore(model);
            return View();
        }

        public ActionResult CollectNumber()
        {
            CollectNumberModel model = new CollectNumberModel();
            List<StoreManagerAmountModel> lstStoreManagerAmount = new List<StoreManagerAmountModel>();
            List<StoreManager> lstStoreManager = StoreManagerBUS.GetList().ToList();
            
            foreach(StoreManager storeManager in lstStoreManager)
            {
                StoreManagerAmountModel item = new StoreManagerAmountModel();
                item.Id = storeManager.Id;

                if (storeManager.IdShop == null)
                {
                    item.IdShop = 0;
                }
                else
                {
                    item.IdShop = (int)storeManager.IdShop;
                }

                
                item.Address = (string)storeManager.Address;

                List<StoreUser> lstStoreUser = StoreUserBUS.GetList(item.Id).ToList();
                int iBalance = 0;
                foreach (StoreUser u in lstStoreUser)
                {
                    iBalance += PacificCodeBUS.GetTotalAmount(u.Id);
                }

                item.Balance = iBalance;
                item.Checked = true;

                lstStoreManagerAmount.Add(item);
            }
            
            model.lstManagerAmount = lstStoreManagerAmount;
            model.lstAgent = AgentBUS.GetLisṭ̣().ToList();
            return View(model);
        }
    }
}
