using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class Kitchen
    {
        public int KitchenID { get; set; }
        public int HouseholdID { get; set; }

        [DisplayName("Washing Machine")]
        public bool WashingMachine { get; set; }
        public bool Dishwasher { get; set; }

        [DisplayName("Update Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }

        public virtual Household Household { get; set; }
    }
}
