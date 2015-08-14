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
    public class AdviceTypesController : Controller
    {
        private WETcontext db = new WETcontext();

        // GET: AdviceTypes
        public ActionResult Index()
        {
            return View(db.AdviceTypes.ToList());
        }

        // GET: AdviceTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviceType adviceType = db.AdviceTypes.Find(id);
            if (adviceType == null)
            {
                return HttpNotFound();
            }
            return View(adviceType);
        }

        // GET: AdviceTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdviceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdviceTypeID,Type")] AdviceType adviceType)
        {
            if (ModelState.IsValid)
            {
                db.AdviceTypes.Add(adviceType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adviceType);
        }

        // GET: AdviceTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviceType adviceType = db.AdviceTypes.Find(id);
            if (adviceType == null)
            {
                return HttpNotFound();
            }
            return View(adviceType);
        }

        // POST: AdviceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdviceTypeID,Type")] AdviceType adviceType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adviceType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adviceType);
        }

        // GET: AdviceTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdviceType adviceType = db.AdviceTypes.Find(id);
            if (adviceType == null)
            {
                return HttpNotFound();
            }
            return View(adviceType);
        }

        // POST: AdviceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdviceType adviceType = db.AdviceTypes.Find(id);
            db.AdviceTypes.Remove(adviceType);
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
