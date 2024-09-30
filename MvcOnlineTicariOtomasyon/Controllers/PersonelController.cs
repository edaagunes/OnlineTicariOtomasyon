using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context context=new Context();
        public ActionResult Index()
        {
            var degerler = context.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {

            List<SelectListItem> deger1 = (from x in context.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.deger = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            context.Personels.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.deger = deger1;
            var prs=context.Personels.Find(id);
            return View("PersonelGetir",prs);
        }

        public ActionResult PersonelGuncelle(Personel p) 
        {
            var prsn=context.Personels.Find(p.PersonelID);
            prsn.PersonelAd=p.PersonelAd;
            prsn.PersonelSoyad=p.PersonelSoyad;
            prsn.PersonelGorsel=p.PersonelGorsel;
            prsn.DepartmanID = p.DepartmanID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}