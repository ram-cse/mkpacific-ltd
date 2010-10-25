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

using System.Configuration;
using MoneyPacificSrv.DTO;

namespace P9_CallMoneyPacificSrv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        //MainClient clientDebug;
        //MainClient clientLocalhost;

        private void Grid_Initialized(object sender, EventArgs e)
        {
            // HelloWorldClient("BasicHttpBinding_IHelloWorld",
            // newEndpointAddress("http: //localhost:8888/BasicHost/HelloWorld"));
            // new MainClient("BasicHttpBinding_IMain", "http://localhost:2000/Main.svc");

            //clientDebug = new MainClient("BasicHttpBinding_IMain_Localhost");
            //clientLocalhost = new MainClient( "BasicHttpBinding_IMain_Debug");
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private MainClient GetClient(bool bLocalHost)
        {
            if(bLocalHost)
                return new MainClient("BasicHttpBinding_IMain_Localhost");
            return new MainClient("BasicHttpBinding_IMain_Debug");
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MainClient mainClient = new MainClient();
                MainClient mainClient = GetClient((bool)chkLocalhost.IsChecked);
                txtMessage.Text = "";
                txtMessage.Text = mainClient.SendMessage(txtContent.Text);
                mainClient.Close();
            }
            catch (Exception ex)
            {
                txtMessage.Text = "WCF Service Error: " + ex.Message;
            }
        }

        private void btnMakePayment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // MainClient mainClient = new MainClient();
                MainClient mainClient = GetClient((bool)chkLocalhost.IsChecked);

                txtPaymentResult.Text = "";

                txtPacificCode.Text = txtPacificCode.Text.Trim(' ');
                string[] arrTest = txtPacificCode.Text.Split(' ');
                txtPacificCode.Text = string.Concat(arrTest);

                string[] arrCodeNumber = txtPacificCode.Text.Split(';');
                int amount = int.Parse(txtAmount.Text);

                PaymentModel result = mainClient.MakePayment(arrCodeNumber, amount);

                txtPaymentResult.Text = result.Success.ToString() + "-"
                    + result.Message;
                
                mainClient.Close();
            }
            catch (Exception ex)
            {
                txtPaymentResult.Text = ex.Message;
            }
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "+84932130483*12345*500000*0939146267*500000";
        }

        private void btnValue_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "+84939146267*9428 4988 2578 2945";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // lblMoneyPacific.Content = "...13...";
            // +ConfigurationSettings.AppSettings.Get("endpoint").ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
            txtPaymentResult.Text = "";
        }

        

        private void ChangeAddressService(string sNewAddress)
        { 
            
        }

      

       
    }
}
