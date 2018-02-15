using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWebPage.LabelGenService;
using TestWebPage.LocalService;


namespace TestWebPage
{
    public enum PrinterArea
    {
        smt = 20,
        in_process = 40,
        baseplate = 50,
        final = 100,
        wherehouse
    }

    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //LabelGenService.LabelGeneratorClient c = new LabelGenService.LabelGeneratorClient();
            
// 
//             
// 
// 
             
// 
//             //int nJobNum = c.AddPrintJob(LabelGenService.PrinterArea.final, LabelGenService.LabelTypes.aspinv, s);
//             int nJobNum = c.AddPrintJob(LocalService.PrinterArea.final, LocalService.LabelTypes.aspinv, s);
// 
//             c.AddDataRow2(0, "SMT1.1.", 10, 1);
// 
//             List<List<string>> myData = new List<List<string>>();
//             List<string> theRow = new List<string>();
// 
//             theRow.Add("SMT1.1.");
// 
//             myData.Add()
// 
//             //nJobNum = c.AddPrintJob(LabelGenService.PrinterArea.final, LabelGenService.LabelTypes.aspinv, s);
// 
//             //c.AddDataRow2(nJobNum, "SMT1.2.", 10, 1);
// 
//             c.PrintLabels();
            //TextBox1.Text = nQty.ToString();

            LocalService.LabelGeneratorClient c = new LocalService.LabelGeneratorClient();
            
            List<string> myList = new List<string>();
            myList.Add("Col 1");
            string[] s = myList.ToArray();

            c.Print(LocalService.PrinterArea.final, LocalService.LabelTypes.aspinv, s, "", 10, 1);
        }
    }
}
