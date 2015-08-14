using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class HeatingSystemType
    {
        public int HeatingSystemTypeID { get; set; }

        [DisplayName("Heating System")]
        public string Type { get; set; }

        public virtual ICollection<HouseholdInformation> HouseholdInformation { get; set; }
    }
}
