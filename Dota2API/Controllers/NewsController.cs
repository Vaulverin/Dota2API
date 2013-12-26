using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dota2API.Models;
using Dota2API.Models.NewsParser;

namespace Dota2API.Controllers
{
    public class NewsController : Controller
    {
        private Dota2APIContext db = new Dota2APIContext();

        // GET: /News/

        public ActionResult Index()
        {
            var news = db.News.Include(n => n.Resource);
            return View(news.ToList());
        }

        // GET: /News/Details/5

        public ActionResult Details(int id = 0)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: /News/Create

        public ActionResult Create()
        {
            ViewBag.ResourceId = new SelectList(db.Resources, "Id", "Resource");
            return View();
        }

        // POST: /News/Create

        [HttpPost]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResourceId = new SelectList(db.Resources, "Id", "Resource", news.ResourceId);
            return View(news);
        }

        // GET: /News/Edit/5

        public ActionResult Edit(int id = 0)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResourceId = new SelectList(db.Resources, "Id", "Resource", news.ResourceId);
            return View(news);
        }

        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResourceId = new SelectList(db.Resources, "Id", "Resource", news.ResourceId);
            return View(news);
        }

        // GET: /News/Delete/5

        public ActionResult Delete(int id = 0)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InitNewsParser()
        {
            List<Resources> res = db.Resources.ToList();
            foreach (Resources item in res)
            {
                IParser parser = ParserFactory.GetParser(item.Type);
                List<News> news = parser.Parse(item.Resource);
                foreach(News p in news)
                {
                    var result = db.News.Where(n => n.Link == p.Link);
                    if (result.ToList().Count == 0)
                    {
                        p.ResourceId = item.Id;
                        db.News.Add(p);
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}