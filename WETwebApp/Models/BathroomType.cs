using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class BathroomType
    {
        public int BathroomTypeID { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Bathroom> Bathrooms { get; set; }
    }
}
