using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MegaTalentService
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void DashboardCloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void DashboardMinimizedBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
