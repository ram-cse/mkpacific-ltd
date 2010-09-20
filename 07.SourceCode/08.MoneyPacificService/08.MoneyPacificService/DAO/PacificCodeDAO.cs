using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService.DTO;

namespace _08.MoneyPacificService.DAO
{
    public class PacificCodeDAO
    {
        // Tất cả các lớp DAO đều sử dụng biến này, cần tạo một nơi để gọi các hàm xử lý chung
        // cho Server đỡ tốn RAM

        private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static void AddNew(DTO.PacificCode newPacificCode)
        {
            mpdb.PacificCodes.InsertOnSubmit(newPacificCode);
            mpdb.SubmitChanges();
        }
    }
}