﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WETwebApp.DAL;
using WETwebApp.Models;

namespace WETwebApp.Controllers
{
    public class BookingsController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Advisor).Include(b => b.Visit);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create(string id)
        {
            string searchString = id;

            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "FirstName");
            ViewBag.VisitID = new SelectList(db.Visits, "VisitID", "VisitID");

            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.VisitID = new SelectList(db.Visits.Where(s=>s.Household.WPnumber.Contains(searchString)),"VisitID","VisitType.Type");
            }

            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,VisitID,AdvisorID,BookingDate,BookedVisitDate,AttemptNumber")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Edit", "Visits", new { id = booking.VisitID });
            }

            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "FirstName", booking.AdvisorID);
            ViewBag.VisitID = new SelectList(db.Visits, "VisitID", "VisitID", booking.VisitID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id, string WPnumber)
        {
            string searchString = WPnumber;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "FirstName", booking.AdvisorID);
            ViewBag.VisitID = new SelectList(db.Visits, "VisitID", "VisitType.Type", booking.VisitID);
          
            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.VisitID = new SelectList(db.Visits.Where(s=>s.Household.WPnumber.Contains(searchString)),"VisitID","VisitType.Type");
            }

            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,VisitID,AdvisorID,BookingDate,BookedVisitDate,AttemptNumber")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "FirstName", booking.AdvisorID);
            ViewBag.VisitID = new SelectList(db.Visits, "VisitID", "VisitID", booking.VisitID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
