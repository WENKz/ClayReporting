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
            Dictionary<int, Dictionary<string, dynamic>> donnees = ObtenirDonneesGraphique(debutPeriode, finPeriode);
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

        public Dictionary<int, Dictionary<string, dynamic>> ObtenirDonneesGraphique(DateTime debutPeriode, DateTime finPeriode)
        {
            Dictionary<string, int> valeurs = new Dictionary<string, int>();
            valeurs.Add("low", 10);
            valeurs.Add("medium", 20);
            valeurs.Add("high", 30);
            if(debutPeriode.Equals(new DateTime()) && finPeriode.Equals(new DateTime()))
            {
                debutPeriode = Convert.ToDateTime("1/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                finPeriode = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            }
            
            Dictionary<int, Dictionary<string, dynamic>> donnees = new Dictionary<int, Dictionary<string, dynamic>>();

            List<rapport> rapports = new ManageurDA().Rapports.getAllRapportInPeriod(debutPeriode, finPeriode);

            int i = 0;
            rapports.ForEach(delegate (rapport rapportExp)
            {

                string dateRapport = rapportExp.DateJour;
                rapportExp.data.ForEach(delegate (data data)
                {
                    Dictionary<string, dynamic> donnee = new Dictionary<string, dynamic>();
                    donnee.Add("date",dateRapport);
                    donnee.Add("quality", valeurs[data.etat.libelle.ToLower()]);
                    donnee.Add("performance", valeurs[data.etat1.libelle.ToLower()]);
                    donnee.Add("couleur", data.couleur.libelle);
                    donnee.Add("composant", data.composant.libelle);
                    donnee.Add("layout", data.layout);
                    donnee.Add("lot", data.lot);

                    donnees.Add(i, new Dictionary<string, dynamic>(donnee));
                    i++;
                });
            });
            return donnees;
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
