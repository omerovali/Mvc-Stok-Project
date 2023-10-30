using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcStok.Models.Entity;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis

        MvcDbStokEntities1 db = new MvcDbStokEntities1 ();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p) 
        { 
            db.TBLSATISLAR.Add (p);
            db.SaveChanges();
            return View("Index");

        }
    }
}