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
       private ObservableCollection<HoofdSpelEntiteit> lijst;
       private Rect doelvierkant;
       
       public HoofdSpelBolletje(ObservableCollection<HoofdSpelEntiteit> lijst, Canvas drawingCanvas)
       {
           this.lijst = lijst;
           CheckKleur();
           ellipse = new Ellipse();
           doelvierkant = new Rect();
           ellipse.Fill = new SolidColorBrush(Kleur);
           X = randomPlaats.Next(151);
           Y = randomPlaats.Next(151);
           DrawingCanvas = drawingCanvas;
           DisplayOn(this.DrawingCanvas);
       }
       public HoofdSpelBolletje(ObservableCollection<HoofdSpelEntiteit> lijst, int x, int y, Canvas drawingCanvas)
       {
           this.lijst = lijst;
           CheckKleur();
           ellipse = new Ellipse();
           doelvierkant = new Rect();
           ellipse.Fill = new SolidColorBrush(Kleur);
           X = x;
           Y = y;
           DrawingCanvas = drawingCanvas;
       }

       public override void DisplayOn(Canvas drawingCanvas)
       {
           drawingCanvas.Children.Add(ellipse);
       }
       protected override void UpdateElement()
       {
           ellipse.Width = Width;
           ellipse.Height = Height;
           ellipse.Margin = new System.Windows.Thickness(X, Y, 0, 0);
           doelvierkant.Width = Width;
           doelvierkant.Height = Height;
           doelvierkant.X = X;
           doelvierkant.Y = Y;
       }

       public override void CheckHit(ObservableCollection<HoofdSpelEntiteit> lijstTegenstander)
       {
           for (int i = 0; i < lijstTegenstander.Count; i++)
           {
               
               if (lijstTegenstander[i].DoelVierkant.IntersectsWith(this.DoelVierkant))
               {
                   HoofdSpelVierkantje vierkantje = new HoofdSpelVierkantje(Lijst,this.DrawingCanvas);
                   this.Lijst.Add(vierkantje);
                   this.Dood();
                   lijstTegenstander[i].CheckHit();
               }
               
           }
           
       }
       public override  void CheckHit()
       {
           HoofdSpelVierkantje vierkantje =  new HoofdSpelVierkantje(lijst,this.DrawingCanvas);
           Lijst.Add(vierkantje);
           this.Dood();
       }
       private void CheckKleur()
       {
           if (lijst is HoofdSpelLijstBlauw)
           {
               Kleur = Colors.Blue;
           }
           if (lijst is HoofdSpelLijstRood)
           {
               Kleur = Colors.Red;
           }
       }
       public override Rect DoelVierkant
       {
           get { return doelvierkant; }
       }

       public override ObservableCollection<HoofdSpelEntiteit> Lijst
       {
           get { return lijst; }
       }
       public override void Dood()
       {
           this.Lijst.Remove(this);
           this.DrawingCanvas.Children.Remove(ellipse);
       }


    }
}
