using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Groepswerk
{
    /* --ZombiespelZombie--
     * Gedrag zombie
     * Author: Carmen Celen
     * Date: 25/04/2015
     */
    public class ZombieSpelZombie : ZombieSpelSprite
    {
        //Lokale variabelen
        private Rectangle vierkant;
        private string kleur;
        private Image afbeelding;
        private Rect doelvierkant;
        private static Random richtingRandom = new Random();
        private Point positie = new Point();

        //Constructors
        public ZombieSpelZombie(Point punt, string kleur)
        {
            vierkant = new Rectangle();
            Kleur = kleur;
            afbeelding = new Image();
            afbeelding.Source = CreateBitmap("bin/Debug/Zombie.png");
            doelvierkant = new Rect(new Size(GROOTTE, GROOTTE));
            Snelheid = 2;
            vierkant.Width = GROOTTE;
            vierkant.Height = GROOTTE;
            afbeelding.Width = GROOTTE;
            afbeelding.Height = GROOTTE;
            Positie = punt;
            do
            {
                RichtingX = BepaalRichting();
                RichtingY = BepaalRichting();
            } while (RichtingX == 0 && RichtingY == 0);
        }

        //Events

        //Methods
        public override void DisplayOn(Canvas drawingCanvas)
        {
            drawingCanvas.Children.Add(vierkant);
            drawingCanvas.Children.Add(afbeelding);
        }
        public override void UpdateElement()
        {
            vierkant.Margin = new Thickness(Positie.X, Positie.Y, 0, 0);
            afbeelding.Margin = new Thickness(Positie.X, Positie.Y, 0, 0);
            doelvierkant.Location = Positie;
        }
        private int BepaalRichting() //0 is -, 1 is blijven staan, 2 is +
        {
            int gekozenrichting = richtingRandom.Next(3);
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
        public void VerwijderZombie(Canvas drawingCanvas)
        {
            drawingCanvas.Children.Remove(vierkant);
            drawingCanvas.Children.Remove(afbeelding);
        }

        //Properties
        public double Snelheid { get; set; }
        public bool GeraaktDoorEigen { get; set; }
        public bool GeraaktDoorVijand { get; set; }
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
                vierkant.Fill = new SolidColorBrush(geconverteerdeKleur);
            }
            get
            {
                return kleur;
            }
        }
        public Rect Doelvierkant
        { 
            get { return doelvierkant; }
        }
        public int RichtingX { get; set; }
        public int RichtingY { get; set; }
    }

}
