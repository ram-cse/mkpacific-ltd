using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificBlackBox.DAO;
using MoneyPacificBlackBox.BUS;
using MoneyPacificBlackBox.DTO;

namespace MoneyPacificBlackBox
{
    /// <summary>
    /// Facade
    /// </summary>
    internal class SecurityGuard
    {
        private PacificCodeBUS _pacificCodeBUS;
        private TransactionBUS _transactionBUS;
        private PacificCodeStateBUS _pacificCodeStateBUS;

        private bool _active;

        internal SecurityGuard()
        {
            _pacificCodeBUS = new PacificCodeBUS();
            _transactionBUS = new TransactionBUS();
            _pacificCodeStateBUS = new PacificCodeStateBUS();
        }

        internal bool Active
        {
            set { this._active = value; }
            get { return this._active; }
        }

        internal PacificCode GetNewPacificCode(int amount)
        {
            
            Transaction newTransaction = new Transaction();            
            PacificCode pacificCode = this._pacificCodeBUS.GetNewPacificCode(amount);

            // Lấy thông tin Transaction
            newTransaction.Amount = pacificCode.ActualAmount;
            newTransaction.CreateDate = pacificCode.CreateDate;
            newTransaction.Origine = "BuyMP";
            newTransaction.PacificCodeId = pacificCode.Id;            
            newTransaction.Comment = string.Format("Buy: {0}", pacificCode.ActualAmount);
            newTransaction.IsSuccessful = true; 
            // Luôn luôn cho phép tạo thành công...

            // Lưu
            this._transactionBUS.AddNew(newTransaction);

            // Trả kết quả
            return pacificCode;
        }

        internal bool CheckIsPossible(string codeNumber)
        {
            Transaction newTransaction = new Transaction();
            
            bool result = GeneratorPacificCode.Generator.isPossibleCode(codeNumber);

            newTransaction.Origine = "Check Possible";
            newTransaction.Comment = "Check Possible: " + codeNumber;
            newTransaction.IsSuccessful = result;

            this._transactionBUS.AddNew(newTransaction);
            return result;
        }

        internal PacificCode Merge(string[] arrCodeNumber)
        {
            /// TODO:
            throw new NotImplementedException();
        }

        /// <summary>
        /// Phương thức này chỉ dùng tạm thời
        /// Cần thiết kế theo cách sau:
        /// - thanh toán xong trả ra Id Transaction
        /// - có 1 phuong thuc khác, cho phép kiểm tra Id Transaction đó có 
        /// thành công hay không
        /// </summary>
        /// <param name="codeNumber">CodeNumber sẽ bị trừ tiền</param>
        /// <param name="partCodeNumber">CodeNumber nhận tiền</param>
        /// <param name="amount">Số tiền thanh toán</param>
        /// <returns></returns>
        internal bool Tranfer(string codeNumber, string partCodeNumber, int amount)
        {
            /// TODO:
            Transaction newTransaction = new Transaction();            
            bool result = this._pacificCodeBUS.Tranfer(codeNumber, partCodeNumber, amount);

            newTransaction.Origine = "Make Payment";            
            newTransaction.Comment = string.Format("Make payment: {0} to {1} with amount: {2}"
                , codeNumber
                , partCodeNumber
                , amount);
            newTransaction.IsSuccessful = result;
            this._transactionBUS.AddNew(newTransaction);
            
            return result;
        }

        internal PacificCode MakePayment(string codeNumber, int amount)
        {
            Transaction newTransaction = new Transaction();
            
            PacificCode pacificCode = this._pacificCodeBUS.MakePayment(codeNumber, amount);
            
            // BEGIN --            
            newTransaction.Origine = "MakePayment";
            newTransaction.PacificCodeId = pacificCode.Id;
            newTransaction.Comment = string.Format("Payment: {0} - {1}"
                ,codeNumber
                ,amount);
            newTransaction.IsSuccessful = true;
            // END --
            
            this._transactionBUS.AddNew(newTransaction);
            return pacificCode;
        }

        internal double GetValue(string partCodeNumber)
        {
            Transaction newTransaction = new Transaction();
            
            double result = this._pacificCodeBUS.GetValue(partCodeNumber);
            
            // BEGIN --            
            newTransaction.Origine = "GetValue";
            newTransaction.Comment = "Check Value: " + partCodeNumber;
            // END --

            this._transactionBUS.AddNew(newTransaction); 
            return result;
        }

        internal DateTime GetExpireDate(string partCodeNumber)
        {
            Transaction newTransaction = new Transaction();

            DateTime result = this._pacificCodeBUS.GetExpireDate(partCodeNumber);

            // Không nên lưu transaction loại này...
            // BEGIN --            
            newTransaction.Origine = "GetExpireDate";
            newTransaction.Comment = "Get ExpireDate(HeThong su dung): " + partCodeNumber;
            // END --

            this._transactionBUS.AddNew(newTransaction);
            return result;
        }



        internal string ChangeCode(int codeNumber)
        {
            Transaction newTransaction = new Transaction();
            string newCodeNumber = this._pacificCodeBUS.ChangeCode(codeNumber);

            // BEGIN --            
            newTransaction.Origine = "ChangeCode";
            newTransaction.Comment = string.Format("ChangeCode: {0} to {1}"
                , codeNumber
                , newCodeNumber);
            // END --

            // Hien tai chưa can luu Transaction loại này
            // this._transactionBUS.AddNew(newTransaction);
            return newCodeNumber;
        }

        internal bool CheckIsExist(string codeNumber)
        {
            Transaction newTransaction = new Transaction();            
            bool result = PacificCodeBUS.IsExistPartCodeNumber(codeNumber);

            // BEGIN --            
            newTransaction.Origine = "Check Exist";
            newTransaction.Comment = string.Format("Check Exist: {0}"
                , codeNumber);
            // END --

            // Hien tai chưa can luu Transaction loại này
            // this._transactionBUS.AddNew(newTransaction);

            return result;
        }
        
        internal bool CheckIsExistPartCodeNumber(string partCodeNumber)
        {
            Transaction newTransaction = new Transaction();
            bool result = PacificCodeBUS.IsExistPartCodeNumber(partCodeNumber);

            // BEGIN --            
            newTransaction.Origine = "Check Exist Part";
            newTransaction.Comment = string.Format("Check Exist Part: {0}"
                , partCodeNumber);
            // END --

            // Hien tai chưa can luu Transaction loại này
            // this._transactionBUS.AddNew(newTransaction);

            return result;
        }

        internal PacificCodeViewModel GetPacificCodeViewModel(string partCodeNumber)
        {
            Transaction newTransaction = new Transaction();
            PacificCodeViewModel model = new PacificCodeViewModel();
            PacificCode pacificCode = PacificCodeBUS.GetObject(partCodeNumber);

            if (pacificCode != null)
            {
                model.SetAttritebuteValue(pacificCode);

                // BEGIN --            
                newTransaction.Origine = "GetPacificCodeViewModel";
                newTransaction.Comment = string.Format("Get PacificCodeViewModel: {0}"
                    , partCodeNumber);
                // END --

                // Hien tai chưa can luu Transaction loại này
                // this._transactionBUS.AddNew(newTransaction);

                return model;
            }
            
            return null;
        }

        internal PacificCodeViewModel[] GetArrayPacificCodeViewModel(string[] arrPartCodeNumber)
        {
            PacificCodeViewModel[] arrResult;

            arrResult = PacificCodeBUS.GetArray(arrPartCodeNumber);


            Transaction newTransaction = new Transaction();
            // BEGIN --            
            newTransaction.Origine = "GetArrayPacificCodeViewModel";
            newTransaction.Comment = string.Format("Get PacificCodeViewModel: array");
            // END --

            // this._transactionBUS.AddNew(newTransaction);

            return arrResult;
            
        }
    }
}