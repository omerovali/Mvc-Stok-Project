using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities1 db =new MvcDbStokEntities1 ();
        public ActionResult Index( string p)
        {
            var degerler = from d in db.TBLMUSTERI select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler= degerler.Where(m=>m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler= db.TBLMUSTERI.ToList ();
            //return View(degerler);
        }

        [HttpGet]

        public ActionResult MusteriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(TBLMUSTERI p1) 
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }
            db.TBLMUSTERI.Add (p1);
            db.SaveChanges ();
            return View();
        }

        public ActionResult SIL (int id)
        {
            var musteri = db.TBLMUSTERI.Find (id);
            db.TBLMUSTERI.Remove(musteri);
            db.SaveChanges ();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir (int id)
        {
            var mus = db.TBLMUSTERI.Find(id);
            return View("MusteriGetir",mus);
        }

        public ActionResult Guncelle(TBLMUSTERI p1)
        {
            var mus = db.TBLMUSTERI.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges ();
            return RedirectToAction ("Index");  
        }
    }
}