using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class VisitType
    {
        public int VisitTypeID { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}
