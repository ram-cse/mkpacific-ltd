using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSite.Models.DAO
{
    public class StoreManagerDAO
    {
        public static bool AddNew(StoreManager newStoreManager)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            db.StoreManagers.AddObject(newStoreManager);
            db.SaveChanges();
            db.Connection.Close();
            return true;
        }

        internal static List<StoreManager> GetList()
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            List<StoreManager> result = db.StoreManagers
                .Include("InternetAccessRole")
                .Include("StoreManagerState")
                .ToList();
            db.Connection.Close();
            return result;
        }

        internal static StoreManager GetItem(int Id)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            // Get City -> chỉ dùng cho StoreManager.Information
            StoreManager result = db.StoreManagers.Include("City")
                .Where(s => s.Id == Id).Single<StoreManager>();
            db.Connection.Close();
            return result;
        }

        internal static bool ChangeLocked(int Id)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            StoreManager existStore = db.StoreManagers.Where(s => s.Id == Id).Single<StoreManager>();

            if (existStore.IsLocked == null)
            {
                existStore.IsLocked = false;
            }
            else
            {
                existStore.IsLocked = !existStore.IsLocked;
            }
            bool isLocked = (bool)existStore.IsLocked;

            db.SaveChanges();
            db.Connection.Close();
            return isLocked;
        }

        internal static StoreManager[] GetList(string statusCode)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            StoreManager[] result = db.StoreManagers
                .Include("InternetAccessRole")
                .Include("StoreManagerState")
                .Where(sm => sm.StoreManagerState.Code.Trim() == statusCode.Trim())
                .ToArray();
            db.Connection.Close();
            return result;
        }

        internal static bool Update(StoreManager storeManager)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            StoreManager exitSM = db.StoreManagers
                .Where(s => s.Id == storeManager.Id)
                .Single<StoreManager>();

            ///exitSM.Id = storeManager.Id;

            exitSM.Address = storeManager.Address;
            exitSM.Address2 = storeManager.Address2;
            
            exitSM.CityId = storeManager.CityId;                                    
            
            exitSM.Country = storeManager.Country;
            exitSM.CreateDate = storeManager.CreateDate;
            exitSM.EmailAlert = storeManager.EmailAlert;
            exitSM.EmailBill = storeManager.EmailBill;

            exitSM.IdShop = storeManager.IdShop;
            exitSM.IsLocked = storeManager.IsLocked;
            exitSM.LastCollectDate = storeManager.LastCollectDate;
            exitSM.LegalStructure = storeManager.LegalStructure;
            exitSM.ManagerPhone = storeManager.ManagerPhone;
            exitSM.Name = storeManager.Name;
            exitSM.NameOfCompany = storeManager.NameOfCompany;
            exitSM.NameOfStore = storeManager.NameOfStore;
            exitSM.NumberOfShop = storeManager.NumberOfShop;
            exitSM.Password = storeManager.Password;
            exitSM.Phone = storeManager.Phone;
            exitSM.Phone2 = storeManager.Phone2;
            exitSM.Product = storeManager.Product;
            exitSM.ShopSize = storeManager.ShopSize;
            exitSM.StatusId = storeManager.StatusId;
            exitSM.StoreInternetAccessId = storeManager.StoreInternetAccessId;
            exitSM.Username = storeManager.Username;
            exitSM.VATNumber = storeManager.VATNumber;
            exitSM.WebSite = storeManager.WebSite;
            exitSM.Zip = storeManager.Zip;
            
            db.SaveChanges();
            db.Connection.Close();
            return true;

        }
    }
}