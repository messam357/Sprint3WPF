using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFITF;
using MECMOD;
using PARTITF;
using System.Windows;


namespace Sprint3WPF
{
    class CatiaConnectionRechteckrohrprofil
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
                hsp_catiaApp = (INFITF.Application)catiaObject;
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Um die Catia-Erweiterung zu starten, bitte CATIA V5 starten");
                return false;
            }
        }

        // CAT datei öffnen 
        public void openFile()
        {

            hsp_catiaPart = (PartDocument)hsp_catiaApp.Documents.Open(@"C:\Users\Thomas\source\repos\Sprint3WPF\Sprint3WPF\bin\Debug\Rechteckrohrprofil.CATPart");



        }


        public void changeUserParameter(double parameterWert, double parameterWert2, double parameterWert3, double parameterWert4)
        {

            KnowledgewareTypeLib.Parameters paras = hsp_catiaPart.Part.Parameters;





            // Parameter ändern : Variante 2 - direkter Zugriff auf die komplexe Datenstruktur
            KnowledgewareTypeLib.Dimension paraDim2 = paras.GetItem("Breite") as KnowledgewareTypeLib.Dimension;
            paraDim2.Value = parameterWert;

            KnowledgewareTypeLib.Dimension paraDim3 = paras.GetItem("Hoehe") as KnowledgewareTypeLib.Dimension;
            paraDim3.Value = parameterWert2;

            KnowledgewareTypeLib.Dimension paraDim4 = paras.GetItem("Dicke") as KnowledgewareTypeLib.Dimension;
            paraDim4.Value = parameterWert3;
            
            KnowledgewareTypeLib.Dimension paraDim5 = paras.GetItem("Laenge") as KnowledgewareTypeLib.Dimension;
            paraDim5.Value = parameterWert4;

            hsp_catiaPart.Part.Update();
        }
    }
}
