using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class Developer
    {
        public int DeveloperID { get; set; }

        [DisplayName("Housing Association/Developer")]
        public string Type { get; set; }

        public virtual ICollection<Household> Households { get; set; }
    }
}
