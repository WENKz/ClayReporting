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
        public Dictionary<int, Dictionary<string, dynamic>> ObtenirDonneesGraphique(DateTime debutPeriode, DateTime finPeriode)
        {
            Dictionary<string, int> valeurs = new Dictionary<string, int>();
            valeurs.Add("low", 10);
            valeurs.Add("medium", 20);
            valeurs.Add("high", 30);

            if (debutPeriode == new DateTime() && finPeriode == new DateTime())
            {
                debutPeriode = Convert.ToDateTime("1/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                finPeriode = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            }
            Dictionary<int, Dictionary<string, dynamic>> donnees = new Dictionary<int, Dictionary<string, dynamic>>();

            List<rapport> rapports = new ManageurDA().Rapports.getAllRapportInPeriod(debutPeriode, finPeriode);

            int i = 0;
            rapports.ForEach(delegate (rapport rapportExp)
            {

                rapportExp.data.ForEach(delegate (data data)
                {
                    Dictionary<string, dynamic> donnee = new Dictionary<string, dynamic>();
                    donnee.Add("quality", valeurs[data.etat.libelle.ToLower()]);
                    donnee.Add("performance", valeurs[data.etat1.libelle.ToLower()]);
                    donnee.Add("couleur", data.couleur.libelle);
                    donnee.Add("composant", data.composant.libelle);
                    donnee.Add("layout", data.layout);
                    donnee.Add("lot", data.lot);

                    donnees.Add(i, donnee);
                    i++;
                });
            });
            return donnees;
        }

        public List<RapportExport> ObtenirRapportExportDeLaPeriode(DateTime debutPeriode, DateTime finPeriode)
        {

            return new ManageurDA().Rapports.getAllRapportInPeriod(debutPeriode, finPeriode)
                       .Select(r => new RapportExport()
                       {
                           data = r.data.Select(d =>
                               new DataExport()
                               {
                                   lot = d.lot,
                                   etat1 = d.etat1,
                                   etat = d.etat,
                                   composant = d.composant,
                                   couleur = d.couleur,
                               })
                               .ToList(),
                           dateTime = r.dateTime,
                       })
                       .ToList();
        }
    }
}
