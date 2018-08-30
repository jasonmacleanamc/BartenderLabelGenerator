using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelGeneratorLib
{
    // ja - This class exposes functions for each printing job (label area and label type)
    //      the data for each job is stored in the DropFileDataList Array
    //      the print function will iterate through all of the jobs and create the text file

    public class PrintJob
    {
        public List<DropFileData> DropFileDataList = new List<DropFileData>();

        // ja - constructor with known column names
        public int AddPrintJobWithColumns(PrinterArea eArea, LabelTypes eLabelType, List<string> sColumns)
        {
            // ja - create data class (container for 3 other classes)
            DropFileData df = new DropFileData(eArea, eLabelType);

            // ja - set the columns names
            df.SetColumnNames(sColumns);

            DropFileDataList.Add(df);

            return DropFileDataList.Count;
        }

        // ja - constructor for generic PM column names
        public bool AddPrintJobForPM(PrinterArea eArea, string sWorkCode)
        {
            bool bFoundPart = false;

            WorkCodeLabel wc = new WorkCodeLabel(sWorkCode);

            string sFomattedVer = ConfigValues.ConvertIntVersion(wc.GetWorkCodeData().nVersion);

            // TODO: ja - test for no version

            AssignedLabelTypes lt;
            // ja - read from Label Codes from the Database
            if (ConfigValues.UseNewLabelCodes)
                lt = new AssignedLabelTypes(eArea, wc.GetWorkCodeData().PartNumber, sFomattedVer);
            else // ja - read from LabelsCode in Workcode Table
                lt = new AssignedLabelTypes(wc.GetLabelsCode(), eArea, wc.GetWorkCodeData().PartNumber);
            
            // ja - need to fill the data for all labels type to print
            foreach(var LabelProperty in lt.AssignedLabels)
            {   
                DropFileData df = new DropFileData(eArea, LabelProperty.AssingedLabel);
                
                df.SetPrintQuanity(LabelProperty.LabelQuanity);

                df.SetCustomerName(LabelProperty.CustomerName);
                
                // ja - add the data to the job
                df.SetWorkCodeData(wc);

                // ja - add the column names
                df.SetColumnNames(PMLabelData.GetPMColumnHeaders());
                
                // ja - add the job
                DropFileDataList.Add(df);

                bFoundPart = true;
            }

            return bFoundPart;
        }

        public void AddDataRowFromDB(List<string> sSerials)
        {
            foreach (string serial in sSerials)
            {
                for (int i = 0; i < DropFileDataList.Count; i++)
                {
                    // ja - create a generic struct
                    LabelDataStruct SerialLabelData = new LabelDataStruct();
                    
                    // ja - fill the struct with the workcode data for each job
                    SerialLabelData = DropFileDataList[i].GetWorkCodeLabel().GetWorkCodeData();
                    
                    // ja - assign a specific serial number
                    SerialLabelData.SerialNumber = serial;

                    // ja - get the customer name
                    string sCustomerName = DropFileDataList[i].GetCustomerName();

                    // ja - convert the generic struct to PM Label Data to massage the data for different label types (such as Philips)
                    PMLabelData labelData = new PMLabelData(SerialLabelData, sCustomerName);
                    
                    // ja - add the formatted data back to the jobs list
                    AddDataRow(i + 1, labelData.GetValueList());
                }
            }
        }

        public void AddDataRow(int nPos, List<string> dataRow)
        {
            int nArrayAccessor = (nPos - 1);

            if (nPos >= 0 && DropFileDataList.Count > 0 && nArrayAccessor <= DropFileDataList.Count)
                DropFileDataList[nArrayAccessor].SetData(dataRow);
        }

        public int GetLabelQuanity()
        {
            int nQty = 0;

            if (HasJobs())
            {
                nQty = DropFileDataList[0].GetWorkCodeLabel().GetLabelQuantity();
            }
            
            return nQty;           
        }
        
        public bool Print()
        {
            bool bRet = true;
            
            // ja - loop trough all of the print jobs
            foreach (var data in DropFileDataList)
            {
                int nQty = data.GeSingleLabeltPrintQuanity();

                if (nQty <= 0)
                    nQty = 1;

                for (int nCounter = 0; nCounter < nQty; nCounter++)
                {

                    // ja - gets the bartender header, column names, and data into our List
                    List<string> sFileContentsList = CreateFileContents(data);

                    // ja - create the text file class
                    // TODO: ja - add flag in config to toggle printer name vs label type , printer area
                    BartenderTextFile btTextFile = null;

                    if (true)
                        btTextFile = new BartenderTextFile(data.GetLabelTypeString(), data.GetPrinterAreaString());
                    //else
                        //btTextFile = new BartenderTextFile(data.GetPrinterName());

                    // ja - creates the drop file with the Data
                    if (!btTextFile.CreateTextFile(sFileContentsList))
                        bRet = false;
                }
            }

            return bRet;
        }

        private bool HasJobs()
        {
            if (DropFileDataList.Count() > 0)
                return true;

            return false;
        }
        
        private List<string> CreateFileContents(DropFileData data)
        {
            List<string> theData = new List<string>();

            // ja - add bartender header
            theData.Add(data.GetHeaderString());
                
            // ja - add blank line
            theData.Add(DropFileHeader.GetNewLine());

            // ja - add columns 
            theData.Add(data.GetColumnString());

            // ja - add the data rows
            theData.Add(data.GetDataString());

            return theData;
        }  
    }
}

