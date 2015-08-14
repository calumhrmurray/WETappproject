using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class TelevisionSupplierType
    {
        public int TelevisionSupplierTypeID { get; set; }

        [DisplayName("Television provider")]
        public string Type { get; set; }

        public virtual ICollection<HouseholdInformation> HouseholdInformation { get; set; }

    }
}
