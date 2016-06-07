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

namespace Set2Desktop._controls
{
    /// <summary>
    /// Interaction logic for contactField.xaml
    /// </summary>
    public partial class contactField : UserControl
    {
               
        public contactField()
        {
            InitializeComponent();            
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.backGround.Fill = new SolidColorBrush(System.Windows.Media.Colors.AliceBlue);
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.backGround.Fill = new SolidColorBrush(System.Windows.Media.Colors.Transparent);
        }                         
    }
}
