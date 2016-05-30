using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Set2SMS_Desktop
{
    public partial class mainFrm : Form
    {
        private void setPosition(){
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;            
            this.Location = new Point(x, y);
        }

        public mainFrm()
        {
            InitializeComponent();            
        }

        private void mainFrm_Load(object sender, EventArgs e)
        {
            this.setPosition();
        }
    }
}
