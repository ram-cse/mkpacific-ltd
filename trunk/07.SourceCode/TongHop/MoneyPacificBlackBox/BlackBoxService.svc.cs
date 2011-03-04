using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MoneyPacificBlackBox.DAO;
using MoneyPacificBlackBox.BUS;
using MoneyPacificBlackBox.DTO;

namespace MoneyPacificBlackBox
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class BlackBoxService : IBlackBoxService
    {
        private SecurityGuard _guard = new SecurityGuard();

        public string NewPacificCode(int amount)
        {
            return this._guard.GetNewPacificCode(amount).CodeNumber;            
        }

        public bool IsPossible(string codeNumber)
        {
            return this._guard.CheckIsPossible(codeNumber);
        }

        public PacificCodeViewModel GetPacificCodeViewModel(string partCodeNumber)
        { 
            return this._guard.GetPacificCodeViewModel(partCodeNumber);
        }

        public PacificCodeViewModel[] GetArrayPacificCodeViewModel(string[] arrPartCodeNumber)
        {
            return this._guard.GetArrayPacificCodeViewModel(arrPartCodeNumber);
        }

        public bool IsExist(string codeNumber)
        {
            return this._guard.CheckIsExist(codeNumber);
        }

        public bool IsExistPart(string partCodeNumber)
        {
            return this._guard.CheckIsExistPartCodeNumber(partCodeNumber);
        }

        public string ChangeCode(string codeNumber)
        {
            return this._guard.ChangeCode(codeNumber);
        }

        public int GetValue(string partCodeNumber)
        {
            return (int)this._guard.GetValue(partCodeNumber);
        }

        public DateTime GetExpireDate(string partCodeNumber)
        {
            return this._guard.GetExpireDate(partCodeNumber);
        }

        /// <summary>
        /// Trả ra new CodeNumber có giá trị bằng giá trị đã thanh toán...
        /// </summary>
        public string MakePayment(string codeNumber, int amount)
        {
            return this._guard.MakePayment(codeNumber, amount);
        }

        public bool MakePaymentTo(string codeNumber, string partCodeNumber, int amount)
        {
            return this._guard.Tranfer(codeNumber, partCodeNumber,amount);
        }

        public string Merge(string[] arrCodeNumber)
        {
            return this._guard.Merge(arrCodeNumber).CodeNumber;
        }        
    }
}
