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
        int x, y, width=5, height=5, stepSize=5;
        Color kleur;
        Canvas drawingCanvas;
        List<HoofdSpelEntiteit> lijst;
        static Random randomBeweging = new Random(3);
        //Constructors

        //Events

        //Methods
        public abstract void DisplayOn();
        protected abstract void UpdateElement();
        public void Move()
        {
            if (X < 0 || X > 150 || Y < 0 || Y > 150)
            {
                this.Dood();
            }
            else
            {
                int getalX = randomBeweging.Next(3);
                int getalY = randomBeweging.Next(3);
                switch (getalX)
                {
                    case 0:
                        X -= stepSize;
                        break;
                    case 1:
                        break;
                    case 2:
                        X += stepSize;
                        break;
                    default:
                        break;
                }
                switch (getalY)
                {
                    case 0:
                        Y -= stepSize;
                        break;
                    case 1:
                        break;
                    case 2:
                        Y += stepSize;
                        break;
                    default:
                        break;
                }
            }
        }
        public abstract void CheckHit(List<HoofdSpelEntiteit> lijstTegenstander);
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
        public int Width 
        {
            get { return width; }
            set { width = value; UpdateElement(); } 
        }
        public int Height 
        {
            get { return height; }
            set { height = value; UpdateElement(); } 
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
        public List<HoofdSpelEntiteit> Lijst
        {
            get { return lijst; }
            set { lijst = value; }
        }
        public Canvas DrawingCanvas
        {
            get { return drawingCanvas; }
            set { drawingCanvas = value; }
        }
    }
}
