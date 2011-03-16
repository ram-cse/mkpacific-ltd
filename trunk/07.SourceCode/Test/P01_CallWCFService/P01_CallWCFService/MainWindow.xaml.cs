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
using System.Threading;

using MoneyPacificService.DTO;

namespace P01_CallWCFService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainClient mainClient;        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtAmount.Text = "1000";
            //txtPhone.Text = "0932130483";
            txtContent.Text = "0932130483*12345*500000*0939146267*500000";
            txtMessage.Text = "";

            rdoLocalhost.IsChecked = true;

            mainClient = new MainClient("BasicHttpBinding_IMain");
        }

        private void rdoBuy_Checked(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "0932130483*12345*500000*0939146267*500000";
        }

        private void rdoValue_Checked(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "0932130483*6369 4340 8380 5658";
        }

        private void rdoMplas_Checked(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "0932130483*MPLAS*12345";
        }

        private void rdoMpday_Checked(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "0932130483*MPDAY*12345";
        }

        private void rdoMpbal_Checked(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "0932130483*MPBAL*12345";
        }

        private void rdoMpdis_Checked(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "0932130483*MPDIS*12345";
        }

        private void rdoMpena_Checked(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "0932130483*MPENA*54321";
        }

        private void rdoMpcol_Checked(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "0932130483*MPCOL*12345";
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            btnSend.IsEnabled = false;
            txtMessage.Text = "Waiting...";

            //Thread thread = new Thread(new ThreadStart(
            //    delegate()
            //    {
            //        //Thread.Sleep(500);
            //        txtMessage.Dispatcher.Invoke(
            //            System.Windows.Threading.DispatcherPriority.Normal,
            //            new Action(
            //                delegate()
            //                {
            //                    txtMessage.Text = "Hello abc...";
            //                }
            //            )
            //        );
            //    }
            //));

            Thread thread = new Thread(new ThreadStart(
                delegate()
                {
                    Thread.Sleep(500);
                    txtMessage.Dispatcher.Invoke(
                        System.Windows.Threading.DispatcherPriority.Background,
                        new Action(
                            delegate()
                            {
                                try
                                {
                                    txtMessage.Text = mainClient.SendMessage(txtContent.Text);
                                }
                                catch (Exception ex)
                                {
                                    txtMessage.Text = "WCF Error:" + ex.Message;
                                }
                            }
                        )
                    );
                }
            ));

            thread.Start();

            btnSend.IsEnabled = true;
        }

        private void rdoTest_Checked(object sender, RoutedEventArgs e)
        {
            mainClient = new MainClient("BasicHttpBinding_IMain");
        }

        private void rdoLocalhost_Checked(object sender, RoutedEventArgs e)
        {
            //mainClient = new MainClient("BasicHttpBinding_Localhost");
        }

        private void rdoServer_Checked(object sender, RoutedEventArgs e)
        {
            //mainClient = new MainClient("BasicHttpBinding_Server");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = replacePhone(txtContent.Text, txtPhone.Text);
        }

        #region SERVICES
        private string replacePhone(string sContent, string newPhone)
        {
            string sResult = "";
            int p = 0;
            for (int i = 0; i < sContent.Length; i++)
            {
                if (sContent[i] == '*')
                {
                    p = i;
                    break;
                }
            }
            sResult = sContent.Remove(0, p);
            sResult = newPhone + sResult;

            return sResult;
        }

        private void CallService()
        {
            
        }
        
        #endregion 

        private void txtPacificCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            txtPacificCode.Text = txtPacificCode.Text.Trim(' ');

            string[] arrTest = txtPacificCode.Text.Split(' ');
            txtPacificCode.Text = string.Concat(arrTest);

            string[] arrCodeNumber = txtPacificCode.Text.Split(';');
            int amount = int.Parse(txtAmount.Text);
                        
            Thread thread = new Thread(new ThreadStart(
                delegate()
                {
                    Thread.Sleep(50);
                    txtMessage.Dispatcher.Invoke(
                        System.Windows.Threading.DispatcherPriority.Background,
                        new Action(
                            delegate()
                            {
                                try
                                {
                                    PaymentModel result = mainClient.MakePayment(arrCodeNumber, amount);
                                    txtMessage.Text = result.Success.ToString() + ' ' + result.Message;
                                }
                                catch (Exception ex)
                                {
                                    txtMessage.Text = "WCF Error:" + ex.Message;
                                }
                            }
                        )
                    );
                }
            ));

            thread.Start();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mainClient.Close();
        }
    }
}
