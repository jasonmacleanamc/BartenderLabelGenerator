using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Xml;
using AMCCommon;

namespace LabelGeneratorLib
{
    public static class ConfigValues
    {
        // ja - each job knows about its printer and btw file name
        //Dictionary<int, string> JobData = new Dictionary<int, string>();

        // TODO: ja- temp
        public static string TableName = "";
        //public static LabelOverrides LabelOverride = LabelOverrides.none;
        public static string ConfigLabelName = "none"; 
        public static bool ForcePrintNow = false;
        public static int SingleLabelQty = 1;
        public static Customers CustomerName = Customers.amc;      
        
        public static bool _bTUV = false;
        public static bool UseNewLabelCodes { get; set; }

        public static Log TheLog = new Log(System.IO.Directory.GetCurrentDirectory());

        // ja - config values
        public static int HeaderPosition { get; set; }
        public static string TextDropDirectory { get; set; }
        public static string BtwFileDirectory { get; set; }
        public static string ConfigFilePath { get; set; }
        public static string ServerName { get; set; }
        public static bool AllwaysUseDrop { get; set; }
        private static string DatabaseName { get; set; }
        private static string DatabaseUserID { get; set; }
        private static string DatabasePW { get; set; }
        public static string DBServerName { get; set; }

        public static bool RMADataOverride { get; set; }

        public static RmaOverrides rmaOverride = new RmaOverrides();

        public static void ResetConfigValues()
        {
            TableName = "";
            ConfigLabelName = "none";
            //LabelOverride = LabelOverrides.none;
            ForcePrintNow = false;
            SingleLabelQty = 1;
            CustomerName = Customers.amc;
            _bTUV = false;
            RMADataOverride = false;
        }

        public static void ReadConfigFile(PrinterArea ePrinterArea, LabelTypes eLabelType)
        {
            try
            {
                // ja - get all the types of labels we need to print from the config
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFilePath);

                // ja - global printer area
                string sArea = Enum.GetName(typeof(PrinterArea), ePrinterArea);

                // ja - get the list of labels
                string sLabelTypeString = Enum.GetName(typeof(LabelTypes), eLabelType);

                XmlNode LabelTypeNode = doc.SelectSingleNode("/configuration/printerStations/" + sArea + "//" + sLabelTypeString);

                string sPrinterName = LabelTypeNode.Attributes.GetNamedItem("printer_name").Value;
                string sBtwFileName = LabelTypeNode.Attributes.GetNamedItem("bt_filename").Value;

                // TODO: change this to Customer in config file
                string sCustomer = LabelTypeNode.Attributes.GetNamedItem("customer").Value;
            }
            catch (System.Exception ex)
            {
                TheLog.WriteInfo(ex.Message);
            }
        }

        public static bool ReadTypeALabelRules(string sPartNumber)
        {
            bool bFound = false;
            
            try
            {
                // ja - get all the types of labels we need to print from the config
                XmlDocument doc = new XmlDocument();
                doc.Load(@"\\nightadder\btwFiles\LabelRules.xml");

                // ja - get the list of labels
                string sLabelTypeString = Enum.GetName(typeof(LabelTypes), LabelTypes.type_a);

                XmlNodeList links = doc.DocumentElement.SelectNodes("/root/" + sLabelTypeString + "/part");
                foreach (XmlNode child in links)
                {
                    XmlNode pnNode = child.SelectSingleNode("partNum");
                    string sPartNum = pnNode.InnerText;

                    if (sPartNumber.Equals(sPartNum))
                    {
                        bFound = true;
                        
                        XmlNode tuvNode = child.SelectSingleNode("tuv");
                        if (Convert.ToBoolean(tuvNode.InnerText))
                            _bTUV = true;
                        break;
                    }                    
                }
            }
            catch (System.Exception ex)
            {
                TheLog.WriteInfo(ex.Message);
            }

            return bFound;
        }

        public static string GetConnectionString()
        {
            string ConnectionString = "user id=" + DatabaseUserID + ";password=" + DatabasePW + ";Data Source=" + DBServerName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=True";

            return ConnectionString;
        }

        public static void ReadSettingsFromRegistry()
        {
            TheLog.WriteInfo("ReadSettingsFromRegistry");
                
            // ja - reset the static variables
            ResetConfigValues();

            const string APPLICATION_NAME = "LabelGenerator";
            const string REGISTRY_PATH = "Software\\Advanced Motion Controls";

            const string DB_SERVER_NAME = "Server DB Name";
            const string DATABASE_NAME = "Database Name";
            const string DATABASE_USERID = "Database User ID";
            const string DATABASE_PW = "Database Password";

            const string HEADER_POSITION = "Header Position";
            const string TEXTDROP_DIRECTORY = "Drop File Output Directory";
            const string BTWFILE_DIRECTORY = "BTW File Directory";
            const string CONFIG_FILE_PATH = "Config File Path";
            const string SERVER_NAME = "Server Name";
            const string ALLWAYS_USE_DROP = "Use Drop for Text Files";

            try
            {
//#if DEBUG
                RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_PATH + "\\" + APPLICATION_NAME);
//#else
  //              RegistryKey key = Registry.LocalMachine.OpenSubKey(REGISTRY_PATH + "\\" + APPLICATION_NAME);
//#endif

                // ja - if the registry has been written to read in values
                if (key != null)
                {
                    Console.WriteLine("ReadPathFromRegistry - Reading Values");
                    HeaderPosition = Convert.ToInt32(key.GetValue(HEADER_POSITION).ToString());
                    TextDropDirectory = key.GetValue(TEXTDROP_DIRECTORY).ToString();
                    BtwFileDirectory = key.GetValue(BTWFILE_DIRECTORY).ToString();
                    ConfigFilePath = key.GetValue(CONFIG_FILE_PATH).ToString();
                    ServerName = key.GetValue(SERVER_NAME).ToString();
                    AllwaysUseDrop = Convert.ToBoolean(key.GetValue(ALLWAYS_USE_DROP).ToString());
                    DBServerName = key.GetValue(DB_SERVER_NAME).ToString();
                    DatabaseName = key.GetValue(DATABASE_NAME).ToString();
                    DatabaseUserID = key.GetValue(DATABASE_USERID).ToString();
                    DatabasePW = key.GetValue(DATABASE_PW).ToString();

                    key.Close();
                }
                else
                {
                    Console.WriteLine("ReadPathFromRegistry - Writing Values, using Defaults");

                    HeaderPosition = 3;
                    TextDropDirectory = "btFileDrop";
                    BtwFileDirectory = "btwFiles";
                    ConfigFilePath = @"\\nightadder\btwFiles\BTLabelApp.config";
                    ServerName = @"\\nightadder";
                    AllwaysUseDrop = true;
                    DBServerName = "BUSHMASTER";
                    DatabaseName = "ProductionManualLabels";
                    DatabaseUserID = "prodmanuser";
                    DatabasePW = "71m30u7";

//#if DEBUG
                    RegistryKey amcKey = Registry.CurrentUser.CreateSubKey(REGISTRY_PATH);
//#else
//                    RegistryKey amcKey = Registry.LocalMachine.CreateSubKey(REGISTRY_PATH);
//#endif
                    RegistryKey burnKey = amcKey.CreateSubKey(APPLICATION_NAME);

                    // ja store the default values  
                    burnKey.SetValue(HEADER_POSITION, HeaderPosition);
                    burnKey.SetValue(TEXTDROP_DIRECTORY, TextDropDirectory);
                    burnKey.SetValue(BTWFILE_DIRECTORY, BtwFileDirectory);
                    burnKey.SetValue(CONFIG_FILE_PATH, ConfigFilePath);
                    burnKey.SetValue(SERVER_NAME, ServerName);
                    burnKey.SetValue(ALLWAYS_USE_DROP, AllwaysUseDrop);
                    burnKey.SetValue(DB_SERVER_NAME, DBServerName);
                    burnKey.SetValue(DATABASE_NAME, DatabaseName);
                    burnKey.SetValue(DATABASE_USERID, DatabaseUserID);
                    burnKey.SetValue(DATABASE_PW, DatabasePW);
                    

                    burnKey.Close();
                }
            }
            catch (System.Exception ex)
            {
                TheLog.WriteInfo(ex.Message);
            }
        }

        public static string ConvertIntVersion(int nVersion)
        {
            string sFomattedVer = "";
            
            if (nVersion > 9)
                sFomattedVer = "0." + nVersion.ToString();
            else if (nVersion <= 9)
                sFomattedVer = "0.0" + nVersion.ToString();
            else if (nVersion > 99)
                sFomattedVer = "1." + nVersion.ToString();

            return sFomattedVer;
        }
    }
}
