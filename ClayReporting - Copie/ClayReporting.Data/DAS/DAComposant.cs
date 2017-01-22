using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayReporting.DataAcces.DAS
{
    class DAComposant
    {
        private clayreportingEntities Context;

        public DAComposant(clayreportingEntities context)
        {
            Context = context;
        }

        public composant ObtenirComposantParId(int id)
        {
            return Context.composant.FirstOrDefault(c => c.id == id);
        }
    }
}
