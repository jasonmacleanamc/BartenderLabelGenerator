using LabelGeneratorLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestBartenderFileGenerator
{
    public partial class LabelSelect : Form
    {
        public TestLabelGen TheParent { get; set; }

        public LabelSelect(object Parent)
        {
            InitializeComponent();

            TheParent = (TestLabelGen)Parent;
        }

        private void LabelSelect_Load(object sender, EventArgs e)
        {
            ReadSelectedLabels();
        }

        private void ReadSelectedLabels()
        {
            if (TheParent.IsFinal())
            {
                GetLabelTypesFromDataBase();

                partNumberTB.Text = GetPartNumber();
                versionUD.Value = Convert.ToDecimal(GetPartVersion());
                jobNumberTB.Text = GetJobNumber();
;
                dateCodeTB.Text = GetDateCode();
                revTB.Text = GetRevision();
                inputTB.Text = GetInput();
                OutputTB.Text = GetOutput();
            }
        }
               
        // TODO: ja - read from Label Gen Config
        public string GetConnectionString()
        {
            string ConnectionString = "user id=" + "prodmanuser" + ";password=" + "71m30u7" + ";Data Source=" + "BUSHMASTER" + ";Initial Catalog=" + "ProductionManualLabels" + ";Integrated Security=True";

            return ConnectionString;
        }

        // TODO: ja - move to Config??
        private void GetLabelTypesFromDataBase()
        {
            string ConnectionString = ConfigValues.GetConnectionString();

            SqlDataReader myReader = null;
            SqlConnection TheConnection = null;
            string sPartNumber = GetPartNumber();
            string sPartVersion = GetPartVersion();

            try
            {
                TheConnection = new SqlConnection(ConnectionString);

                TheConnection.Open();

                // ja - get the label information from the database view
                SqlCommand myCommand = new SqlCommand("select * from label_Data where Part_Number = '" + sPartNumber + "' and Part_Version = '" + sPartVersion + "'", TheConnection);
                myReader = myCommand.ExecuteReader();              

                // ja - loop through all of the assigned label types
                while (myReader.Read())
                {
                    // ja - get the information from the database
                    string sLocation = myReader["Location_Name"].ToString();
                    string sType = myReader["Label_Type_Name"].ToString();
                    string sQty = myReader["Print_Qty"].ToString();
                    string sCustomerName = myReader["Customer_Name"].ToString();  

                    int nRow = dataGridView1.Rows.Add();

                    dataGridView1.Rows[nRow].Cells[0].Value = true;
                    dataGridView1.Rows[nRow].Cells[1].Value = sLocation;
                    dataGridView1.Rows[nRow].Cells[2].Value = sType;
                    dataGridView1.Rows[nRow].Cells[3].Value = sQty;
                    dataGridView1.Rows[nRow].Cells[4].Value = sCustomerName;                   
                }

                myReader.Close();
                TheConnection.Close();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                myReader.Close();
                TheConnection.Close();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateBtn_Click_1(object sender, EventArgs e)
        {
            SetDateCode(dateCodeTB.Text);
            SetVersion(versionUD.Value.ToString());
            SetPartNumber(partNumberTB.Text);
            SetRevision(revTB.Text);
            SetInput(inputTB.Text);
            SetOutput(OutputTB.Text);

            MessageBox.Show("Label Data Updated");

            this.Close();
        }        

        public string GetPartNumber()
        {
            LabelDataStruct partInfo = TheParent.LabelGeneratorLib.GetWorkCodeData();

            return partInfo.PartNumber;
        }

        public string GetJobNumber()
        {
            return TheParent.GetJobNumber();
        }

        public string GetPartVersion()
        {
            LabelDataStruct partInfo = TheParent.LabelGeneratorLib.GetWorkCodeData();

            string sVersion = ConfigValues.ConvertIntVersion(partInfo.nVersion);

            return sVersion;
        }

        public string GetDateCode()
        {
            LabelDataStruct partInfo = TheParent.LabelGeneratorLib.GetWorkCodeData();

            string sDateCode = partInfo.DateCode;

            return sDateCode;
        }

        public string GetRevision()
        {
            LabelDataStruct partInfo = TheParent.LabelGeneratorLib.GetWorkCodeData();

            string sRevision = partInfo.RevLetter;

            return sRevision;
        }

        public string GetInput()
        {
            LabelDataStruct partInfo = TheParent.LabelGeneratorLib.GetWorkCodeData();

            string sInput = partInfo.InputSpecs;

            return sInput;
        }

        public string GetOutput()
        {
            LabelDataStruct partInfo = TheParent.LabelGeneratorLib.GetWorkCodeData();

            string sOutput = partInfo.OutputSpecs;

            return sOutput;
        }

        public void SetDateCode(string sDateCode)
        {
            if (sDateCode != GetDateCode())
                TheParent.LabelGeneratorLib.SetRMADateCode(sDateCode);
        }

        public void SetVersion(string sVersion)
        {
            if (sVersion != GetPartVersion())
                TheParent.LabelGeneratorLib.SetRMAVersion(sVersion);
        }

        public void SetPartNumber(string sPartNumber)
        {
            if (sPartNumber != GetPartNumber())
                TheParent.LabelGeneratorLib.SetRMAPartNumber(sPartNumber);
        }

        public void SetRevision(string sRevision)
        {
            if (sRevision != GetRevision())
                TheParent.LabelGeneratorLib.SetRMARevision(sRevision);
        }

        public void SetInput(string sInput)
        {
            if (sInput != GetInput())
                TheParent.LabelGeneratorLib.SetRMAInput(sInput);
        }

        public void SetOutput(string sOutput)
        {
            if (sOutput != GetInput())
                TheParent.LabelGeneratorLib.SetRMAOutput(sOutput);
        }

        private void dateCodeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void revTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar);// && !char.IsControl(e.KeyChar);
        }

        private void GetFromBtn_Click(object sender, EventArgs e)
        {
            string sPartNumber = PopFromPNTB.Text;
            string sVersion = PopFromVerUD.Value.ToString();

            try
            {
                LabelGen lg = new LabelGen();
                RmaOverrides rma = lg.GetRMADataFromPartsInfo(sPartNumber, sVersion);

                inputTB.Text = rma.InputSpecs;
                revTB.Text = rma.RevLetter;
                OutputTB.Text = rma.OutputSpecs;
                partNumberTB.Text = sPartNumber;
                versionUD.Value = Convert.ToDecimal(sVersion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void todayCK_CheckedChanged(object sender, EventArgs e)
        {
            if (todayCK.Checked)
            {
                DateTime dt = DateTime.Now;

                double dWeeks = (dt.DayOfYear / 7);

                if (dWeeks < 1.00)
                    dWeeks = 1;
                else
                    dWeeks += 1;

                int Weeks = ((int)dWeeks);
                var sYear = DateTime.Now.ToString("yy");

                var sWeeks = string.Format("{0}", Weeks);
                if (Weeks < 10)
                    sWeeks = string.Format("0{0}", Weeks);

                string dc = string.Format("{0}{1}", sYear, sWeeks);
                dateCodeTB.Text = dc;
            }
            else
            {
                dateCodeTB.Text = "";
            }
        }
    }
}
