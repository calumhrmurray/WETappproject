using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WETwebApp.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public int HouseholdID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        [DisplayName("Preferred Communication")]
        public string Communication { get; set; }
        public string Notes { get; set; }

        [DisplayName("Update Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }

        public virtual Household Household { get; set; }
    }
}