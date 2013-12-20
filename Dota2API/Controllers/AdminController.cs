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
using Dota2API.Models;

namespace Dota2API.Controllers
{ 
    public class AdminController : ApiController
    {
        private Dota2APIContext db = new Dota2APIContext();

        // GET api/Admin
        public IEnumerable<News> GetNews()
        {
            return db.News.AsEnumerable();
        }

        // GET api/Admin/5
        public News GetNews(int id)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return news;
        }

        // PUT api/Admin/5
        public HttpResponseMessage PutNews(int id, News news)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != news.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(news).State = EntityState.Modified;

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

        // POST api/Admin
        public HttpResponseMessage PostNews(News news)
        {
            if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, news);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = news.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Admin/5
        public HttpResponseMessage DeleteNews(int id)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.News.Remove(news);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, news);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}