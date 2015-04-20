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
       private ObservableCollection<HoofdSpelEntiteit> lijst;
       private Rect doelVierkant;

       public HoofdSpelVierkantje(ObservableCollection<HoofdSpelEntiteit> lijst, Canvas drawingCanvas)
       {
           this.lijst = lijst;
           CheckKleur();
           vierkant = new Rectangle();
           vierkant.Fill = new SolidColorBrush(Kleur);
           X = randomPlaats.Next(151);
           Y = randomPlaats.Next(151);
           doelVierkant = new Rect();
           DrawingCanvas = drawingCanvas;
           DisplayOn(this.DrawingCanvas);
           
       }

       public override void DisplayOn(Canvas drawingCanvas)
       {
           drawingCanvas.Children.Add(vierkant);
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

       public override void CheckHit(ObservableCollection<HoofdSpelEntiteit> lijstTegenstander)
       {
           for (int i = 0; i < lijstTegenstander.Count; i++)
           {

               if (lijstTegenstander[i].DoelVierkant.IntersectsWith(this.DoelVierkant))
               {
                   this.Dood();
                   lijstTegenstander[i].CheckHit();
               }

           }
           for (int i = 0; i < lijst.Count; i++)
           {
               if (lijst[i] is HoofdSpelBolletje && lijst[i].DoelVierkant.IntersectsWith(this.DoelVierkant))
               {
                       HoofdSpelBolletje bolletje = new HoofdSpelBolletje(lijst, this.X, this.Y, this.DrawingCanvas);
                       Lijst.Add(bolletje);
                       this.Dood();                  
               }
           }

       }
       public override void CheckHit()
       {
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
           get { return doelVierkant; }
       }
       public override ObservableCollection<HoofdSpelEntiteit> Lijst
       {
           get { return lijst; }
       }
       public override void Dood()
       {
           this.Lijst.Remove(this);
           this.DrawingCanvas.Children.Remove(vierkant);
       }
    }
}
