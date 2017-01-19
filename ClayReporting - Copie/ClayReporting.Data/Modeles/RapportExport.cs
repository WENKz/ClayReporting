using ClayReporting.DataAcces.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClayReporting.DataAcces.Modeles
{
    [XmlRoot("datas")]
    public class RapportExport : RapportBase
    {
        [XmlElement("data")]
        public List<DataExport> data { get; set; }

        public RapportExport() 
        {
            dateTime = new DateTime();
        }

        public RapportExport(RapportExport rapport)
        {
            dateTime = rapport.dateTime;
            data = rapport.data;
        }
    }
}
