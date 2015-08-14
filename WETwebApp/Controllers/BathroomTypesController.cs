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
    public class BathroomTypesController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: BathroomTypes
        public ActionResult Index()
        {
            return View(db.BathroomTypes.ToList());
        }

        // GET: BathroomTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BathroomType bathroomType = db.BathroomTypes.Find(id);
            if (bathroomType == null)
            {
                return HttpNotFound();
            }
            return View(bathroomType);
        }

        // GET: BathroomTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BathroomTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BathroomTypeID,Type")] BathroomType bathroomType)
        {
            if (ModelState.IsValid)
            {
                db.BathroomTypes.Add(bathroomType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bathroomType);
        }

        // GET: BathroomTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BathroomType bathroomType = db.BathroomTypes.Find(id);
            if (bathroomType == null)
            {
                return HttpNotFound();
            }
            return View(bathroomType);
        }

        // POST: BathroomTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BathroomTypeID,Type")] BathroomType bathroomType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bathroomType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bathroomType);
        }

        // GET: BathroomTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BathroomType bathroomType = db.BathroomTypes.Find(id);
            if (bathroomType == null)
            {
                return HttpNotFound();
            }
            return View(bathroomType);
        }

        // POST: BathroomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BathroomType bathroomType = db.BathroomTypes.Find(id);
            db.BathroomTypes.Remove(bathroomType);
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
