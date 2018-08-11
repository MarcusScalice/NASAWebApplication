using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application Developed by Georgian College";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact the Project Team";

            return View();
        }
    }
}