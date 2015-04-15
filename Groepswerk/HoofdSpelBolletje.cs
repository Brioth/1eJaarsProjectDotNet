using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Groepswerk
{

   public class HoofdSpelBolletje : HoofdSpelEntiteit
    {
       private Ellipse ellipse;
       private static Random randomPlaats = new Random(151);
       private List<HoofdSpelEntiteit> lijst;

       public HoofdSpelBolletje(List<HoofdSpelEntiteit> lijst)
       {
           this.lijst = lijst;
           CheckKleur();
           ellipse = new Ellipse();
           ellipse.Fill = new SolidColorBrush(Kleur);
           X = randomPlaats.Next(151);
           Y = randomPlaats.Next(151);
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
       }

       public override void CheckHit(List<HoofdSpelEntiteit> lijstTegenstander)
       {
           for (int i = 0; i < lijstTegenstander.Count; i++)
           {
               if (this.X == lijstTegenstander[i].X && this.Y == lijstTegenstander[i].Y)
               {
                   new HoofdSpelVierkantje(lijst,this.X, this.Y);
                   lijst.Remove(this);
               }
           }
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

    }
}
