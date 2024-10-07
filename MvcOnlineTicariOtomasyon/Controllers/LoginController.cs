using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
       Context context=new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cariler p)
        {
            context.Carilers.Add(p);
            context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler p)
        {
            var values = context.Carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.CariMail, false);
                Session["CariMail"]=values.CariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "login");
            }          
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = context.Admins.FirstOrDefault(x=>x.KullaniciAd==p.KullaniciAd&&x.Sifre==p.Sifre);
            if (bilgiler != null) 
            { 
            FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"]=bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "login");
            }
        }
    }
}