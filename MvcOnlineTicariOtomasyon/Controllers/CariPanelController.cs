using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["MusteriMail"];
            var degerler = c.mesajlars.Where(x => x.Alici == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Musteris.Where(x => x.MusteriMail == mail).Select(y => y.MusteriID).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis = c.SatisHarekets.Count(x => x.Musteriid == mailid);
            ViewBag.toplamsatis = toplamsatis;
            var toplamtutar = c.SatisHarekets.Where(x => x.Musteriid == mailid).Sum(y => y.Tutar);
            ViewBag.toplamtutar = toplamtutar;
            var toplamurunsayisi = c.SatisHarekets.Where(x => x.Musteriid == mailid).Sum(y => y.Adet);
            ViewBag.toplamurunsayisi = toplamurunsayisi;
            var adsoyad = c.Musteris.Where(x => x.MusteriMail == mail).Select(y => y.MusteriAdi + " " + y.MusteriSoyAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["MusteriMail"];
            var id = c.Musteris.Where(x => x.MusteriMail == mail.ToString()).Select(y => y.MusteriID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.Musteriid == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["MusteriMail"];
            var mesajlar = c.mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["MusteriMail"];
            var mesajlar = c.mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(z => z.MesajID).ToList();
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["MusteriMail"];
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["MusteriMail"];
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(mesajlar m)
        {
            var mail = (string)Session["MusteriMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            c.mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.KargoDetays select x;
            k = k.Where(y => y.TakipKodu.Contains(p));
            return View(k.ToList());
        }
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["MusteriMail"];
            var id = c.Musteris.Where(x => x.MusteriMail == mail).Select(y => y.MusteriID).FirstOrDefault();
            var caribul = c.Musteris.Find(id);
            return PartialView("Partial1", caribul);
        }
        public PartialViewResult Partial2()
        {
            var veriler = c.mesajlars.Where(x => x.Gonderici == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGuncelle(Musteri cr)
        {
            var cari = c.Musteris.Find(cr.MusteriID);
            cari.MusteriAdi = cr.MusteriAdi;
            cari.MusteriSoyAdi = cr.MusteriSoyAdi;
            cari.CariSehir=cr.CariSehir;
            cari.Sifre = cr.Sifre;
            cari.Telno=cr.Telno;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}