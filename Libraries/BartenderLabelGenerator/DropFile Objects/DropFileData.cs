/*
*  This class holds all of the data for the label including the raw data, header and columns
* 
*  it also will read the configuration file to determine the printer and file names
*
*  the workcode data must be passed in
*/

using System;
using System.Collections.Generic;
using System.Xml;

namespace LabelGeneratorLib
{
    public class DropFileData
    {
        private PrinterArea ePrinterArea;
        private LabelTypes eLabelType;
        private string _sPrinterName;
        private string _sBtwFileName;
        private int _PrintQuanity;
        private string _CustomerName;

        private string LabelTypeString { get; set;}
        private string PrinterAreaString { get; set; }

        private DropFileColumns DropFileColumnsObj = new DropFileColumns();
        public DropFileValues DropFileValuesObj = new DropFileValues();
        
        // ja - instantiated in Constructor
        private DropFileHeader DropFileHeaderObj;
        
        // ja - passed in
        public WorkCodeLabel WorkCodeLabelObj;

        public DropFileData(PrinterArea eArea, LabelTypes eType)
        {
            ePrinterArea = eArea;
            eLabelType = eType;

            // ja - convert printer area and type of label to public strings

            //if (ConfigValues.LabelOverride == LabelOverrides.none)
            if (ConfigValues.ConfigLabelName == "none")
                    LabelTypeString = Enum.GetName(typeof(LabelTypes), eLabelType);
            else
                //LabelTypeString = Enum.GetName(typeof(LabelOverrides), ConfigValues.LabelOverride);
                LabelTypeString = ConfigValues.ConfigLabelName;

            PrinterAreaString = Enum.GetName(typeof(PrinterArea), ePrinterArea);

            // ja - get the filename and printer from the config file
            ReadConfigFile();

            // ja - create the header for the printer file
            DropFileHeaderObj = new DropFileHeader(_sBtwFileName, _sPrinterName);            
        }

        private void ReadConfigFile()
        {
            try
            {
                //string LabelTypeString = ConfigValues.ConfigLabelName;

                // ja - get all the types of labels we need to print from the config
                XmlDocument doc = new XmlDocument();
                // TODO: ja - Read from Registry
                doc.Load(@"\\nightadder\btwFiles\BTLabelApp.config");

                // ja - get the list of labels
                XmlNode LabelTypeNode = doc.SelectSingleNode("/configuration/printerStations/" + PrinterAreaString + "//" + LabelTypeString);

                // ja - read in the printer name and btw filename
                _sPrinterName = LabelTypeNode.Attributes.GetNamedItem("printer_name").Value;
                _sBtwFileName = LabelTypeNode.Attributes.GetNamedItem("bt_filename").Value;
                
            }
            catch (System.Exception ex)
            {
                //ConfigValues.TheLog.WriteInfo(ex.Message);
            }                           
        }
        
        // ja - setters
        public void SetWorkCodeData(WorkCodeLabel wcLabel)
        {
            WorkCodeLabelObj = wcLabel;
        }
        
        public void SetColumnNames(List<string> sColumns)
        {
            DropFileColumnsObj.PopulateColumns(sColumns);
        }

        public void SetData(List<string> sData)
        {
            DropFileValuesObj.AddDataRow(sData);
        }  

        public void SetPrintQuanity(int nQty)
        {
            _PrintQuanity = nQty;
        }

        public void SetCustomerName(string sCustomerName)
        {
            _CustomerName = sCustomerName;
        }

        // ja - getters
        public WorkCodeLabel GetWorkCodeLabel()
        {
            return WorkCodeLabelObj;
        }

        public string GetHeaderString()
        {
            return DropFileHeaderObj.GetBartenderHeader();
        }

        public string GetColumnString()
        {
            return DropFileColumnsObj.GetColumnsString();
        }

        public string GetDataString()
        {
            return DropFileValuesObj.GetDataString();
        }

         public string GetLabelTypeString()
         {
             //return LabelTypeString;
             return ConfigValues.ConfigLabelName;
         }

        public string GetPrinterAreaString()
        {
            return PrinterAreaString;
        }

        public string GetPrinterName()
        {
            return _sPrinterName;
        }

        public string GetWorkCode()
        {
            return WorkCodeLabelObj.GetWorkCode();
        }

        public int GeSingleLabeltPrintQuanity()
        {
            return _PrintQuanity;
        }

        public string GetCustomerName()
        {
            return _CustomerName;
        }
    }
    
}
