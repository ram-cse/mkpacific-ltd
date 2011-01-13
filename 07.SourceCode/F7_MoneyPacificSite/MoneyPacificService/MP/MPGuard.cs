using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificService.CMD;

namespace MoneyPacificService
{
    internal class MPGuard
    {
        private Invoker _invoker;
        private AMPCommand _command;

        /// <summary>
        /// Lưu transaction trong này?
        /// </summary>
        internal string Execute()
        {
            return this._command.Execute();
        }

        internal AMPCommand Command
        {
            set { this._command = value; }
        }
    }

    internal class Invoker
    {
        private string _phoneNumber;

        internal String PhoneNumber
        {
            get { return _phoneNumber; }
        }

        internal Invoker(string phoneNumber)
        {
            // TODO: Complete member initialization
            this._phoneNumber = phoneNumber;
        }

        internal bool IsInBlackList()
        {
            // TODO: throw new NotImplementedException();
            return false;
        }

        internal bool IsLockedCustomer()
        {
            // TODO:throw new NotImplementedException();
            return false;
        }

        internal bool IsStoreUser()
        {
            // TODO: throw new NotImplementedException();
            return true;
        }
        internal bool IsStoreManager()
        {
            // TODO: throw new NotImplementedException();
            return true;
        }
        internal bool IsCustomer()
        {
            // TODO: throw new NotImplementedException();
            return true;
        }
    }

    internal class Receiver
    {
        internal String PhoneNumber;
    }
}