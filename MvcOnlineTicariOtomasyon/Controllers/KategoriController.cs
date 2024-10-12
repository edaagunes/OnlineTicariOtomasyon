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
    public class KategoriController : Controller
    {
        Context context =new Context();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = context.Kategoris.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            context.Kategoris.Add(k);
            context.SaveChanges();
            return RedirectToAction("Index");    
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori=context.Kategoris.Find(id);
            context.Kategoris.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = context.Kategoris.Find(id);
            return View("KategoriGetir",kategori);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kategori= context.Kategoris.Find(k.KategoriID);
            kategori.KategoriAd=k.KategoriAd;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Deneme()
        {
            KategoriListe list= new KategoriListe();
            list.Kategoriler = new SelectList(context.Kategoris, "KategoriID", "KategoriAd");
            list.Urunler = new SelectList(context.Uruns, "UrunID", "UrunAd");
            return View(list);
        }
        public JsonResult UrunGetir(int p)
        {
            var urunlistesi=(from x in context.Uruns
                             join y in context.Kategoris
                             on x.Kategori.KategoriID equals y.KategoriID
                             where x.Kategori.KategoriID == p
                             select new
                             {
                                 Text = x.UrunAd,
                                 Value=x.UrunID.ToString(),
                             }).ToList();
            return Json(urunlistesi,JsonRequestBehavior.AllowGet);
        }
    }
}