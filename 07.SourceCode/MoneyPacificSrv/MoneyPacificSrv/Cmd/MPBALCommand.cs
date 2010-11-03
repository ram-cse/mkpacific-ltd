using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.General;

namespace MoneyPacificSrv.Cmd
{
    public class MPBALCommand : IMPCommand
    {
        #region IMPCommand Members

        /// <summary>
        /// args[0] = the Phone of StoreUser or StoreManager
        /// args[1] = the PinStore
        /// </summary>        
        [Authorize(Roles="StoreManager, StoreUser")]
        public string Execute(string[] args)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}