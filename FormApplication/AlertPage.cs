using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApplication
{
    public partial class AlertPage : Form
    {
        public AlertPage(string message)
        {
            InitializeComponent();
            labelMessage.Text = message;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {

        }

        private void btnAgree_Click(object sender, EventArgs e)
        {

        }
    }
}
