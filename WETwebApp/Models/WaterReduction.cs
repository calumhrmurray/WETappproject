using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class WaterReduction
    {
        public int WaterReductionID { get; set; }

        [DisplayName("How important is reducing water consumption?")]
        public string Type { get; set; }

        public virtual ICollection<WaterUnderstanding> WaterUnderstanding { get; set; }
    }
}
