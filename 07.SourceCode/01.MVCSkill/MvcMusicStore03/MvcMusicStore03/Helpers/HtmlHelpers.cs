using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore03.Helpers
{
    public static class HtmlHelpers
    {
        public static string Truncate(this HtmlHelper helper, string input, int lengh)
        {
            if (input.Length <= lengh)
            {
                return input;
            }
            else
            {
                return input.Substring(0, lengh) + "...";
            }
        }
    }
}