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

   public class HoofdSpelBolletje : HoofdSpelEntiteit
    {
       private Ellipse ellipse;
       private static Random randomPlaats = new Random(151);
       private Rect doelVierkant;
       
       public HoofdSpelBolletje(List<HoofdSpelEntiteit> lijst, Canvas drawingCanvas)
       {
           ellipse = new Ellipse();
           doelVierkant = new Rect();
           DrawingCanvas = drawingCanvas;
           Lijst = lijst;
           CheckKleur();
           ellipse.Fill = new SolidColorBrush(Kleur);
           X = randomPlaats.Next(151);
           Y = randomPlaats.Next(151);
           DisplayOn();
       }
       public HoofdSpelBolletje(List<HoofdSpelEntiteit> lijst, int x, int y, Canvas drawingCanvas)
       {
           DrawingCanvas = drawingCanvas;
           Lijst = lijst;
           CheckKleur();
           ellipse = new Ellipse();
           ellipse.Fill = new SolidColorBrush(Kleur);
           X = x;
           Y = y;
           DisplayOn();
       }

       public override void DisplayOn()
       {
           DrawingCanvas.Children.Add(ellipse);
       }
       protected override void UpdateElement()
       {
           ellipse.Width = Width;
           ellipse.Height = Height;
           ellipse.Margin = new System.Windows.Thickness(X, Y, 0, 0);
           doelVierkant.Width = Width;
           doelVierkant.Height = Height;
           doelVierkant.X = X;
           doelVierkant.Y = Y;
       }

       public override void CheckHit(List<HoofdSpelEntiteit> lijstTegenstander)
       {
           for (int i = 0; i < lijstTegenstander.Count; i++)
           {
               
               if (lijstTegenstander[i].DoelVierkant.IntersectsWith(DoelVierkant))
               {
                   HoofdSpelVierkantje vierkantje = new HoofdSpelVierkantje(Lijst,DrawingCanvas);
                   Lijst.Add(vierkantje);
                   Dood();
                   lijstTegenstander[i].CheckHit(); //Tegenstander moet ook vierkantje worden/dood gaan
               }
               
           }
           
       }
       public override  void CheckHit() //Als tegenstander bolletje is kom je hier terecht, zijn tegenstander is reeds gechecked
       {
           HoofdSpelVierkantje vierkantje =  new HoofdSpelVierkantje(Lijst,DrawingCanvas);
           Lijst.Add(vierkantje);
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
       }
       public override Rect DoelVierkant
       {
           get { return doelVierkant; }
       }


    }
}
