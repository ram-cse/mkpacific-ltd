using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService.DTO;

namespace _08.MoneyPacificService.BUS
{
    public class PacificCodeBUS
    {
        private static int[] arrCode = new int[16];

        internal static PacificCode GenerateNew()
        {
            Random randomNumer = new Random();

            PacificCode newPCode = new PacificCode();

            newPCode.PacificCode1 = "";
            
            for (int i = 0; i<=15; i++)
            {
                arrCode[i] = randomNumer.Next(10);
                
                // LoadRule lên và phát sinh code theo Rule
                
                newPCode.PacificCode1 += arrCode[i].ToString();
            }

            return newPCode;
        }

        internal static bool checkExist(string p)
        {
            // throw new NotImplementedException();
            // Chưa tồn tại trong csdl
            return false;
        }
    }
}