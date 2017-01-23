using ClayReporting.DataAcces;
using ClayReporting.DataAcces.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayReporting.Process
{
    public class PageGraphique
    {
        public Dictionary<string, dynamic> GenererDonneesgraphs(DateTime debutPeriode, DateTime finPeriode)
        {
            ProcessGlobaux pg = new ProcessGlobaux();
            Dictionary<int, Dictionary<string, dynamic>> donnees = pg.ObtenirDonneesGraphique(debutPeriode, finPeriode);
            Dictionary<string, dynamic> donneesGraphs = new Dictionary<string, dynamic>();
            Dictionary<string, int[]> donnesGraphQualityParComposant = new Dictionary<string, int[]>();
            Dictionary<string, int> donnesGraphNombreLotParColor = new Dictionary<string, int>();
            Dictionary<int, int> donnesGraphQualityParLot = new Dictionary<int, int>();
            Dictionary<int, int[]> donnesGraphPerformanceParLayout = new Dictionary<int, int[]>();
            donneesGraphs.Add("graphQualiteParComposant", new Dictionary<string, int>());
            donneesGraphs.Add("graphNombreLotParColor", new Dictionary<string, int>());
            donneesGraphs.Add("graphQualiteParLot", new Dictionary<int, int>());
            donneesGraphs.Add("graphPerformanceLayout", new Dictionary<int, int>());
            foreach (int r in donnees.Keys)
            {
                donnesGraphQualityParComposant = GennerDonneesGraphQualityParComposant(donnees[r], donnesGraphQualityParComposant);
                donnesGraphNombreLotParColor = GenererGraphNombreLotParColor(donnees[r], donnesGraphNombreLotParColor);
                donnesGraphQualityParLot.Add(donnees[r]["lot"], donnees[r]["quality"]);
                donnesGraphPerformanceParLayout = GennerDonneesGraphPerformanceParLayout(donnees[r], donnesGraphPerformanceParLayout);
            }
            donneesGraphs["graphQualiteParComposant"] = CalculeMoyenne(donnesGraphQualityParComposant);
            donneesGraphs["graphNombreLotParColor"] = donnesGraphNombreLotParColor;
            donneesGraphs["graphQualiteParLot"] = donnesGraphQualityParLot;
            donneesGraphs["graphPerformanceLayout"] = CalculeMoyenne(donnesGraphPerformanceParLayout);
            return donneesGraphs;
        }

        
        private Dictionary<string, int[]> GennerDonneesGraphQualityParComposant(Dictionary<string, dynamic> donneeACalculee,Dictionary<string,int[]> donneesExistantes)
        {
            if (!donneesExistantes.Keys.Any(k => k.Equals(donneeACalculee["composant"])))
            {
                donneesExistantes.Add(donneeACalculee["composant"], new int[] { donneeACalculee["quality"], 1 });
            }
            else
            {
                donneesExistantes[donneeACalculee["composant"]][0] += donneeACalculee["quality"];
                donneesExistantes[donneeACalculee["composant"]][1] += 1;
            }

            return donneesExistantes;
        }

        private Dictionary<string, int> GenererGraphNombreLotParColor(Dictionary<string, dynamic> donneeACalculee, Dictionary<string, int> donneesExistantes)
        {
            if (!donneesExistantes.Keys.Any(k => k.Equals(donneeACalculee["couleur"])))
            {
                donneesExistantes.Add(donneeACalculee["couleur"], 1);
            }
            else
            {
                donneesExistantes[donneeACalculee["couleur"]] += 1 ;
            }
            return donneesExistantes;
        }

        private Dictionary<int, int[]> GennerDonneesGraphPerformanceParLayout(Dictionary<string, dynamic> donneeACalculee, Dictionary<int, int[]> donneesExistantes)
        {
            if (!donneesExistantes.Keys.Any(k => k.Equals(donneeACalculee["layout"])))
            {
                donneesExistantes.Add(donneeACalculee["layout"], new int[] { donneeACalculee["performance"], 1 });
            }
            else
            {
                donneesExistantes[donneeACalculee["layout"]][0] += donneeACalculee["performance"];
                donneesExistantes[donneeACalculee["layout"]][1] += 1;
            }

            return donneesExistantes;
        }

        private Dictionary<dynamic, int> CalculeMoyenne(dynamic donnees)
        {
            Dictionary<dynamic, int> result = new Dictionary<dynamic, int>();
            foreach (dynamic k in donnees.Keys)
            {
                int moy = donnees[k][0] / donnees[k][1];
                result.Add(k, moy);
            }

            return result;
        }
        /*public List<RapportExport> ObtenirRapportExportDeLaPeriode(DateTime debutPeriode, DateTime finPeriode) 
        {

            
        }*/
    }
}
