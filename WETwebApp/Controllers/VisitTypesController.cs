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
    public class VisitTypesController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: VisitTypes
        public ActionResult Index()
        {
            return View(db.VisitTypes.ToList());
        }

        // GET: VisitTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitType visitType = db.VisitTypes.Find(id);
            if (visitType == null)
            {
                return HttpNotFound();
            }
            return View(visitType);
        }

        // GET: VisitTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisitTypeID,Type")] VisitType visitType)
        {
            if (ModelState.IsValid)
            {
                db.VisitTypes.Add(visitType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visitType);
        }

        // GET: VisitTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitType visitType = db.VisitTypes.Find(id);
            if (visitType == null)
            {
                return HttpNotFound();
            }
            return View(visitType);
        }

        // POST: VisitTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitTypeID,Type")] VisitType visitType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visitType);
        }

        // GET: VisitTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitType visitType = db.VisitTypes.Find(id);
            if (visitType == null)
            {
                return HttpNotFound();
            }
            return View(visitType);
        }

        // POST: VisitTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitType visitType = db.VisitTypes.Find(id);
            db.VisitTypes.Remove(visitType);
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
