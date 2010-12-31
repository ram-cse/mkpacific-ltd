using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string codenumber = GeneratorPacificCode.Generator.getNewCode();
            codenumber = insertSeparateChar(codenumber, '-', 4);
            Console.WriteLine(codenumber);
        }

        public static string insertSeparateChar(string sOrginal, char c, int l)
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

    }
}
