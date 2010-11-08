using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using P4_MoneyPacificSite.ViewModels;
using P4_MoneyPacificSite.Models.DAO;

namespace P4_MoneyPacificSite.Models.BUS
{
    public class StoreManagerBUS
    {
        public static bool AskTobeParnerStore(StoreViewModel storeInfo)
        {
            StoreManager newStoreManager = new StoreManager();

            newStoreManager.Name = storeInfo.Name;
            newStoreManager.NameOfStore = storeInfo.NameOfStore;
            newStoreManager.Address = storeInfo.Address;
            newStoreManager.Address2 = storeInfo.Address02;
            newStoreManager.Zip = storeInfo.Zip;
            newStoreManager.Town = storeInfo.Town;
            newStoreManager.Country = storeInfo.Coutry;
            newStoreManager.Phone = storeInfo.Phone;
            newStoreManager.Phone2 = storeInfo.Phone02;
            newStoreManager.EmailAlert = storeInfo.Email;
            newStoreManager.WebSite = storeInfo.WebSite;

            newStoreManager.Product = storeInfo.Product;
            newStoreManager.ShopSize = storeInfo.ShopSize;
            newStoreManager.NumberOfShop = storeInfo.NumberOfShop;

            newStoreManager.LegalStructure = storeInfo.LegalStructure;
            newStoreManager.NameOfCompany = storeInfo.NameOfCompany;
            newStoreManager.VATNumber = storeInfo.VATNumber;
            
            // Status

            newStoreManager.StatusId = StoreManagerStateDAO.getId("09");
            newStoreManager.StoreInternetAccess = 9;

            return StoreManagerDAO.AddNew(newStoreManager);
        }

        internal static StoreManager[] GetList()
        {
            return StoreManagerDAO.GetList();
        }

        internal static StoreManager GetItem(int Id)
        {
            return StoreManagerDAO.GetItem(Id);

        }

        internal static void UpdateStore(StoreManager model)
        {
            StoreManagerBUS.UpdateStore(model);
        }

        internal static DateTime GetLastTransactionDate(int ManagerId)
        {
            StoreUser[] lstStoreUser = StoreUserDAO.GetList(ManagerId);

            DateTime lastDate = DateTime.MinValue;
            foreach (StoreUser u in lstStoreUser)
            {
                if (u.LastDate != null)
                {
                    if (u.LastDate > lastDate) lastDate = (DateTime)u.LastDate;
                }
            }
            return lastDate;
        }



        internal static int GetTotalLastMonthAmount(int ManagerId)
        {
            StoreUser[] lstStoreUser = StoreUserDAO.GetList(ManagerId);
            int iTotal = 0;
            
            foreach (StoreUser u in lstStoreUser)
            {
                iTotal += StoreUserDAO.GetTotalLastMonthAmount(u.Id);
            }
            return iTotal;

        }

        internal static int GetTotalLastMonthTransaction(int ManagerId)
        {
            StoreUser[] lstStoreUser = StoreUserDAO.GetList(ManagerId);
            int iCount = 0;

            foreach (StoreUser u in lstStoreUser)
            {
                iCount += StoreUserDAO.GetTotalLastMonthTranSaction(u.Id);
            }
            return iCount;
        }

        internal static bool ChangeLocked(int Id)
        {
            return StoreManagerDAO.ChangeLocked(Id);
        }
    }
}