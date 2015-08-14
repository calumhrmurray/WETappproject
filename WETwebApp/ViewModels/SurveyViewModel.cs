using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WETwebApp.Models;

namespace WETwebApp.ViewModels
{
    public class SurveyViewModel
    {
        public List<Household> Household { get; set; }
        public List<Person> Person { get; set; }
        public List<Advice> Advice { get; set; }
        public List<Attitude> Attitude { get; set; }
        public List<Bathroom> Bathroom { get; set; }
        public List<HouseholdInformation> HouseholdInformation { get; set; }
        public List<Kitchen> Kitchen { get; set; }
        public List<Occupant> Occupant { get; set; }
        public List<Outdoor> Outdoor { get; set; }
        public List<WaterUnderstanding> WaterUnderstanding { get; set; }
    }
}