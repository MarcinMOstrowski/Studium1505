using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liczniki.Controllers
{
    public class LicznikiController : Controller
    {
        private LicznikiDbEntities _db = new LicznikiDbEntities();
        // GET: Liczniki
        public ActionResult Index()
        {
            return View(_db.Licznik.ToList());
        }

        // GET: Liczniki/Details/5
        public ActionResult Details(int id)
        {
            var licznikiDetails = (from m in _db.Licznik where m.Id == id select m).First();
            return View(licznikiDetails);
        }

        // GET: Liczniki/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Liczniki/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Licznik licznikToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    return View();
                _db.Licznik.Add(licznikToCreate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Liczniki/Edit/5
        public ActionResult Edit(int id)
        {
            var licznikToEdit = (from m in _db.Licznik
                                 where m.Id == id
                                 select m).First();
            return View(licznikToEdit);
        }

        // POST: Liczniki/Edit/5
        [HttpPost]
        public ActionResult Edit(Licznik licznikToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalLicznik = (from m in _db.Licznik
                                       where m.Id == licznikToEdit.Id
                                       select m).First();
                if (!ModelState.IsValid)
                    return View(originalLicznik);
                _db.Entry(originalLicznik).CurrentValues.SetValues(licznikToEdit);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Liczniki/Delete/5
        public ActionResult Delete(int id)
        {
            var licznikToDelete = (from m in _db.Licznik
                                   where m.Id == id
                                   select m).First();
            return View(licznikToDelete);
        }

        // POST: Liczniki/Delete/5
        [HttpPost]
        public ActionResult Delete(Licznik licznikToDelete)
        {
            try
            {
                // TODO: Add delete logic here
                var originalLicznik = _db.Licznik.Find(licznikToDelete.Id);
                if (originalLicznik != null)
                    _db.Licznik.Remove(originalLicznik);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
