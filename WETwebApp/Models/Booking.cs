using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int VisitID { get; set; }
        public int AdvisorID { get; set; }

        [DisplayName("Date of booking")]
        public DateTime BookingDate { get; set; }
        [DisplayName("Date booked for visit")]
    /*    [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] */
        public DateTime? BookedVisitDate { get; set; }
        public int AttemptNumber { get; set; }

        public virtual Visit Visit { get; set; }
        public virtual Advisor Advisor { get; set; }
    }
}
