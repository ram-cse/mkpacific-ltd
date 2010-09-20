using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService.DAO;
using _08.MoneyPacificService.DTO;

namespace _08.MoneyPacificService.BUS
{
    public class CustomerBUS
    {
        // Thêm một Customer mới với số điện thoại mới
        internal static int AddNew(String sPhoneNumber)
        {
            if (CustomerDAO.checkExist(sPhoneNumber) == true)
            {
                // Đã tồn tại, không thêm khách hàng nào hết
                return 0;                
            }
            else {
                return CustomerDAO.AddNew(sPhoneNumber);
            }
            
        }

        internal static Customer getCustomer(string sPhoneNumber)
        {
            return CustomerDAO.getCustomer(sPhoneNumber);
        }

        internal static bool checkCustomer(DTO.Customer buyerCustomer)
        {
            // Check STATUS_Customer
            return true;
        }
    }
}