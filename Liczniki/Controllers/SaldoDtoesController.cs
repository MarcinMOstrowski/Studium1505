using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Liczniki;
using Liczniki.Models;

namespace Liczniki.Controllers
{
    public class SaldoDtoesController : Controller
    {
        private LicznikiDbEntities db = new LicznikiDbEntities();

        // GET: SaldoDtoes
        public ActionResult Index()
        {
            return View(db.SaldoDtoes.ToList());
        }

        // GET: SaldoDtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var licznik = db.Licznik.Find(id);
            string nrLicznika = licznik.NrLicznika;
            var OperacjeLicznika = db.WykazOperacji.Where(o => o.NrLicznika == nrLicznika).ToList();
            var WplatyLicznika = db.WykazOperacji.Where(o => o.NrLicznika == nrLicznika).OrderBy(c=> c.DataOperacji);
            var OdczytyLicznika = db.WykazOperacji.Where(o => o.NrLicznika == nrLicznika);
            var ostatniaOperacja = OperacjeLicznika[0];
            //SaldoDto saldoDto = db.SaldoDtoes.Find(id);
            //if (saldoDto == null)
            //{
            //    return HttpNotFound();
            //}
            var saldoDto = new SaldoDto() { NrLicznika = nrLicznika, DataOperacji=ostatniaOperacja.DataOperacji, Odczyt = ostatniaOperacja.ObciazenieSuma, Wplata=ostatniaOperacja.UznanieSuma, StanSalda=ostatniaOperacja.Saldo };
            return View(saldoDto);
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
