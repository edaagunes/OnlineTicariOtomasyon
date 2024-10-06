using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        Context context=new Context();
        public ActionResult Index()
        {
            var deger1=context.Carilers.Count().ToString();
            ViewBag.d1=deger1;

            var deger2=context.Uruns.Count().ToString();
            ViewBag.d2=deger2;

            var deger3=context.Kategoris.Count().ToString();
            ViewBag.d3=deger3;

            var deger4=(from x in context.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4=deger4;

            var yapilacaklar = context.Yapilacaks.ToList();
            return View(yapilacaklar);
        }
    }
}