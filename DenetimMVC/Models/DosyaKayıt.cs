using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DenetimMVC.Models
{
    public partial class DosyaKayıt : MyModelBase
    {
      
        [Key]
        public int Id { get; set; }

        private string dosyaNo;

        public string DosyaNo
        {
            get { return dosyaNo; }
            set
            { dosyaNo = value;
             RaisePropertyChanged();
            }
        }


        public string AnaSüreçKodu { get; set; }
        public int Yıl { get; set; }
        public string SüreçKodu { get; set; }
        public string AltSüreçKodu { get; set; }
        public string SüreçKonu { get; set; }
        public Nullable<System.DateTime> SüreçBaşlangıçTar { get; set; }
        public Nullable<System.DateTime> SüreçBitişTar { get; set; }
        public Nullable<System.DateTime> EbysGelişTar { get; set; }
        public string EbysGelişSayı { get; set; }
        public string Oluşturan { get; set; }
        public Nullable<System.DateTime> OluşturanTar { get; set; }
        public string Değiştiren { get; set; }
        public Nullable<System.DateTime> DeğiştirmeTar { get; set; }
   
    }
}
