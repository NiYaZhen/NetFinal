using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1410831003.Controllers
{
    public class moonController : Controller
    {
        // GET: moon
        public ActionResult Index()
        {
            ViewBag.A = "~/Views/imgCarousel/Index.cshtml";
            return View();
        }
    }
}