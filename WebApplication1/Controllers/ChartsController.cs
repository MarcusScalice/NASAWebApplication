using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ChartsController : Controller
    {

        private DataContext db = new DataContext();
        // GET: Charts
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult MeteoritesColumnChart()
        {
            //List<Meteorite> items = new List<Meteorite>();
            List<Meteorite> items = db.Meteorites.ToList();
            List<Meteorite> items2 = new List<Meteorite>();
            foreach (var item in items)
            {
                if (item.Mass > 100000)
                {
                    items2.Add(item);
                }
            }
            //items.Add(new Meteorite { MeteoriteID = 1, Mass = 100, Name = "Test", FellDate = DateTime.UtcNow, GeoLocation = "[6.08333, 50.775]", CreationDate = DateTime.UtcNow, AddID = 1 });
            //items.Add(new Meteorite { MeteoriteID = 100, Mass = 100, Name = "Test", FellDate = DateTime.UtcNow, GeoLocation = "[6.08333, 50.775]", CreationDate = DateTime.UtcNow, AddID = 2 });
           items2 = items2.OrderBy(x => x.Mass).ToList();

                return (Json(items2, JsonRequestBehavior.AllowGet));
        }

        public JsonResult MeteoritesGeoChart()
        {
            List<Meteorite> items = db.Meteorites.ToList();
           
            return (Json(items, JsonRequestBehavior.AllowGet));
        }

        public JsonResult MeteoritesTableChart()
        {
            List<Meteorite> items = db.Meteorites.ToList();


            return (Json(items, JsonRequestBehavior.AllowGet));
        }

    }
}