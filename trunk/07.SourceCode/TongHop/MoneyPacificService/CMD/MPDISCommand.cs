using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificService.BUS;

namespace MoneyPacificService.CMD
{
    internal class MPDISCommand : AMPCommand
    {
        /// <summary>
        /// MPDAY: cú pháp
        /// args[0] = Sender's Phone
        /// args[1] = MPDIS
        /// args[2] = one of StoreUseres' PINStore 
        /// </summary>
        internal override string Execute()
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
    }
}