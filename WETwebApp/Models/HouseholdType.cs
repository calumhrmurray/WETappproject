using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class HouseholdType
    {
        public int HouseholdTypeID { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Household> Households { get; set; }
    }
}
