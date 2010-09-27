using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using P8_EvaluateExpression;
using System.Xml;

namespace P8_EvaluateExpression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCal_Click(object sender, RoutedEventArgs e)
        {
            txtKetQua.Text = ExpressionClass.evaluateExp(txtBieuThuc.Text).ToString();
        }

        private void btnCalcFromXML_Click(object sender, RoutedEventArgs e)
        {
            // Load tập tin XML
            // Load biến, biến vừa có giá trị thực & tính toán

            List<PCArg> lstArg = new List<PCArg>();

            XmlDocument xmlDoc = new XmlDocument();
            
            string pathFile = Directory.GetCurrentDirectory() + "\\Expression.xml";
            xmlDoc.Load(pathFile);

            XmlNode rootNode = xmlDoc.DocumentElement;

            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                //MessageBox.Show(childNode.Attributes["name"].Value + ":" + childNode.Attributes["value"].Value);
                PCArg newArg = new PCArg();
                newArg.name = childNode.Attributes["name"].Value.Trim(' ');
                newArg.value = childNode.Attributes["value"].Value.Trim(' ');

                lstArg.Add(newArg);
            }

            // Tính giá trị các biến & tính biểu thức

            Random randomNumber = new Random();
            foreach(PCArg arg in lstArg)
            {
                if (arg.value.ToLower() == "random")
                {
                    arg.value = randomNumber.Next(10).ToString();
                }
            }

            foreach (PCArg arg in lstArg)
            {
                // nếu không là số
                if (!IsNumber(arg.value))
                {
                    foreach (PCArg argConst in lstArg)
                    {
                        if (IsNumber(argConst.value))
                        {
                            // Thay tất cả các biến bằng giá trị
                            arg.value = arg.value.Replace(argConst.name[0], argConst.value[0]);
                        }
                    }
                    // Tính giá trị luôn   
                    arg.value = ((int)ExpressionClass.evaluateExp(arg.value)).ToString();
                    // MessageBox.Show(arg.value);
                }
            }

            // Kết hợp thành chuỗi và xuất chuỗi kết quả
            string sResult = "";
            for (int i = 0; i < lstArg.Count; i++)
            {
                sResult += lstArg[i].value;
                if (i % 4 == 3 && i != lstArg.Count - 1)
                {
                    sResult += "-";
                }
            }
            //MessageBox.Show(sResult);
            lblPCode.Content = sResult;
        }

        bool IsNumber(string s)
        {
            bool bResult = true;
            foreach (char c in s)
            {
                bResult = bResult && (char.IsDigit(c));
            }
            return bResult;
        }        
    }


    class PCArg
    {
        public string name;
        public string value;
    }
}
