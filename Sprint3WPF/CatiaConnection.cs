using System;
using System.Windows;
using INFITF;
using MECMOD;
using PARTITF;
//using CATMat;
//using SAMITF;


namespace Sprint3WPF
{
    public class CatiaConnection
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
                return false;
            }
        }

        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;
            return true;
        }

        public void ErstelleLeereSkizze()
        {
            // geometrisches Set auswaehlen und umbenennen
            HybridBodies catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaProfil.SetAbsoluteAxisData(arr);
        }

        public void ErzeugeProfil(Double b, Double h)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Rechteck");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-50, 50);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(50, 50);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(50, -50);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-50, -50);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(-50, 50, 50, 50);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(50, 50, 50, -50);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(50, -50, -50, -50);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-50, -50, -50, 50);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        } 





        
        // Zuweisung des Materials: Das war tricky...
      /*  public void setMaterial()
        {
            // https://ww3.cad.de/foren/ubb/Forum137/HTML/001194.shtml

            // API Docu:
            // Applying or Retrieving a Material on a Product, a Part, or a Body

            // "C:\Program Files\Dassault Systemes\B28\win_b64\startup\materials\German\Catalog.CATMaterial"
            // using CATMat; nicht vergessen

            String sFilePath = @"C:\Program Files\Dassault Systemes\B28\win_b64\startup\materials\German\Catalog.CATMaterial";
            MaterialDocument oMaterial_document = (MaterialDocument)hsp_catiaApp.Documents.Open(sFilePath);
            MaterialFamilies cFamilies_list = oMaterial_document.Families;
            
            foreach (MaterialFamily mf in cFamilies_list)
            {
                Console.WriteLine(mf.get_Name());
            }

            MaterialFamily myMf = cFamilies_list.Item("Metall");
            foreach (Material mat in myMf.Materials)
            {
                Console.WriteLine(mat.get_Name());
            }

            Material myStahl = myMf.Materials.Item("Stahl");

            MaterialManager partMatManager = hsp_catiaPart.Part.GetItem("CATMatManagerVBExt") as MaterialManager;

            // brauchen Sie Stahl im Part?
            short linkMode = 0;
            partMatManager.ApplyMaterialOnPart(hsp_catiaPart.Part, myStahl, linkMode);

            // brauchen Sie Stahl im Body?
            linkMode = 1;
            partMatManager.ApplyMaterialOnBody(hsp_catiaPart.Part.MainBody, myStahl, linkMode);
        } */

        public void ErzeugeBalken(Double l)
        {
            // Hauptkoerper in Bearbeitung definieren
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, l);

            // Block umbenennen
            catPad1.set_Name("Balken");

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        } 
        



        // Zur Erstellung eines Screenshots mit weißem Hintergrund
       /* public void Screenshot(string bildname)
        {

            object[] arr1 = new object[3];
            hsp_catiaApp.ActiveWindow.ActiveViewer.GetBackgroundColor(arr1);
            Console.WriteLine("Col: " + arr1[0] + " " + arr1[1] + " " + arr1[2]);
            
            object[] arr2 = new object[] { 1, 1, 1 };
            hsp_catiaApp.ActiveWindow.ActiveViewer.PutBackgroundColor(arr2);

            hsp_catiaApp.StartCommand("CompassDisplayOff");
            hsp_catiaApp.ActiveWindow.ActiveViewer.Reframe();

            // hsp_catiaApp.ActiveWindow.ActiveViewer.Viewpoint3D = INFITF.Viewpoint3D;
            //int[] color = new int[3]; // Hintergundfarbe in Weiß setzen
            //color[0] = 1;
            //color[1] = 1;
            //color[2] = 1;
            // CATSafeArray color[] = new CATSafeArrayVariant[3];

            INFITF.SettingControllers settingControllers1 = hsp_catiaApp.SettingControllers;
            //INFITF.VisualizationSettingAtt visualizationSettingAtt1 = settingControllers1.Item("CATVizVisualizationSettingCtrl");

            // hsp_catiaApp.ActiveWindow.ActiveViewer.PutBackgroundColor(color);

            hsp_catiaApp.ActiveWindow.ActiveViewer.CaptureToFile(CatCaptureFormat.catCaptureFormatBMP, "C:\\Temp\\" + bildname + ".bmp");
        } */

        // Öffnen einer bestehenden Datei in Catia
    


       /* public void changeUserParameter(double parameterWert)
        {
            // Neuen Parameter erzeugen
            KnowledgewareTypeLib.Dimension meineLaenge1 = hsp_catiaPart.Part.Parameters.CreateDimension("TestParameter", "LENGTH", 0.000000);
            meineLaenge1.Rename("CreatedDimension");
            meineLaenge1.Value = 42;

            // Parameter ändern : Variante 1 - mit foreach Schleife für die Suche
            // TestLaenge (Parameter in einer Datei) verändern
            KnowledgewareTypeLib.Parameters paras = hsp_catiaPart.Part.Parameters;

            MessageBox.Show(" " + paras.Count + " "); // Test: haben wir was gefunden? Wieviel?

            foreach (KnowledgewareTypeLib.Parameter para in paras)
            {
                if (para.get_Name().Contains("TestLaenge"))
                {
                    // Parameter können auch 
                    KnowledgewareTypeLib.Dimension paraDim = (KnowledgewareTypeLib.Dimension)para;
                    paraDim.Value = parameterWert;

                    MessageBox.Show("Gefunden: " + para.GetType() + " " + para.get_Name() + Environment.NewLine);
                }
            }

            // Parameter ändern : Variante 2 - direkter Zugriff auf die komplexe Datenstruktur
            KnowledgewareTypeLib.Dimension paraDim2 = paras.GetItem("TestLaenge") as KnowledgewareTypeLib.Dimension;
            paraDim2.Value = parameterWert+2;

        } 

        internal void FEM()
        {
            // Umgebung aktivieren
            PartDocument mydoc = (PartDocument)hsp_catiaApp.ActiveDocument;

            // INFITF.SpecsAndGeomWindow specsAndGeomWindow1 = (INFITF.SpecsAndGeomWindow) hsp_catiaApp.ActiveWindow;
            hsp_catiaApp.StartWorkbench("GPSCfg");

            AnalysisDocument analysisDocument1 = (AnalysisDocument) hsp_catiaApp.ActiveDocument;
            var analysisManager1 = analysisDocument1.Analysis;

            // Part laden
            object[] arrayOfVariantOfShort1 = new object[] { 0 };
            analysisManager1.ImportDefineFile(@"D:\Nextcloud\1_VL\HSP\So20\03_code\FEM\Part1.CATPart", "CATAnalysisImport", arrayOfVariantOfShort1);
            var analysisModels1 = analysisManager1.AnalysisModels;
            var analysisModel1 = analysisModels1.Item(1);

            // statische Analyse wählen
            analysisModel1.RunTransition("CATGPSStressAnalysis_template");
            var analysisCases1 = analysisModel1.AnalysisCases;
            var analysisCase1 = analysisCases1.Item(1);

            // verteilte Last aufbringen
            var analysisSets1 = analysisCase1.AnalysisSets;
            var analysisSet1 = analysisSets1.Item("Lasten.1", CATAnalysisSetSearchType.catAnalysisSetSearchAll);
            var analysisEntities1 = analysisSet1.AnalysisEntities;
            var analysisEntity1 = analysisEntities1.Add("SAMDistributedForce");
            var analysisLinkedDocuments1 = analysisManager1.LinkedDocuments;
            var partDocument1 = (PartDocument)analysisLinkedDocuments1.Item(1);

            ProductStructureTypeLib.Product product1 = partDocument1.Product;
            var part1 = partDocument1.Part;
            // Die folgede Reference ist abhängig von Ihrem Part - selbst rausfinden per Makrorekorder
            Reference reference1 = part1.CreateReferenceFromName("Selection_RSur:(Face:(Brp:(Pad.1;0:(Brp:(Sketch.1;3)));None:();Cf11:());Pad.1_ResultOUT;Last;Z0;G8226)");

            analysisEntity1.AddSupportFromProduct(product1, reference1);
            BasicComponents basicComponents1 = analysisEntity1.BasicComponents;
            BasicComponent basicComponent1 = (BasicComponent) basicComponents1.GetItem("SAMForceAxis.1");
            basicComponent1.SetValue("Values", 0, 0, 0, 1);

            BasicComponent basicComponent2 = (BasicComponent) basicComponents1.GetItem("SAMForceVector.1");
            basicComponent2.SetDimensions(3, 1, 1);
            basicComponent2.SetValue("Values", 1, 1, 1, 0.000000);
            basicComponent2.SetValue("Values", 2, 1, 1, 0.000000);
            basicComponent2.SetValue("Values", 3, 1, 1, 1000.000000);

            // Festlager definieren
            AnalysisSet analysisSet2 = (AnalysisSet)analysisSets1.Item("Randbedingungen.1", CATAnalysisSetSearchType.catAnalysisSetSearchAll);
            var analysisEntities2 = analysisSet2.AnalysisEntities;
            var analysisEntity2 = analysisEntities2.Add("SAMClamp");
            partDocument1 = (PartDocument)analysisLinkedDocuments1.Item(1);
            product1 = partDocument1.Product;
            var reference2 = part1.CreateReferenceFromName("Selection_RSur:(Face:(Brp:(Pad.1;1);None:();Cf11:());Pad.1_ResultOUT;Last;Z0;G8226)");
            analysisEntity2.AddSupportFromProduct(product1, reference2);

            // Berechnung tarten
            analysisCase1.Compute();

            var analysisSet3 = analysisSets1.Item("Lösung für statischen Prozess.1", CATAnalysisSetSearchType.catAnalysisSetSearchAll);
            var analysisImages1 = analysisSet3.AnalysisImages;
            var analysisImage1 = analysisImages1.Add("StressVonMises_Iso_Smooth", true, false, false);

            INFITF.Window specsAndGeomWindow1 = hsp_catiaApp.ActiveWindow;
            var viewer3D1 = specsAndGeomWindow1.ActiveViewer;
            viewer3D1.Reframe();
        }
        */

    }
}
