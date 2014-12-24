using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DenetimMVC.Models;

namespace DenetimMVC.Controllers
{
   
    public class KullanicilarController : ApiController
    {
        private denetimdbYeniContext db = new denetimdbYeniContext();

        // GET api/Kullanicilar

     [Authorize]
        public IEnumerable<Kullanicilar> GetKullanicilars()
        {
            return db.Kullanicilar.AsEnumerable();
        }

         // GET api/Kullanicilar/5
        public Kullanicilar GetKullanicilar(string id)
        {
            Kullanicilar kullanicilar = db.Kullanicilar.Where(c => c.KullaniciTc == id).FirstOrDefault();
            if (kullanicilar == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return kullanicilar;
        }

        // PUT api/Kullanicilar/5

         [Authorize]
        public HttpResponseMessage PutKullanicilar(string id, Kullanicilar kullanicilar)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != kullanicilar.KullaniciTc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(kullanicilar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

         // POST api/Kullanicilar
        public HttpResponseMessage PostKullanicilar(Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                db.Kullanicilar.Add(kullanicilar);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, kullanicilar);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = kullanicilar.KullaniciTc }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Kullanicilar/5
        public HttpResponseMessage DeleteKullanicilar(string id)
        {
            Kullanicilar kullanicilar = db.Kullanicilar.Find(id);
            if (kullanicilar == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Kullanicilar.Remove(kullanicilar);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, kullanicilar);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}