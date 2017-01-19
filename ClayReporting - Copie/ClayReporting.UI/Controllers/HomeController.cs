using ClayReporting.DataAcces;
using ClayReporting.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClayReporting.Process;
using System.Web.Script.Serialization;

namespace ClayReporting.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Class1 c1 = new Class1();
            c1.test();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Graph()
        {
            RapportMois rp = new RapportMois();
            ViewBag.ListRapports = rp.Rapports;
            ViewBag.Message = "Graphique de production";

            return View();
        }
    }
}