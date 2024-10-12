using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CariPanelController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Mesajlars.Where(x => x.Alici == mail).ToList();
            ViewBag.m_mail = mail;
            var mailid = context.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            ViewBag.mailid = mailid;
            var toplamsatis = context.SatisHarekets.Where(x => x.CariID == mailid).Count();
            ViewBag.toplamsatis = toplamsatis;
            var toplamtutar = context.SatisHarekets.Where(x => x.CariID == mailid).Sum(y =>(decimal?) y.ToplamTutar);
            ViewBag.toplamtutar = toplamtutar;
            var toplamurunsayisi = context.SatisHarekets.Where(x => x.CariID == mailid).Sum(y => (decimal?)y.Adet);
            ViewBag.toplamurunsayisi = toplamurunsayisi;
            var adsoyad=context.Carilers.Where(x=>x.CariMail==mail).Select(y=>y.CariAd+" "+y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;  
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = context.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = context.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = context.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelenSayisi = context.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidenSayisi = context.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            ViewBag.d2 = gidenSayisi;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = context.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelenSayisi = context.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidenSayisi = context.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            ViewBag.d2 = gidenSayisi;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = context.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelenSayisi = context.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidenSayisi = context.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            ViewBag.d2 = gidenSayisi;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelenSayisi = context.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidenSayisi = context.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            ViewBag.d2 = gidenSayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            context.Mesajlars.Add(m);
            context.SaveChanges();
            return View();
        }

        public ActionResult KargoTakip(string p)
        {
            var degerler = context.KargoDetays.Where(c => c.TakipKodu.Equals(p)).ToList();

            return View(degerler);
        }

        public ActionResult CariKargoTakip(string id)
        {
            var degerler = context.KargoTakips.Where(x => x.TakipKodu == id).ToList();
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
            var mail = (string)Session["CariMail"];
            var id=context.Carilers.Where(x=>x.CariMail==mail).Select(y=>y.CariID).FirstOrDefault();
            var caribul = context.Carilers.Find(id);
            return PartialView("Partial1",caribul);
        }


        public PartialViewResult Partial2()
        {
            var degerler=context.Mesajlars.Where(x=>x.Gonderici=="admin").ToList();
            return PartialView(degerler);
        }

        public ActionResult CariBilgiGuncelle(Cariler cariler)
        {
            var cari=context.Carilers.Find(cariler.CariID);
            cari.CariAd = cariler.CariAd;
            cari.CariSoyad = cariler.CariSoyad;
            cari.CariSifre = cariler.CariSifre;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}