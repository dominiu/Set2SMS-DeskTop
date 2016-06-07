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
using System.Threading;

namespace Set2Desktop._pages
{
    /// <summary>
    /// Interaction logic for connectToDevice.xaml
    /// </summary>
    public partial class connectToDevice : Page
    {
        public connectToDevice()
        {
            InitializeComponent();
            status.Visibility = Visibility.Hidden;
            this.ip.Text = _class.core.localIPAddress();
        }

        private void connect_btn_Click(object sender, RoutedEventArgs e)
        {
            status.Visibility = Visibility.Visible;
            status.Content = "Trying to connect to mobile...";           
            _class.core.connectToDevice(ip.Text.ToString(), port.Text.ToString());
            status.Content = "Connected....";
            status.Visibility = Visibility.Hidden;

            if (_class.core.isConnected)
            {
                this.NavigationService.Navigate(new _pages.contacts());
            }
        }

        private void searchDevices_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new _pages.autoFindDevices());    
        }
            
    }
}
