using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DenetimMVC.Models
{
    public partial class Faaliyet
    {
        [Key]
        public int Id { get; set; }
        public string Tamamlandı { get; set; }
        public System.DateTime TamamlanmaTar { get; set; }
        public Nullable<int> DosyaKayıt_Id { get; set; }
        public virtual DosyaKayıt DosyaKayıt { get; set; }
    }
}
