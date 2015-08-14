using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class GasSupplierType
    {
        public int GasSupplierTypeID { get; set; }

        [DisplayName("Gas Supplier")]
        public string Type { get; set; }

        public virtual ICollection<HouseholdInformation> HouseholdInformation { get; set; }
    }
}
