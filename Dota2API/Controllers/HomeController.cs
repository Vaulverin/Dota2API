using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dota2API.Models;

namespace Dota2API.Controllers
{
    public class HomeController : Controller
    {
        private Dota2APIContext db = new Dota2APIContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult Admin()
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "admin", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View();
        }
    }
}
