using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class HouseholdDescriptionType
    {
        public int HouseholdDescriptionTypeID { get; set; }

        [DisplayName("Household description")]
        public string Type { get; set; }

        public virtual ICollection<HouseholdInformation> HouseholdInformation { get; set; }
    }
}
