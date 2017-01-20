using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClayReporting.DataAcces.Modeles
{
    public class DataExport
    {
        [XmlIgnore]
        public int id { get; set; }

        [XmlIgnore]
        public Nullable<int> lot { get; set; }
        [XmlIgnore]
        public Nullable<int> id_composant { get; set; }
        [XmlIgnore]
        public virtual composant composant { get; set; }
        [XmlIgnore]
        public Nullable<int> id_couleur { get; set; }
        [XmlIgnore]
        public virtual couleur couleur { get; set; }
        [XmlIgnore]
        public Nullable<int> id_etat { get; set; }
        [XmlIgnore]
        public virtual etat etat { get; set; }
        [XmlIgnore]
        public Nullable<int> id_etat_1 { get; set; }
        [XmlIgnore]
        public virtual etat etat1 { get; set; }
        

        public DataExport() 
        {
            this.lot = 0;
            this.composant = new composant();
            this.couleur = new couleur();
            this.etat = new etat();
            this.etat1 = new etat();
            
        }

        [NotMapped]
        [XmlAttribute("lot")]
        public int ValeurLot
        {
            get
            {
                if (lot.HasValue)
                {
                    return lot.Value;
                }
                else 
                {
                    return 0;
                }
            }

            set 
            {
                lot = value;
            }
        }

        
        [NotMapped]
        [XmlElement("component")]
        public string ComponentLibelle
        {
            get
            {
                return composant.libelle;
            }

            set
            {
                composant = new composant() { libelle = value };
            }
        }

        [NotMapped]
        [XmlElement("colorbound")]
        public string ColorboundLibelle
        {
            get
            {
                return couleur.libelle;
            }

            set
            {
                couleur = new couleur() { libelle = value };
            }
        }

        [NotMapped]
        [XmlElement("quality")]
        public string QualiteLibelle
        {
            get
            {
                return etat.libelle;
            }

            set
            {
                etat = new etat() { libelle = value };
            }
        }

        [NotMapped]
        [XmlElement("performance")]
        public string PerformanceLibelle
        {
            get
            {
                return etat1.libelle;
            }

            set
            {
                etat1 = new etat() { libelle = value };
            }
        }
    }
}
