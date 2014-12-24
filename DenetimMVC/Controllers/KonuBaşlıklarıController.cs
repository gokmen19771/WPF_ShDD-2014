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
    public class KonuBaşlıklarıController : ApiController
    {
        private denetimdbYeniContext db = new denetimdbYeniContext();

        // GET api/KonuBaşlıkları
        public IEnumerable<KonuBasliklari> GetKonuBasliklaris()
        {
            return db.KonuBaşlıkları.AsEnumerable();
        }

        // GET api/KonuBaşlıkları/5
        public KonuBasliklari GetKonuBasliklari(int id)
        {
            KonuBasliklari konubasliklari = db.KonuBaşlıkları.Find(id);
            if (konubasliklari == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return konubasliklari;
        }

        // PUT api/KonuBaşlıkları/5
        public HttpResponseMessage PutKonuBasliklari(int id, KonuBasliklari konubasliklari)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != konubasliklari.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(konubasliklari).State = EntityState.Modified;

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

        // POST api/KonuBaşlıkları
        public HttpResponseMessage PostKonuBasliklari(KonuBasliklari konubasliklari)
        {
            if (ModelState.IsValid)
            {
                db.KonuBaşlıkları.Add(konubasliklari);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, konubasliklari);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = konubasliklari.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/KonuBaşlıkları/5
        public HttpResponseMessage DeleteKonuBasliklari(int id)
        {
            KonuBasliklari konubasliklari = db.KonuBaşlıkları.Find(id);
            if (konubasliklari == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.KonuBaşlıkları.Remove(konubasliklari);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, konubasliklari);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}