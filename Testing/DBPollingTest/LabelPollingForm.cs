using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using LabelGeneratorLib;
using System.Threading;
using AMCCommon;

namespace DBPollingTest
{
    public partial class LabelPollingForm : Form
    {
        public LabelPollingForm()
        {

            InitializeComponent();

            Config.ReadSettingsFromRegistry();
            
            this.EventLog = new EventLogger("LabelPolling", "LabelPollingLog");

            Log("Label Polling Started", false);

            try
            {
                SqlCmd = new SqlCommands();
            }
            catch (System.Exception ex)
            {
                Log(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Form 1 Load...";

            // ja - start the timer 
            var callback = new TimerCallback(StartPolling);
            TheTimer = new System.Threading.Timer(callback, null, 0, (Config.PollingInterval * 1000));
        }
    }
        
}
