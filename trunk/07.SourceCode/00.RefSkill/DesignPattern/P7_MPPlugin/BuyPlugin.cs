using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P7_MPPlugin
{
    class BuyPlugin : IMPPlugin
    {
        public override void Execute()
        {
            Console.WriteLine("BUY...");
        }
    }
}
