using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShDenetim.Web.Utils
{
    public class YeniEventArgs:EventArgs
    {
       

         private string message;

         public YeniEventArgs(string m)
         { 
            this.message=m; 
         }

         public string SoruKodlari()
         { 
            return message; 
         } 

    }
  

    
    public class Genel
    {



    }


}