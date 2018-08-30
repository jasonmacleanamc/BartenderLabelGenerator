using System;
using System.Collections.Generic;
using System.ServiceProcess;
using AMCCommon;
using System.Threading;
using System.Data.SqlClient;
using LabelGeneratorLib;

namespace LabelsPollingService
{
    public class Worker
    {
        // ja - Volatile is used as hint to the compiler that this data member will be accessed by multiple threads
        private volatile bool _stopThread = false;

        // ja- test

        // ja - This method will be called when the thread is started. 
        public void PollingThread()
        {
            while (!_stopThread)
            {                
                Thread.Sleep(30);
            }            
        }

        public void RequestStop()
        {
            _stopThread = true;
        }
    }

    public partial class LabelPollingService : ServiceBase
    {
        private Timer TheTimer;
        private volatile bool TimerThreadRunning = false;
        private SqlCommands SqlCmd;
        
        Worker _workerObject = new Worker();
        Thread _workerThread = null;

        public LabelPollingService()
        {
            InitializeComponent();
            
            Config.ReadSettingsFromRegistry();

            Config.Log("Label Polling Started", false);

            try
            {
                SqlCmd = new SqlCommands();
            }
            catch (System.Exception ex)
            {
                Config.Log(ex.Message);
            }

            // ja - read in the Last Key used for each "Trigger"
            foreach (ITriggerTables obj in SqlCmd.Trig)
            {
                // ja - enumerators are read only so copy the object
                ITriggerTables writeObj = obj;
                Config.ReadLastKey(ref writeObj);
            }

        }

#if DEBUG
        internal void TestStartupAndStop()
        {
            string[] args = new string[1];
            this.OnStart(args);
        }
#endif

        protected override void OnStart(string[] args)
        {
            // ja - start the timer 
            var callback = new TimerCallback(StartPolling);
            TheTimer = new System.Threading.Timer(callback, null, 0, (Config.PollingInterval * 1000));

            // ja - need to start a worker thread to keep the application alive
            _workerThread = new Thread(_workerObject.PollingThread);
            _workerThread.Start();

            // ja - Loop until worker thread activates. 
            while (!_workerThread.IsAlive);                        
        }

        protected override void OnStop()
        {
            // ja - write the last used key in the registry
            foreach (ITriggerTables obj in SqlCmd.Trig)
            {
                Config.WriteLastKey(obj);
            }
                        
            TheTimer.Dispose();
            _workerObject.RequestStop();
        }

        // ja - threaded callback function
        private void StartPolling(Object state)
        {
            // ja - if another thread is already running exit out and wait for next call
            if (TimerThreadRunning)
            {
                Console.WriteLine("Thread already Running...");
                return;
            }

            // ja - set the flag to make sure only one thread runs at a time
            TimerThreadRunning = true;

            // ja - delete the entry in the database every x minutes (read from registry)
            DeleteOldData();

            // ja - don't process the job queue until all of the "triggers" are done
            if (ProcessTriggers())
                return;

            SqlDataReader dataReader = null;
            
            try
            {
                Console.WriteLine(DateTime.Now.ToString() + " - Polling Jobs Table...");
                
                // ja - read only 1 job at a time and wait x seconds to give the database time to populate all the serials
                dataReader = SqlCmd.GetJobQueueReader();

                // ja - get 1 row
                dataReader.Read();

                // ja - only read first result 
                if (dataReader.HasRows)
                {
                    string sKey = dataReader["Label_Key"].ToString();
                    string sWorkCode = dataReader["WorkCode"].ToString();
                    string sTableName = dataReader["Table_Name"].ToString();

                    Console.WriteLine("Found Key: " + sKey + "...");

                    dataReader.Close();

                    // ja - call into the Label Generator Library to print the labels or reset the flag
                    if (!String.IsNullOrWhiteSpace(sWorkCode))
                        PrintLabel(sKey, sWorkCode, sTableName);
                    else
                        SetPrintedFlag(sKey);
                }
                else
                {
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                dataReader.Close();
                Config.Log(ex.Message);
            }

            // ja - all done reset the flag
            TimerThreadRunning = false;
        }

        private bool ProcessTriggers()
        {
            bool bFound = false;
            foreach (ITriggerTables obj in SqlCmd.Trig)
            {
                // ja - if we find values in the table keep looping until no more items are added b4 we process the labels
                if (MonitorTriggerTable(obj))
                {
                    bFound = true;
                }
            }

            if (bFound)
            {
                TimerThreadRunning = false;
                return true;
            }

            return false;
        }

        private bool MonitorTriggerTable(ITriggerTables theObj)
        {
            SqlDataReader dataReader = null;
            bool bFound = false;
            int nKey = -1;
            List<string> serialsList = new List<string>();
            
            try
            {
                Console.WriteLine(DateTime.Now.ToString() + " - Polling " + theObj.GetTableName() + "...");
                
                // ja - read from the generic trigger table (only unprocessed keys) ordered by the table key 
                dataReader = SqlCmd.GetTrigerReader(theObj);
                
                // ja - only read first result 
                while (dataReader.Read())
                {
                    bFound = true;
                    
                    string sKey = dataReader[theObj.GetKeyName()].ToString().Trim();
                    string sSerialNumber = dataReader[theObj.GetBasePlate()].ToString().Trim();

                    Console.WriteLine("Found Key in " + theObj.GetTableName() + ": Key = " + sKey + "...");
                    Console.WriteLine("Found Serial in " + theObj.GetTableName() + ": Serial = " + sSerialNumber + "...");

                    // ja - store serial numbers so they can be written after this reader is closed as I only maintain one DB connection at a time
                    if (!String.IsNullOrEmpty(sSerialNumber) && !sSerialNumber.Contains("End"))
                        serialsList.Add(sSerialNumber);
                    
                    // ja - get the last key used
                    nKey = Convert.ToInt32(sKey);

                }

                // ja - store the last key...
                if (nKey > -1)
                    theObj.LastKeyUsed = nKey;
               
                dataReader.Close();

                foreach (string serial in serialsList)
                {
                    SqlCmd.FillJobsQueue(theObj, serial);
                }
               
            }
            catch (Exception ex)
            {
                dataReader.Close();
                Config.Log(ex.Message);
            }

            return bFound;
        }

        private void PrintLabel(string sKey, string sWorkCode, string sTable)
        {
            Console.WriteLine("Printing Labels: " + sWorkCode + "...");

#if DEBUG
            SetPrintedFlag(sKey);

            //return;
#endif

            try
            {
                // ja - start a new print job
                LabelGen pd = new LabelGen(sTable);

                // ja - from the table name determine the location they are printing from
                LabelGeneratorLib.PrinterArea eLoc = FindLocation(sTable);

                // ja - add the job (read labelcodes from Database)
                pd.AddPrintJob(eLoc, sWorkCode, true);

                // ja - read the serials database and fill the list
                List<string> myList = GetSerials(sKey);

                // ja - add the serial numbers to the print job
                pd.AddDataRowFromDB(myList);

                // ja - print the labels for all of the jobs
                pd.PrintLabels();

                // ja - mark in the jobs database queue that this has been printed
                SetPrintedFlag(sKey);

            }
            catch (System.Exception ex)
            {
                Config.Log(ex.Message);
            }
        }

        private List<string> GetSerials(string sKey)
        {
            Console.WriteLine("Getting Serials for Key:" + sKey + "...");

            List<string> myList = new List<string>();
            SqlDataReader dataReader = null;

            try
            {
                // ja - read in all of the serial numbers related to the job
                dataReader = SqlCmd.GetSerialReader(sKey);

                // ja - loop though all of the serials 
                while (dataReader.Read())
                {
                    // ja - get the serial number and add to the list
                    string sSerialNumber = dataReader["Serial_Number"].ToString().Trim();
                    myList.Add(sSerialNumber);
                }

                dataReader.Close();
            }
            catch (System.Exception ex)
            {
                dataReader.Close();
                Config.Log(ex.Message);
            }

            // ja - return the list of serials
            return myList;
        }

        private void SetPrintedFlag(string sKey)
        {
            Console.WriteLine("Set Printed Flag: " + sKey + "...");

            try
            {
                // ja - update the printed flag in the jobs table
                SqlCmd.UpdatePrintedFlag(sKey);
            }
            catch (System.Exception ex)
            {
                Config.Log(ex.Message);
            }
        }

        private void DeleteOldData()
        {
            SqlDataReader dataReader = null;

            try
            {
                List<string> deleteKeys = new List<string>();

                // ja - get all of the jobs that are printed and that are at least x minutes old
                dataReader = SqlCmd.GetOldJobsReader();

                // ja - loop through old jobs and add to our list
                while (dataReader.Read())
                {
                    string sKey = dataReader["Label_Key"].ToString();
                    deleteKeys.Add(sKey);
                }

                dataReader.Close();

                // ja - there are jobs to delete
                if (deleteKeys.Count > 0)
                {
                    Console.WriteLine("Deleting Old Data...");

                    // ja - loop through list and delete from the serial table first and then the job table
                    foreach (string sKey in deleteKeys)
                    {
                        // ja - delete the rows (not going to worry about the results)
                        SqlCmd.DeleteSerials(sKey);
                        SqlCmd.DeleteJobs(sKey);
                    }
                }
            }
            catch (System.Exception ex)
            {
                dataReader.Close();
                Config.Log(ex.Message);
            }
        }

        // ja - reads from the SQL Location Config file to get a location from the table name
        private LabelGeneratorLib.PrinterArea FindLocation(string sTable)
        {
            PrinterArea eLoc = PrinterArea.smt;

            string sLoc = Config.ReadConfigFile(sTable);

            eLoc = (PrinterArea)Enum.Parse(typeof(PrinterArea), sLoc);
           
            return eLoc;
        }        
    }
}
