using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WETwebApp.Models
{
    public class Visit
    {
        public int VisitID { get; set; }
        public int HouseholdID { get; set; }
        public int VisitTypeID { get; set; }

        public bool Complete { get; set; }
        [DisplayName("Date of visit")]
        public DateTime? VisitDate { get; set; }

        public virtual Household Household { get; set; }
        public virtual VisitType VisitType { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}