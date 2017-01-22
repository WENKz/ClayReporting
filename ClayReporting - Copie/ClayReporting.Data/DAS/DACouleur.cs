using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayReporting.DataAcces.DAS
{
    public class DACouleur
    {
        private clayreportingEntities Context;

        public DACouleur(clayreportingEntities context)
        {
            Context = context;
        }

        public couleur ObtenirCouleurParId(int id)
        {
            return Context.couleur.FirstOrDefault(c => c.id == id);
        }
    }
}
