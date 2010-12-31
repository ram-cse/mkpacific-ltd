using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneratorPacificCode.XAO;

namespace GeneratorPacificCode
{
    public  class Generator
    {
        public  static string getNewCode()
        {
            return GeneratorXAO.generateNewCode();
        }
        public  static bool isPossibleCode(string sCodeNumber)
        {
            return GeneratorXAO.isPossibleCode(sCodeNumber);
        }

        public  static bool isPossibleCode(int codeNumber)
        {
            throw new NotImplementedException();
        }
    }
}
