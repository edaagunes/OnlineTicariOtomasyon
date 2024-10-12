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
            var liste = context.Faturalars.ToList();
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
            var fatura = context.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = context.Faturalars.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.Saat = f.Saat;
            fatura.Tarih = f.Tarih;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            fatura.VergiDairesi = f.VergiDairesi;
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

        public ActionResult Dinamik()
        {
            DinamikFatura dinamik = new DinamikFatura();
            dinamik.deger1 = context.Faturalars.ToList();
            dinamik.deger2 = context.FaturaKalems.ToList();
            return View(dinamik);
        }

        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSıraNo, DateTime Tarih, string VergiDairesi, string Saat, string TeslimEden, string TeslimAlan, string Toplam, FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSıraNo = FaturaSıraNo;
            f.Tarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.Saat = Saat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.Toplam = decimal.Parse(Toplam);
            context.Faturalars.Add(f);

            foreach (var x in kalemler)
            {
                if (x != null)
                {

                    FaturaKalem fk = new FaturaKalem();
                    fk.Aciklama = x.Aciklama;
                    fk.BirimFiyat = x.BirimFiyat;
                    fk.FaturaID = x.FaturaKalemID;
                    fk.Miktar = x.Miktar;
                    fk.Tutar = x.Tutar;
                    context.FaturaKalems.Add(fk);

                }
            }

            context.SaveChanges();
            return Json("İşlem Başarılı");
        }
    }
}