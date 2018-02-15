using System;
using System.Linq;
using AMCDatabase;

namespace LabelGeneratorLib
{
    public struct LabelDataStruct
    {
        // TODO: ja - Do we need this?
        //int nPrintJobNumber;

        // TODO: ja - how do we handle multiple?
        public string SerialNumber;
        public string PartNumber;
        public string DateCode;

        // ja - for adding rev letter to part number on label
        public string BaseModel;
        public string Extension;

        public int nVersion;

        public string RevLetter;
        public string InputSpecs;
        public string OutputSpecs;

        public bool EtherCat;
        public bool UL;
        public bool CE;
        public bool ProtoType;
        public bool ROHS;

        // ja - internal use
        public string sLabelsCode;
        public int nQty;

        // ja - Tuv for type A
        public bool Tuv;
    }

    public class WorkCodeLabel
    {
        private string WorkCode { get; set; }
        private LabelDataStruct _wcLabelData;

        public WorkCodeLabel(string sWorkCode)
        {
            WorkCode = sWorkCode;
            
            if (WorkCode == "999999")
                FillLabelDataGeneric();
            else
                FillLabelData();
        }

        public LabelDataStruct GetWorkCodeData()
        {
            return _wcLabelData;
        }

        protected bool GetWorkcode(string sSerialNumber, ref string sWorkCode)
        {
            if (sSerialNumber.Length < 5)
                return false;

            // ja - extract workcode
            sWorkCode = sSerialNumber.Substring(0, 5);

            if (String.IsNullOrWhiteSpace(sWorkCode))
                return false;

            int n;
            if (!int.TryParse(sWorkCode.Substring(0, 5), out n))
                return false;

            return true;
        }

        private void FillLabelData()
        {
            _wcLabelData = new LabelDataStruct();

            Workcode wc = new Workcode(WorkCode);

            if (wc.KeyFound())
            {
                string sPartNumber = wc.GetValue(wc.MODELLCODE).Trim();
                _wcLabelData.PartNumber = sPartNumber;
                _wcLabelData.ROHS = Convert.ToBoolean(wc.GetValue("Rohasyorn"));

                string sVersion = wc.GetValue(wc.AMPVERSION);
                _wcLabelData.nQty = Convert.ToInt32(wc.GetValue("Quantity"));

                // ja - separate the 0. from the 00
                string[] sStrippedVersion = sVersion.Split('.');
                if (sStrippedVersion.Count() > 1)
                    _wcLabelData.nVersion = Convert.ToInt32(sStrippedVersion[1]);

                PartsTable pt = new PartsTable(sPartNumber, sVersion);

                if (pt.KeyFound())
                {
                    _wcLabelData.EtherCat = Convert.ToBoolean(pt.GetValue("Ethercat"));
                    _wcLabelData.UL = Convert.ToBoolean(pt.GetValue("UL"));
                    _wcLabelData.InputSpecs = pt.GetValue("Inspecs").Trim();
                    _wcLabelData.OutputSpecs = pt.GetValue("Outspecs").Trim();
                    _wcLabelData.RevLetter = pt.GetValue("Revision").Trim();
                    _wcLabelData.CE = Convert.ToBoolean(pt.GetValue("Emc"));
                    _wcLabelData.ProtoType = Convert.ToBoolean(pt.TableName == "Proto");

                    // ja - internal use
                    _wcLabelData.BaseModel = pt.GetValue("BaseModel").Trim();
                    _wcLabelData.Extension = pt.GetValue("Extension").Trim();
                    _wcLabelData.sLabelsCode = pt.GetValue("Labelscode");
                }
            }

        }

        private void FillLabelDataGeneric()
        {
            _wcLabelData = new LabelDataStruct();


            string sPartNumber = "111";
            _wcLabelData.PartNumber = sPartNumber;
            _wcLabelData.ROHS = true;
            //string sVersion = "0.01";
            _wcLabelData.nQty = 1;

            _wcLabelData.nVersion = 1;

               
            _wcLabelData.EtherCat = true;
            _wcLabelData.UL = true;
            _wcLabelData.InputSpecs = "Input";
            _wcLabelData.OutputSpecs = "Output";
            _wcLabelData.RevLetter = "A";
            _wcLabelData.CE = true;
            _wcLabelData.ProtoType = true;

            // ja - internal use
            _wcLabelData.BaseModel = "111";
            _wcLabelData.Extension = "111";
            _wcLabelData.sLabelsCode = "10-1, 20-1, 50-1, 100-1";
           
        }

        public int GetLabelQuantity()
        {
            return _wcLabelData.nQty;
        }

        public string GetLabelsCode()
        {
            return _wcLabelData.sLabelsCode;
        }

        public string GetWorkCode()
        {
            return WorkCode;
        }
    }
}
