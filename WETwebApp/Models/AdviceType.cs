using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class AdviceType
    {
        public int AdviceTypeID { get; set; }

        [DisplayName("If yes, where did the advice come from?")]
        public string Type { get; set; }

        public virtual ICollection<Advice> Advice { get; set; }
    }
}
