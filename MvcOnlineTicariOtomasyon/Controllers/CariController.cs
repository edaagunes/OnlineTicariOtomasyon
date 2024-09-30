using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum = true;
            context.Carilers.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cariler = context.Carilers.Find(id);
            cariler.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = context.Carilers.Find(id);
            return View("CariGetir", cari);
        }

        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }

            else
            {
                var cari = context.Carilers.Find(p.CariID);
                cari.CariAd = p.CariAd;
                cari.CariSoyad = p.CariSoyad;
                cari.CariSehir = p.CariSehir;
                cari.CariMail = p.CariMail;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult MusteriSatis(int id) 
        {
            var degerler=context.SatisHarekets.Where(x=>x.CariID==id).ToList();
            var cr = context.Carilers.Where(x=>x.CariID==id).Select(y=>y.CariAd + " "+y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}