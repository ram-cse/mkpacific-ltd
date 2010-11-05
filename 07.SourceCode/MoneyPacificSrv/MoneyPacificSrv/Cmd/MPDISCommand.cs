using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.General;
using MoneyPacificSrv.BUS;

namespace MoneyPacificSrv.Cmd
{
    public class MPDISCommand : IMPCommand
    {
        #region IMPCommand Members

        /// <summary>
        /// MPDAY: cú pháp
        /// args[0] = Sender's Phone
        /// args[1] = MPDIS
        /// args[2] = one of StoreUseres' PINStore 
        /// </summary>
        [Authorize(Roles = "StoreManager")]
        public string Execute(string[] args)
        {
            string sPhone = args[0].Trim();
            string sPINStore = args[2].Trim();
            string sReceivePhone = sPhone;
            string sContentSMS = "";

            bool isValidate = StoreManagerBUS.Validate(sPhone, sPINStore);
            if (isValidate)
            {
                bool isLocked = StoreManagerBUS.Lock(sPhone, sPINStore);
                if (isLocked)
                {
                    sContentSMS = MessageManager.GetValue("MPDIS_DISABLE_SUCCESSFULL");
                }
                else
                {
                    sContentSMS = MessageManager.GetValue("MPDIS_DISABLE_ERROR");
                }
            }
            else
            {
                sContentSMS = MessageManager.GetValue("MPDIS_DISABLE_ERROR");
            }
            return sReceivePhone + "*" + sContentSMS;
        }
        #endregion
    }
}