using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

namespace ShDenetim.Web.Utils
{
    public class NesneIslemleri
    {


        public static object parseSearchString(string search_string)
        {    
            int obInt;    
            DateTime obDt;    
            bool obBool;
            string obStr;

            if (Int32.TryParse(search_string, out obInt)) return obInt;
            else if (DateTime.TryParse(search_string, out obDt)) return obDt;
            else if (bool.TryParse(search_string, out obBool)) return obBool;
            else return obStr=search_string;

        }


        public static void NesneOzellikDegerAta(object o, string ozellik, object deger)
        {
            PropertyInfo[] p = o.GetType().GetProperties();
            PropertyInfo pinfo = p.Where(c => c.Name == ozellik).FirstOrDefault();



            pinfo.SetValue(o, deger, null);
        }

        public static object NesneOzellikDegerGetir(object o, string ozellik)
        {
            PropertyInfo[] p = o.GetType().GetProperties();
            PropertyInfo pinfo = p.Where(c => c.Name == ozellik).FirstOrDefault();


            return pinfo.GetValue(o, null);

        }

        public static string CheckListTamCevapGetir(CheckBoxList chkList)
        {
            string cevap = "";
            foreach (ListItem chk in chkList.Items)
            {
                cevap += chk.Selected ? chk.Value + "; " : "";
            }


            return cevap.TrimEnd(';');
        }




    }
}