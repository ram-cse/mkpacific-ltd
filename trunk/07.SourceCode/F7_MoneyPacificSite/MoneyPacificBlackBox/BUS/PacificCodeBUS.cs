using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificBlackBox.DAO;

namespace MoneyPacificBlackBox.BUS
{
    internal class PacificCodeBUS
    {
        internal PacificCode GetNewPacificCode(int amount)
        {
            
            /// Tao PacificCode mà chưa tồn tại            
            bool isExistPacfificCode = false;
            string codeNumber;
            do
            {
                codeNumber = GeneratorPacificCode.Generator.getNewCode();
                isExistPacfificCode = PacificCodeBUS.IsExist(codeNumber);
            } while (isExistPacfificCode);
            
            PacificCode newPacificCode = new PacificCode();
            newPacificCode.CodeNumber = codeNumber;
            newPacificCode.ActualAmount = amount;
            newPacificCode.InitialAmount = amount;
            newPacificCode.CreateDate = DateTime.Now;

            int iYear = DateTime.Now.Year + 1;
            int iMonth = DateTime.Now.Month;
            int iDay = DateTime.Now.Day;
            
            newPacificCode.ExpireDate = new DateTime(iYear, iMonth, iDay);

            PacificCodeDAO.AddNew(newPacificCode);
            
            return newPacificCode;
        }

        internal static bool IsExist(string codeNumber)
        {
            return PacificCodeDAO.IsExist(codeNumber);
        }

        /// <summary>
        /// Phương thức này chưa có trong yêu cầu
        /// </summary>
        internal bool Tranfer(string codeNumber, string partCodeNumber, int amount)
        {
            //bool isExist = PacificCodeDAO.IsExist(codeNumber) && PacificCodeDAO.IsExist(partCodeNumber);
            //if (!isExist)
            //{
            //    return false;
            //}
            //return true;

            throw new NotImplementedException();
        }

        internal PacificCode MakePayment(string codeNumber, int amount)
        {
            if (!PacificCodeDAO.IsExist(codeNumber))
                return null;
            return (new PacificCode());
        }

        /// <summary>
        /// Giống GetActualAmount
        /// </summary>        
        internal double GetValue(string partCodeNumber)
        {
            bool bExist = PacificCodeDAO.IsExistPartCodeNumber(partCodeNumber);
            if (bExist)
            {
                PacificCode existPacificCode = PacificCodeDAO.GetObject(partCodeNumber);
                return (double)existPacificCode.ActualAmount;
            }
            return 0;
        }

        internal string ChangeCode(int codeNumber)
        {
            throw new NotImplementedException();
        }

        internal DateTime GetExpireDate(string partCodeNumber)
        {
            bool bExist = PacificCodeDAO.IsExistPartCodeNumber(partCodeNumber);
            if (bExist)
            {
                PacificCode existPacificCode = PacificCodeDAO.GetObject(partCodeNumber);
                return (DateTime)existPacificCode.ExpireDate;
            }
            return DateTime.MinValue; //Mac dinh neu khong co expiredate => khong co hieu luc tất cả
        }

        #region STATIC_AREA
        /// <summary>
        /// Chỉ trả ra giá trị nếu thật sự có giá trị
        /// </summary>
        //private static double GetActualAmount(string partCodeNumber)
        //{
        //    bool bExist = PacificCodeDAO.IsExistPartCodeNumber(partCodeNumber);
        //    if (bExist)
        //    {
        //        PacificCode existPacificCode = PacificCodeDAO.GetObject(partCodeNumber);
        //        return (double)existPacificCode.ActualAmount;
        //    }
        //    return 0;
        //}
        #endregion STATIC_AREA        
    
        internal static PacificCode GetObject(string partCodeNumber)
        {
            return PacificCodeDAO.GetObject(partCodeNumber);
        }
    }
}