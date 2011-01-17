using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSite.Models.DAO
{
    public class StoreUserDAO
    {
        internal static StoreUser GetItem(int Id)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            StoreUser storeUser = db.StoreUsers.Where(s => s.Id == Id).Single<StoreUser>();
            db.Connection.Close();
            return storeUser;
        }

        internal static StoreUser[] GetArray(int ManagerId)
        {
            MoneyPacificEntities mpdb = new MoneyPacificEntities();
            StoreUser[] lstUser = mpdb.StoreUsers
                .Include("StoreUserState")
                .Where(s => s.ManagerId == ManagerId).ToArray();
            mpdb.Connection.Close();
            return lstUser;
        }

        /// <summary>
        /// Lấy tất cả các PacificCode được mua bởi StoreUser này, 
        /// ở trong tháng. Tính tổng tất cả InitialAmount 
        /// </summary>        
        internal static int GetTotalLastMonthAmount(int storeId)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            int iTotalAmount = 0;

            /// TODO: Sua theo ben MoneyPacificSrv cho chính xác
            iTotalAmount = (from p in db.PacificCodes
                            where p.StoreId == storeId
                            select (int)p.InitialAmount).DefaultIfEmpty().Sum();

            db.Connection.Close();
            return iTotalAmount;
        }

        internal static int GetTotalLastMonthTranSaction(int storeUserId)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();

            int iCount = 0;
            iCount = (from p in db.PacificCodes
                      where (p.StoreId == storeUserId
                             && ((DateTime)p.Date).Month == DateTime.Now.Month
                             && ((DateTime)p.Date).Year == DateTime.Now.Year)
                      select p.Id).Count();

            db.Connection.Close();
            return iCount;
        }

    }
}