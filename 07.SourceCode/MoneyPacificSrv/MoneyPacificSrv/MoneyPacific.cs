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
            string smsResponse =  "Server is busy!..";
            

            // Phân tích để lấy command & arguments

            string sCommand = "";
            smsContent = smsContent.Trim(' ');
            string[] arrArg = smsContent.Split('*');
            sCommand = arrArg[0];
            
            // Get higher priorty Command
            IMPCommand mpCommand;

            if (Validator.isPhoneNumber(sCommand) && (arrArg.Length == 5))
            {
                sCommand = "BUY";                
            }
            else if (Validator.isPacificCode(sCommand))
            {
                sCommand = "CHECK_VALUE";
            }

            // Create Command and Execute
            
            if (sCommand == "BUY")
            {   
                mpCommand = new BuyPacificCodeCmd();
            }
            else if(sCommand == "PAY")
            {
                mpCommand = new UnderContructionCmd();
                smsResponse = "PAY - ";
            }
            else if (sCommand == "TRANFER")
            {
                mpCommand = new UnderContructionCmd();
                smsResponse = "TRANFER - ";
            }
            else if (sCommand == "MERGE")
            {
                mpCommand = new UnderContructionCmd();
                smsResponse = "MERGE - ";
            }
            else
            {
                mpCommand = new UnderContructionCmd();
                smsResponse = sCommand;
            }
            
            smsResponse += mpCommand.Execute(arrArg);


            return smsResponse;
        }

        private static string buyNewPacificCode(string[] arrArguments)
        {

            return "Error argument!...";
        }
    }
}