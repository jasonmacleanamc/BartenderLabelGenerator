using System;
using System.IO;

namespace AMCCommon
{
    public class Log
    {
        public StreamWriter _sw;
        public string _sLogFileName = "";

        public bool LogUserName { get; set; }

        public Log(string sPath, bool bUserName = false)
        {
            GetLogFileName(sPath);
            _sw = new StreamWriter(_sLogFileName);
            LogUserName = bUserName;
        }

        private void GetLogFileName(string sPath)
        {
            // ja - create a valid log name with todays date and time in the current directory 
            string sDir = sPath;

            if (!Directory.Exists(sDir))
            {
                Directory.CreateDirectory(sDir);
            }

            if (LogUserName)
                _sLogFileName = sDir + @"\" + GetUserName() + ":" + DateTime.Now.ToString("yyyyMMdd-HHmm") + @".log";
            else
                _sLogFileName = sDir + @"\" + DateTime.Now.ToString("yyyyMMdd-HHmm") + @".log";
        }

        public void WriteInfo(string sInfo)
        {
            _sw.WriteLine(sInfo);
            Console.WriteLine(sInfo);
            _sw.Flush();
        }

        public string GetUserName()
        {
            return Environment.UserName;
        }

        public void CloseLogging()
        {
            _sw.Close();
        }
    }
}
