using AMCDatabase;
using System;
using System.Collections.Generic;

namespace LabelGeneratorLib
{
    public enum PrinterArea
    {
        smt = 20,
        in_process = 40,
        baseplate = 50,
        final = 100   
    }

    public enum LabelTypes
    {
        none = 0,
        small = 1,
        large = 2,
        both = 3,
        cable = 4,
        type_a = 5,
        aspinv = 6,
        philips_small = 10,
        philips_large = 20,
        philips_packing = 50
    } 
    
    // ja - TODO: this is temp for final labels
//     public enum LabelOverrides
//     {
//         none = 0,
//         type_a,
//         axcent,
//         bedrock,
//         lr2,
//         lr3,
//         digiflex,
//         philips_large,
//         bedrock_8902
//     }

    public enum Customers
    {
        amc = 0,
        phillips
    }


    // ja - this is the starting point for the DLL, all exposed public functions will be in LabelGen
    //      Usage:
    //      1 - User creates LabelGen Reference
    //      2 - For each Label user calls AddPrintJob with the area and type of label or workcode and or Column Names
    //      3 - For each individual label the user will pass in a Array of Serial Numbers to AddDataRow
    //      4 - Lastly call PrintLabels to generate the text files

    public class LabelGen
    {
        protected PrintJob printJobs = new PrintJob();
        
        public LabelGen()
        {   
            ConfigValues.ReadSettingsFromRegistry();
        }
        
        // TODO: ja- temp
        public LabelGen(string sTableName)
        {             
            ConfigValues.ReadSettingsFromRegistry();
            ConfigValues.TableName = sTableName;
        }

        // TODO: ja- temp for final
        //         public LabelGen(LabelOverrides Override)
        //         {
        //             ConfigValues.ReadSettingsFromRegistry();
        //             ConfigValues.LabelOverride = Override;            
        //         }

        public LabelGen(string sConfigFileName, bool bUseNew)
        {
            ConfigValues.ReadSettingsFromRegistry();
            ConfigValues.ConfigLabelName = sConfigFileName;
        }

        public void ForcePrintNow()
        {
            ConfigValues.ForcePrintNow = true;
        }

        public void SetSingleLabelQty(int nQty)
        {
            // ja - set the config value
            ConfigValues.SingleLabelQty = nQty;
        }

        public void SetCustomer(Customers theCustomer)
        {
            ConfigValues.CustomerName = theCustomer;
        }

        // ja - for WCF Service used for Inv labels
        public int AddPrintJob(PrinterArea ePrinterArea, LabelTypes eLabelType, List<string> sColumns)
        {
            ConfigValues.TheLog.WriteInfo("AddPrintJob");
            
            ConfigValues.UseNewLabelCodes = false;

            return printJobs.AddPrintJobWithColumns(ePrinterArea, eLabelType, sColumns);
        }

        //  ja - for regular App Calls 
        public bool AddPrintJob(PrinterArea ePrinterArea, string sWorkCode)
        {
            ConfigValues.TheLog.WriteInfo("AddPrintJob");
            
            ConfigValues.UseNewLabelCodes = false;

            printJobs.AddPrintJobForPM(ePrinterArea, sWorkCode);

            return true;
        }
        
        // ja - for trigger based printing
         public bool AddPrintJob(PrinterArea ePrinterArea, string sWorkCode, bool bUseNewLabelCodes)
         {

             ConfigValues.TheLog.WriteInfo("AddPrintJob - trigger");

             ConfigValues.UseNewLabelCodes = bUseNewLabelCodes;

             return printJobs.AddPrintJobForPM(ePrinterArea, sWorkCode);             
         }

        // ja - for hard coded labels
        public bool AddPrintJob(PrinterArea ePrinterArea)
        {

            ConfigValues.TheLog.WriteInfo("AddPrintJob - trigger");

            ConfigValues.UseNewLabelCodes = true;

            return printJobs.AddPrintJobForPM(ePrinterArea, "999999"); 
        }

        public int GetLabelQty()
        {
            return printJobs.GetLabelQuanity();
        }

        // ja - need to manipulate the data for RMA's
        public void ModifyRMAData(LabelDataStruct newData)
        {
            // ??
        }
        
        // ja - this function is used to add the serial numbers (individual labels)
        public bool AddDataRow(int nJobNumber, List<string> sData)
        {
            printJobs.AddDataRow(nJobNumber, sData);

            return true;
        }

        public bool AddDataRowFromDB(List<string> sSerials)
        {
            ConfigValues.TheLog.WriteInfo("AddDataRowFromDB");
            
            // ja- need to share the data for all jobs!!!
            printJobs.AddDataRowFromDB(sSerials);

            return true;
        }

        // ja - this will generate x number of labels from start to qty
        public bool AddDataRow(int nJobNumber, string sValue, int nQty, int nStart = 0)
        {
            List<string> sData = new List<string>();

            for (int i = nStart; i <= nQty; i++)
            {
                List<string> theRow = new List<string>();

                theRow.Add(sValue + Convert.ToString(i));

                printJobs.AddDataRow(nJobNumber, theRow);                                
            }

            return true;
        }

        public bool PrintLabels()
        {
            ConfigValues.TheLog.WriteInfo("PrintLabels");

            printJobs.Print();
            
            return true;
        }

        // ja - This function was added specifically to get information from the parts table to 
        //      populate RMA data from a different part
        public RmaOverrides GetRMADataFromPartsInfo(string sPartNumber, string sVersion)
        {
            RmaOverrides rma = new RmaOverrides();

            try
            {
                PartsTable pt = new PartsTable(sPartNumber, sVersion);

                rma.InputSpecs = pt.GetValue("Inspecs");
                rma.OutputSpecs = pt.GetValue("Outspecs");
                rma.RevLetter = pt.GetValue("Revision");
            }
            catch (Exception)
            {

                throw;
            }           

            return rma;
        }

        public LabelDataStruct GetWorkCodeData()
        {
            var data = printJobs.DropFileDataList[0];
            
                LabelDataStruct x = data.WorkCodeLabelObj.GetWorkCodeData();

                string s = x.PartNumber;                     

            return x;
        }

        public void ToggleRMAOvveride(bool bRMAOn = true)
        {
            ConfigValues.RMADataOverride = bRMAOn;
        }

        public void SetRMADateCode(string sDateCode)
        {
            ToggleRMAOvveride(true);

            ConfigValues.rmaOverride.DateCode = sDateCode;
        }

        public void SetRMAVersion(string sVersion)
        {
            ToggleRMAOvveride(true);

//             string sFomattedVer = "";
// 
//             if (nVersion > 9)
//                 sFomattedVer = "0." + nVersion.ToString();
//             else if (nVersion <= 9)
//                 sFomattedVer = "0.0" + nVersion.ToString();
//             else if (nVersion > 99)
//                 sFomattedVer = "1." + nVersion.ToString();

            ConfigValues.rmaOverride.Version = sVersion;
        }

        public void SetRMAPartNumber(string sNewPartNumber)
        {

            ToggleRMAOvveride(true);

            ConfigValues.rmaOverride.PartNumber = sNewPartNumber;
        }

        public void SetRMARevision(string sNewRevision)
        {

            ToggleRMAOvveride(true);

            ConfigValues.rmaOverride.RevLetter = sNewRevision;
        }

        public void SetRMAInput(string sNewInput)
        {
            ToggleRMAOvveride(true);

            ConfigValues.rmaOverride.InputSpecs = sNewInput;
        }

        public void SetRMAOutput(string sNewOutput)
        {
            ToggleRMAOvveride(true);

            ConfigValues.rmaOverride.OutputSpecs = sNewOutput;
        }

    }
}
