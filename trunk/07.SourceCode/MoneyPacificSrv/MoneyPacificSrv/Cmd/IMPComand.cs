using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSrv.Cmd
{
    public interface IMPComand
    {
        string Execute(string[] args);
    }
}