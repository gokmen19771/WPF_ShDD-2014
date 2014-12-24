using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DenetimMVC.Models
{
    public partial class Menü
    {
        [Key]
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string SüreçSüreçKodu { get; set; }
        public string ViewModelName { get; set; }
        public string ViewName { get; set; }
        public bool GrupMu { get; set; }
        public int Sıralama { get; set; }
        public string MenüAd { get; set; }
        public byte[] İcon { get; set; }
    }
}
