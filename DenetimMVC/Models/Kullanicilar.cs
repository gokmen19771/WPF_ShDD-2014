using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenetimMVC.Models
{
    
    public partial class Kullanicilar
    {
        [Key]
        public string KullaniciTc { get; set; }
        public string KullaniciAdSoyad { get; set; }
        public string Parola { get; set; }
        public string Rol;
    }
}
