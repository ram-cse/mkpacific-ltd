using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificSrv.BUS;
using MoneyPacificSrv.XAO;

internal enum PHONE_NUMBER
{ 
    MIN = 10,
    MAX = 20
}

internal enum PACIFIC_CODE
{ 
    LENGTH = 16
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

        internal static bool isPosibleCode(string sCodeNumber)
        {
            if (isPacificCode(sCodeNumber))
            {
                return PacificCodeXAO.isPossibleCode(sCodeNumber);
            }
            return false;
        }

        // check is PacificCode or NOT, but may be the CodeNumber is not keep to the RuleCode
        internal static bool isPacificCode(string sCodeNumber)
        {
            //throw new NotImplementedException();
            bool bResult = true;

            // remove the space char
            sCodeNumber = Util.removeSpaceChar(sCodeNumber);

            // Kiểm tra
            bResult = bResult && (sCodeNumber.Length == (int)PACIFIC_CODE.LENGTH);

            for (int i = 0; i < sCodeNumber.Length; i++)
            {
                bResult = bResult && Char.IsDigit(sCodeNumber[i]);
            }

            return bResult;

        }


        internal static bool iPassStore(string sCommand)
        {
            sCommand = sCommand.Trim();

            if (sCommand.Length == 5)
                return true;
            return
                false;
        }
    }
}