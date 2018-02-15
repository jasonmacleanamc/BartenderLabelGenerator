using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
//using CLRLabelTrigger.LabelGenService;

//namespace CLRLabelTrigger
//{
    public partial class CLRTrigger
    {
        [SqlTrigger(Name = @"ShowInserted", Target = "[dbo].[Users]", Event = "FOR INSERT, UPDATE, DELETE")]
        public static void ShowInserted()
        {
            SqlTriggerContext triggContext = SqlContext.TriggerContext;
            SqlConnection conn = new SqlConnection(" context connection =true ");
            conn.Open();
            SqlCommand sqlComm = conn.CreateCommand();
            SqlPipe sqlP = SqlContext.Pipe;
            SqlDataReader dr;
            sqlComm.CommandText = "SELECT Burst_2d_Modell1, Burst_2d_Modell2 from inserted";
            dr = sqlComm.ExecuteReader();
            

//             string sqlcmd = @"\\boa\Production\Production Manual Development\go.bat";
//             SqlCommand sqlComm2 = conn.CreateCommand();
//             sqlComm2.CommandText = "EXEC master..xp_cmdshell " + sqlcmd + , no_output;
            

//             sqlcmd = ""
// 
//              :) 
            
//             LabelGeneratorClient cl = new LabelGeneratorClient();
// 
//            List<string> myList = new List<string>();
//             myList.Add("Col 1");
//             string[] s = myList.ToArray();
// 
//             cl.Print(CLRLabelTrigger.LabelGenService.PrinterArea.final, CLRLabelTrigger.LabelGenService.LabelTypes.aspinv, s, "", 10, 1);
// 
//             //cl.Print(CLRLabelTrigger.LabelGenService.PrinterArea.final, CLRLabelTrigger.LabelGenService.LabelTypes.aspinv, string[] sColumns, string sTemplate, int nQty, int nStartPos) {
// 
//             //cl.PrintLabels();

            while (dr.Read())
                sqlP.Send("Yo - " + (string)dr[0] + "," + (string)dr[1]);

            
        }
    }
//}

