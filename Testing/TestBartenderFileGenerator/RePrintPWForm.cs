using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestBartenderFileGenerator
{
    public partial class RePrintPWForm : Form
    {
        public RePrintPWForm()
        {
            InitializeComponent();
            //okBtn.Enabled = false;
        }

        private void passwordMTB_Enter(object sender, EventArgs e)
        {
//             if (passwordMTB.Text == "Jason")
//                 okBtn.Enabled = true;
        }

        private void RePrintPWForm_FormClosing(object sender, FormClosingEventArgs e)
        {
#if !DEBUG
            if (passwordMTB.Text != "GoDodgers18" && this.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Incorrect Password");
                e.Cancel = true;
            }
#endif
        }
    }
}
