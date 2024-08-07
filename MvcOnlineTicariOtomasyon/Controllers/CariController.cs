using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context cntxContext = new Context();
        public ActionResult Index()
        {
            var degList = cntxContext.Musteris.Where(x => x.Durum == true).ToList();
            return View(degList);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Musteri p)
        {
            p.Durum = true;
            cntxContext.Musteris.Add(p);
            cntxContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = cntxContext.Musteris.Find(id);
            cr.Durum = false;
            cntxContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = cntxContext.Musteris.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Musteri m)
        {
            if (!ModelState.IsValid)//modelstatenin güncellemesi yani veri taanındaki kısıtlama geçerli değilse
            {
                return View("CariGetir");
            }
            var mg = cntxContext.Musteris.Find(m.MusteriID);
            mg.MusteriAdi = m.MusteriAdi;
            mg.MusteriSoyAdi = m.MusteriSoyAdi;
            mg.MusteriMail = m.MusteriMail;
            mg.CariSehir=m.CariSehir;
            mg.Telno = m.Telno;
            cntxContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = cntxContext.SatisHarekets.Where(x => x.Musteriid == id).ToList();
            var cr = cntxContext.Musteris.Where(x => x.MusteriID == id).Select(y => y.MusteriAdi + " " + y.MusteriSoyAdi).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}