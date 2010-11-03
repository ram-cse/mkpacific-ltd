using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSrv.Cmd
{
    public class UnderContructionCommand : IMPCommand
    {
        #region IMPCommand Members

        public string Execute(string[] args)
        {
            return "0*This function is under construction!..";
        }

        #endregion
    }
}