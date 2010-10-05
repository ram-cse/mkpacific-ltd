using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.Cmd;
using MoneyPacificSrv.Util;
using MoneyPacificSrv.DTO;
using MoneyPacificSrv.BUS;

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

            // Check BLACK LIST
            string senderPhone = arrArg[0];
            bool bLocked = false;

            if (Validator.isPhoneNumber(senderPhone))
            {
                if (CustomerBUS.isInBlackList(senderPhone))
                {
                    return "0*" + MessageManager.getValue("BLACK_LIST");                 
                }

                bLocked = CustomerBUS.isLockedCustomer(senderPhone);
                if (bLocked)
                {
                    smsResponse = "0*" + MessageManager.getValue("LOCKED_CUSTOMER");
                }

            }

            // The first argument alway is the phonenumber
            sCommand = arrArg[1];

            IMPCommand mpCommand;
            
            if (Validator.iPassStore(sCommand) && (arrArg.Length == 5))
            {
                sCommand = "BUY";
                bLocked = false; // cho phép mua
            }
            else if (Validator.isPacificCode(sCommand))
            {
                sCommand = "VALUE";                
            }

            if (bLocked) return smsResponse;

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

            //DTO.DBMoneyPacificDataContext storedb = new DTO.DBMoneyPacificDataContext();
            //List<Store> pCode = storedb.Stores.ToList<Store>();
            //return "finished!.. test..12..";

            smsResponse += mpCommand.Execute(arrArg);
            return smsResponse;
        }
    }
}