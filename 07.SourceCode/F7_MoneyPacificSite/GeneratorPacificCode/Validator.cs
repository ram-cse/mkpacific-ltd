using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneratorPacificCode
{
    class Validator
    {
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
