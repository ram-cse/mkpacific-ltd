using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class CustomerDAO
    {
        public static Customer GetObject(Guid id)
        {
            throw new NotImplementedException();
        }

        public static bool AddNew(Customer entity)
        {
            DataAccessLayer.mpdb.Customers.InsertOnSubmit(entity);
            DataAccessLayer.mpdb.SubmitChanges();
            return true;
        }

        public static bool Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public static bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public static List<Customer> GetList()
        {
            throw new NotImplementedException();
        }

        public static List<Customer> GetList(bool condition)
        {
            throw new NotImplementedException();
        }

        public static Customer[] GetArray()
        {
            throw new NotImplementedException();
        }

        public static Customer[] GetArray(bool condition)
        {
            throw new NotImplementedException();
        }

        //
        public static bool IsExist(string phoneNumber)
        {
            return DataAccessLayer.mpdb.Customers.Any(c => c.PhoneNumber.Trim() == phoneNumber.Trim());
        }

        public static Customer GetObject(string phoneNumber)
        {
            return DataAccessLayer.mpdb.Customers
                .Where(c => c.PhoneNumber.Trim().Equals(phoneNumber.Trim()))
                .Single<Customer>();
        }
    }
}
