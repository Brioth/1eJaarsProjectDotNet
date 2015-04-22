using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Groepswerk
{
    public class HoofdSpelVierkantje : HoofdSpelEntiteit
    {
        private Rectangle vierkant;
        private static Random randomPlaats = new Random(151);
        private Rect doelVierkant;

        public HoofdSpelVierkantje(HoofdSpelEntiteitenLijst lijst, Canvas drawingCanvas)
        {
            Lijst = lijst;
            CheckKleur();
            vierkant = new Rectangle();
            doelVierkant = new Rect();
            DrawingCanvas = drawingCanvas;
            vierkant.Fill = new SolidColorBrush(Kleur);
            X = randomPlaats.Next(151);
            Y = randomPlaats.Next(151);
            DisplayOn();

        }

        public override void DisplayOn()
        {
            DrawingCanvas.Children.Add(vierkant);
        }
        protected override void UpdateElement()
        {
            vierkant.Width = Width;
            vierkant.Height = Height;
            vierkant.Margin = new System.Windows.Thickness(X, Y, 0, 0);
            doelVierkant.Width = Width;
            doelVierkant.Height = Height;
            doelVierkant.X = X;
            doelVierkant.Y = Y;
        }

        public override void CheckHit(HoofdSpelEntiteitenLijst lijstTegenstander)
        {
            for (int i = 0; i < lijstTegenstander.Count; i++)
            {

                if (lijstTegenstander[i].DoelVierkant.IntersectsWith(doelVierkant))
                {
                    Dood();
                    lijstTegenstander[i].CheckHit(); //Tegenstander moet vierkantje worden of doodgaan
                }

            }
            for (int i = 0; i < Lijst.Count; i++) //Als je je eigen bolletje raakt
            {
                if (Lijst[i] is HoofdSpelBolletje && Lijst[i].DoelVierkant.IntersectsWith(doelVierkant))
                {
                    HoofdSpelBolletje bolletje = new HoofdSpelBolletje(Lijst, X, Y, DrawingCanvas);
                    Lijst.Add(bolletje);
                    Lijst.Bolletjes = Lijst.Bolletjes + 1;
                    Dood();
                }
            }

        }
        public override void CheckHit() //Als tegenstander vierkantje was is die nu dood
        {
            Dood();
        }
        private void CheckKleur()
        {
            if (Lijst is HoofdSpelLijstBlauw)
            {
                Kleur = Colors.Blue;
            }
            if (Lijst is HoofdSpelLijstRood)
            {
                Kleur = Colors.Red;
            }
        }
        public override Rect DoelVierkant
        {
            get { return doelVierkant; }
        }
        public override void Dood()
        {
            Lijst.Remove(this);
            DrawingCanvas.Children.Remove(vierkant);
            Lijst.Vierkantjes = Lijst.Vierkantjes - 1;
        }
    }
}
