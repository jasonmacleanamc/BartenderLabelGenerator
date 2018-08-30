using System;
using Microsoft.Win32;
using System.Xml;

namespace AMCCommon
{
    public static class Config
    {
        // ja - public access
        public static string ServerName { get; set; }
        public static int PollingInterval { get; set; }

        // ja - internal use
        private static int SelectDelay { get; set; }
        private static int DeleteInterval { get; set; }
        private static string ConnectionString { get; set; }
        private static string DatabaseName { get; set; }
        private static string DatabaseUserID { get; set; }
        private static string DatabasePW { get; set; }

        const string APPLICATION_NAME = "LabelPollingService";
        const string REGISTRY_PATH = "Software\\Advanced Motion Controls";

        // ja - for logging
        //private static EventLogger EventLog = new EventLogger("LabelPollingService", "LabelPollingLog");

        public static string GetConnectionString()
        {
            string ConnectionString = "user id=" + DatabaseUserID + ";password=" + DatabasePW + ";Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=True";

            return ConnectionString;
        }

        public static string GetSelectDelay()
        {
            return SelectDelay.ToString();
        }

        public static string GetDeleteInterval()
        {
            return DeleteInterval.ToString();
        }

        public static void Log(string sMsg, bool bError = true)
        {
            Console.WriteLine(sMsg);

#if NO
            if (bError)
                EventLog.WriteToEventLog(sMsg, "Error");
            else
                EventLog.WriteToEventLog(sMsg, "Info");
#endif
        }

        public static void foo()
        {
            int t = 0;

            t++;
        }

        public static void ReadSettingsFromRegistry()
        {
            const string SERVER_NAME = "Server DB Name";
            const string DATABASE_NAME = "Database Name";
            const string DATABASE_USERID = "Database User ID";
            const string DATABASE_PW = "Database Password";
            const string SELECT_DELAY = "Delay Time for Select (In Seconds)";
            const string DELETE_INTERVAL = "Delete Interval (In Minutes)";
            const string POLLING_INTERVAL = "Polling Interval (In Seconds)";

            // ja - force compile
            
          
            try
            {
                RegistryKey key = GetRegistryKey(true);

                // ja - if the registry has been written to read in values
                if (key != null)
                {
                    Console.WriteLine("ReadPathFromRegistry - Reading Values");

                    ServerName = key.GetValue(SERVER_NAME).ToString();
                    DatabaseName = key.GetValue(DATABASE_NAME).ToString();
                    DatabaseUserID = key.GetValue(DATABASE_USERID).ToString();
                    DatabasePW = key.GetValue(DATABASE_PW).ToString();
                    SelectDelay = Convert.ToInt32(key.GetValue(SELECT_DELAY).ToString());
                    DeleteInterval = Convert.ToInt32(key.GetValue(DELETE_INTERVAL).ToString());
                    PollingInterval = Convert.ToInt32(key.GetValue(POLLING_INTERVAL).ToString());
                    
                    key.Close();
                }
                else
                {
                    Console.WriteLine("ReadPathFromRegistry - Writing Values, using Defaults");

                    
                    ServerName = "amc-sql01";
                    DatabaseName = "AMC_MfgData";
                    DatabaseUserID = "autest";
                    DatabasePW = "autest1234";
                    SelectDelay = 2;
                    DeleteInterval = 15;
                    PollingInterval = 5;

                    RegistryKey amcKey = GetRegistryKey(false);
                    RegistryKey burnKey = amcKey.CreateSubKey(APPLICATION_NAME);

                    // ja store the default values  
                    burnKey.SetValue(SERVER_NAME, ServerName);
                    burnKey.SetValue(DATABASE_NAME, DatabaseName);
                    burnKey.SetValue(DATABASE_USERID, DatabaseUserID);
                    burnKey.SetValue(DATABASE_PW, DatabasePW);
                    burnKey.SetValue(SELECT_DELAY, SelectDelay);
                    burnKey.SetValue(DELETE_INTERVAL, DeleteInterval);
                    burnKey.SetValue(POLLING_INTERVAL, PollingInterval);
                    
                    burnKey.Close();
                }
            }
            catch (System.Exception ex)
            {
                Log(ex.Message);
            }
        }

        public static string ReadConfigFile(string sTableName)
        {
            string sArea = "";
            
            try
            {
                // ja - get all the types of labels we need to print from the config
                XmlDocument doc = new XmlDocument();
                // TODO: ja - read from reg
                doc.Load(@"\\nightadder\btwFiles\Sql Tables Location.config");

                XmlNode LabelTypeNode = doc.SelectSingleNode("/production_manual_labels/sql_table_name/" + sTableName.ToLower());

                sArea = LabelTypeNode.Attributes.GetNamedItem("location").Value;
            }
            catch (System.Exception ex)
            {
                Log(ex.Message);
            }

            return sArea;
        }

        public static void ReadLastKey(ref ITriggerTables triggerObj)
        {
         
            string sRegKeyName = GetLastKeyName(triggerObj);

            try
            {
                RegistryKey key = GetRegistryKey(true);
                
                // ja - this should throw an exception if it does not yet exists
                int nLastKey = Convert.ToInt32(key.GetValue(sRegKeyName).ToString());

                if (nLastKey > 0)
                    triggerObj.LastKeyUsed = nLastKey;

                key.Close();
                                
            }
            catch (System.Exception)
            {                
                // ja - do nothing because the key might not of been written yet
            }
        }

        public static void WriteLastKey(ITriggerTables triggerObj)
        {
            try
            {
                Console.WriteLine("WriteLastKey - Writing Last Key Values");
                
                int nLastKey = triggerObj.LastKeyUsed;
                string sRegKeyName = GetLastKeyName(triggerObj);

                RegistryKey amcKey = GetRegistryKey(false);
                RegistryKey burnKey = amcKey.CreateSubKey(APPLICATION_NAME);

                // ja store the default values  
                burnKey.SetValue(sRegKeyName, nLastKey);

                burnKey.Close();
               
            }
            catch (System.Exception ex)
            {
                Log(ex.Message);
            }
        }

        public static string GetLastKeyName(ITriggerTables triggerObj)
        {
            return "LastKeyFor_" + triggerObj.GetTableName();                       
        }

        private static RegistryKey GetRegistryKey(bool bRead)
        {
            RegistryKey key = null;
            
            if (bRead)
            {
#if DEBUG
                key = Registry.CurrentUser.OpenSubKey(REGISTRY_PATH + "\\" + APPLICATION_NAME);
#else
                key = Registry.LocalMachine.OpenSubKey(REGISTRY_PATH + "\\" + APPLICATION_NAME);
#endif
            }
            else
            {
#if DEBUG
                key = Registry.CurrentUser.CreateSubKey(REGISTRY_PATH);
#else
                key = Registry.LocalMachine.CreateSubKey(REGISTRY_PATH);
#endif
            }

            return key;
        }
    }
}
