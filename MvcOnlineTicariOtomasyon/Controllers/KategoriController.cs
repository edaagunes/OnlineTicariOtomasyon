using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context context =new Context();
        public ActionResult Index()
        {
            var degerler = context.Kategoris.ToList();
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
    }
}