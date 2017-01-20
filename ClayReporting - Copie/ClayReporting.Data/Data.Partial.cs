using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClayReporting.DataAcces
{
    public partial class data 
    {
        [XmlIgnore]
        public Nullable<int> offset { get; set; }
        [XmlIgnore]
        public Nullable<int> pressure { get; set; }
        [XmlIgnore]
        public Nullable<int> layout { get; set; }
        [XmlIgnore]
        public Nullable<bool> result { get; set; }
        //public Nullable<int> lot { get; set; }
        [XmlIgnore]
        public Nullable<int> timecode { get; set; }

        [NotMapped]
        [XmlAttribute("timecode")]
        public int ValeurTimecode
        {
            get
            {
                if (timecode.HasValue)
                {
                    return timecode.Value;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                timecode = value;
            }
        }

        [XmlElement("offset")]
        public int ValeurOffset
        {
            get
            {
                if (this.offset.HasValue)
                {
                    return offset.Value;
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                offset = value;
            }
        }

        [XmlElement("pressure")]
        public int ValeurPressure
        {
            get
            {
                if (pressure.HasValue)
                {
                    return offset.Value;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                pressure = value;
            }
        }

        [XmlElement("layout")]
        public int ValeurLayout
        {
            get
            {
                if (layout.HasValue)
                {
                    return layout.Value;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                layout = value;
            }
        }

        [XmlElement("result")]
        public int ValeurResult
        {
            get
            {
                if (result.HasValue)
                {
                    if (result.Value.Equals(true))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                result = Convert.ToBoolean(value);
            }
        }
    }
}
