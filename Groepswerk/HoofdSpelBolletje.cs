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
       private Canvas canvas;
       private static Random randomPlaats = new Random(151);

       public HoofdSpelBolletje(Color kleur)
       {
           ellipse = new Ellipse();
           ellipse.Fill = new SolidColorBrush(kleur);
           X = randomPlaats.Next(151);
           Y = randomPlaats.Next(151);
       }
       public override void DisplayOn(Canvas drawingCanvas)
       {
           drawingCanvas.Children.Add(ellipse);
           canvas = drawingCanvas;
       }
       protected override void UpdateElement()
       {
           ellipse.Width = Width;
           ellipse.Height = Height;
           ellipse.Margin = new System.Windows.Thickness(X, Y, 0, 0);
       }

       public override void CheckHit()
       {

       }

    }
}
