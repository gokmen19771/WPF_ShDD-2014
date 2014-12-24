using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenetimMVC.Models
{
    public partial class EvrakKayıtEski
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int KayitNo { get; set; }
        public string EvrakTip { get; set; }
        public string Sayi { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Il { get; set; }
        public string Kurum { get; set; }
        public string KonuBasligi { get; set; }

        public string Konu { get; set; }
        public string IslemYapan { get; set; }
        public Nullable<System.DateTime> IslemTarihi { get; set; }

        public string SonIslemYapan { get; set; }
        public Nullable<System.DateTime> SonIslemTarihi { get; set; }

        public string KaldirildigiKlasor { get; set; }
        public string KlasorSiraNo { get; set; }
        public string EvrakIcerikDosyaAd { get; set; }
        public byte[] EvrakIcerik { get; set; }
        public string Aciklama { get; set; }
        public Nullable<bool> EskiVeri { get; set; }
        public string Reklam_TeklifEdilen { get; set; }
        public string Reklam_Uygulanan { get; set; }
        public string Reklam_KuruluşTuru { get; set; }
    }
}
