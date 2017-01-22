using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayReporting.DataAcces.DAS
{
    public class DAEtat
    {
        private clayreportingEntities Context;

        public DAEtat(clayreportingEntities context)
        {
            Context = context;
        }
        public etat ObtenirEtatParId(int id)
        {
            return Context.etat.FirstOrDefault(e => e.id == id);
        }
    }
}
