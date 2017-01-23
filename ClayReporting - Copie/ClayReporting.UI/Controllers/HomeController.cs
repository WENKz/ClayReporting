using ClayReporting.Process;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Globalization;
using System.IO;
using System.Text;

namespace ClayReporting.UI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var nvc = Request.Form;
            DateTime date = new DateTime();
            ProcessGlobaux pg = new ProcessGlobaux();

            if (!string.IsNullOrEmpty(nvc["fromDate"]) && !string.IsNullOrEmpty(nvc["toDate"]) )
            {
                DateTime fromDate = Convert.ToDateTime(nvc["fromDate"]);
                DateTime toDate = Convert.ToDateTime(nvc["toDate"]);
                if (fromDate <= toDate)
                {
                    Dictionary<int, Dictionary<string, dynamic>> données = pg.ObtenirDonneesGraphique(fromDate, toDate);
                    ViewData["fromDate"] = fromDate;
                    ViewData["toDate"] = toDate;
                    ViewData["list"] = données;
                    return View();
                }
                else
                {
                    ViewData["messageError"] = "La periode selectionné est incorrecte";
                }
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
            Class1 c = new Class1();
            c.test();
            // ViewBag.Message = "Graphique de production";
            var nvc = Request.Form;
            DateTime date = new DateTime();
            PageGraphique pg = new PageGraphique();

            if (!string.IsNullOrEmpty(nvc["fromDate"]) && !string.IsNullOrEmpty(nvc["toDate"]))
             {
                 DateTime fromDate = Convert.ToDateTime(nvc["fromDate"]);
               DateTime toDate = Convert.ToDateTime(nvc["toDate"]);
                if (fromDate <= toDate)
                {
                    Dictionary<string, dynamic> donnees = pg.GenererDonneesgraphs(fromDate, toDate);
                    ViewData["fromDate"] = fromDate;
                    ViewData["toDate"] = toDate;
                    ViewData["list"] = donnees;
                    return View();
                }
                else
                {
                    ViewData["messageError"] = "La periode selectionné est incorrecte";
                }
            }
            
            Dictionary<string, dynamic> test = pg.GenererDonneesgraphs(new DateTime(), new DateTime());
            ViewData["list"] = test;
            return View();
        }

        public ActionResult Export()
        {
            var nvc = Request.Form;

            if (!string.IsNullOrEmpty(nvc["fromDateExport"]) && !string.IsNullOrEmpty(nvc["toDateExport"]))
            {
                DateTime fromDate = Convert.ToDateTime(nvc["fromDateExport"]);
                DateTime toDate = Convert.ToDateTime(nvc["toDateExport"]);
                if (fromDate <= toDate)
                {
                    RapportMois rapportMois = new RapportMois(fromDate, toDate);
                    Response.AddHeader("content-disposition", "attachment; filename=" + string.Format("rapprot-{0}-{1}.xml", rapportMois.startDayMonth.ToString("dd_MM_yyyy", CultureInfo.InvariantCulture), rapportMois.endDayMonth.ToString("dd_MM_yyyy", CultureInfo.InvariantCulture)));
                    Response.ContentType = "text/xml";
                    using (StreamWriter sw = new StreamWriter(Response.OutputStream, Encoding.UTF8))
                    {
                        ManipulateurXML xml = new ManipulateurXML();
                        string contenu = xml.Serialize(rapportMois, typeof(RapportMois));
                        sw.Write(contenu);
                    }
                    Response.End();


                    /*RapportMois rapportMois = new RapportMois(new DateTime(),new DateTime());
                    if (rapportMois.Rapports.Count > 0)
                    {
                        ManipulateurXML xml = new ManipulateurXML();
                        xml.Ecrire(rapportMois, typeof(RapportMois), string.Format("rapprot-{0}-{1}.xml", rapportMois.startDayMonth.ToString("dd_MM_yyyy", CultureInfo.InvariantCulture), rapportMois.endDayMonth.ToString("dd_MM_yyyy", CultureInfo.InvariantCulture)));
                    }*/
                }
                else
                {
                    ViewData["messageError"] = "La periode selectionné est incorrecte";
                }
                
            }
            string view = "/Home/Index";
            if (!nvc["currentView"].Equals("/") && !nvc["currentView"].Equals("/Home/Index"))
            {
                view = nvc["currentView"];
            }

            
            ViewData["view"] = view;
            
            return View();
        }
    }
}