using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChinanetCenterAssistant
{
    public partial class MainFrm : Form
    {

        Login login = new Login();
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainFrm_Shown(object sender, EventArgs e)
        {
            login.ShowDialog();
        }
    }
}
