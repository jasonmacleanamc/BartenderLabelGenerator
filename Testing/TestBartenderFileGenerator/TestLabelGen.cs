using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LabelGeneratorLib;
using System.Xml;
using System.Data.SqlClient;
using TestResultsLib;
using System.Threading;
using System.ComponentModel;
using System.Linq;

namespace TestBartenderFileGenerator
{
    
    public partial class TestLabelGen : Form
    {
        // ja - temp code...
        public LabelGen LabelGeneratorLib = null;

        List<string> sHardcodedLabel;
        List<string> sDataLabel;

        public PrinterArea ThePrinterArea { get; set; }

        private bool PopulatingList { get; set; }
        public bool PrintJobFound { get; private set; }
        public bool BurstLabels { get; private set; }

        private TestResults TheTestResults;

        private object ThreadParams = new object();

        DataProgress TheDataDialog = new DataProgress();

        public TestLabelGen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
#if DEBUG
            //workcodeTB.Text = "70706";
            workcodeTB.Text = "67219";
#else
             // ja - temp
            //finalCheckBox.Checked = true;
            //finalCheckBox.Enabled = false;
#endif
            // ja - init to make faster later on
            TheTestResults = new TestResults();

            DisableAllControls();

            sHardcodedLabel = ReadConfigFile("hardcoded");
            sDataLabel = ReadConfigFile("data");
            BurstLabels = false;
        }

        public List<string> ReadConfigFile(string sSearch)
        {
            
            List<string> strings = new List<string>();

            try
            {
                string ConfigFilePath = @"\\nightadder\btwFiles\BTLabelApp.config";

                // ja - get all the types of labels we need to print from the config
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFilePath);

                XmlElement root = doc.DocumentElement;
                XmlNode nm1 = doc.SelectSingleNode("/configuration/printerStations/final"); // You can also use XPath here

                XmlNodeList nm = nm1.ChildNodes;
                foreach (XmlNode node in nm)
                {
                    string slabeltype = node.Attributes.GetNamedItem("label_type").Value;

                    if (slabeltype.Equals(sSearch))
                    {
                        strings.Add(node.Name);
                    }

                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Config File is corrupt please contact Admin");
            }

            return strings;
        }

        private bool TestForPhilips(string sLabel)
        {
            bool bRet = false;

            string sTemp = sLabel.ToLower();
            if (sTemp.Contains("phillips") || sTemp.Contains("philips"))
                bRet = true;

            return bRet;
        }


        private void InitLabelGen()
        {
            if (singleFinalRB.Checked == true)
            {
                // ja - what kind of label are we printing?
                string sLabel = GetFinalDropDownValue();

                // ja - is this a phillips label?
                if (TestForPhilips(sLabel))
                    LabelGeneratorLib.SetCustomer(Customers.phillips);
               
                // ja - override the quantity for hardcoded labels
                if ((int)genericQtyUD.Value > 0)
                    LabelGeneratorLib.SetSingleLabelQty(Convert.ToInt32(genericQtyUD.Value));
            }

            // ja- put this into a thread...
            try
            {
                //DataProgress TheDataDialog = new DataProgress();

                DisableAllControls();

                // ja - launch a background worker thread to read in the data
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += delegate { AddPrintJobThread(); };
                worker.RunWorkerCompleted += PrintJobThreadDone;
                worker.RunWorkerAsync();

                // ja - show a modal progress dialog

                TheDataDialog.ShowDialog();

                //worker.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }                         

            // ja - enable or disable check all 
            bool bCanCheckAll = ThePrinterArea != PrinterArea.final;

            //#if !DEBUG
            bCanCheckAll = true;
            checkAllChk.Checked = false;
            checkAllChk.Enabled = bCanCheckAll;
//#endif
            


        }

        private void AddPrintJobThread()
        {
            PrintJobFound = LabelGeneratorLib.AddPrintJob(ThePrinterArea, GetWorkCode(), true);
        }

        private void PrintJobThreadDone(object sender, RunWorkerCompletedEventArgs e)
        {
            if (PrintJobFound)
            {
                PopulatingList = true;

                for (int i = 1001; i < (1001 + LabelGeneratorLib.GetLabelQty()); i++)
                {
                    string sSerialNumber = workcodeTB.Text + "-" + i.ToString();
                    listView1.Items.Add(sSerialNumber);
                }

                PopulatingList = false;

                SetStationGBControls(false);
                SetLabelInfoGBControls(true);
            }
            else
                 MessageBox.Show("WorkCode Not found in Database");

            TheDataDialog.Close();
        }


        // ja - to make the call to the listview thread safe
        //         private delegate ListView.ListViewItemCollection GetItems(ListView lstview);
        // 
        //         private ListView.ListViewItemCollection getListViewItems(ListView lstview)
        //         {
        //             ListView.ListViewItemCollection temp = new ListView.ListViewItemCollection(new ListView());
        //             if (!lstview.InvokeRequired)
        //             {
        //                 foreach (ListViewItem item in listView1.Items)
        //                     temp.Add((ListViewItem)item.Clone());
        //                 return temp;
        //             }
        //             else
        //                 return (ListView.ListViewItemCollection)this.Invoke(new GetItems(getListViewItems), new object[] { listView1 });
        //         }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "Reading Data from Database...";

            GoBtn.Enabled = false;
            printBtn.Enabled = false;

            listView1.Clear();
            checkAllChk.Checked = false;

            bool bFinalOverride = singleFinalRB.Checked;

            string sLabelLocation = "";
            ThePrinterArea = 0;

            if (smtRB.Checked)
            {
                sLabelLocation = "serial1";
                ThePrinterArea = PrinterArea.smt;
            }
            else if (baseplateRB.Checked)
            {
                sLabelLocation = "Large_AMC_BasePlate";
                //sLabelLocation = "burst1_2d";
                ThePrinterArea = PrinterArea.baseplate;
            }
            else if (inProcessRB.Checked)
            {
                sLabelLocation = "Small_AMC_InProcess";
                //sLabelLocation = "inproc2_2d";
                ThePrinterArea = PrinterArea.in_process;

                // ja - for in process ask if this is a re print otherwise labels will be bursted into amplifs
                if (MessageBox.Show("Is this a Re-Print?", "Label Printer", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    BurstLabels = true;

            }
            else if (finalRB.Checked)
            {
                sLabelLocation = "inproc2_2d";
                ThePrinterArea = PrinterArea.final;
            }
                       
            //string sWorkCode = workcodeTB.Text.Trim();
            bool bPrintNow = forcePrintNowCB.Checked == true;

            if (bFinalOverride)
            {
                //LabelOverrides labelOverride = GetOverride();
                string labelOverride = GetFinalDropDownValue();

                LabelGeneratorLib = new LabelGen(labelOverride, true);
            }
            else
                LabelGeneratorLib = new LabelGen(sLabelLocation, true);

            //DataReadThread

            InitLabelGen();           

            GoBtn.Enabled = false;
            clearBtn.Enabled = true;
            printBtn.Enabled = true;

            if (BurstLabels)
                RemoveBurstedSerials();

            StatusLabel.Text = "Data Populated...";

            ScanTB.Focus();


        }

        private string GetFinalDropDownValue(bool bCheckForValue = true)
        {
            //LabelOverrides labelOverride = (LabelOverrides)0;
            string selected = "";
            try
            {
                int nSel = finalCB.SelectedIndex;

                if (nSel > -1)
                {

                    //labelOverride = (LabelOverrides)nSel;

                    selected = finalCB.GetItemText(finalCB.SelectedItem);

                    //labelOverride = (LabelOverrides)Enum.Parse(typeof(LabelOverrides), selected.ToLower());
                }
                else
                {
                    if (bCheckForValue)
                        MessageBox.Show("Please Choose an Item from the Special Final Combobox");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return selected;
        }

        // ja - print routine for generic final labels
        private void finalPrintBtn_Click(object sender, EventArgs e)
        {
            PrinterArea printArea = PrinterArea.final;

            //LabelOverrides labelOverride = GetOverride();
            string labelOverride = GetFinalDropDownValue();

            LabelGeneratorLib = new LabelGen(labelOverride, true);

            LabelGeneratorLib.AddPrintJob(printArea);

            List<string> list = new List<string>();

            for (int i = 0; i < genericQtyUD.Value; i++)
            {
                list.Add("99999-1001");
            }

            LabelGeneratorLib.AddDataRowFromDB(list);

            if (LabelGeneratorLib.PrintLabels())
            {
                MessageBox.Show("Labels Printed Successfully");
            }
            else
                MessageBox.Show("There was a Problem Printing Labels", "Label Printer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

        }

        private List<string> GetSerials()
        {
            List<string> list = new List<string>();

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                {
                    list.Add(item.Text);
                }
            }

            return list;
        }

        private void RemoveBurstedSerials()
        {
            PMDatabases.UpdateDatabases burstData = new PMDatabases.UpdateDatabases();

            string sWorkCode = GetWorkCode();
            List<string> burstedList = new List<string>();

            try
            {
                burstedList = burstData.GetExistingSerials(sWorkCode);

                // ja - remove all of the already bursted serials
                foreach (string sSerial in burstedList)
                {
                    ListViewItem item = listView1.FindItemWithText(sSerial);
                    if (item != null)
                        item.Remove();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void BurstSerials(List<string> theSerials)
        {

//#if 1
            if (inProcessRB.Checked)
            {
                PMDatabases.UpdateDatabases burstData = new PMDatabases.UpdateDatabases();

                string sWorkCode = GetWorkCode();

                // ja - this will read the partnumber from epicor
                TestResults res = new TestResults(sWorkCode);

                string sPartNumber = res.GetPartNumber();

                int nArraySize = theSerials.Count;

                string[] serialNumbers = new string[nArraySize];

                int nPosition = 0;
                foreach (string sSerial in theSerials)
                {
                    serialNumbers[nPosition] = sSerial;                   

                    nPosition++;                    
                }

                burstData.Burst(serialNumbers, sPartNumber, sWorkCode);
            }

//#endif
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (rmaCB.Checked && finalRB.Checked)
                ShowRmaDlg();            

            printBtn.Enabled = false;
          
            if (finalRB.Checked && workCodeCB.Checked)
            {
                string sWorkCode = workcodeTB.Text.Trim();
                PrintLabel(sWorkCode);
                return;
            }

            List<string> serialsList = GetSerials();

            if (serialsList.Count == 0)
            {
                MessageBox.Show("No Items to Print");
                return;
            }

            // ja - add the serial numbers to the print job
            LabelGeneratorLib.AddDataRowFromDB(serialsList);

            // ja - print the labels for all of the jobs 
            if (LabelGeneratorLib.PrintLabels())
            {
                // ja - burst the serial numbers
                if (BurstLabels)
                    BurstSerials(serialsList);

                LogLables(serialsList);

                MessageBox.Show(serialsList.Count.ToString() +  " - Labels Printed Successfully");                            
            }
            else
                MessageBox.Show("There was a Problem Printing Labels", "Label Printer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            printBtn.Enabled = true;

#if DEBUG
            System.Diagnostics.Process.Start(@"\\nightadder\btwFiles\testFiles");
#endif

        }

        private void LogLables(List<string> serialsList)
        {
            bool bIsRma = rmaCB.Checked;
            string sLabelStation = "";
            string sLabelType = GetFinalDropDownValue(false);

            if (smtRB.Checked)
                sLabelStation = "SMT";
            else if (baseplateRB.Checked)
                sLabelStation = "BasePlate";
            else if (inProcessRB.Checked)
                sLabelStation = "InProcess";
            else if (finalRB.Checked)
                sLabelStation = "Final";

            try
            {
                TestResults.LogLables(serialsList, bIsRma, sLabelStation, sLabelType, BurstLabels);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                listView1.MultiSelect = true;
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Selected = true;
                }
            }
        }

        private void checkAllChk_CheckedChanged(object sender, EventArgs e)
        {

            if (PopulatingList)
                return;

#if !DEBUG
//             // ja - we canot allow them to do this for final becaus of the label check
//             if (finalRB.Checked)
//             {
//                 MessageBox.Show("Select all is Disabled for Final Labels");
//                 return;
//             }

            
#endif
            checkAllChk.Enabled = false;

            bool bChecked = checkAllChk.Checked;

            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = bChecked;
            }

            if (bChecked)
                checkAllChk.Text = "De-Select All";
            else
                checkAllChk.Text = "Select All";

            checkAllChk.Enabled = true;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
//#if !DEBUG

            // ja - Check for test and burn requirements 
            if (finalRB.Checked && !PopulatingList)// && checkAllChk.Checked)
            {
                string sSerialNumber = e.Item.SubItems[0].Text;
                if (!CheckTestResults(sSerialNumber))
                {
                    e.Item.Remove();
                    return;
                }
            }            
//#endif

            ListViewItem.ListViewSubItem selItem = e.Item.SubItems[0];   
            
            selItem.Font = new System.Drawing.Font(selItem.Font, selItem.Font.Style & ~System.Drawing.FontStyle.Bold);

            if (e.Item.Checked)
                selItem.Font = new System.Drawing.Font(selItem.Font, selItem.Font.Style | System.Drawing.FontStyle.Bold);

            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            int nCount = checkedItems.Count;

            numItemsLbl.Text = nCount.ToString() + " Items Selected";
        }

        private bool CheckTestResults(string sSerialNumber)
        {
            if (rmaCB.Checked)
                return true;

            string sMsgStart = sSerialNumber + " - Has Not Passed the Following:";
            string sMsgMiddle = "";
            string sMsgEnd = "Final Label will not be Printed!";
            string sCaption = "Label Error - " + sSerialNumber;          

            try
            {
                // ja - set the serial number for test Results lib
                TheTestResults.SetSerialNumber(sSerialNumber);
                List<string> sFailedTests = TheTestResults.GetFailedTypes();

                foreach (string sTestDesc in sFailedTests)
                {
                    sMsgMiddle += Environment.NewLine + "( '" + sTestDesc + "' )";
                }

                if (!string.IsNullOrEmpty(sMsgMiddle))
                {
                    string sMsg = sMsgStart + Environment.NewLine + sMsgMiddle + Environment.NewLine + Environment.NewLine + sMsgEnd;
                    MessageBox.Show(sMsg, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;  
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            DisableAllControls();

            SetStationGBControls(true);

            listView1.Items.Clear();

            // ja - clear out the global library 
            LabelGeneratorLib = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        //string _Barcode;

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            string x = e.KeyValue.ToString();

            string y = ((char)e.KeyCode).ToString();

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            //int y = 0;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // e.GetType().listView1.item.Checked = true;

            //e.Item.Checked = true;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //             System.Windows.Forms.ListViewItem.ListViewSubItem selItem = e.Item.SubItems[0];
            //             selItem.Font = new System.Drawing.Font(selItem.Font, selItem.Font.Style & ~System.Drawing.FontStyle.Bold);
            // 
            //             e.Item.Checked = true;
            //             selItem.Font = new System.Drawing.Font(selItem.Font, selItem.Font.Style | System.Drawing.FontStyle.Bold);
            // 
            //             ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            //             int nCount = checkedItems.Count;
            // 
            //             numItemsLbl.Text = nCount.ToString() + " Items Selected";
        }



        private void finalRB_CheckedChanged(object sender, EventArgs e)
        {
            bool bIsChecked = finalRB.Checked;

            SetFinalControls(bIsChecked);
        }

        private void smtRB_CheckedChanged(object sender, EventArgs e)
        {
            SetWorkCodeSettings();
        }

        private void inProcessRB_CheckedChanged(object sender, EventArgs e)
        {
            SetWorkCodeSettings();
        }

        private void baseplateRB_CheckedChanged(object sender, EventArgs e)
        {
            SetWorkCodeSettings();
        }

        private void SetWorkCodeSettings()
        {
            // ja - disable the final settings
            SetFinalControls(false);
        }

        private void SetFinalControls(bool bEnabled)
        {
            bool bIsChecked = finalRB.Checked;

            workCodeCB.Enabled = true;
            workCodeCB.Checked = true;

            singleFinalRB.Enabled = bIsChecked;
            genericRB.Enabled = bIsChecked;

        }

        private void DisableAllControls()
        {
            SetWorkCodeGBControls(false);
            SetLabelInfoGBControls(false);
            SetLabelTypeGBControls(false);
            SetSpecialFinalGBControls(false);
        }


        private void SetControlStates(GroupBox gbControl, bool bEnabled)
        {
            foreach (Control ctl in gbControl.Controls)
            {
                if (ctl.Name != reset_btn.Name)
                {

                    if (ctl.GetType() != typeof(Label))
                        ctl.Enabled = bEnabled;
                }
            }
        }

        private void SetWorkCodeGBControls(bool bEnabled)
        {

            SetControlStates(workCodeGB, bEnabled);
        }

        private void SetLabelInfoGBControls(bool bEnabled)
        {
            SetControlStates(labelInfoGB, bEnabled);
        }


        private void SetLabelTypeGBControls(bool bEnabled)
        {
            SetControlStates(labelTypeGB, bEnabled);
        }

        private void SetSpecialFinalGBControls(bool bEnabled)
        {
            SetControlStates(specialFinalGB, bEnabled);

            finalPrintBtn.Enabled = false;
            finalPrintBtn.Text = "Enter WC";
        }

        private void SetStationGBControls(bool bEnabled)
        {
            if (bEnabled)
            {
                smtRB.Checked = false;
                inProcessRB.Checked = false;
                finalRB.Checked = false;
                baseplateRB.Checked = false;
            }

            SetControlStates(stationGB, bEnabled);

        }

        private void workCodeCB_CheckedChanged(object sender, EventArgs e)
        {
            bool bIsChecked = workCodeCB.Checked;

            if (bIsChecked)
            {
                SetWorkCodeGBControls(true);
                SetSpecialFinalGBControls(false);

                // ja -git test
                specialFinalStatic.Text = "";
            }
        }

        private void overrideCB_CheckedChanged(object sender, EventArgs e)
        {
            bool bIsChecked = singleFinalRB.Checked;

            if (bIsChecked)
            {
                SetWorkCodeGBControls(false);
                SetSpecialFinalGBControls(true);

                finalCB.Items.Clear();
                finalCB.Text = "";

                ////
                //                 List<string> shardcode = ReadConfigFile("hardcoded");
                //                 List<string> sLabelData = ReadConfigFile("new");

                finalCB.Items.Add("None");
                foreach (string sLabelType in sDataLabel)
                {
                    finalCB.Items.Add(sLabelType);
                }

                specialFinalStatic.Text = "Select the Type of Label to Print with PM Data.";
            }
        }

        private void finalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool bIsChecked = genericRB.Checked;

            if (bIsChecked)
            {
                SetWorkCodeGBControls(false);
                SetSpecialFinalGBControls(true);

                finalCB.Items.Clear();
                finalCB.Text = "";


                finalCB.Items.Add("None");
                foreach (string sLabelType in sHardcodedLabel)
                {
                    finalCB.Items.Add(sLabelType);
                }


                specialFinalStatic.Text = "Select the Type of Generic Label and the Quantity to Print.";

            }
        }

        private void finalCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bIsGenericChecked = genericRB.Checked;
            bool bIsSingleChecked = singleFinalRB.Checked;

            if (bIsSingleChecked && finalCB.SelectedIndex > 0)
            {
                SetWorkCodeGBControls(true);
            }

            if (bIsGenericChecked && finalCB.SelectedIndex > 0)
            {
                finalPrintBtn.Enabled = true;
                finalPrintBtn.Text = "Print";
            }
        }

        private void workcodeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == 13)
            {
                GoBtn.PerformClick();
            }
        }

        private void listView1_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show("Got it");
        }

        private void filterChk_CheckedChanged(object sender, EventArgs e)
        {
            // ja - filter the results

        }

        private void FizzBuzz()
        {
            for (int nCount = 1; nCount <= 100; nCount++)
            {
                string sOutput = "";

                //sOutput = ((((nCount % 3 == 0) ? "Fizz" : "") + ((nCount % 5 == 0) ? "Buzz" : ""))) = true ? "" : nCount.ToString();

                if (nCount % 3 == 0)
                    sOutput = "Fizz";

                if (nCount % 5 == 0)
                    sOutput += "Buzz";

                if (String.IsNullOrEmpty(sOutput))
                    sOutput = nCount.ToString();

                Console.WriteLine(sOutput);
            }
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            //FizzBuzz();

            DisableAllControls();

            // ja - reset all parameters
            smtRB.Checked = false;
            inProcessRB.Checked = false;
            baseplateRB.Checked = false;
            finalRB.Checked = false;
            workCodeCB.Checked = false;
            singleFinalRB.Checked = false;
            genericRB.Checked = false;
            rmaCB.Checked = false;

            genericQtyUD.Value = 1;

            listView1.Items.Clear();

            finalCB.Items.Clear();
            workcodeTB.Clear();

            StatusLabel.Text = "";

            //SetFinalControls(false);
            SetControlStates(workCodeGB, false);
            SetControlStates(stationGB, true);

            BurstLabels = false;

            // ja -Temp
            //singleFinalRB.Enabled = false;
        }

        private void rmaDataBtn_Click(object sender, EventArgs e)
        {
            RMAData rmaData = new RMAData();

            rmaData.ShowDialog();

            string sRmaDateCode = rmaData.RMADateCode;
            string sRmaVersion = rmaData.RMAVersion;
        }



        private void PrintLabel(string sWorkCode)
        {
            Console.WriteLine("Printing Labels: " + sWorkCode + "...");

            StatusLabel.Text = "Printing Labels for: " + sWorkCode + "...";

            try
            {
                // ja - start a new print job
                LabelGen pd = new LabelGen();

                // ja - from the table name determine the location they are printing from
                LabelGeneratorLib.PrinterArea eLoc = PrinterArea.final;

                // ja - add the job (read labelcodes from Database)
                pd.AddPrintJob(eLoc, sWorkCode, true);

                // ja - read the serials database and fill the list
                List<string> myList = GetSerials();

                // ja - add the serial numbers to the print job
                pd.AddDataRowFromDB(myList);

                // ja - print the labels for all of the jobs
                if (pd.PrintLabels())
                {
                    MessageBox.Show("Labels Printed Successfully");
                    StatusLabel.Text = "Labels Printed Successfully";
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ScanTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void ScanTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                var item = listView1.FindItemWithText(ScanTB.Text.Trim());

                if (item != null)
                {
                    //item.Selected = true;
                    item.Checked = true;


                }

                ScanTB.Text = "";

                ScanTB.Focus();


                //                 MessageBox.Show(ScanTB.Text);
                // 
                //                 int index = listView1.FindString(myString, -1);
                //                 if (index != -1)
                //                 {
                //                     // Select the found item:
                //                     listBox1.SetSelected(index, true);
                //                     // Send a success message:
                //                     MessageBox.Show("Found the item \"" + myString +
                //                         "\" at index: " + index);
                //                 }
                //                 else
                //                     MessageBox.Show("Item not found.");
            }
        }

        private void MainBtn_Click(object sender, EventArgs e)
        {
            ShowRmaDlg();
        }

        private void ShowRmaDlg()
        {
            LabelSelect dlg = new LabelSelect(this);

            var res = dlg.ShowDialog();

            if (res == DialogResult.OK)
            {
                StatusLabel.Text = "Job Information Modified...";
            }

            // TODO: ja - get results from gridview and modify print job
        }

        // ja - Public functions for Select Label Dialog

        public bool IsFinal()
        {
            return finalRB.Checked;
        }

        public string GetJobNumber()
        {
            return workcodeTB.Text;
        }

        public string GetWorkCode()
        {
            string sWorkCode = "";
            this.Invoke(new MethodInvoker(delegate () { sWorkCode = workcodeTB.Text.Trim(); }));

            return sWorkCode;
        }

    }
}
