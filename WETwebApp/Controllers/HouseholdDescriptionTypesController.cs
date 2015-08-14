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
    public class HouseholdDescriptionTypesController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: HouseholdDescriptionTypes
        public ActionResult Index()
        {
            return View(db.HouseholdDescriptionTypes.ToList());
        }

        // GET: HouseholdDescriptionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdDescriptionType householdDescriptionType = db.HouseholdDescriptionTypes.Find(id);
            if (householdDescriptionType == null)
            {
                return HttpNotFound();
            }
            return View(householdDescriptionType);
        }

        // GET: HouseholdDescriptionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseholdDescriptionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseholdDescriptionTypeID,Type")] HouseholdDescriptionType householdDescriptionType)
        {
            if (ModelState.IsValid)
            {
                db.HouseholdDescriptionTypes.Add(householdDescriptionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(householdDescriptionType);
        }

        // GET: HouseholdDescriptionTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdDescriptionType householdDescriptionType = db.HouseholdDescriptionTypes.Find(id);
            if (householdDescriptionType == null)
            {
                return HttpNotFound();
            }
            return View(householdDescriptionType);
        }

        // POST: HouseholdDescriptionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseholdDescriptionTypeID,Type")] HouseholdDescriptionType householdDescriptionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(householdDescriptionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(householdDescriptionType);
        }

        // GET: HouseholdDescriptionTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdDescriptionType householdDescriptionType = db.HouseholdDescriptionTypes.Find(id);
            if (householdDescriptionType == null)
            {
                return HttpNotFound();
            }
            return View(householdDescriptionType);
        }

        // POST: HouseholdDescriptionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseholdDescriptionType householdDescriptionType = db.HouseholdDescriptionTypes.Find(id);
            db.HouseholdDescriptionTypes.Remove(householdDescriptionType);
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
