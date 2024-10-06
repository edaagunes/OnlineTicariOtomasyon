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
            var id=context.Carilers.Where(x=>x.CariMail==mail.ToString()).Select(y=>y.CariID).FirstOrDefault();
            var degerler=context.SatisHarekets.Where(x=>x.CariID==id).ToList();
            return View(degerler);
        }
    }
}