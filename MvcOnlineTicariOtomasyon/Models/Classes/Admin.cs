﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string Yetki { get; set; }
    }
}