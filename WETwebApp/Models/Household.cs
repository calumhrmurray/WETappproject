using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class Household
    {
        public int HouseholdID { get; set; }
        public int HouseholdTypeID { get; set; }
        public int DeveloperID { get; set; }

        [DisplayName("WP number")]
        public string WPnumber { get; set; }
        [DisplayName("Address")]
        public string Address1 { get; set; }
        [DisplayName("   ")]
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        [DisplayName("HES area")]
        public string HESarea { get; set; }
        [DisplayName("HES batch")]
        public string HESbatch { get; set; }

        [DisplayName("Monitor Status")]
        public string MonitorStatus { get; set; }
        [DisplayName("First Reading")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FirstReading { get; set; }

        public virtual HouseholdType HouseholdType { get; set; }
        public virtual Developer Developer { get; set; }

        public ICollection<Visit> Visits { get; set; }

        public ICollection<Attitude> Attitudes { get; set; }
        public ICollection<Person> Persons { get; set; }
        public ICollection<Occupant> Occupants { get; set; }
        public ICollection<HouseholdInformation> HouseholdInformation { get; set; }
        public ICollection<Bathroom> Bathrooms { get; set; }
        public ICollection<Kitchen> Kitchens { get; set; }
        public ICollection<Outdoor> Outdoors { get; set; }
        public ICollection<WaterReduction> WaterReductions { get; set; }
        public ICollection<WaterUnderstanding> WaterUnderstandings { get; set; }
        public ICollection<Advice> Advice { get; set; }

    }
}
