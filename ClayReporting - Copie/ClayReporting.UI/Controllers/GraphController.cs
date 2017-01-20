using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClayReporting.Process;
namespace ClayReporting.UI.Controllers
{
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult Index()
        {
            PageGraphique pg = new PageGraphique();
            Dictionary<int, Dictionary<string, dynamic>> test = pg.ObtenirDonneesGraphique(new DateTime(), new DateTime());
            ViewData["list"] = test;
            return View();
        }
    }
}