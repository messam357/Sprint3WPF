using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sprint3WPF.Properties;


namespace Sprint3WPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private double _matKonst = 0;

        private void Rechteckprofil_selected(object sender, RoutedEventArgs e)
        {
            RechteckProfil_Grid.Visibility = Visibility.Visible;
            Rundprofil_Grid.Visibility = Visibility.Hidden;
            Rohrprofil_Grid.Visibility = Visibility.Hidden;
            Rechteckrohrprofil_Grid.Visibility = Visibility.Hidden;
            Tprofil_Grid.Visibility = Visibility.Hidden;
            btn_brechnung_Rechteckprofil.Visibility = Visibility.Visible;
            btn_brechnung_rundprofil.Visibility = Visibility.Hidden;
            btn_berechnung_rohrprofil.Visibility = Visibility.Hidden;
            btn_berechnung_rechteckrohrprofil.Visibility = Visibility.Hidden;
            btn_brechnung_Tprofil.Visibility = Visibility.Hidden;



        }

        private void Rundprofil_selected(object sender, RoutedEventArgs e)
        {
            RechteckProfil_Grid.Visibility = Visibility.Hidden;
            Rundprofil_Grid.Visibility = Visibility.Visible;
            Rohrprofil_Grid.Visibility = Visibility.Hidden;
            Rechteckrohrprofil_Grid.Visibility = Visibility.Hidden;
            Tprofil_Grid.Visibility = Visibility.Hidden;
            btn_brechnung_Rechteckprofil.Visibility = Visibility.Hidden;
            btn_brechnung_rundprofil.Visibility = Visibility.Visible;
            btn_berechnung_rohrprofil.Visibility = Visibility.Hidden;
            btn_berechnung_rechteckrohrprofil.Visibility = Visibility.Hidden;
            btn_brechnung_Tprofil.Visibility = Visibility.Hidden;
        }

        private void Rohrprofil_selected(object sender, RoutedEventArgs e)
        {
            RechteckProfil_Grid.Visibility = Visibility.Hidden;
            Rundprofil_Grid.Visibility = Visibility.Hidden;
            Rohrprofil_Grid.Visibility = Visibility.Visible;
            Rechteckrohrprofil_Grid.Visibility = Visibility.Hidden;
            Tprofil_Grid.Visibility = Visibility.Hidden;
            btn_brechnung_Rechteckprofil.Visibility = Visibility.Hidden;
            btn_brechnung_rundprofil.Visibility = Visibility.Hidden;
            btn_berechnung_rohrprofil.Visibility = Visibility.Visible;
            btn_berechnung_rechteckrohrprofil.Visibility = Visibility.Hidden;
            btn_brechnung_Tprofil.Visibility = Visibility.Hidden;
        }

        private void Rechteckrohrprofil_selected(object sender, RoutedEventArgs e)
        {
            RechteckProfil_Grid.Visibility = Visibility.Hidden;
            Rundprofil_Grid.Visibility = Visibility.Hidden;
            Rohrprofil_Grid.Visibility = Visibility.Hidden;
            Rechteckrohrprofil_Grid.Visibility = Visibility.Visible;
            Tprofil_Grid.Visibility = Visibility.Hidden;
            btn_brechnung_Rechteckprofil.Visibility = Visibility.Hidden;
            btn_brechnung_rundprofil.Visibility = Visibility.Hidden;
            btn_berechnung_rohrprofil.Visibility = Visibility.Hidden;
            btn_berechnung_rechteckrohrprofil.Visibility = Visibility.Visible;
            btn_brechnung_Tprofil.Visibility = Visibility.Hidden;
        }

        private void Tprofil_Selected(object sender, RoutedEventArgs e)
        {
            RechteckProfil_Grid.Visibility = Visibility.Hidden;
            Rundprofil_Grid.Visibility = Visibility.Hidden;
            Rohrprofil_Grid.Visibility = Visibility.Hidden;
            Rechteckrohrprofil_Grid.Visibility = Visibility.Hidden;
            Tprofil_Grid.Visibility = Visibility.Visible;
            btn_brechnung_Rechteckprofil.Visibility = Visibility.Hidden;
            btn_brechnung_rundprofil.Visibility = Visibility.Hidden;
            btn_berechnung_rohrprofil.Visibility = Visibility.Hidden;
            btn_berechnung_rechteckrohrprofil.Visibility = Visibility.Hidden;
            btn_brechnung_Tprofil.Visibility = Visibility.Visible;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        // Rechteckprofil Ausfuehrung Berechnung
        public void btn_brechnung_Rechteckprofil_Click(object sender, RoutedEventArgs e)
        {

            bool checkmate = false;
            do
            {
                try
                {

                    double Breite = double.Parse(txtbox_rechteckprofil_b.Text);
                    double Hoehe = double.Parse(txtbox_rechteckprofil_h.Text);
                    double Laenge = double.Parse(txtbox_rechteckprofil_l.Text);

                    if (Breite <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Breite muss größer als 0 sein!");
                        checkmate = false;
                        Breite = 0;
                        Hoehe = 0;
                        Laenge = 0;
                    }

                    if (Hoehe <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Hoehe muss größer als 0 sein!");
                        checkmate = false;
                        Hoehe = 0;
                        Breite = 0;
                        Laenge = 0;
                    }

                    if (Laenge <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Laenge muss größer als 0 sein!");
                        checkmate = false;
                        Laenge = 0;
                        Breite = 0;
                        Hoehe = 0;
                    }

                    txtVolumen.Text = (berechnungVolumen_Rechteckprofil(Breite, Hoehe, Laenge) + "mm³");
                    txtIXX.Text = (berechnungIXX_Rechteckprofil(Breite, Hoehe) + "mm^4");
                    txtIYY.Text = (berechnungIYY_Rechteckprofil(Breite, Hoehe) + "mm^4");
                    txtWXX.Text = (berechnungWXX_Rechteckprofil(Breite, Hoehe) + "mm^4");
                    txtWYY.Text = (berechnungWYY_Rechteckprofil(Breite, Hoehe) + "mm^4");
                    SchwerpunktX.Text = (berechnungSchwerpunktX_Rechteckprofil(Breite) + "mm");
                    SchwerpunktY.Text = (berechnungSchwerpunktY_Rechteckprofil(Hoehe) + "mm");
                    txtMasse.Text = (berechnungGewicht_Rechteckprofil(Breite, Hoehe, Laenge) + "g");
                    new CatiaControl(Breite, Hoehe, Laenge);
                   


                }

                catch (FormatException)
                {

                    MessageBox.Show("Error! Keine Buchstaben eingeben!");
                }
            }
            while (checkmate);
        }
        // Berechnung
        public double berechnungVolumen_Rechteckprofil(double Breite, double Hoehe, double Laenge)
        {
            double Volumen_Rechteckprofil =Math.Round( Breite * Hoehe * Laenge,3);


            return Volumen_Rechteckprofil;
        }

        public double berechnungIXX_Rechteckprofil(double Breite, double Hoehe)
        {
            double IXX_Rechteckprofil =Math.Round( (Breite * (Math.Pow(Hoehe, 3)) / 12),3);

            return IXX_Rechteckprofil;
        }

        public double berechnungIYY_Rechteckprofil(double Breite, double Hoehe)
        {
            double IYY_Rechteckprofil = Math.Round((Hoehe * (Math.Pow(Breite, 3)) / 12),3);

            return IYY_Rechteckprofil;
        }

        public double berechnungWXX_Rechteckprofil(double Breite, double Hoehe)
        {
            double WXX_Rechteckprofil = Math.Round((Breite * (Math.Pow(Hoehe, 2)) / 6),3);

            return WXX_Rechteckprofil;
        }

        public double berechnungWYY_Rechteckprofil(double Breite, double Hoehe)
        {
            double WYY_Rechteckprofil = Math.Round((Hoehe * (Math.Pow(Breite, 2)) / 6),3);
            
            return WYY_Rechteckprofil;
        }

        public double berechnungGewicht_Rechteckprofil(double Breite, double Hoehe, double Laenge)
        {
            double Gewicht_Rechteckprofil = Math.Round(((Breite * Hoehe * Laenge) * _matKonst),3);

            return Gewicht_Rechteckprofil;
        }

        public double berechnungSchwerpunktX_Rechteckprofil(double Breite)
        {
            double SchwerpunktX_Rechteckprofil = Math.Round((Breite / 2),3);

            return SchwerpunktX_Rechteckprofil;
        }

        public double berechnungSchwerpunktY_Rechteckprofil(double Hoehe)
        {
            double SchwerpunktY_Rechteckprofil = Math.Round((Hoehe / 2),3);

            return SchwerpunktY_Rechteckprofil;
        }


        // Rundprofil Ausfuehrung Berechnung
        public void btn_brechnung_Rundprofil_Click(object sender, RoutedEventArgs e)

        {

            bool checkmate = false;
            do
            {
                try
                {

                    double Durchmesser = double.Parse(txtbox_rundprofil_dm.Text);
                    double Laenge = double.Parse(txtbox_rundprofil_l.Text);

                    if (Durchmesser <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Breite muss größer als 0 sein!");
                        checkmate = false;
                        Durchmesser = 0;
                        Laenge = 0;
                    }

                    if (Laenge <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Laenge muss größer als 0 sein!");
                        checkmate = false;
                        Laenge = 0;
                        Durchmesser = 0;
                    }

                    txtVolumen.Text = (berechnungVolumen_Rundprofil(Durchmesser, Laenge) + "mm³");
                    txtIXX.Text = (berechnungIXX_Rundprofil(Durchmesser) + "mm");
                    txtIYY.Text = (berechnungIXX_Rundprofil(Durchmesser) + "mm");
                    txtWXX.Text = (berechnungWXX_Rundprofil(Durchmesser) + "mm");
                    txtWYY.Text = (berechnungWXX_Rundprofil(Durchmesser) + "mm");
                    txtMasse.Text = (berechnungGewicht_Rundprofil(Durchmesser, Laenge) + "g");
                    SchwerpunktX.Text = (berechnungSchwerpunktX_Rundprofil(Durchmesser) + "mm");
                    SchwerpunktY.Text = (berechnungSchwerpunktX_Rundprofil(Durchmesser) + "mm");
                    new CatiaControlRundprofil(Durchmesser, Laenge);

                }

                catch (FormatException)
                {

                    MessageBox.Show("Error! Keine Buchstaben eingeben!");
                }
            }
            while (checkmate);
        }
        public double berechnungVolumen_Rundprofil(double Durchmesser, double Laenge)
        {
            double Volumen_Rundprofil = Math.Round((((Math.PI * Math.Pow(Durchmesser, 2)) / 4) * Laenge),3);


            return Volumen_Rundprofil;
        }

        public double berechnungIXX_Rundprofil(double Durchmesser)
        {
            double IXX_Rundprofil = Math.Round(((Math.PI * Math.Pow(Durchmesser, 4)) / 64),3);

            return IXX_Rundprofil;
        }

        public double berechnungWXX_Rundprofil(double Durchmesser)
        {
            double WXX_Rundprofil = Math.Round(((Math.PI * Math.Pow(Durchmesser, 3)) / 3),3);

            return WXX_Rundprofil;
        }

        public double berechnungGewicht_Rundprofil(double Durchmesser, double Laenge)
        {
            double Gewicht = Math.Round(((((Math.PI * Math.Pow(Durchmesser, 2)) / 4) * Laenge) * _matKonst),3);

            return Gewicht;
        }


        public double berechnungSchwerpunktX_Rundprofil(double Durchmesser)
        {
            double SchwerpunktX = Math.Round(Durchmesser / 2,3);

            return SchwerpunktX;
        }

        //Rohrprofil Ausführung Berechnung

        public void btn_berechnung_Rohrprofil_Click(object sender, RoutedEventArgs e)
        {

            bool checkmate = false;
            do
            {
                try
                {

                    double Durchmesser = double.Parse(txtbox_rohrprofil_dm.Text);
                    double Laenge = double.Parse(txtbox_rohrprofil_l.Text);
                    double Dicke = double.Parse(txtbox_rohrprofil_d.Text);


                    if (Durchmesser <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Breite muss größer als 0 sein!");
                        checkmate = false;
                        Durchmesser = 0;
                        Laenge = 0;
                        Dicke = 0;
                    }

                    if (Laenge <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Laenge muss größer als 0 sein!");
                        checkmate = false;
                        Laenge = 0;
                        Durchmesser = 0;
                        Dicke = 0;

                    }

                    if (Dicke <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Dicke muss größer als 0 sein!");
                        checkmate = false;
                        Dicke = 0;
                        Durchmesser = 0;
                        Laenge = 0;
                    }



                    txtVolumen.Text = (berechnungVolumen_Rohrprofil(Durchmesser, Dicke, Laenge) + "mm³");
                    txtIXX.Text = (berechnungIXX_Rohrprofil(Durchmesser, Dicke) + "mm");
                    txtIYY.Text = (berechnungIXX_Rohrprofil(Durchmesser, Dicke) + "mm");
                    txtWXX.Text = (berechnungWXX_Rohrprofil(Durchmesser, Dicke) + "mm");
                    txtWYY.Text = (berechnungWXX_Rohrprofil(Durchmesser, Dicke) + "mm");
                    txtMasse.Text = (berechnungGewicht_Rundprofil(Durchmesser, Laenge) + "g");
                    SchwerpunktX.Text = (berechnungSchwerpunktX_Rohrprofil(Durchmesser) + "mm");
                    SchwerpunktY.Text = (berechnungSchwerpunktX_Rohrprofil(Durchmesser) + "mm");
                    new CatiaControlRohrprofil(Durchmesser, Dicke, Laenge);
                }

                catch (FormatException)
                {

                    MessageBox.Show("Error! Keine Buchstaben eingeben!");
                }
            }
            while (checkmate);

        }
        // Berechnung
        public double berechnungVolumen_Rohrprofil(double Durchmesser, double Dicke, double Laenge)
        {
            double Volumen_Rohrprofil = Math.Round((((Math.PI * Math.Pow(Durchmesser, 2)) / 4) - ((Math.PI * Math.Pow((Durchmesser - (2 * Dicke)), 2)) / 4)) * Laenge,3);


            return Volumen_Rohrprofil;
        }

        public double berechnungIXX_Rohrprofil(double Durchmesser, double Dicke)
        {
            double IXX_Rohrprofil = Math.Round((Math.PI * (Math.Pow(Durchmesser, 4)) - (Math.Pow((Durchmesser - (2 * Dicke)), 4))) / 64,3);

            return IXX_Rohrprofil;
        }

        public double berechnungWXX_Rohrprofil(double Durchmesser, double Dicke)
        {
            double WXX_Rohrprofil = Math.Round((Math.PI * (Math.Pow(Durchmesser, 4)) - (Math.Pow((Durchmesser - (2 * Dicke)), 4))) / 32,3);

            return WXX_Rohrprofil;
        }

        public double berechnungGewicht_Rohrprofil(double Durchmesser, double Dicke, double Laenge)
        {
            double Geweicht_Rohrprofil = Math.Round((((Math.PI * Math.Pow(Durchmesser, 2)) / 4) - ((Math.PI * Math.Pow((Durchmesser - (2 * Dicke)), 2)) / 4)) * Laenge * _matKonst,3);

            return Geweicht_Rohrprofil;
        }


        public double berechnungSchwerpunktX_Rohrprofil(double Durchmesser)
        {
            double SchwerpunktX = Math.Round(Durchmesser / 2,3);

            return SchwerpunktX;
        }

        // Rechteckrohr Ausführung Berechnung
        public void btn_berechnung_rechteckrohrprofil_Click(object sender, RoutedEventArgs e)
        {

            bool checkmate = false;
            do
            {
                try
                {

                    double Breite = double.Parse(txtbox_rechteckrohrprofil_b.Text);
                    double Hoehe = double.Parse(txtbox_rechteckrohrprofil_h.Text);
                    double Laenge = double.Parse(txtbox_rechteckrohrprofil_l.Text);
                    double Dicke = double.Parse(txt_rechteckrohrprofil_d.Text);

                    if (Breite <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Breite muss größer als 0 sein!");
                        checkmate = false;
                        Breite = 0;
                        Hoehe = 0;
                        Laenge = 0;
                        Dicke = 0;
                    }

                    if (Hoehe <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Höhe muss größer als 0 sein!");
                        checkmate = false;
                        Hoehe = 0;
                        Breite = 0;
                        Laenge = 0;
                        Dicke = 0;
                    }

                    if (Laenge <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Laenge muss größer als 0 sein!");
                        checkmate = false;
                        Laenge = 0;
                        Breite = 0;
                        Hoehe = 0;
                        Dicke = 0;


                    }

                    if (Dicke <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Dicke muss größer als 0 sein!");
                        checkmate = false;
                        Dicke = 0;
                        Breite = 0;
                        Hoehe = 0;
                        Laenge = 0;
                    }



                    txtVolumen.Text = (berechnungVolumen_Rechteckrohrprofil(Breite, Hoehe, Dicke, Laenge) + "mm³");
                    txtIXX.Text = (berechnungIXX_Rechteckrohrprofil(Breite, Hoehe, Dicke) + "mm");
                    txtIYY.Text = (berechnungIXX_Rechteckrohrprofil(Breite, Hoehe, Dicke) + "mm");
                    txtWXX.Text = (berechnungWXX_Rechteckrohrprofil(Breite, Hoehe, Dicke) + "mm");
                    txtWYY.Text = (berechnungWXX_Rechteckrohrprofil(Breite, Hoehe, Dicke) + "mm");
                    txtMasse.Text = (berechnungGewicht_Rechteckrohrprofil(Breite, Hoehe, Dicke, Laenge) + "g");
                    SchwerpunktX.Text = (berechnungSchwerpunktX_Rechteckrohrprofil(Breite) + "mm");
                    SchwerpunktY.Text = (berechnungSchwerpunktX_Rechteckrohrprofil(Hoehe) + "mm");
                    new CatiaControlRechteckrohrprofil(Breite,Hoehe,Dicke,Laenge);
                }

                catch (FormatException)
                {

                    MessageBox.Show("Error! Keine Buchstaben eingeben!");
                }
            }
            while (checkmate);

        }

        //Berechnung 

        public double berechnungVolumen_Rechteckrohrprofil(double Breite, double Hoehe, double Dicke, double Laenge)
        {
            double Volumen_Rechteckrohrprofil = Math.Round((Breite * Hoehe) - ((Breite - (2 * Dicke)) + (Hoehe - (2 * Dicke))) * Laenge,3);

            return Volumen_Rechteckrohrprofil;
        }

        public double berechnungIXX_Rechteckrohrprofil(double Breite, double Hoehe, double Dicke)
        {
            double IXX_Rechteckrohrprofil = Math.Round(((Hoehe * Math.Pow(Breite, 3)) - (((Hoehe - (2 * Dicke))) * Math.Pow(Breite - (2 * Dicke), 3))) / 12,3);

            return IXX_Rechteckrohrprofil;
        }

        public double berechnungIYY_Rechteckrohrprofil(double Breite, double Hoehe, double Dicke)
        {
            double IYY_Rechteckrohrprofil = Math.Round(((Breite * Math.Pow(Hoehe, 3)) - (((Breite - (2 * Dicke))) * Math.Pow(Hoehe - (2 * Dicke), 3))) / 12,3);

            return IYY_Rechteckrohrprofil;
        }

        public double berechnungWXX_Rechteckrohrprofil(double Breite, double Hoehe, double Dicke)
        {
            double WXX_Rechteckrohrprofil = Math.Round(((Hoehe * Math.Pow(Breite, 3)) + (((Hoehe - (2 * Dicke))) * Math.Pow(Breite - (2 * Dicke), 3))) / 6 * Hoehe,3);

            return WXX_Rechteckrohrprofil;
        }

        public double berechnungWYY_Rechteckrohrprofil(double Breite, double Hoehe, double Dicke)
        {
            double WYY_Rechteckrohrprofil = Math.Round(((Breite * Math.Pow(Hoehe, 3)) + (((Breite - (2 * Dicke))) * Math.Pow(Hoehe - (2 * Dicke), 3))) / 6 * Hoehe,3);

            return WYY_Rechteckrohrprofil;
        }

        public double berechnungGewicht_Rechteckrohrprofil(double Breite, double Hoehe, double Dicke, double Laenge)
        {
            double Gewicht_Rechteckrohrprofil = Math.Round((Breite * Hoehe) - ((Breite - (2 * Dicke)) + (Hoehe - (2 * Dicke))) * Laenge * _matKonst,3);

            return Gewicht_Rechteckrohrprofil;
        }

        public double berechnungSchwerpunktX_Rechteckrohrprofil(double Breite)
        {
            double SchwerpunktX_Rechteckrohrprofil = Math.Round((Breite / 2),3);

            return SchwerpunktX_Rechteckrohrprofil;
        }

        public double berechnungSchwerpunktY_Rechteckrohrprofil(double Hoehe)
        {
            double SchwerpunktY_Rechteckrohrprofil = Math.Round((Hoehe / 2),3);

            return SchwerpunktY_Rechteckrohrprofil;
        }


        public void btn_brechnung_Tprofil_Click(object sender, RoutedEventArgs e)
        {

            bool checkmate = false;
            do
            {
                try
                {

                    double Breite_B = double.Parse(txtbox_Tprofil_B.Text);
                    double Breite_b = double.Parse(txtbox_Tprofil_b.Text);
                    double Hoehe_H = double.Parse(txtbox_Tprofil_H.Text);
                    double Hoehe_h = double.Parse(txtbox_Tprofil_h.Text);
                    double Laenge_l = double.Parse(txtbox_Tprofil_l.Text);


                    if (Breite_B <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Breite B muss größer als 0 sein!");
                        checkmate = false;
                        Breite_B = 0;
                        Breite_b = 0;
                        Hoehe_H = 0;
                        Hoehe_h = 0;
                        Laenge_l = 0;

                    }

                    if (Breite_b <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Breite b muss größer als 0 sein!");
                        checkmate = false;
                        Breite_b = 0;
                        Breite_B = 0;
                        Hoehe_H = 0;
                        Hoehe_h = 0;
                        Laenge_l = 0;
                    }

                    if (Hoehe_H <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Höhe H muss größer als 0 sein!");
                        checkmate = false;
                        Hoehe_H = 0;
                        Breite_B = 0;
                        Breite_b = 0;
                        Hoehe_h = 0;
                        Laenge_l = 0;
                    }

                    if (Hoehe_h <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Höhe h muss größer als 0 sein!");
                        checkmate = false;
                        Hoehe_h = 0;
                        Breite_B = 0;
                        Breite_b = 0;
                        Hoehe_H = 0;
                        Laenge_l = 0;
                    }

                    if (Laenge_l <= 0)
                    {
                        checkmate = true;
                        MessageBox.Show("Länge muss größer als 0 sein!");
                        checkmate = false;
                        Laenge_l = 0;
                        Hoehe_h = 0;
                        Breite_B = 0;
                        Breite_b = 0;
                        Hoehe_H = 0;
                    }


                    txtVolumen.Text = (berechnungVolumen_Tprofil(Breite_B, Breite_b, Hoehe_H, Hoehe_h, Laenge_l) + "mm³");
                    txtIXX.Text = (berechnungIXX_Tprofil(Breite_B, Breite_b, Hoehe_H, Hoehe_h) + "mm");
                    txtIYY.Text = (berechnungIXX_Tprofil(Breite_B, Breite_b, Hoehe_H, Hoehe_h) + "mm");
                    txtWXX.Text = (berechnungWXX_Tprofil(Breite_B, Breite_b, Hoehe_H, Hoehe_h) + "mm");
                    txtWYY.Text = (berechnungWXX_Tprofil(Breite_B, Breite_b, Hoehe_H, Hoehe_h) + "mm");
                    txtMasse.Text = (berechnungGewicht_Tprofil(Breite_B, Breite_b, Hoehe_H, Hoehe_h, Laenge_l) + "g");
                    SchwerpunktX.Text = (berechnungSchwerpunktX_Tprofil(Hoehe_H) + "mm");
                    SchwerpunktY.Text = (berechnungSchwerpunktY_Tprofil(Breite_B, Breite_b, Hoehe_H, Hoehe_h) + "mm");
                    new CatiaControlTprofil(Breite_B, Breite_b, Hoehe_h, Hoehe_H, Laenge_l);
                }

                catch (FormatException)
                {

                    MessageBox.Show("Error! Keine Buchstaben eingeben!");
                }
            }
            while (checkmate);



        }

        public double berechnungVolumen_Tprofil(double Breite_B, double Breite_b, double Hoehe_H, double Hoehe_h, double Laenge_l)
        {
            double Volumen_Tprofil = Math.Round(((Breite_B * Hoehe_H) + (Breite_b * Hoehe_h)) * Laenge_l,3);

            return Volumen_Tprofil;
        }

        public double berechnungIXX_Tprofil(double Breite_B, double Breite_b, double Hoehe_H, double Hoehe_h)
        {
            double IXX_Tprofil = Math.Round((Hoehe_H * Math.Pow(Breite_B, 3) + Hoehe_h * Math.Pow(Breite_b, 3)) / 12,3);

            return IXX_Tprofil;
        }

        public double berechnungIYY_Tprofil(double Breite_B, double Breite_b, double Hoehe_H, double Hoehe_h)
        {
            double IYY_Tprofil = Math.Round((Breite_B * Math.Pow(Hoehe_H, 3) + Breite_b * Math.Pow(Hoehe_h, 3)) / 12,3);

            return IYY_Tprofil;
        }

        public double berechnungWXX_Tprofil(double Breite_B, double Breite_b, double Hoehe_H, double Hoehe_h)
        {
            double WXX_Tprofil = Math.Round((Hoehe_H * Math.Pow(Breite_B, 3) + Hoehe_h * Math.Pow(Breite_b, 3)) / 6 * Hoehe_H,3);

            return WXX_Tprofil;
        }

        public double berechnungWYY_Tprofil(double Breite_B, double Breite_b, double Hoehe_H, double Hoehe_h)
        {
            double WYY_Tprofil = Math.Round((Breite_B * Math.Pow(Hoehe_H, 3) + Breite_b * Math.Pow(Hoehe_h, 3)) / 6 * Hoehe_H,3);

            return WYY_Tprofil;
        }

        public double berechnungGewicht_Tprofil(double Breite_B, double Breite_b, double Hoehe_H, double Hoehe_h, double Laenge_l)
        {
            double Gewicht_Tprofil = Math.Round(((Breite_B * Hoehe_H) + (Breite_b * Hoehe_h)) * Laenge_l * _matKonst,3);

            return Gewicht_Tprofil;
        }

        public double berechnungSchwerpunktX_Tprofil(double Hoehe_H)
        {
            double SchwerpunktX_tProfil = Math.Round(Hoehe_H / 2,3);

            return SchwerpunktX_tProfil;
        }

        public double berechnungSchwerpunktY_Tprofil(double Breite_B, double Breite_b, double Hoehe_H, double Hoehe_h)
        {
            double SchwerpunktY_tProfil = Math.Round(0.5 * (((Breite_B * Math.Pow(Hoehe_H, 2)) + (Breite_b * Math.Pow(Hoehe_h, 2))) / (Breite_B * Hoehe_H) + (Breite_b * Hoehe_h)),3);

            return SchwerpunktY_tProfil;
        }



        private void laenge_anzeigen_rechteck(object sender, System.Windows.Input.MouseEventArgs e)
        {

            laenge_Rechteck.Visibility = Visibility.Visible;

        }

        private void laenge_verdecken_rechteck(object sender, System.Windows.Input.MouseEventArgs e)
        {
            laenge_Rechteck.Visibility = Visibility.Hidden;

        }

        private void breite_anzeigen_rechteck(object sender, System.Windows.Input.MouseEventArgs e)
        {

            breite_Rechteck.Visibility = Visibility.Visible;

        }

        private void breite_verdecken_rechteck(object sender, System.Windows.Input.MouseEventArgs e)
        {

            breite_Rechteck.Visibility = Visibility.Hidden;

        }

        private void hoehe_anzeigen_rechteck(object sender, System.Windows.Input.MouseEventArgs e)
        {

            hoehe_Rechteck.Visibility = Visibility.Visible;

        }

        private void hoehe_verdecken_rechteck(object sender, System.Windows.Input.MouseEventArgs e)
        {

            hoehe_Rechteck.Visibility = Visibility.Hidden;

        }

        private void durchmesser_anzeigen_rund(object sender, System.Windows.Input.MouseEventArgs e)
        {
            durchmesser_Rund.Visibility = Visibility.Visible;

        }

        private void durchmesser_verdecken_rund(object sender, System.Windows.Input.MouseEventArgs e)
        {
            durchmesser_Rund.Visibility = Visibility.Hidden;

        }

        private void laenge_anzeigen_rund(object sender, System.Windows.Input.MouseEventArgs e)
        {

            laenge_Rund.Visibility = Visibility.Visible;

        }

        private void laenge_verdecken_rund(object sender, System.Windows.Input.MouseEventArgs e)
        {

            laenge_Rund.Visibility = Visibility.Hidden;

        }

        private void durchmesser_anzeigen_rohr(object sender, System.Windows.Input.MouseEventArgs e)
        {
            durchmesser_rohr.Visibility = Visibility.Visible;

        }

        private void durchmesser_verdecken_rohr(object sender, System.Windows.Input.MouseEventArgs e)
        {

            durchmesser_rohr.Visibility = Visibility.Hidden;

        }

        private void laenge_anzeigen_rohr(object sender, System.Windows.Input.MouseEventArgs e)
        {


            laenge_rohr.Visibility = Visibility.Visible;

        }

        private void laenge_verdecken_rohr(object sender, System.Windows.Input.MouseEventArgs e)
        {

            laenge_rohr.Visibility = Visibility.Hidden;

        }

        private void laenge_anzeigen_rechteckrohr(object sender, System.Windows.Input.MouseEventArgs e)
        {

            laenge_rechteckrohr.Visibility = Visibility.Visible;

        }

        private void laenge_verdecken_rechteckrohr(object sender, System.Windows.Input.MouseEventArgs e)
        {
            laenge_rechteckrohr.Visibility = Visibility.Hidden;

        }

        private void breite_anzeigen_rechteckrohr(object sender, System.Windows.Input.MouseEventArgs e)
        {
            breite_rechteckrohr.Visibility = Visibility.Visible;

        }

        private void breite_verdecken_rechteckrohr(object sender, System.Windows.Input.MouseEventArgs e)
        {

            breite_rechteckrohr.Visibility = Visibility.Hidden;

        }

        private void hoehe_anzeigen_rechteckrohr(object sender, System.Windows.Input.MouseEventArgs e)
        {
            hoehe_rechteckrohr.Visibility = Visibility.Visible;
        }

        private void hoehe_verdecken_rechteckrohr(object sender, System.Windows.Input.MouseEventArgs e)
        {

            hoehe_rechteckrohr.Visibility = Visibility.Hidden;
        }

        private void breite_b_anzeigen_tprofil(object sender, System.Windows.Input.MouseEventArgs e)
        {

            breite_b_tprofil.Visibility = Visibility.Visible;

        }

        private void breite_b_verdecken_tprofil(object sender, System.Windows.Input.MouseEventArgs e)
        {

            breite_b_tprofil.Visibility = Visibility.Hidden;


        }

        private void breite_bigb_anzeigen_tprofil(object sender, System.Windows.Input.MouseEventArgs e)
        {
            breite_B_tprofil.Visibility = Visibility.Visible;

        }

        private void breite_bigb_verdecken_tprofil(object sender, System.Windows.Input.MouseEventArgs e)
        {
            breite_B_tprofil.Visibility = Visibility.Hidden;

        }

        private void hoehe_h_anzeigen_tprofil(object sender, System.Windows.Input.MouseEventArgs e)
        {

            hoehe_h_tprofil.Visibility = Visibility.Visible;
        }

        private void hoehe_h_verdecken_tprofil(object sender, System.Windows.Input.MouseEventArgs e)
        {
            hoehe_h_tprofil.Visibility = Visibility.Hidden;
        }

        private void hoehe_bigh_anzeigen_tprofil(object sender, System.Windows.Input.MouseEventArgs e)
        {

            hoehe_H_tprofil.Visibility = Visibility.Visible;

        }

        private void hoehe_bigh_verdecken_tprofil(object sender, System.Windows.Input.MouseEventArgs e)
        {
            hoehe_H_tprofil.Visibility = Visibility.Hidden;

        }

        private void laenge_anzeigen_tprofil(object sender, System.Windows.Input.MouseEventArgs e)
        {

            laenge_tprofil.Visibility = Visibility.Visible;

        }

        private void laenge_verdecken_tprofil(object sender, System.Windows.Input.MouseEventArgs e)
        {

            laenge_tprofil.Visibility = Visibility.Hidden;

        }

        private void Combobox_rechteck_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selIndex = Combobox_rechteck.SelectedIndex;
            switch (selIndex)
            {
                case 2:
                    _matKonst = 0.0027;
                    break;
                case 0:
                    _matKonst = 0.00787;
                    break;
                case 3:
                    _matKonst = 0.00896;
                    break;
                case 1:
                    _matKonst = 0.004506;
                    break;
                default:
                    _matKonst = -1;
                    break;


            }




        }
    }


    public class CatiaControl
    {
        public CatiaControl(double Breite, double Hoehe, double Laenge)
        {
            try
            {

                CatiaConnectionRechteckProfil cc = new CatiaConnectionRechteckProfil();
               


                // Finde Catia Prozess
                if (cc.CATIALaeuft())
                {



                    cc.openFile();

                    cc.changeUserParameter(Breite, Hoehe, Laenge);

                   

                }
                else
                {
                    Console.WriteLine("Laufende Catia Application nicht gefunden");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "Exception aufgetreten");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException);
            }
            Console.WriteLine("Fertig - Taste drücken.");
            // Console.ReadKey();
            
        }
     

    }

    public class CatiaControlRundprofil
    {

        public CatiaControlRundprofil(double Durchmesser, double Laenge)
        {
            try
            {

                CatiaConnectionRundProfil cc = new CatiaConnectionRundProfil();
                //  CatiaConnectionRundProfil cc = new CatiaConnectionRundProfil();


                // Finde Catia Prozess
                if (cc.CATIALaeuft())
                {



                    cc.openFile();

                    cc.changeUserParameter(Durchmesser, Laenge);


                }
                else
                {
                    Console.WriteLine("Laufende Catia Application nicht gefunden");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "Exception aufgetreten");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException);
            }
            Console.WriteLine("Fertig - Taste drücken.");
            // Console.ReadKey();

        }



    }

    public class CatiaControlRohrprofil
    {

        public CatiaControlRohrprofil(double Durchmesser, double Dicke, double Laenge)
        {
            try
            {

                CatiaConnectionRohrProfil cc = new CatiaConnectionRohrProfil();
                //  CatiaConnectionRundProfil cc = new CatiaConnectionRundProfil();


                // Finde Catia Prozess
                if (cc.CATIALaeuft())
                {



                    cc.openFile();

                    cc.changeUserParameter(Durchmesser, Dicke, Laenge);


                }
                else
                {
                    Console.WriteLine("Laufende Catia Application nicht gefunden");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "Exception aufgetreten");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException);
            }
            Console.WriteLine("Fertig - Taste drücken.");
            // Console.ReadKey();

        }


    }

    public class CatiaControlRechteckrohrprofil
    {

        public CatiaControlRechteckrohrprofil(double Breite, double Dicke, double Laenge, double Hoehe)
        {
            try
            {

                CatiaConnectionRechteckrohrprofil cc = new CatiaConnectionRechteckrohrprofil();
             


                // Finde Catia Prozess
                if (cc.CATIALaeuft())
                {



                    cc.openFile();

                    cc.changeUserParameter(Breite, Dicke, Laenge,Hoehe);


                }
                else
                {
                    Console.WriteLine("Laufende Catia Application nicht gefunden");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "Exception aufgetreten");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException);
            }
            Console.WriteLine("Fertig - Taste drücken.");
            // Console.ReadKey();

        }


    }

    public class CatiaControlTprofil
    {

        public CatiaControlTprofil(double Breite_b, double Breite_B, double Hoehe_h, double Hoehe_H, double Laenge_1)
        {
            try
            {

                CatiaConnectionTprofil cc = new CatiaConnectionTprofil();



                // Finde Catia Prozess
                if (cc.CATIALaeuft())
                {



                    cc.openFile();

                    cc.changeUserParameter(Breite_b, Breite_B, Hoehe_h, Hoehe_H, Laenge_1);


                }
                else
                {
                    Console.WriteLine("Laufende Catia Application nicht gefunden");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "Exception aufgetreten");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException);
            }
            Console.WriteLine("Fertig - Taste drücken.");
            // Console.ReadKey();

        }


    }


  





}
