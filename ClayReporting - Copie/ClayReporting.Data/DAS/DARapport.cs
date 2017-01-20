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
            rapports.ForEach(delegate(rapport rap) 
            {
                rap.data.ForEach(delegate (data data) 
                {
                    data.etat = Context.etat.FirstOrDefault(e => e.id == data.id_etat);
                    data.etat1 = Context.etat.FirstOrDefault(e => e.id == data.id_etat_1);
                    data.composant = Context.composant.FirstOrDefault(c => c.id == data.id_composant);
                    data.couleur = Context.couleur.FirstOrDefault(c => c.id == data.id_couleur);
                });
            });
            return rapports; 
        }
    }
}
