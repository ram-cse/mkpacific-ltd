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
            string codeNumber = GeneratorPacificCode.Generator.getNewCode();
            
            PacificCode newPacificCode = new PacificCode();
            newPacificCode.CodeNumber = codeNumber;
            newPacificCode.ActualAmount = amount;
            newPacificCode.InitialAmount = amount;
            newPacificCode.CreateDate = DateTime.Today;

            return newPacificCode;
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

        internal PacificCode GetValue(string partCodeNumber)
        {
            throw new NotImplementedException();
        }

        internal string ChangeCode(int codeNumber)
        {
            throw new NotImplementedException();
        }
    }
}