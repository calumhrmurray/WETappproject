using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class Outdoor
    {
        public int OutdoorID { get; set; }
        public int HouseholdID { get; set; }

        public bool Garden { get; set; }
        public bool Car { get; set; }
        [DisplayName("Use water in the garden")]
        public bool WaterGarden { get; set; }
        [DisplayName("Wash car at home")]
        public bool WashCar { get; set; }

        [DisplayName("Update Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }

        public virtual Household Household { get; set; }

    }
}
