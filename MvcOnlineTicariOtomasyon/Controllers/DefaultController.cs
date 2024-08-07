using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }

        public ActionResult Sil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult Index3()
        {
            var deger2 = (from p in c.Personels
                          group p by p.PersonelAd into g
                          select new GrupSinifi2
                          {
                              Gorev = g.Key,
                              Sayi = g.Count()
                          }).ToList();
            return PartialView(deger2);
        }

        public PartialViewResult deneme()
        {
            //var sorgu = from x in c.Carilers
            //            group x by x.CariSehir into g
            //            select new Class2
            //            {
            //                sehir = g.Key,
            //                sayi = g.Count()
            //            };
            return PartialView();
        }
    }
}