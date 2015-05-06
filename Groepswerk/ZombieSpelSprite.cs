using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Groepswerk
{
    /* --ZombiespelSprite--
     * Algemene klasse voor zombies en humans
     * Author: Carmen Celen
     * Date: 25/04/2015
     */
    public abstract class ZombieSpelSprite : UIElement
    {
        //Lokale variabelen
        private double x, y;
        public static int GROOTTE = 30;

        //Constructors

        //Events

        //Methods
        public abstract void DisplayOn(Canvas drawingCanvas);
        public abstract void UpdateElement();
        public BitmapImage CreateBitmap(string imagepath)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(imagepath, UriKind.RelativeOrAbsolute);
            bi.DecodePixelHeight = GROOTTE;
            bi.EndInit();
            return bi;
        }

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
