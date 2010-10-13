using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public static PacificCode SendMoney(string CodeNumber, string Phone, int Amount)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            bool bExist = db.PacificCodes.Where
                (p=>p.CodeNumber.Trim() == CodeNumber.Trim()).Any();
            
            if (bExist)
            {
                PacificCode pacificCode = db.PacificCodes.Where
                    (p => p.CodeNumber.Trim() == CodeNumber.Trim()).Single<PacificCode>();

                if (pacificCode.InitialAmount > Amount)
                {
                    PacificCode newPacificCode = db.PacificCodes.CreateObject();

                    pacificCode.InitialAmount -= Amount;
                    newPacificCode.InitialAmount = Amount;
                    
                    //Customer

                    return newPacificCode;
                }
            }
            return null;
        }
    }
}