using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService.DAO;
using _08.MoneyPacificService.DTO;

namespace _08.MoneyPacificService.BUS
{
    public class PacificCodeBUS
    {

        private static int[] arrCode = new int[16];

        internal static PacificCode GenerateNewCode()
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

        internal static PacificCode getNewPacificCode(int storeId, int customerId)
        {
            PacificCode newPacificCode = new PacificCode();

            bool bGetNewPacificCode = false;
            do
            {
                newPacificCode = PacificCodeBUS.GenerateNewCode();

                // Nếu không bị trùng (trường hợp này rất ít khi xảy ra, tỉ lệ xảy ra là 1/10^11)
                bGetNewPacificCode = !PacificCodeBUS.checkExist(newPacificCode.PacificCode1);

            } while (bGetNewPacificCode == false);

            newPacificCode.StoreID = storeId;
            newPacificCode.CustomerID = customerId;

            PacificCodeDAO.AddNew(newPacificCode);

            return newPacificCode;            
        }
    }
}