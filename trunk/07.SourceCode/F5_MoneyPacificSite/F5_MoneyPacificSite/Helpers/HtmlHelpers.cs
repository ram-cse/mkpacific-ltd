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

        public static string insertSeparateChar(this HtmlHelper helper, string sCodeNumber, char c, int l)
        {
            string sResult = "";
            sCodeNumber = sCodeNumber.Trim();
            for (int i = 0; i * l < sCodeNumber.Length; i++)
            {
                if ((i + 1) * l >= sCodeNumber.Length)
                {
                    sResult += sCodeNumber.Substring(i * l, sCodeNumber.Length - i * l);
                }
                else
                {
                    sResult += sCodeNumber.Substring(i * l, l) + c;
                }
            }
            return sResult;
        }
    }
}