using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificService.General;
using MoneyPacificService.BUS;

namespace MoneyPacificService.CMD
{
    internal class MPENACommand : AMPCommand
    {
        /// <summary>
        /// MPDAY: cú pháp
        /// args[0] = Sender's Phone
        /// args[1] = MPENA
        /// args[2] = one of StoreUseres' PINStore 
        /// </summary>
        [Authorize(Roles = "StoreManager")]
        internal override string Execute()
        {
            string sPhone = args[0].Trim();
            string sPINStore = args[2].Trim();
            string sReceivePhone = sPhone;
            string sContentSMS = "";

            bool isValidate = StoreManagerBUS.Validate(sPhone, sPINStore);
            if (isValidate)
            {
                bool isUnLocked = StoreManagerBUS.UnLock(sPhone, sPINStore);
                if (isUnLocked)
                {
                    sContentSMS = MessageManager.GetValue("MPENA_ENABLE_SUCCESSFULL");
                }
                else
                {
                    sContentSMS = MessageManager.GetValue("MPENA_ENABLE_ERROR");
                }
            }
            else
            {
                sContentSMS = MessageManager.GetValue("MPENA_ENABLE_ERROR");
            }
            return sReceivePhone + "*" + sContentSMS;            
        }
    }
}