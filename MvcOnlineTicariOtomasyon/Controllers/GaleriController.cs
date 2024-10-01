using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
      Context context=new Context();
        public ActionResult Index()
        {
            var degerler=context.Uruns.ToList();
            return View(degerler);
        }
    }
}