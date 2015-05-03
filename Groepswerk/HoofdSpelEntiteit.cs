using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Groepswerk
{
    /* --Entiteit--
     * Abstracte klasse om gemeenschappelijke eigenschappen bolletjes en vierkantjes samen te voegen
     * Rect Doelvierkant om IntersectsWith te kunnen gebruiken, niet hetzelfde als Rectangle!!
     * Author: Carmen Celen
     * /Date: 13/04/2015
     */
    public abstract class HoofdSpelEntiteit : UIElement
    {
        //Lokale variabelen
        private int x, y;
        public static int GROOTTE = 20;
        private Color kleur;
        private Canvas drawingCanvas;
        private HoofdSpelEntiteitenLijst lijst;
        private static Random richtingRandom = new Random();

        //Constructors

        //Events

        //Methods
        public abstract void DisplayOn();
        protected abstract void UpdateElement();
        public void Move()
        {
            if (this.X + GROOTTE >= DrawingCanvas.ActualWidth || this.X < 0)
            {
                RichtingX = -RichtingX;
                RichtingY = BepaalRichting();
            }
            if (this.Y + GROOTTE >= DrawingCanvas.ActualHeight || this.Y < 0)
            {
                RichtingX = BepaalRichting();
                RichtingY = -RichtingY;
            }

            X = X + RichtingX * Snelheid;
            Y = Y + RichtingY * Snelheid;

            //if (X < 0 || X > 150 || Y < 0 || Y > 150)
            //{
            //    this.Dood();
            //}
            //else
            //{
            //    int getalX = randomBeweging.Next(3);
            //    int getalY = randomBeweging.Next(3);
            //    switch (getalX)
            //    {
            //        case 0:
            //            X -= stepSize;
            //            break;
            //        case 1:
            //            break;
            //        case 2:
            //            X += stepSize;
            //            break;
            //        default:
            //            break;
            //    }
            //    switch (getalY)
            //    {
            //        case 0:
            //            Y -= stepSize;
            //            break;
            //        case 1:
            //            break;
            //        case 2:
            //            Y += stepSize;
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }
        protected int BepaalRichting() //0 is -, 1 is blijven staan, 2 is +
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
        public abstract void CheckHit(HoofdSpelEntiteitenLijst lijstTegenstander);
        public abstract void CheckHit();
        public abstract void Dood();

        //Properties
        public int X
        {
            get { return x; }
            set { x = value; UpdateElement(); }
        }
        public int Y
        {
            get { return y; }
            set { y = value; UpdateElement(); }
        }
        public Color Kleur
        {
            get { return kleur; }
            set { kleur = value;}
        }
        public abstract Rect DoelVierkant
        {
            get;
        }
        public HoofdSpelEntiteitenLijst Lijst
        {
            get { return lijst; }
            set { lijst = value; }
        }
        public Canvas DrawingCanvas
        {
            get { return drawingCanvas; }
            set { drawingCanvas = value; }
        }
        public int RichtingX { get; set; }
        public int RichtingY { get; set; }
        public int Snelheid { get; set; }

    }
}
