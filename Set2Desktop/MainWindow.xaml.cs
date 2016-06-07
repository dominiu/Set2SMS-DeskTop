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
using MahApps.Metro.Controls;
using System.Threading;

namespace Set2Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            setPosition();
            startServer();
        }        

        private void setPosition()
        {
            this.Left = SystemParameters.PrimaryScreenWidth - (this.Width + 10);
            this.Top = 10;
        }

        public void startServer()
        {
            _class.HttpServer httpServer;            
            httpServer = new _class.MyHttpServer(int.Parse(_class.core.settings.recivePort));            
            Thread thread = new Thread(new ThreadStart(httpServer.listen));
            thread.Start();            
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _forms.settings S = new _forms.settings();
            S.Show();
            
        }        

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.mainFrame.Navigate(new _pages.contacts());            
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_class.core.isConnected || _class.core.ip == "")
            {
                this.mainFrame.Navigate(new _pages.connectToDevice());
            }
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
