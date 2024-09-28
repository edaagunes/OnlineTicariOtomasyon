using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            context.Departmans.Add(d);
            context.SaveChanges();
           return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = context.Departmans.Find(id);
            departman.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id) 
        {
            var departman = context.Departmans.Find(id);
            return View("DepartmanGetir",departman);
        }

        public ActionResult DepartmanGuncelle(Departman p)
        {
            var departman=context.Departmans.Find(p.DepartmanID);
            departman.DepartmanAd=p.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id) 
        {
            var degerler=context.Personels.Where(x=>x.DepartmanID==id).ToList();
            var departman=context.Departmans.Where(x=>x.DepartmanID==id).Select(y=>y.DepartmanAd).FirstOrDefault();
            ViewBag.dpt = departman;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler=context.SatisHarekets.Where(x=>x.PersonelID==id).ToList();
            var per = context.Personels.Where(x=>x.PersonelID==id).Select(y=>y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers=per;
            return View(degerler);
        }
    }
}