using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class HouseholdInformation
    {
        public int HouseholdInformationID { get; set; }
        public int HouseholdID { get; set; }
        public int ElectricitySupplierTypeID { get; set; }
        public int GasSupplierTypeID { get; set; }
        public int TelevisionSupplierTypeID { get; set; }
        public int HeatingSystemTypeID { get; set; }
        public int HouseholdDescriptionTypeID { get; set; }

        [DisplayName("Internet access at home")]
        public bool InternetAccess { get; set; }

        [DisplayName("Household notes")]
        public string HouseholdNotes { get; set; }

        [DisplayName("Update Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }

        public Household Household { get; set; }
        public ElectricitySupplierType ElectricitySupplierType { get; set; }
        public GasSupplierType GasSupplierType { get; set; }
        public TelevisionSupplierType TelevisionSupplierType { get; set; }
        public HeatingSystemType HeatingSystemType { get; set; }
        public HouseholdDescriptionType HouseholdDescriptionType { get; set; }

    }
}
