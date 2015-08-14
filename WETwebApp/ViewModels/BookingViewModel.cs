using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WETwebApp.Models;

namespace WETwebApp.ViewModels
{
    public class BookingViewModel
    {
        public List<Household> Households { get; set; }
        public List<Person> Persons { get; set; }
        public List<Visit> Visits { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}