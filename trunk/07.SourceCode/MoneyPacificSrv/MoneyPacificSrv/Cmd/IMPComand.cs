using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSrv.Cmd
{   
    public interface IMPCommand
    {
        string Execute(string[] args);        
    }

    public enum Command
    { }
}