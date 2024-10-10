using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using PagedList;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context context=new Context();
        public ActionResult Index(string p)
        {

            var degerler = context.KargoDetays.Where(c => c.TakipKodu.Contains(p) || p == null).ToList();

            return View(degerler);

        
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1=rnd.Next(0,4);
            k2=rnd.Next(0,4);
            k3=rnd.Next(0,4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod=s1.ToString()+karakterler[1]+s2+karakterler[2]+s3+karakterler[3];
            ViewBag.takipkod = kod;

            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            context.KargoDetays.Add(d);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        {
            var degerler = context.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }

    }
}