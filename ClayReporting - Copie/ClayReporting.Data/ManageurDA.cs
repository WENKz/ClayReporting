using ClayReporting.DataAcces;
using ClayReporting.DataAcces.DAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayReporting.DataAcces
{
    public class ManageurDA
    {
        private clayreportingEntities Context = new clayreportingEntities();
        public DARapport Rapports { get; set; }
        public DAEtat Etats { get; set; }
        public DAComposant Composants { get; set; }
        public DACouleur Couleurs { get; set; }
        public ManageurDA()
        {
            clayreportingEntities context = new clayreportingEntities();
            Rapports = new DARapport(context);
            Etats = new DAEtat(context);
            Couleurs = new DACouleur(context);
            Composants = new DAComposant(context);
        }
        public void SauvegarderChangement()
        {
            Context.SaveChanges();
        }
    }
}
