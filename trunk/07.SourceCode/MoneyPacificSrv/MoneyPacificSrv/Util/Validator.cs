using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

internal enum PHONE_NUMBER
{ 
    MIN = 10,
    MAX = 20
}

namespace MoneyPacificSrv.Util
{
    public class Validator
    {
        public static bool isPhoneNumber(string sPhoneNumber)
        {
            bool bResult = true;

            bResult = bResult && (sPhoneNumber.Length <= (int)PHONE_NUMBER.MAX) && (sPhoneNumber.Length >= (int)PHONE_NUMBER.MIN);

            for (int i = 0; i < sPhoneNumber.Length; i++)
            {
                bResult = bResult && Char.IsDigit(sPhoneNumber[i]);
            }

            return bResult;
        }

        internal static bool isNumber(string s)
        {
            bool bResult = true;
            foreach (char c in s)
            {
                bResult = bResult && char.IsDigit(c);
            }
            return bResult;
        }
    }
}