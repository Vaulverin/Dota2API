using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dota2API.Models;

namespace Dota2API.Controllers
{
    public class LeaguesController : Controller
    {
        private Dota2APIContext db = new Dota2APIContext();

        //
        // GET: /Leagues/

        public ActionResult Index()
        {
            return View(db.Leagues.ToList());
        }

        //
        // GET: /Leagues/Details/5

        public ActionResult Details(int id = 0)
        {
            LeaguesModel leaguesmodel = db.Leagues.Find(id);
            if (leaguesmodel == null)
            {
                return HttpNotFound();
            }
            return View(leaguesmodel);
        }

        //
        // GET: /Leagues/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Leagues/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaguesModel leaguesmodel)
        {
            if (ModelState.IsValid)
            {
                db.Leagues.Add(leaguesmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leaguesmodel);
        }

        //
        // GET: /Leagues/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LeaguesModel leaguesmodel = db.Leagues.Find(id);
            if (leaguesmodel == null)
            {
                return HttpNotFound();
            }
            return View(leaguesmodel);
        }

        //
        // POST: /Leagues/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaguesModel leaguesmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaguesmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leaguesmodel);
        }

        //
        // GET: /Leagues/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LeaguesModel leaguesmodel = db.Leagues.Find(id);
            if (leaguesmodel == null)
            {
                return HttpNotFound();
            }
            return View(leaguesmodel);
        }

        //
        // POST: /Leagues/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaguesModel leaguesmodel = db.Leagues.Find(id);
            db.Leagues.Remove(leaguesmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Load()
        {
            List<LeaguesModel> _leagues = Models.APIWorker.APIWorker.GetLeagueListing(Languages.ru);
            foreach (LeaguesModel _item in _leagues)
            {
                _item.Language = Languages.ru;
                var _loadedLeague = db.Leagues.Where(elem => elem.Language == _item.Language && elem.LeagueId == _item.LeagueId);
                if (_loadedLeague.Count() == 0)
                {
                    db.Leagues.Add(_item);
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