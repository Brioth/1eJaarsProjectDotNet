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
    public class HoofdSpelVierkantje : HoofdSpelEntiteit
    {
       private List<HoofdSpelEntiteit> lijstEntiteiten;
       private Rectangle vierkant;
       private Canvas canvas;
       private static Random randomPlaats = new Random(151);

       public HoofdSpelVierkantje(List<HoofdSpelEntiteit> lijst, Color kleur)
       {
           vierkant = new Rectangle();
           vierkant.Fill = new SolidColorBrush(kleur);
           X = randomPlaats.Next(151);
           Y = randomPlaats.Next(151);
           lijstEntiteiten = lijst;
           lijstEntiteiten.Add(this);
       }
       public override void DisplayOn(Canvas drawingCanvas)
       {
           drawingCanvas.Children.Add(vierkant);
           canvas = drawingCanvas;
       }
       protected override void UpdateElement()
       {
           vierkant.Width = Width;
           vierkant.Height = Height;
           vierkant.Margin = new System.Windows.Thickness(X, Y, 0, 0);
       }

       public override void CheckHit()
       {

       }
    }
}
