using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;

namespace AMCCommon
{
    public class SqlCommands
    {
        private SqlConnection TheConnection = null;
        public Triggers Trig = new Triggers();

        private const string JobsQueueTable = "lg_JobsQueue";
        private const string SerialTable = "lg_Serials";

        public SqlCommands()
        {
            try
            {
                // ja - create a global database connection
                TheConnection = new SqlConnection(Config.GetConnectionString());

                TheConnection.Open();
            }
            catch (System.Exception ex)
            {
                Config.Log(ex.Message);
            }
        }

        private string GetSerialSql(string sKey)
        {
            return "Select Serial_Number from " + SerialTable + " where Label_Key = '" + sKey + "'";
        }

        private string GetJobQueueSql()
        {
            string sSql = "Select Top 1 * from " + JobsQueueTable + " where Printed = '0' and GETDATE() > DateAdd(s, " + Config.GetSelectDelay() + ", AddedDate) order by AddedDate";

            return sSql;
        }

        private string GetOldJobsSql()
        {
            return "Select * from " + JobsQueueTable + " where Printed = '1' and ( DATEDIFF( minute , AddedDate, GETDATE() ) >= " + Config.GetDeleteInterval() + " )";
        }

        private string DeleteSerialsSql(string sKey)
        {
            return "Delete from " + SerialTable + " where Label_Key = '" + sKey + "'";
        }

        private string DeleteJobsSql(string sKey)
        {
            return "Delete from " + JobsQueueTable + " where Label_Key = '" + sKey + "'";
        }

        private string UpdatePrintedFlagSql(string sKey)
        {
            return "Update " + JobsQueueTable + " set Printed = '1' where Label_Key = '" + sKey + "'";
        }

        private string GetTriggerTableSql(ITriggerTables TheClass)
        {
            string sSql = "Select ";
            sSql += TheClass.GetKeyName() + ", " + TheClass.GetBasePlate();
            sSql += " from " + TheClass.GetTableName();
            sSql += " where " + TheClass.GetKeyName() + " > " + TheClass.LastKeyUsed.ToString();
            sSql += " order by " + TheClass.GetKeyName();
            
            return sSql;
        }

        private string ExecuteFillLabelGen(ITriggerTables triggerObj, string sSerialNumber)
        {
            string sSql = "exec usp_FillLabelGen '" + triggerObj.GetTableName() + "', '" + sSerialNumber + "'";

            return sSql;
        }     

        public SqlCommand GetSerialCommand(string sKey)
        {
            SqlCommand sqlCommand = new SqlCommand(GetSerialSql(sKey), TheConnection);

            return sqlCommand;
        }

        public SqlDataReader GetSerialReader(string sKey)
        {
            SqlCommand sqlCommand = GetSerialCommand(sKey);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            return dataReader;
        }

        public SqlCommand GetJobQueueCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(GetJobQueueSql(), TheConnection);

            return sqlCommand;
        }

        public SqlDataReader GetJobQueueReader()
        {
            SqlCommand sqlSelect = GetJobQueueCommand();
            SqlDataReader dataReader = sqlSelect.ExecuteReader();

            return dataReader;
        }

        public SqlCommand GetOldJobsCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(GetOldJobsSql(), TheConnection);

            return sqlCommand;
        }

        public SqlDataReader GetOldJobsReader()
        {
            SqlCommand sqlSelect = GetOldJobsCommand();
            SqlDataReader dataReader = sqlSelect.ExecuteReader();

            return dataReader;
        }

        public SqlCommand GetTriggerCommand(ITriggerTables triggerObj)
        {
            SqlCommand sqlCommand = new SqlCommand(GetTriggerTableSql(triggerObj), TheConnection);

            return sqlCommand;
        }

        public SqlDataReader GetTrigerReader(ITriggerTables triggerObj)
        {
            SqlCommand sqlSelect = GetTriggerCommand(triggerObj);
            SqlDataReader dataReader = sqlSelect.ExecuteReader();

            return dataReader;
        }

        public int FillJobsQueue(ITriggerTables triggerObj, string sSerialNumber)
        {
            SqlCommand sqlCommand = new SqlCommand(ExecuteFillLabelGen(triggerObj, sSerialNumber), TheConnection);
            int nResults = sqlCommand.ExecuteNonQuery();

            return nResults;
        }
        

        public int DeleteSerials(string sKey)
        {
            SqlCommand myDeleteSerial = new SqlCommand(DeleteSerialsSql(sKey), TheConnection);
            int nResults = myDeleteSerial.ExecuteNonQuery();

            return nResults;
        }

        public int DeleteJobs(string sKey)
        {
            SqlCommand myDeleteJob = new SqlCommand(DeleteJobsSql(sKey), TheConnection);
            int nResults = myDeleteJob.ExecuteNonQuery();

            return nResults;
        }

        public int UpdatePrintedFlag(string sKey)
        {
            SqlCommand sqlCommand = new SqlCommand(UpdatePrintedFlagSql(sKey), TheConnection);
            int nResults = sqlCommand.ExecuteNonQuery();

            return nResults;
        }
    }
}
