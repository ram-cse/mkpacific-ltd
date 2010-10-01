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

namespace P9_CallMoneyPacificSrv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainClient mainClient = new MainClient();
                txtMessage.Text = "";
                txtMessage.Text = mainClient.SendMessage(txtContent.Text);
                mainClient.Close();
            }
            catch (Exception ex)
            {
                txtMessage.Text = "WCF Service Error: " + ex.Message;
            }
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "0932130483*12345*500000*0939146267*500000";
        }

        private void btnValue_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = "0939146267*9428 4988 2578 2945";
        }
    }
}
