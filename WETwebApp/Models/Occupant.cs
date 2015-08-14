using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class Occupant
    {
        public int OccupantID { get; set; }
        public int HouseholdID { get; set; }

        [DisplayName("Number of male adults")]
        public int MaleQuantity { get; set; }
        [DisplayName("Number of female adults")]
        public int FemaleQuantity { get; set; }
        [DisplayName("Number of children")]
        public int ChildQuantity { get; set; }

        [DisplayName("Occupant notes")]
        public string OccupantNotes { get; set; }

        [DisplayName("Self employed")]
        public int SelfEmployed { get; set; }
        [DisplayName("Employed full time")]
        public int EmployedFull { get; set; }
        [DisplayName("Employed part time")]
        public int EmployedPart { get; set; }
        [DisplayName("Looking after home or family")]
        public int Home { get; set; }
        [DisplayName("Retired")]
        public int Retired { get; set; }
        [DisplayName("Unemployed or seeking work")]
        public int Unemployed { get; set; }
        [DisplayName("At school")]
        public int School { get; set; }
        [DisplayName("Further/Higher education")]
        public int Further { get; set; }
        [DisplayName("Government work/Training scheme")]
        public int GovWork { get; set; }
        [DisplayName("Pre-school/Not yet at school")]
        public int PreSchool { get; set; }
        [DisplayName("Other demographics")]
        public int Other { get; set; }

        [DisplayName("Demographic notes")]
        public string DemographicNotes { get; set; }

        [DisplayName("Number of bedrooms")]
        public int BedroomQuantity { get; set; }
 
        [DisplayName("Update Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }

        public virtual Household Household { get; set; }
    }
}
