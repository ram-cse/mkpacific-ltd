using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyPacificService.CMD
{
    internal abstract class AMPCommand
    {
        internal virtual string Execute()
        {
            return "This Command is not exist or underconstruction!..";
        }
    }
}
