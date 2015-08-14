using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class ElectricitySupplierType
    {
        public int ElectricitySupplierTypeID { get; set; }

        [DisplayName("Electricity Supplier")]
        public string Type { get; set; }

        public virtual ICollection<HouseholdInformation> HouseholdInformation { get; set; }

    }
}
