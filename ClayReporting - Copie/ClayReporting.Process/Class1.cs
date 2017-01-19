using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClayReporting.DataAcces.Modeles;
using System.IO;
using System.Reflection;
using ClayReporting.DataAcces;

namespace ClayReporting.Process
{
    public class Class1
    {

        public void test()
        {


            clayreportingEntities Context = new clayreportingEntities();

            List<rapport> rapport = Context.rapport.ToList();
            ManipulateurXML xml = new ManipulateurXML();
            List<data> datas = new List<data>();
            datas.Add(new data() { couleur = new couleur() { libelle = "green" }, composant = new composant() { libelle = "toto" } });
            datas.Add(new data() { couleur = new couleur() { libelle = "red" }, composant = new composant() { libelle = "titi" } });
            DateTime Date = new DateTime(2016, 02, 03);
            rapport objet = new rapport() {data = datas ,dateTime = Date };
            xml.Ecrire(objet, typeof(rapport), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.xml"));

            RapportMois rm = new RapportMois();
            List<DataExport> de = datas.Select(d => new DataExport { couleur = d.couleur,composant = d.composant, etat1 = d.etat1,etat = d.etat }).ToList();
            RapportExport re = new RapportExport();
            re.data = de;
            rm.Rapports.Add(new RapportExport(re));
            objet.dateTime = new DateTime(2020, 04, 04);
            rm.Rapports.Add(new RapportExport(re));
            objet.dateTime = new DateTime(2100, 06, 06);
            rm.Rapports.Add(new RapportExport(re));

            xml.Ecrire(rm, typeof(RapportMois), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rm.xml"));
            rapport r = xml.Lire(typeof(rapport), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xmlType.xml"));
            Context.rapport.Add(r);
            Context.SaveChanges();
            //rapport r = xml.Lire(typeof(rapport), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.xml"));
        }
    }
}