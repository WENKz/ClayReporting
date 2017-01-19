using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayReporting.Process
{
    public class ManipulateurXML
    {
        public ManipulateurXML() 
        {
        
        }

        public dynamic Lire(Type type, string chemin)
        {
            System.Xml.Serialization.XmlSerializer lecteur = new System.Xml.Serialization.XmlSerializer(type);
            System.IO.StreamReader fichier = new System.IO.StreamReader(chemin);
            var overview2 = lecteur.Deserialize(fichier);
            fichier.Close();
            return Convert.ChangeType(overview2, type);
        }

        public void Ecrire(dynamic objet, Type type, string chemin)
        {
            System.Xml.Serialization.XmlSerializer Ecriveur = new System.Xml.Serialization.XmlSerializer(type);
            System.IO.FileStream fichier = System.IO.File.Create(chemin);
            Ecriveur.Serialize(fichier, Convert.ChangeType(objet, type));
            fichier.Close();
        }
    }
}
