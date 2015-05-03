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
        private Ellipse ellipse;
        private static Random randomPlaats = new Random(151); //static random en later Next want anders toch dezelfde seed
        private Rect doelVierkant;



        //Constructors
        public HoofdSpelBolletje(HoofdSpelEntiteitenLijst lijst, Canvas drawingCanvas)
        {
            //Nieuw bolletje op random plaats
            ellipse = new Ellipse();
            doelVierkant = new Rect();
            DrawingCanvas = drawingCanvas;
            Lijst = lijst;
            CheckKleur();
            ellipse.Fill = new SolidColorBrush(Kleur);
            ellipse.Width = GROOTTE;
            ellipse.Height = GROOTTE;
            doelVierkant.Width = GROOTTE;
            doelVierkant.Height = GROOTTE;
            X = randomPlaats.Next(151);
            Y = randomPlaats.Next(151);
            Snelheid = 5;
            DisplayOn();
            do
            {
                RichtingX = BepaalRichting();
                RichtingY = BepaalRichting();
            } while (RichtingX == 0 && RichtingY == 0);
        }
        public HoofdSpelBolletje(HoofdSpelEntiteitenLijst lijst, int x, int y, Canvas drawingCanvas)
        {
            //vierkantje wordt bolletje op plaats van vierkantje
            DrawingCanvas = drawingCanvas;
            Lijst = lijst;
            CheckKleur();
            ellipse = new Ellipse();
            ellipse.Fill = new SolidColorBrush(Kleur);
            doelVierkant = new Rect();
            ellipse.Height = GROOTTE;
            ellipse.Width = GROOTTE;
            doelVierkant.Width = GROOTTE;
            doelVierkant.Height = GROOTTE;
            Snelheid = 5;
            X = x;
            Y = y;
            DisplayOn();
            do
            {
                RichtingX = BepaalRichting();
                RichtingY = BepaalRichting();
            } while (RichtingX == 0 && RichtingY == 0);
        }

        //Events

        //Methods
        public override void DisplayOn()
        {
            DrawingCanvas.Children.Add(ellipse);
        }
        protected override void UpdateElement()
        {
            ellipse.Margin = new System.Windows.Thickness(X, Y, 0, 0);
            doelVierkant.X = X;
            doelVierkant.Y = Y;
        }
        public override void CheckHit(HoofdSpelEntiteitenLijst lijstTegenstander)
        {
            for (int i = 0; i < lijstTegenstander.Count; i++)
            {

                if (lijstTegenstander[i].DoelVierkant.IntersectsWith(DoelVierkant))
                {
                    HoofdSpelVierkantje vierkantje = new HoofdSpelVierkantje(Lijst, DrawingCanvas);
                    Lijst.Add(vierkantje);
                    Lijst.Vierkantjes = Lijst.Vierkantjes + 1;
                    Dood();
                    lijstTegenstander[i].CheckHit(); //Tegenstander moet ook vierkantje worden/dood gaan
                }
            }
        }
        public override void CheckHit() //Als tegenstander bolletje is kom je hier terecht, zijn tegenstander is reeds gechecked
        {
            HoofdSpelVierkantje vierkantje = new HoofdSpelVierkantje(Lijst, DrawingCanvas);
            Lijst.Add(vierkantje);
            Lijst.Vierkantjes = Lijst.Vierkantjes + 1;
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
        public override void Dood()
        {
            Lijst.Remove(this);
            DrawingCanvas.Children.Remove(ellipse);
            Lijst.Bolletjes = Lijst.Bolletjes - 1;
        }
        //Properties
        public override Rect DoelVierkant
        {
            get { return doelVierkant; }
        }
    }
}
