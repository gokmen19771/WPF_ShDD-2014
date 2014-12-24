using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DenetimMVC.Models
{
    public partial class Yapılanİşlemler
    {
        [Key]
        public int İşlemId { get; set; }
        public string İşlemAdı { get; set; }
        public string Süreç_SüreçKod { get; set; }
        public virtual Süreç Süreç { get; set; }
    }
}
