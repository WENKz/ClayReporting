using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClayReporting.DataAcces;
using System.IO;
namespace ClayReporting.Process
{
    public class ProcessGlobaux
    {
        public Dictionary<int, Dictionary<string, dynamic>> ObtenirDonneesGraphique(DateTime debutPeriode, DateTime finPeriode)
        {
            Dictionary<string, int> valeurs = new Dictionary<string, int>();
            valeurs.Add("low", 10);
            valeurs.Add("medium", 20);
            valeurs.Add("high", 30);
            if (debutPeriode.Equals(new DateTime()) && finPeriode.Equals(new DateTime()))
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
                    donnee.Add("date", dateRapport);
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

        public Dictionary<int, Dictionary<string, dynamic>> ObtenirDonneesTableau(DateTime debutPeriode, DateTime finPeriode)
        {
           
            if (debutPeriode.Equals(new DateTime()) && finPeriode.Equals(new DateTime()))
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
                    donnee.Add("date", dateRapport);
                    donnee.Add("quality", data.etat.libelle.ToLower());
                    donnee.Add("performance", data.etat1.libelle.ToLower());
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

        public void ImporterFichier(string cheminDossier)
        {
            
        }

    }
}
