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
    public partial class RMAData : Form
    {
        public string RMAVersion;
        public string RMADateCode;

        public RMAData()
        {
            InitializeComponent();
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            RMAVersion = versionUP.Value.ToString();
            RMADateCode = dateCodeTB.Text;
        }
    }
}
