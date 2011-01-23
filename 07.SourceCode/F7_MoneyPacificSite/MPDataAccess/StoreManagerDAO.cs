using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class StoreManagerDAO
    {
        public static StoreManager GetObject(Guid userId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            StoreManager obj= mpdb.StoreManagers
                .Where(s => s.UserId == userId)
                .Single<StoreManager>();
            mpdb.Connection.Close();
            return obj;
        }

        public static StoreManager GetObject(string phoneNumber)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            StoreManager obj = mpdb.StoreManagers
                .Where(s => s.ManagerPhone.Trim().Equals(phoneNumber.Trim()))
                .Single<StoreManager>();
            mpdb.Connection.Close();
            return obj;
        }

        public static bool AddNew(StoreManager entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Update(StoreManager entity)
        {
            //throw new Exception("chua lam!...");
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            StoreManager existSM = mpdb.StoreManagers
                .Where(s => s.UserId.Equals(entity.UserId))
                .Single<StoreManager>();

            existSM.Address = entity.Address;
            existSM.Address2 = entity.Address2;
            existSM.AreaId = entity.AreaId;
            existSM.Country = entity.Country;
            existSM.EmailBill = entity.EmailBill;
            existSM.IdShop = entity.IdShop;
            existSM.IsLocked = entity.IsLocked;
            existSM.LastCollectDate = entity.LastCollectDate;
            existSM.LegalStructure = entity.LegalStructure;
            existSM.ManagerPhone = entity.ManagerPhone;
            existSM.NameOfCompany = entity.NameOfCompany;
            existSM.NameOfStore = entity.NameOfStore;
            existSM.NumberOfShop = entity.NumberOfShop;
            existSM.Phone = entity.Phone;
            existSM.Phone2 = entity.Phone2;
            existSM.Product = entity.Product;
            existSM.ShopSize = entity.ShopSize;
            existSM.StatusId = entity.StatusId;
            existSM.StoreInternetAccessId = entity.StoreInternetAccessId;
            existSM.UserId = entity.UserId;
            existSM.VATNumber = entity.VATNumber;
            existSM.Website = entity.Website;
            existSM.Zip = entity.Zip;

            mpdb.SubmitChanges();          

            mpdb.Connection.Close();
            return true;
        }

        public static bool Remove(Guid id)
        {
            throw new Exception("chua lam!...");
        }

        public static List<StoreManager> GetList()
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            List<StoreManager> result = mpdb.StoreManagers.ToList<StoreManager>();
            mpdb.Connection.Close();
            return result;
        }

        public static List<StoreManager> GetList(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static StoreManager[] GetArray()
        {
            throw new Exception("chua lam!...");
        }

        public static StoreManager[] GetArray(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static bool IsExist(string phoneNumber)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            bool result = mpdb.StoreManagers
                .Any(s => s.ManagerPhone.Trim() == phoneNumber.Trim());
            mpdb.Connection.Close();
            return result;
        }
    }
}
