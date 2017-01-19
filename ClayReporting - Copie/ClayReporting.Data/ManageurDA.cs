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
        public DARapport Rapports { get; set; }

        public ManageurDA()
        {
            ClayReportingEntities context = new ClayReportingEntities();
            Rapports = new DARapport(context);

        }
    }
}
