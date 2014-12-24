using DenetimMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DenetimWIN
{
    public class Utils
    {
       public static Kullanicilar AktifKullanıcı { get; set; }

       public static HttpClient Client { get; set; }
    

    }
}
