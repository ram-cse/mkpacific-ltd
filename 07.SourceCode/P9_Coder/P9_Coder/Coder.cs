using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P9_Coder
{
    class Coder
    {
        internal static int iKey01 = 19;
        internal static int iKey02 = 83;

        internal static string EnCode(string originString)
        {
            string resultString = "";

            for (int i = 0; i < originString.Length; i++)
            {
                if (i % 2 == 0)
                    resultString += (char)(originString[i] ^ iKey01);
                else
                    resultString += (char)(originString[i] ^ iKey02);
            }

            resultString = (char)iKey02 + resultString;
            resultString = (char)iKey01 + resultString;

            return resultString;
        }

        internal static string DeCode(string originString)
        {
            // 2 ký tự đầu tiên là khóa

            int pKey01 = (int)originString[0];
            int pKey02 = (int)originString[1];

            string resultString = "";

            for (int i = 2; i < originString.Length; i++)
            {
                if (i % 2 == 0)
                    resultString += (char)(originString[i] ^ pKey01);
                else
                    resultString += (char)(originString[i] ^ pKey02);
            }

            return resultString;
        }
    }
}
