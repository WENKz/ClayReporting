using ClayReporting.DataAcces;
using ClayReporting.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ClayReporting.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var nvc = Request.Form;
            DateTime date = new DateTime();
            PageGraphique pg = new PageGraphique();

            if (!string.IsNullOrEmpty(nvc["fromDate"]) && !string.IsNullOrEmpty(nvc["toDate"]))
            {
                DateTime fromDate = Convert.ToDateTime(nvc["fromDate"]);
                DateTime toDate = Convert.ToDateTime(nvc["toDate"]);

                Dictionary<int, Dictionary<string, dynamic>> données = pg.ObtenirDonneesGraphique(fromDate, toDate);
                ViewData["fromDate"] = fromDate;
                ViewData["toDate"] = toDate;
                ViewData["list"] = données;
                return View();
            }

            Dictionary<int, Dictionary<string, dynamic>> test = pg.ObtenirDonneesGraphique(new DateTime(), new DateTime());
            ViewData["list"] = test;

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
            /*Class1 c = new Class1();
            c.test();*/
            // ViewBag.Message = "Graphique de production";
            var nvc = Request.Form;
            DateTime date = new DateTime();
            PageGraphique pg = new PageGraphique();

            if (!string.IsNullOrEmpty(nvc["fromDate"]) && !string.IsNullOrEmpty(nvc["toDate"]))
             {
                 DateTime fromDate = Convert.ToDateTime(nvc["fromDate"]);
               DateTime toDate = Convert.ToDateTime(nvc["toDate"]);

                Dictionary<string, dynamic> donnees = pg.GenererDonneesgraphs(fromDate, toDate );
                ViewData["fromDate"] = fromDate;
                ViewData["toDate"] = toDate;
                ViewData["list"] = donnees;
                return View();
            }
            
            Dictionary<string, dynamic> test = pg.GenererDonneesgraphs(new DateTime(), new DateTime());
            ViewData["list"] = test;
            return View();
        }
    }
}