using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WETwebApp.DAL;
using WETwebApp.Models;
using WETwebApp.ViewModels;
using PagedList;


namespace WETwebApp.Controllers
{
    public class NavigationController : Controller
    {

        private WETcontext db = new WETcontext();

        // GET: Navigation
        public ActionResult Index()
        {
            return View();
        }

        /*searchWPnumber, searchArea, searchBatch filter the results. */
        public ActionResult Management( string searchWPnumber,
                                       string searchArea, string searchBatch, int? page, string id)
        {
            string interaction = id;
            

            // the following create the lists used by the dropdown filters
            var AreaLst = new List<string>();

            var AreaQry = from d in db.Households
                          orderby d.HESarea
                          select d.HESarea;

            AreaLst.AddRange(AreaQry.Distinct());
            ViewBag.searchArea = new SelectList(AreaLst);

            var BatchLst = new List<string>();

            var BatchQry = from d in db.Households
                           orderby d.HESbatch
                           select d.HESbatch;

            BatchLst.AddRange(BatchQry.Distinct());
            ViewBag.searchBatch = new SelectList(BatchLst);

            //creates the unfiltered management data - those where interactions have taken place recently 
            // are at the bottom of the list
            var management = (from v in db.Visits
                             group v by v.HouseholdID into grp
                             select new ManagementViewModel()
                             {
                                 WPnumber = grp.FirstOrDefault().Household.WPnumber,
                                 LatestVisit = grp.Where(c=>c.Complete).OrderByDescending(u=>u.VisitDate).FirstOrDefault().VisitType.Type,
                                 VisitComplete = grp.FirstOrDefault().Complete, //this bit doesn't work at the moment
                                 VisitDate = grp.Where(c => c.Complete).OrderByDescending(u => u.VisitDate).FirstOrDefault().VisitDate,
                                 HESarea = grp.FirstOrDefault().Household.HESarea,
                                 HESbatch = grp.FirstOrDefault().Household.HESbatch,
                                 MonitorStatus = grp.FirstOrDefault().Household.MonitorStatus
                             }).OrderBy(u => u.VisitDate);

            if(!String.IsNullOrEmpty(searchWPnumber))
            {
                management = management.Where(h => h.WPnumber == searchWPnumber).OrderBy(v=>v.VisitDate);
            }

            if(!String.IsNullOrEmpty(searchArea))
            {
                management = management.Where(h => h.HESarea == searchArea).OrderBy(v => v.VisitDate);
            }

            if(!String.IsNullOrEmpty(searchBatch))
            {
                management = management.Where(h => h.HESbatch == searchBatch).OrderBy(v => v.VisitDate);
            }

            // if a visit has been completed then it is removed from this list- needs to be redone
            // just added as an example of needed functionality
            if(!String.IsNullOrEmpty(interaction))
            {
                if (interaction == "Current")
                {
                  management = management.Where(h => h.VisitComplete == false).OrderBy(v => v.VisitDate);
                };

            }

            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(management.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Bookings(string id)
        {
            string searchString = id;

            BookingViewModel bookings = new BookingViewModel()
            {

            };

            if (!String.IsNullOrEmpty(searchString))
            {
                bookings = new BookingViewModel()
                               {
                                   Households = db.Households.Where(h => h.WPnumber.Contains(searchString))
                                                             .ToList(),
                                   Visits = db.Visits.Where(v=> v.Household.WPnumber.Contains(searchString))
                                                     .ToList(),
                                   Bookings = db.Bookings.Where(b=>b.Visit.Household.WPnumber.Contains(searchString))
                                                         .ToList(),
                                   Persons = db.Persons.Where(p=>p.Household.WPnumber.Contains(searchString))
                                                        .OrderByDescending(u=>u.UpdateDate).Take(1).ToList()
                               };
            }

            ViewBag.WPnumber = searchString;

            return View(bookings);
        }

        public ActionResult Survey(string id)
        {
            string searchString = id;


            var surveys = (from h in db.Households
                          select new SurveyViewModel()
            {
                Advice = h.Advice.ToList(),
                Attitude = h.Attitudes.ToList(),
                Bathroom = h.Bathrooms.ToList(),
                HouseholdInformation = h.HouseholdInformation.ToList(),
                Kitchen = h.Kitchens.ToList(),
                Occupant = h.Occupants.ToList(),
                Outdoor = h.Outdoors.ToList(),
                Person = h.Persons.ToList(),
                WaterUnderstanding = h.WaterUnderstandings.ToList(),
                Household = db.Households.ToList()
            }).FirstOrDefault();

            // takes the most recent record for the household corresponding to WPnumber == searchString
            if (!String.IsNullOrEmpty(searchString))
            {

            
                  surveys = (from h in db.Households
                            where h.WPnumber == searchString
                            select new SurveyViewModel()
                {
                    Advice = h.Advice.OrderByDescending(a=>a.UpdateDate).Take(1).ToList(),
                    Attitude = h.Attitudes.OrderByDescending(a => a.UpdateDate).Take(1).ToList(),
                    Bathroom = h.Bathrooms.OrderByDescending(a => a.UpdateDate).Take(1).ToList(),
                    HouseholdInformation = h.HouseholdInformation.OrderByDescending(a => a.UpdateDate).Take(1).ToList(),
                    Kitchen = h.Kitchens.OrderByDescending(a => a.UpdateDate).Take(1).ToList(),
                    Occupant = h.Occupants.OrderByDescending(a => a.UpdateDate).Take(1).ToList(),
                    Outdoor = h.Outdoors.OrderByDescending(a=>a.UpdateDate).Take(1).ToList(),
                    Person = h.Persons.OrderByDescending(a => a.UpdateDate).Take(1).ToList(),
                    WaterUnderstanding = h.WaterUnderstandings.OrderByDescending(a => a.UpdateDate).Take(1).ToList(),
                    Household = db.Households.Where(v => v.WPnumber.Contains(searchString)).Take(1).ToList()
                }).FirstOrDefault();
            }

            //Data checks
            //Garden check
            if (surveys.Outdoor != null && surveys.Outdoor.Count()>0)
            { 
                    if (!(surveys.Outdoor.OrderByDescending(a => a.UpdateDate).FirstOrDefault().Garden) && (surveys.Attitude.OrderByDescending(a => a.UpdateDate).FirstOrDefault().WaterCan || surveys.Attitude.OrderByDescending(a => a.UpdateDate).FirstOrDefault().WaterButt || surveys.Attitude.OrderByDescending(a => a.UpdateDate).FirstOrDefault().NoHosepipe || surveys.Attitude.OrderByDescending(a => a.UpdateDate).FirstOrDefault().NoWaterLawn))
                        {
                            ViewBag.GardenError = "Garden not selected.";
                        }
            }
            //Occupant check
            if (surveys.Occupant != null && surveys.Occupant.Count()>0)
            {
                int NumberOfOccupants =  (surveys.Occupant.FirstOrDefault().MaleQuantity
                                         + surveys.Occupant.FirstOrDefault().FemaleQuantity
                                         + surveys.Occupant.FirstOrDefault().ChildQuantity);
                int NumberOfDemographics =  (surveys.Occupant.FirstOrDefault().SelfEmployed
                                              + surveys.Occupant.FirstOrDefault().EmployedFull
                                              + surveys.Occupant.FirstOrDefault().EmployedPart
                                              + surveys.Occupant.FirstOrDefault().Home
                                              + surveys.Occupant.FirstOrDefault().Retired
                                              + surveys.Occupant.FirstOrDefault().Unemployed
                                              + surveys.Occupant.FirstOrDefault().School
                                              + surveys.Occupant.FirstOrDefault().Further
                                              + surveys.Occupant.FirstOrDefault().GovWork
                                              + surveys.Occupant.FirstOrDefault().PreSchool
                                              + surveys.Occupant.FirstOrDefault().Other);
                   
                if (!(NumberOfOccupants==NumberOfDemographics))
                {
                    ViewBag.OccupantError = "Demographic and occupant numbers are not equal.";
                }

            }
            // Toilet check
            if (surveys.Bathroom != null && surveys.Bathroom.Count()>0)
            {

                if (!(surveys.Bathroom.FirstOrDefault().ToiletQuantity == 
                    surveys.Bathroom.FirstOrDefault().SingleToiletQuantity
                    + surveys.Bathroom.FirstOrDefault().DualToiletQuantity))
                {
                    ViewBag.ToiletError = "The number of toilets does not equal the number of dual/single flush toilets.";
                }
            }
                


            // Household description check 
            // this part of the view is not working at the moment so I have left this for just now
            // the complete logic exists in MS access
     /*       if (surveys.HouseholdInformation !=null && surveys.HouseholdInformation.Count()>0)
            {
                int Adults = (surveys.Occupant.FirstOrDefault().MaleQuantity + surveys.Occupant.FirstOrDefault().FemaleQuantity);
                int Children = surveys.Occupant.FirstOrDefault().ChildQuantity;

                if (surveys.HouseholdInformation.FirstOrDefault().HouseholdDescriptionType.Type == "Couple, depen")
               
            }
      */
     
         


            return View(surveys);   
        }

        public ActionResult Visits(string searchAdvisor, string searchArea, string searchBatch, string id, int? page)
        {
            string searchString = id;
            ViewBag.searchString = id;            
            DateTime currentDate = System.DateTime.Now.Date;

            var AreaLst = new List<string>();

            var AreaQry = from d in db.Households
                          orderby d.HESarea
                          select d.HESarea;

            AreaLst.AddRange(AreaQry.Distinct());
            ViewBag.searchArea = new SelectList(AreaLst);

            var BatchLst = new List<string>();

            var BatchQry = from d in db.Households
                           orderby d.HESbatch
                           select d.HESbatch;

            BatchLst.AddRange(BatchQry.Distinct());
            ViewBag.searchBatch = new SelectList(BatchLst);

            var AdvisorLst = new List<string>();

            var AdvisorQry = from d in db.Advisors
                             orderby d.FirstName
                             select d.FirstName;

            AdvisorLst.AddRange(AdvisorQry.Distinct());
            ViewBag.searchAdvisor = new SelectList(AdvisorLst);

            var bookings = from  b in db.Bookings
                               select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString == "Upcoming")
                {
                    bookings = bookings.Where(b => b.BookedVisitDate >= currentDate && !b.Visit.Complete);
                }
                else if (searchString == "Past")
                {
                    bookings = bookings.Where(b => currentDate >= b.BookedVisitDate && !b.Visit.Complete);
                }
                else if (searchString == "Completed")
                {
                    bookings = bookings.Where(b => b.Visit.Complete);
                }
            };

            if (!String.IsNullOrEmpty(searchAdvisor))
            {
                bookings = bookings.Where(b => b.Advisor.FirstName == searchAdvisor);
            };

            if (!String.IsNullOrEmpty(searchArea))
            {
                bookings = bookings.Where(b => b.Visit.Household.HESarea == searchArea);
            };

            if (!String.IsNullOrEmpty(searchBatch))
            {
                bookings = bookings.Where(b => b.Visit.Household.HESbatch == searchBatch);
            };

            int pageSize = 3;
            int pageNumber = (page ?? 1);

             return View(bookings.OrderBy(v=>v.BookingDate).ToPagedList(pageNumber, pageSize));
        }


    }
}