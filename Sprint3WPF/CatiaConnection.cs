using System;
using System.Windows;
using INFITF;
using MECMOD;
using PARTITF;
//using CATMat;
//using SAMITF;


namespace Sprint3WPF
{
    public class CatiaConnectionRechteckProfil
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPart;
        MECMOD.Sketch hsp_catiaProfil;
        
        public bool CATIALaeuft()
        {
            try
            {
                object catiaObject = System.Runtime.InteropServices.Marshal.GetActiveObject(
                    "CATIA.Application");
                hsp_catiaApp = (INFITF.Application) catiaObject;
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Um die Catia-Erweiterung zu starten, bitte CATIA V5 starten");
                return false;

            }
        }

        


       

        // Öffnen einer bestehenden Datei in Catia
        public void openFile()
        {
            hsp_catiaPart = (PartDocument)hsp_catiaApp.Documents.Open(@"C:\Users\Thomas\source\repos\Sprint3WPF\Sprint3WPF\bin\Debug\Rechteckprofil.CATPart");
        }


        public void changeUserParameter(double parameterWert, double parameterWert2, double parameterWert3)
        {
           
            KnowledgewareTypeLib.Parameters paras = hsp_catiaPart.Part.Parameters;

            // Parameter ändern : Variante 2 - direkter Zugriff auf die komplexe Datenstruktur
            KnowledgewareTypeLib.Dimension paraDim2 = paras.GetItem("Breite") as KnowledgewareTypeLib.Dimension;
            paraDim2.Value = parameterWert;

            KnowledgewareTypeLib.Dimension paraDim3 = paras.GetItem("Laenge") as KnowledgewareTypeLib.Dimension;
            paraDim3.Value = parameterWert2;

            KnowledgewareTypeLib.Dimension paraDim4 = paras.GetItem("Tiefe") as KnowledgewareTypeLib.Dimension;
            paraDim4.Value = parameterWert3;

            hsp_catiaPart.Part.Update();
            

        } 
    }
}
