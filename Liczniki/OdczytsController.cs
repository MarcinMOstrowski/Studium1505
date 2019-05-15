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
    public class OdczytsController : Controller
    {
        private LicznikiDbEntities db = new LicznikiDbEntities();

        // GET: Odczyts
        public ActionResult Index()
        {
            var odczyt = db.Odczyt.Include(o => o.Licznik);
            return View(odczyt.ToList());
        }

        // GET: Odczyts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odczyt odczyt = db.Odczyt.Find(id);
            if (odczyt == null)
            {
                return HttpNotFound();
            }
            return View(odczyt);
        }

        // GET: Odczyts/Create
        public ActionResult Create()
        {
            ViewBag.LicznikId = new SelectList(db.Licznik, "Id", "NrLicznika");
            return View();
        }

        // POST: Odczyts/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LicznikId,StanPoczatkowy,StanKoncowy,Zuzycie,DataOdczytu,CenaM3")] Odczyt odczyt)
        {
            if (ModelState.IsValid)
            {
                db.Odczyt.Add(odczyt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LicznikId = new SelectList(db.Licznik, "Id", "NrLicznika", odczyt.LicznikId);
            return View(odczyt);
        }

        // GET: Odczyts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odczyt odczyt = db.Odczyt.Find(id);
            if (odczyt == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicznikId = new SelectList(db.Licznik, "Id", "NrLicznika", odczyt.LicznikId);
            return View(odczyt);
        }

        // POST: Odczyts/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LicznikId,StanPoczatkowy,StanKoncowy,Zuzycie,DataOdczytu,CenaM3")] Odczyt odczyt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(odczyt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LicznikId = new SelectList(db.Licznik, "Id", "NrLicznika", odczyt.LicznikId);
            return View(odczyt);
        }

        // GET: Odczyts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odczyt odczyt = db.Odczyt.Find(id);
            if (odczyt == null)
            {
                return HttpNotFound();
            }
            return View(odczyt);
        }

        // POST: Odczyts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Odczyt odczyt = db.Odczyt.Find(id);
            db.Odczyt.Remove(odczyt);
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
