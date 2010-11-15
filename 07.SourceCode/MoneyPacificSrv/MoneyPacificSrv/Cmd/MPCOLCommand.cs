using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSrv.Cmd
{
    public class MPCOLCommand : IMPCommand
    {
        #region IMPCommand Members

        /// <summary>
        /// MPCOL: Thanh toán TOÀN BỘ số tiền chưa trả cho Money PacificCode
        /// Cú Pháp: args[0]*MPCOL*args[2]
        
        /// args[0]: Phone của StoreUser hoặc StoreManager
        /// args[1]: MPDAY
        /// args[2]: PINStore
        
        /// Giải thuật:
        /// Lấy số Phone của Store Manager
        /// Kiểm tra PINStore từ các StoreUser 
        /// Lấy iTotalAmount của SM        
        /// Lấy iCollected
        /// Amount = iTotalAmount - iCollected
        /// Kiểm tra ExpireDate & CreateDate
        /// => Chuyển status thành Collected
        /// </summary>
        public string Execute(string[] args)
        {
            return "UNDERCONSTRUCTION...";
        }

        #endregion
    }
}