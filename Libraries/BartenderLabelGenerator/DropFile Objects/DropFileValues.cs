using System.Collections.Generic;

namespace LabelGeneratorLib
{
    /*
     * Represents the Data Rows for each Serial Number (Label)
     * 
     * Stores the data as a List of List's with each Row as a List of Column data
     */
    public class DropFileValues
    {
        // ja - this is out List of Lists (Rows of Columns)
        private List<List<string>> SerialDataRow = new List<List<string>>();

        public DropFileValues()
        {            
        }

        public void AddDataRow(List<string> serialRow)
        {
            // ja - add a list of List's to the internal member
            SerialDataRow.Add(serialRow);
        }

        public string GetDataString()
        {
            string sDataList = "";
            
            // ja - going to loop trough the internal string list and populate a single string for the txt file
            foreach(List<string> row in SerialDataRow)
            {
                // ja - special case for multiple labels of the same type
                for (int i = 0; i < ConfigValues.SingleLabelQty; i++)
                {
                    sDataList += GetDataStringRow(row);
                    sDataList += DropFileHeader.GetNewLine();
                }
            }

            return sDataList;
        }

        protected string GetDataStringRow(List<string> theRow)
        {
            List<string> sQuotedColumns = new List<string>();

            // ja - add quotes around the data
            foreach (string val in theRow)
            {
                sQuotedColumns.Add(string.Format("\"{0}\"", val));
            }

            // ja - add comma delimitation
            string sFormattedColumns = string.Join(",", sQuotedColumns);

            return sFormattedColumns;
        }
    }
}
