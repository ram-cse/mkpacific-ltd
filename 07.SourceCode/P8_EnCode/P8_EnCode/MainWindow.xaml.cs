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

namespace P8_EnCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BinaryWriter objBinaryWriter;
        BinaryReader objBinaryReader;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEncode_Click(object sender, RoutedEventArgs e)
        {
            /*
            FileStream objFile = new FileStream(lblPathFile.Content,FileAccess.ReadWrite);
            objBinaryReader = new BinaryReader(objFile);
            //*/
            string originString = "abc*123*456";
            string encodedString = "";
            string decodedString = "";                    


            int key  = 88;

            for (int i = 0; i < originString.Length; i++)
            {
                encodedString += (char)(originString[i] ^ key);
            }

            for (int i = 0; i < encodedString.Length; i++)
            {
                decodedString += (char)(encodedString[i] ^ key);
            }

            MessageBox.Show(encodedString + "---" + decodedString);
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = "*.txt";
            dlg.Filter = "Text document (.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();
            if(result == true)
            {
                string fileName = dlg.FileName;
                lblPathFile.Content = fileName;
            }
        }

        private void btnDecode_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
