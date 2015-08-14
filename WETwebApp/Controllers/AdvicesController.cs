using System;
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
    public class AdvicesController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: Advices
        public ActionResult Index()
        {
            var advice = db.Advice.Include(a => a.AdviceType).Include(a => a.Household);
            return View(advice.ToList());
        }

        // GET: Advices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advice advice = db.Advice.Find(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return View(advice);
        }

        // GET: Advices/Create
        public ActionResult Create(string id, string returnUrl)
        {
            string searchString = id;

            ViewBag.returnUrl = Request.UrlReferrer.ToString();
            ViewBag.AdviceTypeID = new SelectList(db.AdviceTypes, "AdviceTypeID", "Type");
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber");

            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.HouseholdID = new SelectList(db.Households.Where(s => s.WPnumber.Contains(searchString)), "HouseholdID", "WPnumber");
            }

            return View();
        }

        // POST: Advices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdviceID,HouseholdID,AdviceTypeID,Aware,AdviceComment,AdviceNotes,MessageComment,UpdateDate")] Advice advice, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                db.Advice.Add(advice);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            ViewBag.AdviceTypeID = new SelectList(db.AdviceTypes, "AdviceTypeID", "Type", advice.AdviceTypeID);
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", advice.HouseholdID);
            return View(advice);
        }

        // GET: Advices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advice advice = db.Advice.Find(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdviceTypeID = new SelectList(db.AdviceTypes, "AdviceTypeID", "Type", advice.AdviceTypeID);
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", advice.HouseholdID);
            return View(advice);
        }

        // POST: Advices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdviceID,HouseholdID,AdviceTypeID,Aware,AdviceComment,AdviceNotes,MessageComment,UpdateDate")] Advice advice, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdviceTypeID = new SelectList(db.AdviceTypes, "AdviceTypeID", "Type", advice.AdviceTypeID);
            ViewBag.HouseholdID = new SelectList(db.Households, "HouseholdID", "WPnumber", advice.HouseholdID);
            return View(advice);
        }

        // GET: Advices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advice advice = db.Advice.Find(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return View(advice);
        }

        // POST: Advices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advice advice = db.Advice.Find(id);
            db.Advice.Remove(advice);
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
