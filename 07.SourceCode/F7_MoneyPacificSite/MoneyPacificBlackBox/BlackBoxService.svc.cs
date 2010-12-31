using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MoneyPacificBlackBox.DAO;
using MoneyPacificBlackBox.BUS;

namespace MoneyPacificBlackBox
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class BlackBoxService : IBlackBoxService
    {
        private SecurityGuard _guard = new SecurityGuard();

        public PacificCode NewPacificCode(int amount)
        {
            return this._guard.GetNewPacificCode(amount);
        }

        public bool IsPossible(string codeNumber)
        {
            return this._guard.CheckIsPossible(codeNumber);
        }

        public string ChangeCode(int codeNumber)
        {
            return this._guard.ChangeCode(codeNumber);
        }

        public PacificCode GetValue(string partCodeNumber)
        {
            return this._guard.GetValue(partCodeNumber);
        }

        public PacificCode MakePayment(string codeNumber, int amount)
        {
            return this._guard.MakePayment(codeNumber, amount);
        }

        public bool MakePaymentTo(string codeNumber, string partCodeNumber, int amount)
        {
            return this._guard.Tranfer(codeNumber, partCodeNumber,amount);
        }

        public PacificCode Merge(string[] arrCodeNumber)
        {
            return this._guard.Merge(arrCodeNumber);
        }        
    }
}
