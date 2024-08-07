using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Musteri p)
        {
            p.Durum = true;
            c.Musteris.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Musteri m)
        {
            try
            {
                var bilgiler = c.Musteris.FirstOrDefault(x => x.MusteriMail == m.MusteriMail && x.Sifre == m.Sifre);
                if (bilgiler != null)
                {
                    FormsAuthentication.SetAuthCookie(bilgiler.MusteriMail, false);
                    Session["MusteriMail"] = bilgiler.MusteriMail.ToString();
                    return RedirectToAction("Index", "CariPanel");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}