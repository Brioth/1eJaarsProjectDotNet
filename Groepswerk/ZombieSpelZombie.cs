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
    public class ZombieSpelZombie : ZombieSpelSprite
    {
        //Lokale variabelen

        private Rectangle vierkant;
        private string kleur;
        private Image afbeelding;


        //Constructors
        public ZombieSpelZombie(Point punt, string kleur)
        {
            vierkant = new Rectangle();
            Kleur = kleur;
            afbeelding = new Image();
            afbeelding.Source = CreateBitmap(@"Zombie.png", 10);
            Snelheid = 1;
            Positie = punt;
            vierkant.Width = 10;
            vierkant.Height = 10;
            afbeelding.Width = 10;
            afbeelding.Height = 10;
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
        }
        //Properties
        public double Snelheid { get; set; }
        public bool GeraaktDoorEigen { get; set; }
        public bool GeraaktDoorVijand { get; set; }
        public Point Positie
        {
            get { return new Point(X, Y); }
            set { X = Positie.X; Y = Positie.Y; }
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
    }

}
