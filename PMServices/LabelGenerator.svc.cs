using System.Collections.Generic;
using LabelGeneratorLib;
using System.ServiceModel;
//using System.Web.UI.Page.Session;

namespace PMServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)] 
    public class LabelGenerator : ILabelGenerator
    {
        
        LabelGen _labelGen = new LabelGen();
        //Session["LabelGen"] = _labelGen;
         
        public bool Print(LabelGeneratorLib.PrinterArea eArea, LabelGeneratorLib.LabelTypes eLabelType, List<string> sColumns, string sTemplate, int nQty, int nStartPos = 0)
        {
            LabelGen _labelGen = new LabelGen();
            
            int nJob = _labelGen.AddPrintJob(eArea, eLabelType, sColumns);

            _labelGen.AddDataRow(nJob, sTemplate, nQty, nStartPos);
         
            _labelGen.PrintLabels();
            
            return true;
        }
       
        public int AddPrintJob(LabelGeneratorLib.PrinterArea eArea, LabelGeneratorLib.LabelTypes eLabelType, List<string> sColumns)
        {
            //LabelGen objClass = (LabelGen)Session["LabelGen"];

            //return objClass.AddPrintJob(eArea, eLabelType, sColumns);

            return _labelGen.AddPrintJob(eArea, eLabelType, sColumns);
            
        }

        public bool  AddDataRow(int nJobNumber, List<string> sData)
        {
            return _labelGen.AddDataRow(nJobNumber, sData);
        }

        public bool AddDataRowFromDB(List<string> sSerials)
        {
            return _labelGen.AddDataRowFromDB(sSerials);
        }

        public bool AddDataRow2(int nJobNumber, string sValue, int nQty, int nStart = 0)
        {
            //return true;
            
            return _labelGen.AddDataRow(nJobNumber, sValue, nQty, nStart);
        }

        public bool PrintLabels()
        {
            return _labelGen.PrintLabels();
        }     
       
    }
}
