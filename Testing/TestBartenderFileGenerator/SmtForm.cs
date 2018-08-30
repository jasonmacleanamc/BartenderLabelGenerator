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
    public partial class SmtForm : Form
    {

        public int SmtCount {
            get { return Convert.ToInt32(smtCountUD.Value); }
            set { }
        }

        public string WorkCode
        {
            get { return workCodeTB.Text; }
            set { }
        }

        public SmtForm()
        {
            InitializeComponent();
        }

       
    }
}
