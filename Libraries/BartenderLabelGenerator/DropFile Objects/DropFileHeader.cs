/*
* This class is responsible for creating the header at the beginning of the 
* 
*  Bartender text file
*/

namespace LabelGeneratorLib
{
    public class DropFileHeader
    {
        protected string BartenderFileName { get; set; } // TODO: ja - check for .btw
        protected string PrinterName { get; set; }

        // ja - Bartender start header
        protected const string _sStartBTW = @"%BTW%";
        
        // ja - Bartender end header
        protected const string _sEndBTW = @"%END%";
        
        // ja - Bartender Filename command
        protected const string _sFileNameCommand = @"/AF=";

        // ja- Trigger Command
        protected const string _sTriggerCommand = @"/D=";

        // ja - printer name command
        protected const string _sPrinterNameCommand = @"/PRN=";

        // ja - print command
        protected const string _sPrinterCommand = @"/P";

        // ja - Delete File command
        protected const string _sDeleteFileCommand = @"/DD";

        // ja - starting row of data
        protected string _sStartRowCommand = "";

        public DropFileHeader(string sFileName, string sPrinter)
        {
            _sStartRowCommand = @"/R=" + ConfigValues.HeaderPosition.ToString();

            BartenderFileName = BartenderTextFile.GetBtwFileHeaderPath(sFileName);
            PrinterName = sPrinter;
        }

        public string GetBartenderHeader()
        {
            string sHeader = "";
            
            // ja - this line is responsible for adding spaces
            string sValues = GetSpace() + GetFormattedBartenderFileName() + GetSpace() + GetTriggerName() + GetSpace() + GetFormattedPrinterName();

            sHeader = WrapHeader(sValues);

            return sHeader;
        }

        protected string WrapHeader(string sValue)
        {
            string sHeader = _sStartBTW + sValue + GetNewLine() + _sEndBTW;

            return sHeader;
        }

        protected string GetFormattedBartenderFileName()
        {
            // ja - /AF="\\path\btwFiles\somefile.btw" 
            // ja - TEMP
            //             if (ConfigValues.TableName == "type_a")
            //             {
            //                 return _sFileNameCommand + GetQuote() + @"\\nightadder\btwFiles\platformA.btw" + GetQuote();
            //             }
            //             else if (ConfigValues.TableName == "axcent")
            //             {
            //                 return _sFileNameCommand + GetQuote() + @"\\nightadder\btwFiles\AxCentTypeA.btw" + GetQuote();
            //             }

            string sRetValue;

            sRetValue = GetQuote() +@"\\nightadder\btwFiles\";



            ///
//             if (ConfigValues.LabelOverride == LabelOverrides.type_a)
//             {
//                 return _sFileNameCommand + GetQuote() + @"\\nightadder\btwFiles\platformA.btw" + GetQuote();
//             }
//             else if (ConfigValues.TableName == "axcent")
//             {
//                 return _sFileNameCommand + GetQuote() + @"\\nightadder\btwFiles\AxCentTypeA.btw" + GetQuote();
//             }

            return _sFileNameCommand + GetQuote() + BartenderFileName + GetQuote();
        }

        protected string GetTriggerName()
        {
            // ja - /D="%Trigger File Name%" 
            return _sTriggerCommand + GetQuote() + "%Trigger File Name%" + GetQuote();
        }

        protected string GetFormattedPrinterName()
        {
            // ja - /PRN="xx-xxx" /R=4 /P /
            if (ConfigValues.TableName == "type_a" || ConfigValues.TableName == "axcent")
            {
                return _sPrinterNameCommand + GetQuote() + "IS-P03" + GetQuote() + GetSpace() + _sStartRowCommand + GetSpace() + _sPrinterCommand + GetSpace() + _sDeleteFileCommand;
            }


            return _sPrinterNameCommand + GetQuote() + PrinterName + GetQuote() + GetSpace() + _sStartRowCommand + GetSpace() + _sPrinterCommand + GetSpace() + _sDeleteFileCommand;
        }

        protected string GetQuote()
        {
            return "\"";
        }

        protected string GetSpace()
        {
            return " ";
        }

        static public string GetNewLine()
        {
            return "\r\n";
        }
    }
}
