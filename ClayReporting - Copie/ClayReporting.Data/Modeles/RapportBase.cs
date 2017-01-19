using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClayReporting.DataAcces.Modeles
{
    public class RapportBase
    {
        [XmlIgnore]
        public Nullable<System.DateTime> dateTime { get; set; }

        [NotMapped]
        [XmlAttribute("date")]
        public string DateJour
        {
            get
            {
                return dateTime.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            set
            {
                dateTime = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }
    }
}
