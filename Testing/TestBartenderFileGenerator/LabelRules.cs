using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBartenderFileGenerator
{
    class LabelRules
    {
#if NO
        private bool CheckTestResults(string sSerialNumber)
        {
            if (Rma)
                return true;

            string sMsgStart = sSerialNumber + " - Has Not Passed the Following:";
            string sMsgMiddle = "";
            string sMsgEnd = "Final Label will not be Printed!";
            string sCaption = "Label Error - " + sSerialNumber;

            try
            {
                // ja - set the serial number for test Results lib
                TheTestResults.SetSerialNumber(sSerialNumber);
                List<string> sFailedTests = TheTestResults.GetFailedTypes();

                foreach (string sTestDesc in sFailedTests)
                {
                    sMsgMiddle += Environment.NewLine + "( '" + sTestDesc + "' )";
                }

                if (!string.IsNullOrEmpty(sMsgMiddle))
                {
                    string sMsg = sMsgStart + Environment.NewLine + sMsgMiddle + Environment.NewLine + Environment.NewLine + sMsgEnd;
                    MessageBox.Show(sMsg, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
#endif
    }
}
