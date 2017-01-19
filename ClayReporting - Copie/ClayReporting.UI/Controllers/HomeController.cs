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
            /*RapportMois rp = new RapportMois();
            ViewBag.ListRapports = rp.Rapports;*/
            // ViewBag.Message = "Graphique de production";
            var nvc = Request.Form;
            DateTime date = new DateTime();
            if (!string.IsNullOrEmpty(nvc["CompanyName"]))
            {
                date = Convert.ToDateTime(nvc["CompanyName"]);
                ViewData["date"] = date;
            }
            var data = Request["CompanyName"];
            var etat = new Dictionary<string, int>();
            etat["low"] = 10;
            etat["medium"] = 20;
            etat["high"] = 30;
            var tab = new Dictionary<string, dynamic>();
            tab["quality"] = etat["medium"];
            tab["performance"] = etat["high"];
            tab["couleur"] = "yellow";
            tab["lot"] = 12;
            tab["layout"] = 45647856;
            tab["composant"] = "fdklkl";

            var tab1 = new Dictionary<string, dynamic>();
            tab1["quality"] = etat["low"];
            tab1["performance"] = etat["high"];
            tab1["couleur"] = "blue";
            tab1["lot"] = 14;
            tab1["layout"] = 456456456;
            tab1["composant"] = "fdklfdkl";


            var tab2 = new Dictionary<string, dynamic>();
            tab2["quality"] = etat["high"];
            tab2["performance"] = etat["medium"];
            tab2["couleur"] = "green";
            tab2["lot"] = 15;
            tab2["layout"] = 456456;
            tab2["composant"] = "fdkleqrakl";


            List<string> d = new List<string>() { "test1", "test3" };
            Dictionary<int, Dictionary<string, dynamic>> list = new Dictionary<int, Dictionary<string, dynamic>>();
            list.Add(0, tab);
            list.Add(1, tab1);
            list.Add(2, tab2);



            ViewData["list"] = list;
            return View();
        }
    }
}