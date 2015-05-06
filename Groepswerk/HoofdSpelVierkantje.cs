using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Groepswerk
{
    /* --HoofdSpelVierkantje--
     * Klasse om vierkantje te maken en gedrag te bepalen
     * Author: Carmen Celen
     * Date: 10/04/2015
     */
    public class HoofdSpelVierkantje : HoofdSpelEntiteit
    {
        //Lokale variabelen
        private Rectangle vierkant;
        private static Random randomPlaats = new Random();
        private Rect doelVierkant;
        private string kleur;
        private Point positie = new Point();
        private Canvas drawingCanvas;

        //Constructors
        public HoofdSpelVierkantje(Point punt, string kleur, Canvas drawingCanvas)
        {
            vierkant = new Rectangle();
            doelVierkant = new Rect(new Size(GROOTTE, GROOTTE));
            Kleur = kleur;
            vierkant.Width = GROOTTE;
            vierkant.Height = GROOTTE;
            doelVierkant.Width = GROOTTE;
            doelVierkant.Height = GROOTTE;
            Snelheid = 2;
            Positie = punt;
            do
            {
                RichtingX = BepaalRichting();
                RichtingY = BepaalRichting();
            } while (RichtingX == 0 && RichtingY == 0);
            this.drawingCanvas = drawingCanvas;
            vierkant.MouseLeftButtonDown += OnEllipseMouseLeftButtonDown;

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
            drawingCanvas.Children.Add(vierkant);
        }
        protected override void UpdateElement()
        {
            vierkant.Margin = new System.Windows.Thickness(X, Y, 0, 0);
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
        public void VerwijderVierkant(Canvas drawingCanvas)
        {
            drawingCanvas.Children.Remove(vierkant);
        }

        //Properties
        public double Snelheid { get; set; }
        public string Kleur
        {
            set
            {
                kleur = value;
                Color geconverteerdeKleur = (Color)ColorConverter.ConvertFromString(kleur);
                vierkant.Fill = new SolidColorBrush(geconverteerdeKleur);
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
        public bool GeraaktDoorEigen { get; set; }
        public bool GeraaktDoorVijand { get; set; }
        public Point Positie
        {
            get { return positie; }
            set { positie = value; this.X = positie.X; this.Y = positie.Y; }
        }
        public int RichtingX { get; set; }
        public int RichtingY { get; set; }
    }
}
