/*
*  This class holds all of the column information for the text file
*
*  it also formats the columns with double quotes
*/

using System.Collections.Generic;

namespace LabelGeneratorLib
{
    public class DropFileColumns
    {
        public List<string> Columns { get; set; }

        public void PopulateColumns(List<string> sColumns)
        {
            Columns = sColumns;
        }

        public string GetColumnsString()
        {
            List<string> sQuotedColumns = new List<string>();

            foreach (var Col in Columns)
            {
                sQuotedColumns.Add(string.Format("\"{0}\"", Col));
            }

            string sFormattedColumns = string.Join(",", sQuotedColumns);

            return sFormattedColumns;
        }
    }
}
