using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MeteoritesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Meteorites
        public ActionResult Index()
        {
            return View(db.Meteorites.ToList());
        }

        // GET: Meteorites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meteorite meteorite = db.Meteorites.Find(id);
            if (meteorite == null)
            {
                return HttpNotFound();
            }
            return View(meteorite);
        }

        // GET: Meteorites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meteorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeteoriteID,Mass,Name,FellDate,Latitude,Longitude,CreationDate,AddID")] Meteorite meteorite)
        {
            if (ModelState.IsValid)
            {
                db.Meteorites.Add(meteorite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meteorite);
        }

        // GET: Meteorites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meteorite meteorite = db.Meteorites.Find(id);
            if (meteorite == null)
            {
                return HttpNotFound();
            }
            return View(meteorite);
        }

        // POST: Meteorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeteoriteID,Mass,Name,FellDate,Latitude,Longitude,CreationDate,AddID")] Meteorite meteorite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meteorite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meteorite);
        }

        // GET: Meteorites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meteorite meteorite = db.Meteorites.Find(id);
            if (meteorite == null)
            {
                return HttpNotFound();
            }
            return View(meteorite);
        }

        // POST: Meteorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meteorite meteorite = db.Meteorites.Find(id);
            db.Meteorites.Remove(meteorite);
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
