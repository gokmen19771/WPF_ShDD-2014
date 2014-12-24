using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DenetimMVC.Models
{
    public partial class Süreç
    {
        public Süreç()
        {
            this.DosyaKayıt = new List<DosyaKayıt>();
            this.Yapılanİşlemler = new List<Yapılanİşlemler>();
        }

        [Key]
        public string SüreçKod { get; set; }
        public int SıraNo { get; set; }
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string SüreçAdı { get; set; }
        public int GünSayısı { get; set; }
        public Nullable<int> UzGünSayısı { get; set; }
        public double FaaliyetMi { get; set; }
        public virtual ICollection<DosyaKayıt> DosyaKayıt { get; set; }
        public virtual ICollection<Yapılanİşlemler> Yapılanİşlemler { get; set; }
    }
}
