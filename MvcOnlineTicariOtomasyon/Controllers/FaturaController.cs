using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var liste=context.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            context.Faturalars.Add(f);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura=context.Faturalars.Find(id);
            return View("FaturaGetir",fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura=context.Faturalars.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.Saat=f.Saat;
            fatura.Tarih=f.Tarih;
            fatura.TeslimAlan=f.TeslimAlan;
            fatura.TeslimEden=f.TeslimEden;
            fatura.VergiDairesi=f.VergiDairesi;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {

            var degerler = context.FaturaKalems.Where(x => x.FaturaID == id).ToList();  
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            context.FaturaKalems.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}