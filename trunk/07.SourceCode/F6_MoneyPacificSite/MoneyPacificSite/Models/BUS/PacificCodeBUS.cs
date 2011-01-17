using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSite.Models.DAO;
using GeneratorPacificCode;

namespace MoneyPacificSite.Models.BUS
{
    public class PacificCodeBUS
    {
        public static PacificCode SendMoney(string codeNumber, string Phone, double Amount)
        {
            bool bExists = PacificCodeDAO.IsExist(codeNumber);
            PacificCode newPacificCode = null;
            if (bExists)
            {
                PacificCode pacificCode = PacificCodeDAO.GetItem(codeNumber);
                if (pacificCode.ActualAmount > Amount)
                {
                    newPacificCode = new PacificCode();

                    bool bExist02;
                    do
                    {
                        newPacificCode.CodeNumber = Generator.getNewCode();
                        bExist02 = PacificCodeDAO.IsExist(newPacificCode.CodeNumber);
                    } while (bExist02);

                    pacificCode.ActualAmount -= (int)Amount;
                    newPacificCode.InitialAmount = (int)Amount;
                    newPacificCode.ActualAmount = (int)Amount;

                    PacificCodeDAO.UpdateAmount(pacificCode, (int)pacificCode.ActualAmount);
                    PacificCodeDAO.AddItem(newPacificCode);
                }
            }
            return newPacificCode;            
        }

        public static PacificCode GetItem(string codeNumber)        
        {
            PacificCode existPacificCode = null ;
            if (PacificCodeDAO.IsExist(codeNumber))
            {
                existPacificCode = PacificCodeDAO.GetItem(codeNumber);
            }
            return existPacificCode;
        }



        internal static bool IsExist(string codeNumber)
        {
            return PacificCodeDAO.IsExist(codeNumber);
        }

        internal static string ChangeCode(string codeNumber)
        {
            return PacificCodeDAO.ChangeCode(codeNumber);
        }

        internal static PacificCode GetLastPacificCode(int customerId)
        {
            return PacificCodeDAO.GetLastPacificCode(customerId);
        }

        internal static PacificCode[] GetList()
        {
            return PacificCodeDAO.GetList();
        }

        internal static int GetTotalAmountOfStoreManager(int smId)
        {
            List<StoreUser> lstStoreUser = StoreUserDAO.GetArray(smId).ToList();
            int iAmount = 0;
            foreach (StoreUser su in lstStoreUser)
            { 
                iAmount += GetTotalAmountOfStoreUser(su.Id);
            }
            return iAmount;
        }

        private static int GetTotalAmountOfStoreUser(int storeUserId)
        {
            List<PacificCode> lstPC = PacificCodeDAO.GetArray(storeUserId).ToList();
            int iInitAmount = 0;
            foreach (PacificCode p in lstPC)
            {
                if (p.InitialAmount == null) p.InitialAmount = 0;
                iInitAmount += (int)p.InitialAmount;
            }
            return iInitAmount;

        }
    }
}