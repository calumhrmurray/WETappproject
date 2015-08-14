using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WETwebApp.Models;

namespace WETwebApp.DAL
{
    public class WETcontext : DbContext
    {
        public WETcontext() : base("WETweb")
        {

        }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Visit> Visits { get; set; }
        public DbSet<VisitType> VisitTypes { get; set; }

        public DbSet<Advisor> Advisors { get; set; }

        public DbSet<Household> Households { get; set; }
        public DbSet<HouseholdType> HouseholdTypes { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public DbSet<Advice> Advice { get; set; }
        public DbSet<AdviceType> AdviceTypes { get; set; }
        public DbSet<Attitude> Attitudes { get; set; }
        public DbSet<Bathroom> Bathrooms { get; set; }
        public DbSet<BathroomType> BathroomTypes { get; set; }
        public DbSet<ElectricitySupplierType> ElectricitySupplierTypes { get; set; }
        public DbSet<GasSupplierType> GasSupplierTypes { get; set; }
        public DbSet<HeatingSystemType> HeatingSystemTypes { get; set; }
        public DbSet<HouseholdInformation> HouseholdInformation { get; set; }
        public DbSet<HouseholdDescriptionType> HouseholdDescriptionTypes { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Occupant> Occupants { get; set; }
        public DbSet<Outdoor> Outdoors { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<TelevisionSupplierType> TelevisionSupplierTypes { get; set; }
        public DbSet<WaterReduction> WaterReductions { get; set; }
        public DbSet<WaterUnderstanding> WaterUnderstanding { get; set; }


    }
}