using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F5_MoneyPacificSite.Models.DAO
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

        internal static StoreManager[] GetList()
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            StoreManager[] result = db.StoreManagers.ToArray();
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
    }
}