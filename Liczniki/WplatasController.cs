using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Liczniki
{
    public class WplatasController : Controller
    {
        private LicznikiDbEntities db = new LicznikiDbEntities();

        // GET: Wplatas
        public ActionResult Index()
        {
            var wplata = db.Wplata.Include(w => w.Licznik);
            return View(wplata.ToList());
        }

        // GET: Wplatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wplata wplata = db.Wplata.Find(id);
            if (wplata == null)
            {
                return HttpNotFound();
            }
            return View(wplata);
        }

        // GET: Wplatas/Create
        public ActionResult Create()
        {
            ViewBag.LicznikId = new SelectList(db.Licznik, "Id", "NrLicznika");
            return View();
        }

        // POST: Wplatas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LicznikId,DataWplaty,Wartosc")] Wplata wplata)
        {
            if (ModelState.IsValid)
            {
                db.Wplata.Add(wplata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LicznikId = new SelectList(db.Licznik, "Id", "NrLicznika", wplata.LicznikId);
            return View(wplata);
        }

        // GET: Wplatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wplata wplata = db.Wplata.Find(id);
            if (wplata == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicznikId = new SelectList(db.Licznik, "Id", "NrLicznika", wplata.LicznikId);
            return View(wplata);
        }

        // POST: Wplatas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LicznikId,DataWplaty,Wartosc")] Wplata wplata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wplata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LicznikId = new SelectList(db.Licznik, "Id", "NrLicznika", wplata.LicznikId);
            return View(wplata);
        }

        // GET: Wplatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wplata wplata = db.Wplata.Find(id);
            if (wplata == null)
            {
                return HttpNotFound();
            }
            return View(wplata);
        }

        // POST: Wplatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wplata wplata = db.Wplata.Find(id);
            db.Wplata.Remove(wplata);
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
