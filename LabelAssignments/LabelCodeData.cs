using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelAssignments
{
    class LabelCodeData
    {
        public List<string> Locations { get; set; }

        public bool SmallLabel { get; set; }
        public bool LargeLabel { get; set; }

        public LabelCodeData()
        {
            Locations = new List<string>();

            Locations.Add("Smt");
            Locations.Add("In Process");
            Locations.Add("BasePlate");
            Locations.Add("Final");

            SmallLabel = true;
            LargeLabel = false;
        }
    }
}
