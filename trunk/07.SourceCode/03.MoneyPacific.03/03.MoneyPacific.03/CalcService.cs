using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.MoneyPacific._03
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalcService" in both code and config file together.
    public class CalcService : ICalcService
    {
        public int AddInt(int x, int y)
        {
            return x + y;
        }

        public double AddDouble(double x, double y)
        {
            return (x + y);
        }
    }
}
