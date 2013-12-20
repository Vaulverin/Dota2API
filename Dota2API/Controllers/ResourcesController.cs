﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dota2API.Models;

namespace Dota2API.Controllers
{
    public class ResourcesController : Controller
    {
        private Dota2APIContext db = new Dota2APIContext();

        //
        // GET: /Resources/

        public ActionResult Index()
        {
            return View(db.Resources.ToList());
        }

        //
        // GET: /Resources/Details/5

        public ActionResult Details(int id = 0)
        {
            Resources resources = db.Resources.Find(id);
            if (resources == null)
            {
                return HttpNotFound();
            }
            return View(resources);
        }

        //
        // GET: /Resources/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Resources/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resources resources)
        {
            if (ModelState.IsValid)
            {
                db.Resources.Add(resources);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resources);
        }

        //
        // GET: /Resources/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Resources resources = db.Resources.Find(id);
            if (resources == null)
            {
                return HttpNotFound();
            }
            return View(resources);
        }

        //
        // POST: /Resources/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Resources resources)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resources).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resources);
        }

        //
        // GET: /Resources/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Resources resources = db.Resources.Find(id);
            if (resources == null)
            {
                return HttpNotFound();
            }
            return View(resources);
        }

        //
        // POST: /Resources/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resources resources = db.Resources.Find(id);
            db.Resources.Remove(resources);
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