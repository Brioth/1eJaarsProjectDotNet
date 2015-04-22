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
    /* --BolletjesSpel--
     * 2 tegenstanders met lijst pionnen worden aangemaakt, elk met eigen timer om pionnen te spawnen
     * Timer om bewegingen te controleren
     * Basisverloop spel wordt hier gecontroleerd
     * Author: Carmen Celen
     * 10/04/2015
     */
    public partial class HoofdSpel : Page
    {
        //Lokale variabelen
        private HoofdSpelLijstRood entiteitenRood;
        private HoofdSpelLijstBlauw entiteitenBlauw;

        private DispatcherTimer animationTimer;//Wnr alles beweegt
        private DispatcherTimer roodTimer;//Wnr nieuw bolletje user spawnt
        private DispatcherTimer blauwTimer;//Wnr nieuw bolletje tegenstander spawnt

        //Constructors
        public HoofdSpel()
        {
            InitializeComponent();

            entiteitenRood = new HoofdSpelLijstRood();
            entiteitenBlauw = new HoofdSpelLijstBlauw();

            BindLijsten();

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
            entiteitenRood.Bolletjes = entiteitenRood.Bolletjes + 1;

            HoofdSpelBolletje bolletjeBlauw = new HoofdSpelBolletje(entiteitenBlauw, drawingCanvas);
            entiteitenBlauw.Add(bolletjeBlauw);
            entiteitenBlauw.Bolletjes = entiteitenBlauw.Bolletjes+1;


        }
        //Events
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
                entiteitenRood.Bolletjes = entiteitenRood.Bolletjes+1;
            }
        }
        private void blauwTimer_Tick(object sender, EventArgs e)
        {
            if (entiteitenBlauw.Count <= 20)
            {
                HoofdSpelBolletje bolletje = new HoofdSpelBolletje(entiteitenBlauw, drawingCanvas);
                entiteitenBlauw.Add(bolletje);
                entiteitenBlauw.Bolletjes = entiteitenBlauw.Bolletjes+1;

            }

        }
        //Methods
        private void BindLijsten()
        {
            Binding b = new Binding();
            b.Source = entiteitenRood;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.Path = new PropertyPath("Bolletjes");
            txtbRoodB.SetBinding(TextBlock.TextProperty, b);

            b = new Binding();
            b.Source = entiteitenRood;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.Path = new PropertyPath("Vierkantjes");
            txtbRoodV.SetBinding(TextBlock.TextProperty, b);

            b = new Binding();
            b.Source = entiteitenBlauw;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.Path = new PropertyPath("Bolletjes");
            txtbBlauwB.SetBinding(TextBlock.TextProperty, b);

            b = new Binding();
            b.Source = entiteitenBlauw;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.Path = new PropertyPath("Vierkantjes");
            txtbBlauwV.SetBinding(TextBlock.TextProperty, b);
        }
        //Properties

    }
}
