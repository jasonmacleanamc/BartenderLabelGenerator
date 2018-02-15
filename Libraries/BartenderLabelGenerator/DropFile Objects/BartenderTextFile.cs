/*
*  This class will generate the actual text file for bartender
*
*  the lines of the text file are passed in and written to the file
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace LabelGeneratorLib
{
    class BartenderTextFile
    {
        protected string FileName = "";
        //protected string FileName2 = "";

        public BartenderTextFile(string sPrinterName)
        {
            FileName = sPrinterName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + ".txt";
        }

        public BartenderTextFile(string sLabelType, string sPrinterArea)
        {
            // TODO: ja- temp (remove table name)
            FileName = "___" + ConfigValues.ConfigLabelName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + ".txt";

            //FileName = ConfigValues.TableName + "_" + sPrinterArea + "_" + sLabelType + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + ".txt";
            //FileName2 = ConfigValues.TableName + "_" + sPrinterArea + "_" + sLabelType + "_" + 
        }

        public BartenderTextFile(string sLabelType, string sPrinterArea, string sWorkCode)
        {
            // TODO: ja- temp (remove table name)
            FileName = sWorkCode + "--" + sPrinterArea + "_" + sLabelType + "_" + DateTime.Now.ToString("fff") + ".txt";
            //FileName2 = ConfigValues.TableName + "_" + sPrinterArea + "_" + sLabelType + "_" + 
        }

        public bool CreateTextFile(List<string> sTxtFileData)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(GetBtwPath(FileName, true)))
                {
                    foreach (var line in sTxtFileData)
                    {
                        file.WriteLine(line);
                    }
                }

                // ja - TODO: make a copy for reprints
            }
            catch (System.Exception ex)
            {
                ConfigValues.TheLog.WriteInfo(ex.Message);
                return false;
            }

            return true;
        }

        static public string GetBtwPath(string sFileName, bool bUseDrop = false)
        {
            string sFilePath = "";

            if ((bUseDrop && ConfigValues.AllwaysUseDrop == true) || ConfigValues.ForcePrintNow)
                sFilePath = ConfigValues.ServerName + "\\" + ConfigValues.TextDropDirectory + "\\" + sFileName;
            else
                sFilePath = ConfigValues.ServerName + "\\" + ConfigValues.BtwFileDirectory + "\\testFiles\\" + sFileName;
            

            return sFilePath;
        }

        static public string GetBtwFileHeaderPath(string sFileName)
        {
            string sFilePath = "";

            sFilePath = ConfigValues.ServerName + "\\" + ConfigValues.BtwFileDirectory + "\\" + sFileName;
            
            return sFilePath;
        }
    }
}    
