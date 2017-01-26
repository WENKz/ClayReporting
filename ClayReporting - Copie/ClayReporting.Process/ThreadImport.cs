using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClayReporting.DataAcces;
using System.IO;
namespace ClayReporting.Process
{
    public class ThreadImport
    {
        private volatile bool arreter = false;
        public void Import()
        {
            while (!arreter)
            {
                if (true)
                {
                    string cheminDossier = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imports");
                    ManipulateurXML xml = new ManipulateurXML();
                    ManageurDA mda = new ManageurDA();
                    /*DirectoryInfo d = new DirectoryInfo(cheminDossier);
                    FileSystemInfo[] f =  d.GetFileSystemInfos();*/
                    if(!Directory.Exists(cheminDossier))
                    {
                        Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imports"));
                    }
                    string[] listeFichier = Directory.GetFiles(cheminDossier, "*.xml");
                    if (listeFichier.Count() > 0)
                    {
                        List<string> listeOk = new List<string>();
                        foreach (string nomfichier in listeFichier)
                        {
                            rapport rapport = xml.Lire(typeof(rapport), nomfichier);
                            try
                            {
                                mda.Rapports.AjouterRapport(rapport);
                                listeOk.Add(nomfichier);  
                            }
                            catch (Exception e)
                            {

                            }
                        }
                        mda.SauvegarderChangement();
                        foreach (string nomfichier in listeOk)
                        {
                            File.Delete(nomfichier);
                        }
                    }
                }
                else
                {
                    Arret();
                }
            }
        }
        public void Arret()
        {
            arreter = true;
        }
    }
}
