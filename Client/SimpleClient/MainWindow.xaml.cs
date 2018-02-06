using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleClient
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SimpleService.SimpleServiceClient httpClient = new SimpleService.SimpleServiceClient("WSHttpBinding_ISimpleService");
            SimpleService.SimpleServiceClient netTcpClient = new SimpleService.SimpleServiceClient("NetTcpBinding_ISimpleService");

            TextBlock.Text = netTcpClient.GetMessage(TextBox.Text);
        }
    }
}
