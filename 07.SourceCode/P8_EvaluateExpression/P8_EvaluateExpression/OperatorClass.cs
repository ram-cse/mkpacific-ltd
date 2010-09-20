using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace P8_EvaluateExpression
{
    class OperatorClass
    {
        internal char value;

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
                    result = int.MaxValue;
                    break;
                case ')':
                    result = int.MinValue;
                    break;
                default:
                    result = 0;
                    break;
            }

          return result;  
        }

        internal double calculate(int x, int y)
        {
            double result = 0;

            switch (value)
            {
                case '+':
                    result = (double)(x + y);
                    break;
                case '-':
                    result = (double)(x - y);
                    break;
                case '*':
                    result = (double)(x * y);
                    break;
                case '/':
                    result = (double)(x / y);
                    break;
                case '%':
                    result = (double)(x % y);
                    break;
                case '^':
                    result = (double)Math.Pow(x, y);
                    break;
            }

            return result;
        }
    }
}
