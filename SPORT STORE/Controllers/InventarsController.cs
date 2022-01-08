using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SPORT_STORE.DAL;
using SPORT_STORE.Models;

namespace SPORT_STORE.Controllers
{
    [Authorize(Roles ="Admin")]
    public class InventarsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Inventars
        public ActionResult Index()
        {
            return View(db.Inventars.ToList());
        }

        // GET: Inventars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventar inventar = db.Inventars.Find(id);
            if (inventar == null)
            {
                return HttpNotFound();
            }
            return View(inventar);
        }

        // GET: Inventars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Sasia")] Inventar inventar)
        {
            if (ModelState.IsValid)
            {
                db.Inventars.Add(inventar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventar);
        }

        // GET: Inventars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventar inventar = db.Inventars.Find(id);
            if (inventar == null)
            {
                return HttpNotFound();
            }
            return View(inventar);
        }

        // POST: Inventars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Sasia")] Inventar inventar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventar);
        }

        // GET: Inventars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventar inventar = db.Inventars.Find(id);
            if (inventar == null)
            {
                return HttpNotFound();
            }
            return View(inventar);
        }

        // POST: Inventars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventar inventar = db.Inventars.Find(id);
            db.Inventars.Remove(inventar);
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
