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
using System.Reflection;
using ShDenetim.Web.Utils;
namespace DenetimMVC.Controllers
{
    public class EvrakKayıtEskiController : ApiController
    {
        private denetimdbYeniContext db = new denetimdbYeniContext();

        // GET api/EvrakKayıtEski
        public IEnumerable<EvrakKayıtEski> GetEvrakKayıtEski()
        {
            return db.EvrakKayıtEski.AsEnumerable();
        }

        // GET api/EvrakKayıtEski/5


        public IQueryable GetEvrakKayıtEski(string param)
        {

           string[] paramList= param.Split(';');

           string strAranan = paramList[0];
           int dönecekKayıtSayısı = int.Parse(paramList[1]);
           int tamEşleşmeMi = int.Parse(paramList[2]);

           if (String.IsNullOrWhiteSpace(strAranan))
           {
               var y = db.EvrakKayıtEski.OrderByDescending(c => c.Id).Take(dönecekKayıtSayısı).AsQueryable();
               return y;
           }

           var sql =MyUtils.MyDynamicSearch.FullColumnSearchSql(typeof(EvrakKayıtEski), strAranan, tamEşleşmeMi, dönecekKayıtSayısı);


           var z = db.Database.SqlQuery<EvrakKayıtEski>(sql).AsQueryable<EvrakKayıtEski>();



           return z;
           
        }


        public EvrakKayıtEski GetEvrakKayıtEski(int id)
        {
            EvrakKayıtEski evrakkayıteski = db.EvrakKayıtEski.Find(id);
            if (evrakkayıteski == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return evrakkayıteski;
        }

        // PUT api/EvrakKayıtEski/5
        public HttpResponseMessage PutEvrakKayıtEski(int id, EvrakKayıtEski evrakkayıteski)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != evrakkayıteski.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(evrakkayıteski).State = EntityState.Modified;

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

        // POST api/EvrakKayıtEski
        public HttpResponseMessage PostEvrakKayıtEski(EvrakKayıtEski evrakkayıteski)
        {
            if (ModelState.IsValid)
            {
                db.EvrakKayıtEski.Add(evrakkayıteski);
                db.SaveChanges();

                if (evrakkayıteski.KayitNo==0 || evrakkayıteski.KayitNo==null )
                {
                    evrakkayıteski.KayitNo = evrakkayıteski.Id;
                    db.SaveChanges();
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, evrakkayıteski);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = evrakkayıteski.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/EvrakKayıtEski/5
        public HttpResponseMessage DeleteEvrakKayıtEski(int id)
        {
            EvrakKayıtEski evrakkayıteski = db.EvrakKayıtEski.Find(id);
            if (evrakkayıteski == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.EvrakKayıtEski.Remove(evrakkayıteski);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, evrakkayıteski);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}