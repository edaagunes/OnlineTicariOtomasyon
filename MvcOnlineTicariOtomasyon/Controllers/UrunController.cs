using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var urunler = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in context.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.deger=deger1;
            return View();
        }


        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            context.Uruns.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = context.Uruns.Find(id);
            deger.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.deger = deger1;
    

            var urunDeger=context.Uruns.Find(id);
            return View("UrunGetir",urunDeger);
        }

        public ActionResult UrunGuncelle(Urun p)
        {
            var urun = context.Uruns.Find(p.UrunID);
            urun.AlisFiyat=p.AlisFiyat;
            urun.Durum=p.Durum;
            urun.KategoriID=p.KategoriID;
            urun.Marka=p.Marka;
            urun.SatisFiyat =p.SatisFiyat;
            urun.Stok=p.Stok;
            urun.UrunAd=p.UrunAd;
            urun.UrunGorsel=p.UrunGorsel;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}