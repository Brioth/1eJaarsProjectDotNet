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
        private double x, y;
        public static int GROOTTE = 20;

        //Constructors

        //Events

        //Methods
        public abstract void DisplayOn(Canvas drawingCanvas);
        protected abstract void UpdateElement();
        //Properties
        public double X
        {
            get { return x; }
            set { x = value; UpdateElement(); }
        }
        public double Y
        {
            get { return y; }
            set { y = value; UpdateElement(); }
        }



    }
}
