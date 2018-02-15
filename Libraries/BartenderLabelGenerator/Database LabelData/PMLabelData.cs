using System;
using System.Collections.Generic;

namespace LabelGeneratorLib
{
    public class PMLabelData
    {
        private string _CustomerName;
        
        // TODO: ja - create ext serial number for symbolics
        private string _SerialNumber;
        public string SerialNumber
        {
            get
            {
                // ja - RMA Override 
                if (ConfigValues.RMADataOverride && !String.IsNullOrEmpty(ConfigValues.rmaOverride.SerialNumber))
                    return ConfigValues.rmaOverride.SerialNumber;

                return _SerialNumber;
            }
            set
            {
                _SerialNumber = value;
            }
        }

        // ja - read only clean serial number
        private string CleanSerialNumber
        {
            get
            {
                // ja - trim serial number of all "-"
                string sClean = _SerialNumber.Replace("-", "");
                // TODO: ja - Test
                return sClean;
            }
        }

        private string _sPartNumber;
        public string PartNumber
        {
            get
            {
                // ja - RMA Override 
                if (ConfigValues.RMADataOverride && !String.IsNullOrEmpty(ConfigValues.rmaOverride.PartNumber))
                    return ConfigValues.rmaOverride.PartNumber;

                // ja - add the revision to the part number for display (taken out 4-11-16)
                string sRevPartNumber = sBaseModel;// + sRevLetter;

                if (!string.IsNullOrEmpty(sExtension))
                    sRevPartNumber += "-" + sExtension;

                return sRevPartNumber;
            }
            set
            {
                _sPartNumber = value;
            }
        }

        // ja - get the clean part number
        private string CleanPartNumber
        {
            get
            {
                // ja - trim serial number of all "-"
                string sClean = PartNumber.Replace("-", "");
                // TODO: ja - Test
                return sClean;
            }
        }

        // ja - get first 11
        private string PartNumberFirst
        {
            get
            {
                int nLen = PartNumber.Length;

                if (nLen > 10)
                    nLen = 10;

                return PartNumber.Substring(0, nLen);
            }
        }

        // ja - get 11th digit on
        private string PartNumberSecond
        {
            get
            {
                int nLength = PartNumber.Length;

                if (nLength >= 11)
                {
                    int nNewLen = nLength - 10;

                    return PartNumber.Substring(10, nNewLen);                    

                }
                else
                    return "";
            }
        }

        // ja - pass in the int version, use the string version for the label
        public int nVersion;
        private string Version
        {
            get
            {
                // ja - RMA Override 
                if (ConfigValues.RMADataOverride && !String.IsNullOrEmpty(ConfigValues.rmaOverride.Version))
                    return ConfigValues.rmaOverride.Version;

                string sFomattedVer = "";

                if (nVersion > 9)
                    sFomattedVer = "0." + nVersion.ToString();
                else if (nVersion <= 9)
                    sFomattedVer = "0.0" + nVersion.ToString();
                else if (nVersion > 99)
                    sFomattedVer = "1." + nVersion.ToString();

                return sFomattedVer;
            }
            set
            {
                nVersion = Convert.ToInt32(value);
            }
        }

        // ja - this is a string because of leading 0
        string _DateCode; 
        string DateCode
        {
            get
            {
                // ja - RMA Override 
                if (ConfigValues.RMADataOverride && !String.IsNullOrEmpty(ConfigValues.rmaOverride.DateCode))
                    return ConfigValues.rmaOverride.DateCode;

                DateTime dt = DateTime.Now;

                double dWeeks = (dt.DayOfYear / 7);

                if (dWeeks < 1.00)
                    dWeeks = 1;
                else
                    dWeeks += 1;

                int Weeks = ((int)dWeeks);
                var sYear = DateTime.Now.ToString("yy");

                var sWeeks = string.Format("{0}", Weeks);
                if (Weeks < 10)
                    sWeeks = string.Format("0{0}", Weeks);
                
                string dc = string.Format("{0}{1}", sYear, sWeeks);

                return dc;          
            }
            set
            {
                _DateCode = value;
            }
        }

        // ja - for adding rev letter to part number on label
        protected string sBaseModel;
        protected string sExtension;

        //string sRevLetter;

        private string _sRevLetter = "";
        public string RevLetter
        {
            get
            {
                // ja - RMA Override 
                if (ConfigValues.RMADataOverride && !String.IsNullOrEmpty(ConfigValues.rmaOverride.RevLetter))
                    return ConfigValues.rmaOverride.RevLetter;

                
                return _sRevLetter;
            }
            set
            {
                _sRevLetter = value;
            }
        }

        private string _sInputSpecs = "";
        protected string sInputSpecs
        {
            get
            {
                // ja - RMA Override 
                if (ConfigValues.RMADataOverride && !String.IsNullOrEmpty(ConfigValues.rmaOverride.InputSpecs))
                    return ConfigValues.rmaOverride.InputSpecs;

                
                return _sInputSpecs;
            }
            set
            {
                _sInputSpecs = value;
            }
        }

        private string _sOutputSpecs = "";
        protected string sOutputSpecs
        {
            get
            {
                // ja - RMA Override 
                if (ConfigValues.RMADataOverride && !String.IsNullOrEmpty(ConfigValues.rmaOverride.OutputSpecs))
                    return ConfigValues.rmaOverride.OutputSpecs;


                return _sOutputSpecs;
            }
            set
            {
                _sOutputSpecs = value;
            }
        }      

        protected bool bEtherCat;
        protected bool bUL;
        protected bool bCE;
        protected bool bProtoType;
        protected bool bROHS;

        protected const string sULFileNumber = "E140173"; // TODO: ja - read in
        protected const string sAmcWebAddress = "www.a-m-c.com"; // TODO: ja - read in

        // ja - for Type A
        private bool _bTuv;
        public bool Tuv
        {
            get
            {
                // TODO: ja - default as false
                // read in from xml file
                //bool bTuv = false;
                
                 // if label type is A then read xml file of same btw name
                bool bTuv = ConfigValues._bTUV;
                
                return bTuv;
            }
            set
            {
                _bTuv = value;
            }
        }

        public PMLabelData(LabelDataStruct theRawData, string sCustomerName)
        {
            if (string.IsNullOrEmpty(sCustomerName))
                sCustomerName = "AMC";

            _CustomerName = sCustomerName;

            SerialNumber = theRawData.SerialNumber;
            PartNumber = theRawData.PartNumber;
            
            DateCode = theRawData.DateCode; 

            nVersion = theRawData.nVersion;

            RevLetter = theRawData.RevLetter;
            sInputSpecs = theRawData.InputSpecs;
            sOutputSpecs = theRawData.OutputSpecs;

            bEtherCat = theRawData.EtherCat;
            bUL = theRawData.UL;
            bCE = theRawData.CE;
            bProtoType = theRawData.ProtoType;
            bROHS = theRawData.ROHS;
            Tuv = theRawData.Tuv;

            // ja - internal use for rev letter
            sBaseModel = theRawData.BaseModel;
            sExtension = theRawData.Extension;

    }

        virtual public string GetBarCodeString()
        {
            if (IsPhilips())
            {
                // ja - Philips uses a standard date code
                string dc = DateTime.Now.ToString("yyMMdd");

                // ja - adding the gs1 codes so the label will pass inspection 
                string sPhilipsBc = "90" + CleanPartNumber + "^1" + "21" + CleanSerialNumber + "^1" + "11" + dc;

                return sPhilipsBc;
            }
            else
                return SerialNumber;
        }        

        public List<string> GetValueList()
        {
            // ja - do not change the order of the adding to the array!!!

            List<string> values = new List<string>();
            
            values.Add(SerialNumber);
            values.Add(PartNumber);
                        
            values.Add(PartNumberFirst);
            values.Add(PartNumberSecond);
            
            values.Add(DateCode);
            
            values.Add(Version);
            values.Add(RevLetter);
            values.Add(sInputSpecs);
            values.Add(sOutputSpecs);

            // ja - boolean values
            values.Add(Convert.ToString(bEtherCat));
            values.Add(Convert.ToString(bUL));
            values.Add(Convert.ToString(bCE));
            values.Add(Convert.ToString(bProtoType));
            values.Add(Convert.ToString(bROHS));
            values.Add(Convert.ToString(Tuv));

            // ja - special value can change for different customers
            values.Add(GetBarCodeString());

            // ja - hard coded values
            values.Add(sULFileNumber);
            values.Add(sAmcWebAddress);

            return values;
        }

        static public List<String> GetPMColumnHeaders()
        {
            // ja - do not change the order of the adding to the array!!!
            List<string> theColumns = new List<string>();
            theColumns.Add("SerialNumber");
            theColumns.Add("PartNumber");
            theColumns.Add("PartNumberFirst");
            theColumns.Add("PartNumberSecond");
            theColumns.Add("DateCode");
            theColumns.Add("Version");
            theColumns.Add("RevLetter");
            theColumns.Add("InputSpecs");
            theColumns.Add("OutputSpecs");
            theColumns.Add("EtherCat");
            theColumns.Add("UL");
            theColumns.Add("CE");
            theColumns.Add("ProtoType");
            theColumns.Add("ROHS");
            theColumns.Add("TUV");
            theColumns.Add("BarCodeData");
            theColumns.Add("ULFileNumber");
            theColumns.Add("WebAddress");

            return theColumns;
        }

        // ja - special customer functions

        // Philips
        bool IsPhilips()
        {
            if (_CustomerName == "PHILLIPS" || ConfigValues.CustomerName == Customers.phillips)
                return true;
            else
                return false;
        }

    }
}
