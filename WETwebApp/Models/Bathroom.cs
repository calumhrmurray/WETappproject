using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class Bathroom
    {
        public int BathroomID { get; set; }
        public int HouseholdID { get; set; }
        public int BathroomTypeID { get; set; }

        [DisplayName("Number of bathrooms")]
        public int BathroomQuantity { get; set; }

        [DisplayName("Number of toilets")]
        public int ToiletQuantity { get; set; }
        [DisplayName("Number of single flush toilets")]
        public int SingleToiletQuantity { get; set; }
        [DisplayName("Number of dual flush toilets")]
        public int DualToiletQuantity { get; set; }
        
        // Showers
        [DisplayName("Electric Shower")]
        public bool Electric { get; set; }
        [DisplayName("Power Shower")]
        public bool Power { get; set; }
        [DisplayName("Mixer Shower")]
        public bool Mixer { get; set; }
        [DisplayName("Unknown Shower")]
        public bool Unknown { get; set; }

        // Taps
        public bool Round { get; set; }
        public bool Threaded { get; set; }
        [DisplayName("Non-threaded")]
        public bool NonThreaded { get; set; }
        [DisplayName("Other or unknown")]
        public bool Other { get; set; }

        [DisplayName("Update Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }

        public virtual Household Household { get; set; }
        public virtual BathroomType BathroomType { get; set; }
    }
}
