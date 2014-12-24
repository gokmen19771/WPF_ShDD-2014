using DenetimMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DenetimMVC.Controllers
{
    public class AccountController : Controller
    {
        private denetimdbYeniContext db = new denetimdbYeniContext();

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Kullanicilar kul = db.Kullanicilar.Where(c => c.KullaniciTc == username && c.Parola == password).FirstOrDefault();
            
            if (kul!=null)
            {
                FormsAuthentication.SetAuthCookie(username, true);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpUnauthorizedResult();
        }
    }
}
