using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificService.CMD
{
    internal abstract class AMPCommand
    {
        protected string[] args;

        internal void SetArgs(string[] args)
        {
            this.args = args;
        }
        internal virtual string Execute()
        {
            return "This Command is not exist or underconstruction!..";
        }

        public AMPCommand()
        { }
    }
}