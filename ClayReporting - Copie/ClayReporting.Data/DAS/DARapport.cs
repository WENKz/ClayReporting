using ClayReporting.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayReporting.DataAcces.DAS
{
    public class DARapport
    {
        private clayreportingEntities Context;

        public DARapport(clayreportingEntities context)
        {
            Context = context;
        }

        public List<rapport> getAllRapportInPeriod(DateTime start, DateTime end)
        {
            List<rapport> rapports =  Context.rapport.Where(r => r.dateTime.Value >= start && r.dateTime.Value <= end).ToList();
            DAEtat daEtat = new DAEtat(Context);
            DACouleur daCouleur = new DACouleur(Context);
            DAComposant daComposant = new DAComposant(Context);
            rapports.ForEach(delegate(rapport rap) 
            {
                rap.data.ForEach(delegate (data data) 
                {
                    data.etat = daEtat.ObtenirEtatParId(data.id_etat.Value);
                    data.etat1 = daEtat.ObtenirEtatParId(data.id_etat_1.Value);
                    data.composant = daComposant.ObtenirComposantParId(data.id_composant.Value);
                    data.couleur = daCouleur.ObtenirCouleurParId(data.id_couleur.Value);
                });
            });
            return rapports; 
        }

        public void AjouterRapport(rapport rapport)
        {
            Context.rapport.Add(rapport);
        }
    }
}
