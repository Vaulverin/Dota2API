using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dota2API.Models;
using Dota2API.Models.Parsers;

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
            NewsModel news = db.News.Find(id);
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
        public ActionResult Create(NewsModel news)
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
            NewsModel news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResourceId = new SelectList(db.Resources, "Id", "Resource", news.ResourceId);
            return View(news);
        }

        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(NewsModel news)
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
            NewsModel news = db.News.Find(id);
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
            NewsModel news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InitNewsParser()
        {
            List<ResourcesModel> res = db.Resources.ToList();
            foreach (ResourcesModel item in res)
            {
                IParser parser = ParserFactory.GetParser(item.ParserType);
                List<NewsModel> news = (List<NewsModel>)parser.Parse(item.Resource);
                foreach(NewsModel p in news)
                {
                    var result = db.News.Where(elem => elem.Link == p.Link);
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