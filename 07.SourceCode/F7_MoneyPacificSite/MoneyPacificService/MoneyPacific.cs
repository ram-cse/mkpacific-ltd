using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificService.DTO;

namespace MoneyPacificService
{
    /// <summary>
    /// Gate Class
    /// </summary>
    public class MoneyPacific
    {
        /// <summary>
        /// Xac dinh lenh, va goi ham thuc thi từ Guard
        /// </summary>
        /// <param name="smsContent"></param>
        /// <returns></returns>
        internal static string SendMessage(string smsContent)
        {
            
            string smsResponse = "";
            string sCommand = "";


            // Phân tích để lấy command & arguments            
            smsContent = smsContent.Trim(' ');
            string[] arrArg = smsContent.Split('*');


            return "null";
        }

        internal static PaymentModel MakePayment(List<string> LstCodeNumber, int Amount)
        {
            throw new NotImplementedException();
        }
    }
}
    