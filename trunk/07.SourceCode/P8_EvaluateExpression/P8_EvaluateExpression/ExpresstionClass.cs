using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace P8_EvaluateExpression
{
    class ExpresstionClass
    {
        private static List<double> lstNumber;
        private static List<OperatorClass> lstOperator;        
        

        internal static double evaluateExp(string sExpression)
        {  
            lstNumber = new List<double>();
            lstOperator = new List<OperatorClass>();

            string[] arrSubString;
            OperatorClass opr = new OperatorClass();

            sExpression = sExpression.Trim(' ');

            while (sExpression.Length > 0)
            {
                arrSubString = getNextObject(sExpression);

                // Nếu là số, chèn vào Queue số
                if (char.IsNumber(arrSubString[0], 0))
                {
                    lstNumber.Add(double.Parse(arrSubString[0]));
                }
                // Nếu là "phép toán", tính toán rồi chèn vào Queue phép toán
                else if (OperatorClass.IsOperator(arrSubString[0][0]))
                {
                    opr.value = arrSubString[0][0];

                    while (lstOperator.Count() > 0)
                    {
                        if (opr.valuePrior() > lstOperator.Last().valuePrior())
                        {
                            break;
                        }
                        calcOneOnQueue();
                    }
                    lstOperator.Add(new OperatorClass(arrSubString[0][0]));

                }                    
                // Xử lý dấu ngoặc
                else if (arrSubString[0][0] == '(')
                {
                    lstOperator.Add(new OperatorClass(arrSubString[0][0]));
                }
                else if (arrSubString[0][0] == ')')
                {
                    // Lôi hết phép tính ra cho tới khi nào gặp ngoặc đóng
                    while (lstOperator.Last().value != '(')
                    {
                        calcOneOnQueue();
                    }
                    // Xóa dấu ngoặc cuối cùng
                    lstOperator.RemoveAt(lstOperator.Count() - 1);
                }
                sExpression = arrSubString[1];
            }

            // Lấy tất cả các phần tử còn lại trong Queue ra tính
            while (lstOperator.Count() > 0)
            {
                calcOneOnQueue();
            }

            return lstNumber.Last() ;
        }

        internal static void calcOneOnQueue()
        {
            double a;
            double b;
            double newNumber;

            OperatorClass o;

            // Pop -> o
            o = lstOperator.Last();
            lstOperator.RemoveAt(lstOperator.Count() - 1);

            // Pop -> b
            b = lstNumber.Last();
            lstNumber.RemoveAt(lstNumber.Count() - 1);

            // Pop -> a
            a = lstNumber.Last();
            lstNumber.RemoveAt(lstNumber.Count() - 1);

            newNumber = o.calculate(a, b);
            lstNumber.Add(newNumber);
        }

        internal static string[] getNextObject(string sExpression)
        {
            string[] arrResult = new string[2];
            char c = sExpression[0];

            // Tách số hoặc phép toán đầu tiên ra
            if (char.IsNumber(c))
            {
                // Nếu là số thì lấy hết dãy số
                arrResult[0] = "";
                
                for (int i = 0; i < sExpression.Length; i++)
                {
                    if (char.IsNumber(sExpression[i]))
                    {
                        arrResult[0] += sExpression[i];
                    }
                    else
                    {
                        break;
                    }
                }

                arrResult[1] = sExpression.Substring(arrResult[0].Length, sExpression.Length - arrResult[0].Length);
            }
            else
            {
                // Nếu là dấu thì chỉ lấy 1 ký tự đầu tiên
                arrResult[0] = "" + c;
                arrResult[1] = sExpression.Substring(1, sExpression.Length - 1);
            }

            return arrResult;
        }
    }
}
