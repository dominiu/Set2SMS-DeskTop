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
using System.Net;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Set2Desktop._pages
{
    /// <summary>
    /// Interaction logic for autoFindDevices.xaml
    /// </summary>
    public partial class autoFindDevices : Page
    {
        BackgroundWorker worker;

        int i = 0;
        int marginTop = 65;

        private delegate void DELEGATE();
        public autoFindDevices()
        {
            InitializeComponent();            
        }

        public void findDevices()
        {
            string myIp = _class.core.localIPAddress();
            string[] temp = myIp.Split('.');
            string startIp = temp[0] + "." + temp[1] + "." + temp[2] + ".";
           
            for (int i = 0; i < 255; i++)
            {
                try
                {
                    WebClient wc = new WebClient();                    
                    wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                    wc.DownloadStringTaskAsync(new Uri("http://" + startIp + i + ":8080/autoDetect/"));
                }
                catch
                {

                }
               
            }               
        }        

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {                               
                _class.deviceInfo device = null;
                var json = e.Result;
                device = JsonConvert.DeserializeObject<_class.deviceInfo>(json);

                marginTop = 65 * i;
                _controls.deviceField deviceField = new _controls.deviceField();
                deviceField.MouseDown += deviceField_click;
                deviceField.Margin = new Thickness(0, marginTop, 0, 0);
                deviceField.deviceName.Content = _class.core.DecodeFromUtf8(device.deviceName.Replace("\n", " "));
                deviceField.deviceIp.Content = device.deviceIP;
                deviceGrid.Children.Add(deviceField);
                i++;
            }
            catch
            {

            }
            
            
        }

        private void deviceField_click(object sender, RoutedEventArgs e)
        {
            _controls.deviceField clicked = (_controls.deviceField)sender;
            string[] ip = clicked.deviceIp.Content.ToString().Split(':');

            if (_class.core.connectToDevice(ip[0], ip[1]))
            {
                _class.core.contactList = null;
                this.NavigationService.Navigate(new _pages.contacts());
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();            
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Delegate del = new DELEGATE(findDevices);
            this.Dispatcher.Invoke(del);            
        }
    }
}
