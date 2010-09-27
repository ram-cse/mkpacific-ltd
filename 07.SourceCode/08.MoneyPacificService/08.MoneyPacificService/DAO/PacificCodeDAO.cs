using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService.DTO;

namespace _08.MoneyPacificService.DAO
{
    public class PacificCodeDAO
    {
        // Tất cả các lớp DAO đều sử dụng biến này, 
        // khởi tạo tại một nơi để sử dụng chung
        

        private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static int AddNew(PacificCode pacificCode)
        {
            int resultID = 0;
            mpdb.PacificCodes.InsertOnSubmit(pacificCode);            
            mpdb.SubmitChanges();
            resultID = pacificCode.ID;
            return resultID;
        }

        internal static bool checkExist(string sPacificCode)
        {
            return mpdb.PacificCodes.Where(p => p.PacificCode1.Trim() == sPacificCode.Trim()).Any();
        }
    }
}