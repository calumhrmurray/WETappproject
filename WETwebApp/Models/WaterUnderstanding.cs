using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WETwebApp.Models
{
    public class WaterUnderstanding
    {
        public int WaterUnderstandingID { get; set; }
        public int HouseholdID { get; set; }
        public int WaterReductionID { get; set; }

        [DisplayName("Know who supplies there water")]
        public bool WaterSupplier { get; set; }
        [DisplayName("How much water does you or your familly use every day?")]
        public string FamilyUsage { get; set; }
        [DisplayName("How much water does each person use?")]
        public string IndividualUsage { get; set; }
        [DisplayName("Feel that saving water can help save on bills")]
        public bool SavingBills { get; set; }
        [DisplayName("If important/not important, why?")]
        public string WaterReductionWhy { get; set; }

        [DisplayName("Update Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }

        public virtual WaterReduction WaterReduction { get; set; }
        public virtual Household Household { get; set; }

    }
}