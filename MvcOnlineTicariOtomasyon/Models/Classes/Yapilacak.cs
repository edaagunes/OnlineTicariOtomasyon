using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Yapilacak
    {

        [Key]
        public int YapilacakID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [Display(Name = "Başlık")]
        public string Baslik { get; set; }
        [Column(TypeName = "bit")]
        public bool Durum { get; set; }
    
    }
}