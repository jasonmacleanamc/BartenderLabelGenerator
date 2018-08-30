using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using AMCCommon;
using System.Threading;

namespace LabelCodePopulator
{
    public partial class LabelCodeForm : Form
    {

        // TODO: ja - share this across code base
        public enum LabelTypes
        {
            none = 0,
            small = 1,
            large = 2,
            both = 3,
            cable = 4,
            philips_small = 10,
            philips_large = 20,
            philips_packing = 50
        }

        public enum PrinterArea
        {
            smt = 20,
            in_process = 40,
            baseplate = 50,
            final = 100            
        }

        private string ConnectionString = "User Id=autest;password=autest1234;server=amc-sql01;database=AMC_MfgData;connection timeout=30";
        //private string ConnectionString = "Data Source=BUSH*MASTER;Initial Catalog=ProductionManualLabels;Integrated Security=True";
       
        private string PartNumber { get; set; }
        private string Version { get; set; }
        private string LabelsCode { get; set; }
        private string Table { get; set; }

        private Log _theLog;

        public LabelCodeForm()
        {
            InitializeComponent();
        }

        private void LabelCodeForm_Load(object sender, EventArgs e)
        {
            _theLog = new Log(System.IO.Directory.GetCurrentDirectory());
        }

        private string GetConnectionString(string sTableName)
        {           
            // ja - create the connection string
            return @"Data Source=\\BOA\Production\Prodman.vfp\DATABASE\" + sTableName + ".dbf;" + @"Provider=VFPOLEDB.1;";
        }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            Thread theThread = new Thread(new ThreadStart(StartGoThread));
            theThread.SetApartmentState(ApartmentState.STA);

            // Start the thread
            theThread.Start();

        }

        private void StartGoThread()
        {
            GoBtn.Invoke(new MethodInvoker(() => GoBtn.Enabled = false));
                        
            if (betaCB.Checked)
            {
                tableNameLabel.Invoke(new MethodInvoker(() => tableNameLabel.Text = "Beta"));
                AddTable("beta");
            }

            if (currentCB.Checked)
            {
                tableNameLabel.Invoke(new MethodInvoker(() => tableNameLabel.Text = "Current"));
                AddTable("current");                            
            }

            if (ProtoCB.Checked)
            {
                tableNameLabel.Invoke(new MethodInvoker(() => tableNameLabel.Text = "Proto"));
                AddTable("proto");                
            }

            if (historyCB.Checked)
            {
                tableNameLabel.Invoke(new MethodInvoker(() => tableNameLabel.Text = "History"));
                AddTable("history");                
            }

            GoBtn.Invoke(new MethodInvoker(() => GoBtn.Enabled = true));
        }

        private int GetCount()
        {
            int nCount = 0;

            Console.WriteLine("Getting Table Count - " + Table);

            string sCmd = "SELECT COUNT(*) FROM " + Table;

            OleDbDataReader myReader = null;
            
            try
            {
                OleDbConnection vfpConnection = new OleDbConnection(GetConnectionString(Table));

                vfpConnection.Open();
                
                OleDbCommand cmdStartUp = new OleDbCommand(sCmd, vfpConnection);
                cmdStartUp.ExecuteNonQuery();

                myReader = cmdStartUp.ExecuteReader();

                myReader.Read();

                nCount = Convert.ToInt32(myReader["Cnt"].ToString().Trim());                  
                
                myReader.Close();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                myReader.Close();
            }

            return nCount;
        }

        private void AddTable(string sTable)
        {
            Console.WriteLine("Adding Table - " + sTable);
            
            OleDbDataReader myReader = null;

            Table = sTable;

            int nTotalCount = GetCount();
            int nCounter = 1;


            try
            {
                OleDbConnection vfpConnection = new OleDbConnection(GetConnectionString(sTable));

                vfpConnection.Open();

                string sPartNumber = partNumberTB.Text;
                string sVersion = versionUD.Text;

                // TODO: ja- add checkbox!
                string sCmd = "SELECT PartNumber, Version, LabelsCode FROM " + sTable;
                string sWhere = " where PartNumber = '" + sPartNumber + "' and Version = '" + sVersion + "'";
                
                if (singlePartCB.Checked)
                {
                    sCmd += sWhere;
                }
                
                OleDbCommand cmdStartUp = new OleDbCommand(sCmd, vfpConnection);
                cmdStartUp.ExecuteNonQuery();

                myReader = cmdStartUp.ExecuteReader();

                while (myReader.Read())
                {
                    PartNumber = myReader["PartNumber"].ToString().Trim();
                    Version = myReader["Version"].ToString().Trim();
                    LabelsCode = myReader["LabelsCode"].ToString().Trim();

                    Console.WriteLine("Found PartNumber: " + PartNumber + "..." + LabelsCode);

                    partNumberLabel.Invoke(new MethodInvoker(() => partNumberLabel.Text = PartNumber));
                    labelsCodeLabel.Invoke(new MethodInvoker(() => labelsCodeLabel.Text = LabelsCode));
                    versionLabel.Invoke(new MethodInvoker(() => versionLabel.Text = Version));

                    string sCounter = nCounter++.ToString() + @"/" + nTotalCount.ToString();

                    countLabel.Invoke(new MethodInvoker(() => countLabel.Text = sCounter));

                    PopulateParts();

                    GetLabelCodes();
                }

                myReader.Close();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                myReader.Close();
            }
        }

        private void PopulateParts()
        {
            SqlConnection theConnection = null;
            
            try
            {
                string sSql = "Exec usp_PopulatePartsLabelData '" + PartNumber + "', '" + Version + "', '" + Table.ToLower() + "'";
                
                theConnection = new SqlConnection(ConnectionString);

                theConnection.Open();

                SqlCommand cmdStartUp = new SqlCommand(sSql, theConnection);
                int nInserted = cmdStartUp.ExecuteNonQuery();

                Console.WriteLine("Adding " + PartNumber + " To label_Parts");
                //_theLog.WriteInfo(String.Format("Adding: PN={0}, LC={1}, TB={2}", PartNumber, LabelsCode, Table));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                
                theConnection.Close();
            }

            theConnection.Close();
            
        }

        private Dictionary<int, List<int>> ParseLabelCode(string sLabelsCode)
        {
            Dictionary<int, List<int>> theList = new Dictionary<int, List<int>>();

            sLabelsCode = sLabelsCode.Trim();

            if (sLabelsCode.Length < 23)
            {
                _theLog.WriteInfo(String.Format("Labels Code is to Short: PN={0}, LC={1}, TB={2}", PartNumber, LabelsCode, Table));
                return theList;
            }
            
            Dictionary<int, int> lab = new Dictionary<int, int>();
            
            try
            {
                string[] labels = sLabelsCode.Split(',');

                if (labels.Count() != 4){
                    _theLog.WriteInfo(String.Format("Labels Code is Corrupted: PN={0}, LC={1}, TB={2}", PartNumber, LabelsCode, Table));
                    return theList;
                }

                foreach (string label in labels)
                {
                    string[] finesplit = label.Split('-');

                    lab.Add(Convert.ToInt32(finesplit[0]), Convert.ToInt32(finesplit[1]));
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            int Smt = lab[20];
            int InProcess = lab[40];
            int BasePlate = lab[50];
            int Final = lab[100];
                        
            List<int> labelsList = new List<int>();

            labelsList = GenerateLabelList(Smt);
            theList.Add(20, labelsList);
        
            labelsList = GenerateLabelList(InProcess);
            theList.Add(40, labelsList);
        
            labelsList = GenerateLabelList(BasePlate);
            theList.Add(50, labelsList);
           
            labelsList = GenerateLabelList(Final);
            theList.Add(100, labelsList);

            return theList;
      
        }

        protected List<int> GenerateLabelList(int nCode)
        {
            List<int> labelsList = new List<int>();

            // ja - large philips
            if (nCode >= (int)LabelTypes.philips_large)
            {
                labelsList.Add((int)LabelTypes.philips_large);
                labelsList.Add((int)LabelTypes.philips_packing);
                nCode -= 20;
            }
            else if (nCode >= (int)LabelTypes.philips_small) // ja - small philips
            {
                labelsList.Add((int)LabelTypes.philips_small);
                labelsList.Add((int)LabelTypes.philips_packing);
                nCode -= 10;
            }

            switch (nCode)
            {
                case 0:
                    break;
                case 1:
                    labelsList.Add((int)LabelTypes.small);
                    break;
                case 2:
                    labelsList.Add((int)LabelTypes.large);
                    break;
                case 3:
                    labelsList.Add((int)LabelTypes.small);
                    labelsList.Add((int)LabelTypes.large);
                    break;
                case 4:
                    labelsList.Add((int)LabelTypes.cable);
                    break;             
            }
            
            return labelsList;
        }

        private string GetLabelCodesParams(int nLocation, int nType)
        {
            string sRet = "";
            string sLoc = "";
            string sType = "";

            sLoc = Enum.GetName(typeof(PrinterArea), nLocation);
            sType = Enum.GetName(typeof(LabelTypes), nType);

            sRet = ", '" + sType + "', '" + sLoc + "', '" + Version + "'";

            return sRet;
        }


        private void GetLabelCodes()
        {
            string sExec = "Exec usp_PopulateLabelCodes '" + PartNumber + "'";
            
            Dictionary<int, List<int>> theList = ParseLabelCode(LabelsCode);

            // TODO: ja - fix labels codes
            if (theList.Count == 0)
            {
                Clipboard.SetText(PartNumber);
                MessageBox.Show("Labels Code Error for: " + PartNumber);
            }

            List<string> sSql = new List<string>();

            foreach (var location in theList)
            {
                int key = location.Key;
                List<int> valList = location.Value;

                foreach (int nVal in valList)
                {
                    sSql.Add(sExec + GetLabelCodesParams(key, nVal));
                }
            }

            // ja - now update the Db
            foreach (string sInsert in sSql)
            {                
                PopulateLabelCode(sInsert);
            }
  
        }

        private void PopulateLabelCode(string sSql)
        {
                      
            SqlConnection theConnection = null;

            try
            {            
                theConnection = new SqlConnection(ConnectionString);

                theConnection.Open();

                SqlCommand cmdStartUp = new SqlCommand(sSql, theConnection);
                cmdStartUp.ExecuteNonQuery();

                Console.WriteLine("Adding To label_Code with " + sSql);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                theConnection.Close();
            }

            theConnection.Close();

        }       
    }
}
