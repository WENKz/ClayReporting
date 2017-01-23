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
            Rapports = new DARapport(Context);
            Etats = new DAEtat(Context);
            Couleurs = new DACouleur(Context);
            Composants = new DAComposant(Context);
        }
        public void SauvegarderChangement()
        {
            Context.SaveChanges();
        }
    }
}
