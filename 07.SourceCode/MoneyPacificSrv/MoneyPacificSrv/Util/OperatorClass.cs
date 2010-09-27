using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSrv.Util
{
    public class OperatorClass
    {
        internal char value;

        public OperatorClass(char p)
        {
            this.value = p;
        }

        public OperatorClass()
        { }

        internal int valuePrior()
        {
            int result = 0;

            switch (value)
            {
                case '+':
                    result = 1;
                    break;
                case '-':
                    result = 1;
                    break;
                case '*':
                    result = 2;
                    break;
                case '/':
                    result = 2;
                    break;
                case '%':
                    result = 2;
                    break;
                case '^':
                    result = 3;
                    break;
                case '(':
                    result = int.MinValue;
                    break;
                case ')':
                    result = int.MaxValue;
                    break;
                default:
                    result = 0;
                    break;
            }

            return result;
        }

        internal double calculate(double x, double y)
        {
            double result = 0;

            switch (value)
            {
                case '+':
                    result = (x + y);
                    break;
                case '-':
                    result = (x - y);
                    break;
                case '*':
                    result = (x * y);
                    break;
                case '/':
                    result = (x / y);
                    break;
                case '%':
                    result = (x % y);
                    break;
                case '^':
                    result = Math.Pow(x, y);
                    break;
            }

            return result;
        }

        internal static bool IsOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' ||
                c == '/' || c == '%' || c == '^')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}