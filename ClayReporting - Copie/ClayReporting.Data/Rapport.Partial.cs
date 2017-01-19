using ClayReporting.DataAcces.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClayReporting.DataAcces
{
    public partial class rapport : RapportBase
    {
        public rapport(rapport rapport) 
        {
            id = rapport.id;
            dateTime = rapport.dateTime;
            data = rapport.data;


        }

        

    }
}
