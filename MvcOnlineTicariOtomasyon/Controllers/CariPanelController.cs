using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m_mail = mail;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = context.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = context.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = context.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x=>x.MesajID).ToList();
            var gelenSayisi = context.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidenSayisi = context.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            ViewBag.d2 = gidenSayisi;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = context.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelenSayisi = context.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidenSayisi = context.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            ViewBag.d2 = gidenSayisi;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler=context.Mesajlars.Where(x=>x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelenSayisi = context.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidenSayisi = context.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            ViewBag.d2 = gidenSayisi;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelenSayisi = context.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidenSayisi = context.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            ViewBag.d2 = gidenSayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            context.Mesajlars.Add(m);
            context.SaveChanges();
            return View();
        }
    }
}