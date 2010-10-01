using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.Cmd;
using MoneyPacificSrv.Util;

namespace MoneyPacificSrv
{
    public class MoneyPacific
    {
        internal static string getRequest(string smsContent)
        {
            string smsResponse = "";
            string sCommand = "";


            // Phân tích để lấy command & arguments            
            smsContent = smsContent.Trim(' ');
            string[] arrArg = smsContent.Split('*');

            if (arrArg.Count() <= 1) return "Invalid Command";

            // The first argument alway is the phonenumber
            sCommand = arrArg[1];
            
            IMPCommand mpCommand;

            //if (Validator.isPhoneNumber(sCommand) && (arrArg.Length == 5))
            
            if (Validator.iPassStore(sCommand) && (arrArg.Length == 5))
            {
                sCommand = "BUY";
            }
            else if (Validator.isPacificCode(sCommand))
            {
                sCommand = "VALUE";                
            }

            // Create Command and Execute            
            if (sCommand == "BUY")
            {   
                mpCommand = new BuyPacificCodeCmd();
            }
            else if (sCommand == "VALUE")
            {
                mpCommand = new ValueDetailCmd();                
            }            
            else
            {
                mpCommand = new UnderContructionCmd();
                smsResponse = sCommand + " - ";
            }
            
            smsResponse += mpCommand.Execute(arrArg);
            return smsResponse;
        }
    }
}