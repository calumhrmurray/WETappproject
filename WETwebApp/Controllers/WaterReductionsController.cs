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
    public class WaterReductionsController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: WaterReductions
        public ActionResult Index()
        {
            return View(db.WaterReductions.ToList());
        }

        // GET: WaterReductions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterReduction waterReduction = db.WaterReductions.Find(id);
            if (waterReduction == null)
            {
                return HttpNotFound();
            }
            return View(waterReduction);
        }

        // GET: WaterReductions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaterReductions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WaterReductionID,Type")] WaterReduction waterReduction)
        {
            if (ModelState.IsValid)
            {
                db.WaterReductions.Add(waterReduction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(waterReduction);
        }

        // GET: WaterReductions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterReduction waterReduction = db.WaterReductions.Find(id);
            if (waterReduction == null)
            {
                return HttpNotFound();
            }
            return View(waterReduction);
        }

        // POST: WaterReductions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WaterReductionID,Type")] WaterReduction waterReduction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waterReduction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waterReduction);
        }

        // GET: WaterReductions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterReduction waterReduction = db.WaterReductions.Find(id);
            if (waterReduction == null)
            {
                return HttpNotFound();
            }
            return View(waterReduction);
        }

        // POST: WaterReductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WaterReduction waterReduction = db.WaterReductions.Find(id);
            db.WaterReductions.Remove(waterReduction);
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
