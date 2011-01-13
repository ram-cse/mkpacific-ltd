using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificService.Util;
using MoneyPacificService.CMD;

namespace MoneyPacificService
{
    public class MoneyPacific
    {
        private static MPGuard _guard = new MPGuard();
        /// <summary>
        /// Xac dinh lenh, va goi ham thuc thi từ Guard
        /// </summary>
        internal static string SendMessage(string smsContent)
        {

            string smsResponse = "";
            string sCommand = "";


            // Phân tích để lấy command & arguments            
            smsContent = smsContent.Trim(' ');
            string[] arrArg = smsContent.Split('*');

            if (arrArg.Count() <= 1) return "Invalid Command";
            arrArg[0] = Utility.formatPhone(arrArg[0]);


            /// INVOKER
            Invoker invoker = new Invoker(arrArg[0]);
            bool bLocked = false;
            if (invoker.IsInBlackList())
            {
                return "0*" + MessageManager.GetValue("BLACK_LIST");
            }
            else if (invoker.IsLockedCustomer())
            {
                bLocked = invoker.IsLockedCustomer();
                smsResponse = "0*" + MessageManager.GetValue("LOCKED_CUSTOMER");
            }

            /// COMMAND
            AMPCommand mpCommand;
            sCommand = arrArg[1];

            if (Validator.isPINStore(sCommand) && (arrArg.Length == 5))
            {
                sCommand = "BUY";
                bLocked = false; // cho phép mua
            }
            else if (Validator.isPacificCode(sCommand))
            {
                sCommand = "VALUE";
            }

            if (bLocked) return smsResponse;

            // Xac dinh lenh...
            if (sCommand == "BUY")
            {
                mpCommand = new MPBUYCommand();
            }
            else if (sCommand == "VALUE")
            {
                mpCommand = new MPVALCommand();
            }
            else if (sCommand == "MPBAL")
            {
                mpCommand = new MPBALCommand();
            }
            else if (sCommand == "MPDAY")
            {
                mpCommand = new MPDAYCommand();
            }
            else if (sCommand == "MPDIS")
            {
                mpCommand = new MPDISCommand();
            }
            else if (sCommand == "MPENA")
            {
                mpCommand = new MPENACommand();
            }
            else if (sCommand == "MPCOL")
            {
                mpCommand = new MPCOLCommand();
            }
            else
            {
                mpCommand = new UMPCommand();
                smsResponse = sCommand + " - ";
            }

            mpCommand.SetArgs(arrArg);

            _guard.Command = mpCommand;
            smsResponse += _guard.Execute();

            /// END
            return smsResponse;
        }

        internal static PaymentModel MakePayment(List<string> LstCodeNumber, int Amount)
        {
            throw new NotImplementedException();
        }
    }
}