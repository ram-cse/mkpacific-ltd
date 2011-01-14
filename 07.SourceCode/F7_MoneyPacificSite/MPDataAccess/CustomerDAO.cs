using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class CustomerDAO
    {
        public static Customer GetObject(Guid customerUserId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            Customer existCustomer = mpdb.Customers
                .Where(c => c.UserId.Equals(customerUserId))
                .Single<Customer>();
            mpdb.Connection.Close();
            return existCustomer;
        }

        public static bool AddNew(Customer entity)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            mpdb.Customers.InsertOnSubmit(entity);
            mpdb.SubmitChanges();
            mpdb.Connection.Close();
            return true;
        }

        public static bool Update(Customer entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Remove(Guid id)
        {
            throw new Exception("chua lam!...");
        }

        public static List<Customer> GetList()
        {
            throw new Exception("chua lam!...");
        }

        public static List<Customer> GetList(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static Customer[] GetArray()
        {
            throw new Exception("chua lam!...");
        }

        public static Customer[] GetArray(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        //
        public static bool IsExist(string phoneNumber)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            bool result = mpdb.Customers.Any(c => c.PhoneNumber.Trim() == phoneNumber.Trim());
            mpdb.Connection.Close();
            return result;
        }

        public static Customer GetObject(string phoneNumber)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            Customer existCustomer = mpdb.Customers
                .Where(c => c.PhoneNumber.Trim().Equals(phoneNumber.Trim()))
                .Single<Customer>();
            mpdb.Connection.Close();
            return existCustomer;
        }

        public static void SetStatus(Guid customerUserId, string status)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();

            // Customer existCustomer = CustomerDAO.getCustomer(customerId); // LAY từ mpdb khác sẽ ko có tác dụng nếu có xử lý
            Customer existCustomer = mpdb.Customers
                .Where(c => c.UserId.Equals(customerUserId))
                .Single<Customer>();

            string oldStatus = CustomerStateDAO.GetObject((int)existCustomer.StatusId).Code;

            // VD: set Status = x32, x33...
            if (status[0] == 'x')
                status = oldStatus[0] + status.Substring(1, status.Length - 1);

            existCustomer.StatusId = CustomerStateDAO.GetObject(status).Id;
            mpdb.SubmitChanges();

            mpdb.Connection.Close();

        }
    }
}
