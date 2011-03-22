using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificBlackBox.DAO;
using MoneyPacificBlackBox.DTO;

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

        internal static bool IsExistPartCodeNumber(string partCodeNumber)
        {
            return PacificCodeDAO.IsExistPartCodeNumber(partCodeNumber);            
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

        /// <summary>
        ///  
        /// </summary>
        /// Giải thuật:
        /// - Kiểm tra số tiền trong codeNumber
        /// - Nếu không đủ tiền, trả về null => bắt buộc khi gọi hàm thanh toán fải biết mình có đủ tiền trả        /// 
        /// - Nếu đủ tiền: 
        ///     + Trừ số tiền theo yêu cầu
        ///     + Tạo một pacific code có giá trị bằng sô tiền đã trừ:
        internal PacificCode MakePayment(string codeNumber, int amount)
        {
            if (!PacificCodeDAO.IsExist(codeNumber))return null;

            PacificCode existPacificCode = PacificCodeBUS.GetObject(codeNumber);
            if (existPacificCode.ActualAmount < amount)
            {
                return null;
            }
            else
            {
                existPacificCode.ActualAmount = existPacificCode.ActualAmount - amount;
                PacificCodeDAO.Update(existPacificCode);

                PacificCode newPacificCode = GetNewPacificCode(amount);
                return newPacificCode;            
            }
            
        }

        internal double GetInitialAmount(string partCodeNumber)
        {
            bool bExist = PacificCodeDAO.IsExistPartCodeNumber(partCodeNumber);
            if (bExist)
            {
                PacificCode existPacificCode = PacificCodeDAO.GetObject(partCodeNumber);
                return (double)existPacificCode.ActualAmount;
            }
            return 0;
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

        internal string ChangeCode(string codeNumber)
        {
            PacificCode existPC = PacificCodeDAO.GetObject(codeNumber);            
            if (codeNumber == existPC.CodeNumber)
            {
                string newCodeNumber = GeneratorPacificCode.Generator.getNewCode();
                existPC.CodeNumber = newCodeNumber;
                PacificCodeDAO.Update(existPC);
                return newCodeNumber;
            }
            return null;
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

        internal static PacificCodeViewModel[] GetArray(string[] arrPartCodeNumber)
        {   

            PacificCode[] arrPC = PacificCodeDAO.GetArray(arrPartCodeNumber);
            List<PacificCodeViewModel> lstPCVM = new List<PacificCodeViewModel>();
            
            for (int i = 0; i < arrPC.Count(); i++)
            {                
                if (arrPC[i] != null)
                {
                    PacificCodeViewModel newItem = new PacificCodeViewModel();
                    newItem.SetAttritebuteValue(arrPC[i]);
                    lstPCVM.Add(newItem);
                }
            }

            return lstPCVM.ToArray();
        }

        
    }
}