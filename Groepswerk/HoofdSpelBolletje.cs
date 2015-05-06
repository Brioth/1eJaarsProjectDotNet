using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Groepswerk
{
    /* --Bolletjes--
     * Klasse om bolletjes aan te maken en gedrag te bepalen
     * Author: Carmen Celen
     * Date: 10/04/2015
     */
    public class HoofdSpelBolletje : HoofdSpelEntiteit
    {
        //Lokale variabelen
        private Ellipse cirkel;
        private string kleur;
        private Point positie = new Point();
        private static Random randomPlaats = new Random(); //static random en later Next want anders toch dezelfde seed
        private Rect doelVierkant;
        private Canvas drawingCanvas;

        //Constructors
        public HoofdSpelBolletje(string kleur, Canvas drawingCanvas)
        {
            //Nieuw bolletje op random plaats
            cirkel = new Ellipse();
            Kleur = kleur;
            doelVierkant = new Rect();
            cirkel.Width = GROOTTE;
            cirkel.Height = GROOTTE;
            doelVierkant.Width = GROOTTE;
            doelVierkant.Height = GROOTTE;
            Positie = new Point(randomPlaats.Next(Convert.ToInt32(drawingCanvas.ActualWidth)), randomPlaats.Next(Convert.ToInt32(drawingCanvas.ActualHeight)));
            Snelheid = 5;
            do
            {
                RichtingX = BepaalRichting();
                RichtingY = BepaalRichting();
            } while (RichtingX == 0 && RichtingY == 0);
            this.drawingCanvas = drawingCanvas;
            cirkel.MouseLeftButtonDown += OnEllipseMouseLeftButtonDown;

        }
        public HoofdSpelBolletje(Point punt, string kleur, Canvas drawingCanvas)
        {
            //vierkantje wordt bolletje op plaats van vierkantje
            cirkel = new Ellipse();
            Kleur = kleur;
            doelVierkant = new Rect(new Size(GROOTTE, GROOTTE));
            cirkel.Height = GROOTTE;
            cirkel.Width = GROOTTE;
            doelVierkant.Width = GROOTTE;
            doelVierkant.Height = GROOTTE;
            Snelheid = 5;
            Positie = punt;
            do
            {
                RichtingX = BepaalRichting();
                RichtingY = BepaalRichting();
            } while (RichtingX == 0 && RichtingY == 0);
            this.drawingCanvas = drawingCanvas;
            cirkel.MouseLeftButtonDown += OnEllipseMouseLeftButtonDown;

        }

        //Events
        void OnEllipseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (kleur.Equals("#CB2611"))
            {
                Positie = new Point(randomPlaats.Next(Convert.ToInt32(drawingCanvas.ActualWidth)), randomPlaats.Next(Convert.ToInt32(drawingCanvas.ActualHeight)));
            }
        }

        //Methods
        public override void DisplayOn(Canvas drawingCanvas)
        {
            drawingCanvas.Children.Add(cirkel);
        }
        protected override void UpdateElement()
        {
            cirkel.Margin = new System.Windows.Thickness(X, Y, 0, 0);
            doelVierkant.Location = Positie;
        }
        private int BepaalRichting() //0 is -, 1 is blijven staan, 2 is +
        {
            int gekozenrichting = randomPlaats.Next(3);
            int richting;

            switch (gekozenrichting)
            {
                case 0:
                    richting = -1;
                    break;
                case 1:
                    richting = 0;
                    break;
                case 2:
                    richting = 1;
                    break;
                default:
                    richting = 0;
                    MessageBox.Show("Richting is niet juist gegenereerd"); //Mag later weg, voor debug
                    break;
            }
            return richting;
        }
        public void VerwijderBolletje(Canvas drawingCanvas)
        {
            drawingCanvas.Children.Remove(cirkel);
        }

        //Properties
        public double Snelheid { get; set; }
        public bool Geraakt { get; set; }
        public Point Positie
        {
            get { return positie; }
            set { positie = value; this.X = positie.X; this.Y = positie.Y; }
        }
        public string Kleur
        {
            set
            {
                kleur = value;
                Color geconverteerdeKleur = (Color)ColorConverter.ConvertFromString(kleur);
                cirkel.Fill = new SolidColorBrush(geconverteerdeKleur);
            }
            get
            {
                return kleur;
            }
        }
        public Rect Doelvierkant
        {
            get { return doelVierkant; }
        }
        public int RichtingX { get; set; }
        public int RichtingY { get; set; }
    }
}
