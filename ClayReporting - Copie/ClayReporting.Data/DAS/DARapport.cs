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
        private ClayReportingEntities Context;

        public DARapport(ClayReportingEntities context)
        {
            Context = context;
            List<etat> etats = Context.etat.ToList();
            Context.Configuration.ProxyCreationEnabled = true;
        }

        public List<rapport> getAllRapportInPeriod(DateTime start, DateTime end)
        {
            return Context.rapport.Where(r => r.dateTime.Value >= start && r.dateTime.Value <= end).ToList();
        }
    }
}
