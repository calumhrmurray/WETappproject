using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class Advice
    {
        public int AdviceID { get; set; }
        public int HouseholdID { get; set; }
        public int AdviceTypeID { get; set; }
        
        [DisplayName("Aware of publicity on energy/water advice recently?")]
        public bool Aware { get; set; }        
        [DisplayName("Notes")]
        public string AdviceComment { get; set; }
        [DisplayName("Notes on where the advice came from")]
        public string AdviceNotes { get; set; }
        [DisplayName("Main message from the advertising or publicity")]
        public string MessageComment { get; set; }

        [DisplayName("Update Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true )]
        public DateTime UpdateDate { get; set; }

        public virtual Household Household { get; set; }
        public virtual AdviceType AdviceType { get; set; }
    }
}
