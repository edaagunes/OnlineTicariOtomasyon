using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var sonuclar = context.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xValue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yValue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xValue, yValues: yValue);


            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif1> Urunlistesi()
        {
            List<Sinif1> sinif = new List<Sinif1>();
            sinif.Add(new Sinif1()
            {
                UrunAd = "Bilgisayar",
                Stok = 120
            });
            sinif.Add(new Sinif1()
            {
                UrunAd = "Beyaz Eşya",
                Stok = 400
            });
            sinif.Add(new Sinif1()
            {
                UrunAd = "Mobilya",
                Stok = 90
            });
            sinif.Add(new Sinif1()
            {
                UrunAd = "Küçük Ev Aletleri",
                Stok = 50
            });
            return sinif;
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(Urunlistesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif2> Urunlistesi2()
        {
            List<Sinif2> snf = new List<Sinif2>();
            using (var context = new Context())
            {
                snf = context.Uruns.Select(x => new Sinif2
                {
                    UrunAd = x.UrunAd,
                    Stok = x.Stok,
                }).ToList();
            }
            return snf;
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult Index6()
        {
            return View();
        }
    }
}