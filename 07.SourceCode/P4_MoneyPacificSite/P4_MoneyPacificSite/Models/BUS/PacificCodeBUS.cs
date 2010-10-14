using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P4_MoneyPacificSite.Models.DAO;



namespace P4_MoneyPacificSite.Models.BUS
{
    public class PacificCodeBUS
    {
        /*
        * Gửi tiền  cho một số một khách hàng khác
        * - Kiểm tra tiền tồn tại trong tài khoản gửi
        * - Trừ tiền gửi
        * - Tạo một tài khoản bằng với số tiền vừa trừ
        * - Tài khoản mới tạo có số phone khách hàng là số phone truyền vào
        * - Trả ra PacificCode mới 
        * */
        public static PacificCode SendMoney(string CodeNumber, string Phone, double Amount)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            bool bExist = db.PacificCodes.Where
                (p=>p.CodeNumber.Trim() == CodeNumber.Trim()).Any();
            
            PacificCode newPacificCode = null;

            if (bExist)
            {
                PacificCode pacificCode = db.PacificCodes.Where
                    (p => p.CodeNumber.Trim() == CodeNumber.Trim()).Single<PacificCode>();

                if (pacificCode.ActualAmount > Amount)
                {
                    newPacificCode = new PacificCode();

                    newPacificCode.CodeNumber = "1111222233334444"; // Thay bằng GenerateCode

                    pacificCode.ActualAmount -= (int)Amount;
                    newPacificCode.InitialAmount = (int)Amount;
                    newPacificCode.ActualAmount = (int)Amount;

                    newPacificCode.ExpireDate = new DateTime(
                        DateTime.Now.Year + 1,
                        DateTime.Now.Month,
                        DateTime.Now.Day
                        );

                    Customer receiverCustomer = CustomerBUS.getCustomerOrCreateNotYetBuy(Phone);
                    newPacificCode.CustomerID = receiverCustomer.ID;
                    // Không có storeId

                    db.PacificCodes.AddObject(newPacificCode);
                }
            }
            db.SaveChanges();
            db.Connection.Close();
            return newPacificCode;
        }


        internal static PacificCode getLastPacificCode(int customerId)
        {
            return PacificCodeDAO.getLastPacificCode(customerId);
        }
    }
}