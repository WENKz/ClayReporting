using ClayReporting.DataAcces;
using ClayReporting.DataAcces.Modeles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClayReporting.Process
{
    [XmlRoot]
    public class RapportMois
    {
        [XmlIgnore]
        public DateTime startDayMonth { get; set; }

        [XmlAttribute("debutPeride")]
        public string DateDebutPeriode
        {
            get
            {
                return startDayMonth.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            set
            {
                startDayMonth = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        [XmlIgnore]
        public DateTime endDayMonth { get; set; }

        [XmlAttribute("finPeriode")]
        public string DateFintPeriode
        {
            get
            {
                return endDayMonth.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            set
            {
                endDayMonth = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        [XmlElement("rapport")]
        public List<RapportExport> Rapports { get; set; }



        public RapportMois()
        {
            startDayMonth = Convert.ToDateTime("1/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            endDayMonth = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            Rapports = new List<RapportExport>();
        }
    }
}
