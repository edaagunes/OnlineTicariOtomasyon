using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class DinamikFatura
    {
        public IEnumerable<Faturalar> deger1 { get; set; }
        public IEnumerable<FaturaKalem> deger2 { get; set; }
    }
}