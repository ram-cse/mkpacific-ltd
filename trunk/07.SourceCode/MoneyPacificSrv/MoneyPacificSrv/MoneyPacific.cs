using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            // Chưa sử dụng tính Đa hình
            // Not yet use Polymorphic 

            if (Validator.isPhoneNumber(sCommand))
            {
                smsResponse = buyNewPacificCode(arrArg);
            }
            else if(sCommand == "PAY")
            {
                smsResponse = "This Function is UnderConstruction!..";
            }
            else if (sCommand == "TRANFER")
            {
                smsResponse = "This Function is UnderConstruction!..";
            }
            else if (sCommand == "MERGE")
            {
                smsResponse = "This Function is UnderConstruction!..";
            }
            else
            {
                smsResponse = "This Function is UnderConstruction!..";
            }

            return smsResponse;
        }

        private static string buyNewPacificCode(string[] arrArguments)
        {

            return "Error argument!...";
        }
    }
}