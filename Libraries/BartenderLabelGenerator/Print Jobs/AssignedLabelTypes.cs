/*      class AssignedLabelTypes
    
        ja - this class will get all of the assigned label types for each part number
        it does this from the PM's LabelCode or from the label_data view 
        it will only get the label types for each area and store in array of assigned Labels
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace LabelGeneratorLib
{
    public struct LabelProperitys
    {
        public LabelTypes AssingedLabel;
        public int LabelQuanity;
        public string CustomerName;
        //public LabelOverrides Overrides;
        public string sConfigLabelName;
    };
    
    public class AssignedLabelTypes
    {
        protected string LabelsCode { get; set; }
        protected string PartNumber { get; set; }
        protected string PartVersion { get; set; }
        protected PrinterArea ePrinterArea { get; set; }
        
        protected int Smt { get; set; }
        protected int InProcess { get; set; }
        protected int BasePlate { get; set; }
        protected int Final { get; set; }

        public List<LabelProperitys> AssignedLabels = new List<LabelProperitys>();
        public List<string> SpecialAttributes = new List<string>();
        
        // ja - for single label type
        public AssignedLabelTypes(LabelTypes eLabelType, PrinterArea eArea)
        {
            ePrinterArea = eArea;

            // ja - here we are only going to print a single label type and it is passed in 
            AssignedLabels.Add(GetDefaultLabelProperity(eLabelType));
        }

        // ja - for new database driven label codes
        public AssignedLabelTypes(PrinterArea eArea, string sPartNumber, string sVersion)
        {
            ePrinterArea = eArea;
            PartNumber = sPartNumber;
            PartVersion = sVersion;

            if (ConfigValues.ConfigLabelName != "none")
            {
                AssignLabelTypesFromOverride();
            }
            else
            { 
                // ja - here we will read in the Label Types from the SQL tables
                AssignLabelTypesFromDataBase();
            }
        }

        // ja - for PM Label Code
        public AssignedLabelTypes(string sLabelsCode, PrinterArea eArea, string sPartNumber)
        {
            LabelsCode = sLabelsCode;
            ePrinterArea = eArea;
            PartNumber = sPartNumber;

            // ja - here we will parse the Label Code string to get the Label Types
            if (ParseLabelCode())
                AssignLabelTypes();
        }

        public bool ParseLabelCode()
        {
            Dictionary<int, int> lab = new Dictionary<int, int>();

            if (LabelsCode.Trim().Length < 23)
            {
                ConfigValues.TheLog.WriteInfo(String.Format("Labels Code is to Short: PN={0}, LC={1}", PartNumber, LabelsCode));
                return false;
            }
            
            try
            {
                string[] labels = LabelsCode.Split(',');

                if (labels.Count() != 4)
                {
                    ConfigValues.TheLog.WriteInfo(String.Format("Labels Code is Corrupted: PN={0}, LC={1}", PartNumber, LabelsCode));
                    return false;
                }

                foreach (string label in labels)
                {
                    string[] finesplit = label.Split('-');

                    lab.Add(Convert.ToInt32(finesplit[0]), Convert.ToInt32(finesplit[1]));
                }
            }
            catch (System.Exception ex)
            {
                ConfigValues.TheLog.WriteInfo(ex.Message);
            }

            Smt = lab[(int)PrinterArea.smt];
            InProcess = lab[(int)PrinterArea.in_process];
            BasePlate = lab[(int)PrinterArea.baseplate];
            Final = lab[(int)PrinterArea.final];

            return true;
          
        }

        private LabelProperitys GetDefaultLabelProperity(LabelTypes type)
        {
            LabelProperitys lp = new LabelProperitys();
            lp.AssingedLabel = type;
            lp.CustomerName = "AMC";
            lp.LabelQuanity = 1;

            return lp;
        }

        protected void GenerateLabelList(int nCode)
        {
            List<LabelTypes> labelsList = new List<LabelTypes>();
            
            // ja - large philips
            if (nCode >= (int)LabelTypes.philips_large)
            {
                labelsList.Add(LabelTypes.philips_large);
                labelsList.Add(LabelTypes.philips_packing);
                nCode -= 20;
            }
            else if (nCode >= (int)LabelTypes.philips_small) // ja - small philips
            {
                labelsList.Add(LabelTypes.philips_small);
                labelsList.Add(LabelTypes.philips_packing);
                nCode -= 10;
            }

            switch (nCode)
            {
                case 0:
                    break;
                case 1:
                    labelsList.Add(LabelTypes.small);
                    break;
                case 2:
                    labelsList.Add(LabelTypes.large);
                    break;
                case 3:
                    labelsList.Add(LabelTypes.small);
                    labelsList.Add(LabelTypes.large);
                    break;
                case 4:
                    labelsList.Add(LabelTypes.cable);
                    break;
            }

            // ja - now add to the assigned labels list
            foreach (LabelTypes type in labelsList)
            {
                AssignedLabels.Add(GetDefaultLabelProperity(type));
            }
        }

        protected void AssignLabelTypes()
        {
            int nArea = 0;
            
            if (ePrinterArea == PrinterArea.smt)
                nArea = Smt;
            else if (ePrinterArea == PrinterArea.in_process)
                nArea = InProcess;
            else if (ePrinterArea == PrinterArea.baseplate)
                nArea = BasePlate;
            else if (ePrinterArea == PrinterArea.final)
                nArea = Final;

            GenerateLabelList(nArea);
            
        }

        private void AssignLabelTypesFromOverride()
        {
            LabelProperitys lp = new LabelProperitys();

            lp.CustomerName = "AMC";
            lp.LabelQuanity = 1;

            // ja - here we will use the override
            lp.sConfigLabelName = ConfigValues.ConfigLabelName;
            //lp.Overrides = ConfigValues.LabelOverride;

            AssignedLabels.Add(lp);
        }

        // ja - new way ....
        // TODO: ja - move to new class?
        private void AssignLabelTypesFromDataBase()
        {   
            string ConnectionString = ConfigValues.GetConnectionString();

            SqlDataReader myReader = null;
            SqlConnection TheConnection = null;

            try
            {
                TheConnection = new SqlConnection(ConnectionString);

                TheConnection.Open();

                // ja - get the label information from the database view
                SqlCommand myCommand = new SqlCommand("select * from label_Data where Part_Number = '" + PartNumber + "' and Part_Version = '" + PartVersion + "'", TheConnection);
                myReader = myCommand.ExecuteReader();

                // ja - loop through all of the assigned label types
                while (myReader.Read())
                {
                    // ja - get the information from the database
                    string sLocation = myReader["Location_Name"].ToString();
                    string sType = myReader["Label_Type_Name"].ToString();
                    string sQty = myReader["Print_Qty"].ToString();
                    string sCustomerName = myReader["Customer_Name"].ToString();

                    LabelTypes type = (LabelTypes)Enum.Parse(typeof(LabelTypes), sType);
                    PrinterArea area = (PrinterArea)Enum.Parse(typeof(PrinterArea), sLocation);
                    
                    // ja - if the printer area matches the passed in area (Physical Printer) add to queue
                    if (area == ePrinterArea)
                    {
                        LabelProperitys lp = new LabelProperitys();

                        lp.CustomerName = sCustomerName;
                        lp.LabelQuanity = Convert.ToInt32(sQty);
                        lp.AssingedLabel = type;

                        AssignedLabels.Add(lp);
                    }
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

        private void GetSpecialLabelTypesFromDataBase()
        {
            string ConnectionString = ConfigValues.GetConnectionString();

            SqlDataReader myReader = null;
            SqlConnection TheConnection = null;

            try
            {
                TheConnection = new SqlConnection(ConnectionString);

                TheConnection.Open();

                SqlCommand myCommand = new SqlCommand("select Condition_Name, Attribute_Value from part_flags where Part_Number = '" + PartNumber + "' and Part_Version = '" + PartVersion + "'", TheConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string sCondition = myReader["Condition_Name"].ToString();
                    string sAttribute = myReader["Attribute_Value"].ToString();

                    // TODO: ja - store these in config?
                    SpecialAttributes.Add(sCondition);
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
    }
}
