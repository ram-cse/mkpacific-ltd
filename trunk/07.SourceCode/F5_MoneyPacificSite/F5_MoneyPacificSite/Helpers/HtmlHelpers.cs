using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace F5_MoneyPacificSite.Helpers
{
    public static class HtmlHelpers
    {
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }

        public static string insertSeparateChar(this HtmlHelper helper, string sOrginal, char c, int l)
        {
            string sResult = "";
            sOrginal = sOrginal.Trim();
            for (int i = 0; i * l < sOrginal.Length; i++)
            {
                if ((i + 1) * l >= sOrginal.Length)
                {
                    sResult += sOrginal.Substring(i * l, sOrginal.Length - i * l);
                }
                else
                {
                    sResult += sOrginal.Substring(i * l, l) + c;
                }
            }
            return sResult;
        }

        public static string formatMoney(this HtmlHelper helper, int amount, char c)
        {
            string sResult = amount.ToString();
            for (int i = sResult.Length - 1; i >= 0; i--)
            {
                sResult = sResult[i] + sResult;
                int j = sResult.Length - i;
                if ((j % 3 == 0) & i != 0)
                {
                    sResult = ',' + sResult;
                }
            }
            return sResult;
        }
        public static string formatMoney(this HtmlHelper helper, int amount)
        {
            char c = ',';
            string sAmount = amount.ToString();
            string sResult = "";
            for (int i = sAmount.Length - 1; i >= 0; i--)
            {
                sResult = sAmount[i] + sResult;
                int j = sAmount.Length - i;
                if ((j % 3 == 0) & i != 0)
                {
                    sResult = c + sResult;
                }
            }
            return sResult;
        }

        public static string GetDay(int id)
        {
            string result = "";
            switch(id){
                case 1:
                    result = "Sunday";
                    break;
                case 2:
                    result = "Monday";
                    break;
                case 3:
                    result = "Tueday";
                    break;
                case 4:
                    result = "Wednesday";
                    break;
                case 5:
                    result = "Thursday";
                    break;
                case 6:
                    result = "Friday";
                    break;                    
                case 7:
                    result = "Saturday";
                    break;
            }            
            return result;
        }

    }
}