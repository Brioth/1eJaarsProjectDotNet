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
       private Rectangle vierkant;
       private static Random randomPlaats = new Random(151);
       private List<HoofdSpelEntiteit> lijst;

       public HoofdSpelVierkantje(List<HoofdSpelEntiteit> lijst)
       {
           this.lijst = lijst;
           CheckKleur();
           vierkant = new Rectangle();
           vierkant.Fill = new SolidColorBrush(Kleur);
           X = randomPlaats.Next(151);
           Y = randomPlaats.Next(151);
           lijst.Add(this);
       }

        public HoofdSpelVierkantje(List<HoofdSpelEntiteit> lijst, int x, int y)
        {
            this.lijst = lijst;
            CheckKleur();
            vierkant = new Rectangle();
            vierkant.Fill=new SolidColorBrush(Kleur);
            X=x;
            Y=y;
            lijst.Add(this);
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
       }

       public override void CheckHit(List<HoofdSpelEntiteit> lijstTegenstander)
       {
           //als geraakt door eigen bolletje dan bolletje
           //als geraakt door tegenstander dan dood
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
