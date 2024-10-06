using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        [Display(Name = "Toplam Tutar")]
        public decimal ToplamTutar { get; set; }

        public int UrunID {  get; set; }
        public int CariID {  get; set; }
        public int PersonelID {  get; set; }
        [Display(Name = "Ürün Adı")]
        public virtual Urun Urun { get; set; }
        [Display(Name = "Cari Adı")]
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }


    }
}