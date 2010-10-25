using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneratorPacificCode
{
    public class Generator
    {
        public static string getNewCode()
        {
            return GeneratorXAO.generateNewCode();
        }
        public static bool isPossibleCode(string sCodeNumber)
        {
            return GeneratorXAO.isPossibleCode(sCodeNumber);
        }
    }
}
