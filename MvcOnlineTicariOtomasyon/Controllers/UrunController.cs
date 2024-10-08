using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();
        public ActionResult Index(int? sayfa, string p)
        {

            var degerler = context.Uruns.Where(c => c.UrunAd.Contains(p) || p == null || c.Marka.Contains(p) || c.Kategori.KategoriAd.Contains(p)).ToList().ToPagedList(sayfa ?? 1, 4);

            return View(degerler);
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
            ViewBag.deger = deger1;
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


            var urunDeger = context.Uruns.Find(id);
            return View("UrunGetir", urunDeger);
        }

        public ActionResult UrunGuncelle(Urun p)
        {
            var urun = context.Uruns.Find(p.UrunID);
            urun.AlisFiyat = p.AlisFiyat;
            urun.Durum = p.Durum;
            urun.KategoriID = p.KategoriID;
            urun.Marka = p.Marka;
            urun.SatisFiyat = p.SatisFiyat;
            urun.Stok = p.Stok;
            urun.UrunAd = p.UrunAd;
            urun.UrunGorsel = p.UrunGorsel;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunListesi()
        {
            var degerler = context.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = context.Uruns.Find(id);
            ViewBag.dgr1 = deger1.UrunID;
            ViewBag.dgr2 = deger1.SatisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}