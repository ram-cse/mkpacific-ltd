using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.BUS;
using MoneyPacificSrv.DTO;
using MoneyPacificSrv.General;

namespace MoneyPacificSrv.Cmd
{
    public class MPDAYCommand : IMPCommand
    {
        #region IMPCommand Members

        /// <summary>
        /// MPDAY: Trả ra tổng số Transaction trong ngày
        /// args[0]: Phone của StoreUser hoặc StoreManager
        /// args[1]: MPDAY
        /// args[2]: PINStore
        /// </summary>
        [Authorize(Roles = "StoreManager, StoreUser")]
        public string Execute(string[] args)
        {
            string sPhone = args[0].Trim();
            string sPINStore = args[2].Trim();
            string sReceivePhone = sPhone;
            string sContentSMS = "";            
            int iTotal = 0;

            StoreManager existStoreManager = null ;
            bool isValidate = false;

            /// Kiem tra quyền
            if (StoreUserBUS.IsExist(sPhone))
            {
                if (StoreUserBUS.Validate(sPhone, sPINStore))
                {
                    StoreUser existStore = StoreUserBUS.GetItem(sPhone);
                    isValidate = StoreUserBUS.Validate(sPhone, sPINStore);
                    existStoreManager = StoreManagerBUS.GetItem((int)existStore.ManagerId);                    
                }
            }
            else if (StoreManagerBUS.IsExist(sPhone))
            {
                existStoreManager = StoreManagerBUS.GetItem(sPhone);
                isValidate = StoreManagerBUS.Validate(sPhone, sPINStore);
            }
            else
            {   
                isValidate = false;
            }

            /// Tính tổng
            if (isValidate)
            {
                List<StoreUser> lstUser = StoreUserBUS.GetArray(existStoreManager.Id).ToList<StoreUser>();
                foreach (StoreUser u in lstUser)
                {
                    iTotal += StoreUserBUS.GetTotalTransaction(u.Id);
                }

                sContentSMS = "TOTAL TRANSACTION:" + iTotal;
            }
            else 
            {
                sContentSMS = MessageManager.GetValue("MPDAY_GET_COLLECT_CODE_ERROR");
            }
                
            return sReceivePhone + "*" + sContentSMS;            
        }

        #endregion
    }
}