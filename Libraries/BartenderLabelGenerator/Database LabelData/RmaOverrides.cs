using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelGeneratorLib
{
    public class RmaOverrides
    {
        public string DateCode { get; set; }    
        public string Version { get; set; }
        public string SerialNumber { get; set; }
        public string PartNumber { get; set; }        
        public string RevLetter { get; set; }
        public string InputSpecs { get; set; }
        public string OutputSpecs { get; set; }
        public bool EtherCat { get; set; }
        public bool UL { get; set; }
        public bool CE { get; set; }
        public bool ProtoType { get; set; }
        public bool ROHS { get; set; }

    }
}
