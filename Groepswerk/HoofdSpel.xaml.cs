using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for HoofdSpel.xaml
    /// </summary>
    public partial class HoofdSpel : Page
    {
        private HoofdSpelLijstRood entiteitenRood;
        private HoofdSpelLijstBlauw entiteitenBlauw;

        private DispatcherTimer animationTimer;//Wnr alles beweegt
        private DispatcherTimer roodTimer;//Wnr nieuw bolletje user spawnt
        private DispatcherTimer blauwTimer;//Wnr nieuw bolletje tegenstander spawnt
        public HoofdSpel()
        {
            InitializeComponent();

            entiteitenRood = new HoofdSpelLijstRood();
            entiteitenBlauw = new HoofdSpelLijstBlauw();

            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(50);
            animationTimer.Tick += animationTimer_Tick;
            animationTimer.IsEnabled = true;

            roodTimer = new DispatcherTimer();
            roodTimer.Interval = TimeSpan.FromSeconds(2);
            roodTimer.Tick += roodTimer_Tick;
            roodTimer.IsEnabled = true;

            blauwTimer = new DispatcherTimer();
            blauwTimer.Interval = TimeSpan.FromSeconds(2);
            blauwTimer.Tick += blauwTimer_Tick;
            blauwTimer.IsEnabled = true;

            HoofdSpelBolletje bolletjeRood = new HoofdSpelBolletje(entiteitenRood, drawingCanvas);
            entiteitenRood.Add(bolletjeRood);

            HoofdSpelBolletje bolletjeBlauw = new HoofdSpelBolletje(entiteitenBlauw, drawingCanvas);
            entiteitenBlauw.Add(bolletjeBlauw);


            this.DataContext = this;           
        }
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            entiteitenRood.Move();
            entiteitenBlauw.Move();
            entiteitenRood.CheckHit(entiteitenBlauw);
            entiteitenBlauw.CheckHit(entiteitenRood);
        }
        private void roodTimer_Tick(object sender, EventArgs e)
        {
            if (entiteitenRood.Count <= 20)
            {
                HoofdSpelBolletje bolletje = new HoofdSpelBolletje(entiteitenRood, drawingCanvas);
                entiteitenRood.Add(bolletje);

            }

        }
        private void blauwTimer_Tick(object sender, EventArgs e)
        {
            if (entiteitenBlauw.Count <= 20)
            {
                HoofdSpelBolletje bolletje = new HoofdSpelBolletje(entiteitenBlauw, drawingCanvas);
                entiteitenBlauw.Add(bolletje);

            }

        }
               
    }
}
