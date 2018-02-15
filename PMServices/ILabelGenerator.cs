using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PMServices
{   
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface ILabelGenerator
    {
        //[OperationContract]
        //int GetLabelQuantity();

        [OperationContract]
        bool Print(LabelGeneratorLib.PrinterArea eArea, LabelGeneratorLib.LabelTypes eLabelType, List<string> sColumns, string sTemplate, int nQty, int nStartPos = 0);

        [OperationContract]
        int AddPrintJob(LabelGeneratorLib.PrinterArea eArea, LabelGeneratorLib.LabelTypes eLabelType, List<string> sColumns);
        
        [OperationContract]
        bool AddDataRow(int nJobNumber, List<string> sData);
        
        [OperationContract]
        bool AddDataRowFromDB(List<string> sSerials);
        
        [OperationContract]
        bool AddDataRow2(int nJobNumber, string sValue, int nQty, int nStart = 0);

        [OperationContract]
        bool PrintLabels();
        
    }
}
