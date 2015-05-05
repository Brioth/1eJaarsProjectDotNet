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
        private Gebruiker actieveGebruiker;

        private DispatcherTimer animationTimer, spawnTimer, speltijdTimer, aftelTimer;//Wnr alles beweegt

        private int resterendeTijd;
        //Constructors
        public HoofdSpel(Gebruiker actieveGebruiker)
        {
            InitializeComponent();

            this.actieveGebruiker = actieveGebruiker;
            Speler = new HoofdspelSpeler();
            Computer = new HoofdspelSpeler();

            //BindLijsten();

            speltijdTimer = new DispatcherTimer();
            speltijdTimer.Interval = TimeSpan.FromSeconds(this.actieveGebruiker.GameTijdSec);
            speltijdTimer.Tick += EindeSpel_Tick;
            speltijdTimer.Start();

            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(50);
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();

            spawnTimer = new DispatcherTimer();
            spawnTimer.Interval = TimeSpan.FromSeconds(2);
            spawnTimer.Tick += Spawner_Tick;
            spawnTimer.Start();

            resterendeTijd = this.actieveGebruiker.GameTijdSec;

            aftelTimer = new DispatcherTimer();
            aftelTimer.Interval = TimeSpan.FromSeconds(1);
            aftelTimer.Tick += Afteller_Tick;
            aftelTimer.Start();

        }

        private void EindeSpel_Tick(object sender, EventArgs e)
        {
            speltijdTimer.Stop();
            aftelTimer.Stop();
            animationTimer.Stop();
            spawnTimer.Stop();


            MessageBox.Show("Tijd is op");
            //scores weergeven en wegschrijven
            TijdOp(); //Zet gameTijd op 0
        }
        //Events

           private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            Speler.Beweeg(drawingCanvas);
            Computer.Beweeg(drawingCanvas);
            Speler.CheckHit(Computer.Bolletjes, Computer.Vierkantjes);
            Computer.CheckHit(Speler.Bolletjes, Speler.Vierkantjes);
            Speler.MaakVrij(drawingCanvas, "#CB2611");
            Computer.MaakVrij(drawingCanvas, "#13737C");
        }
        
        private void Spawner_Tick(object sender, EventArgs e)
        {
            HoofdSpelBolletje bolletjeRood = new HoofdSpelBolletje("#CB2611", drawingCanvas);
            Speler.Bolletjes.Add(bolletjeRood);
            bolletjeRood.DisplayOn(drawingCanvas);
            //entiteitenRood.Bolletjes = entiteitenRood.Bolletjes + 1;

            HoofdSpelBolletje bolletjeBlauw = new HoofdSpelBolletje("#13737C", drawingCanvas);
            Computer.Bolletjes.Add(bolletjeBlauw);
            bolletjeBlauw.DisplayOn(drawingCanvas);
            //entiteitenBlauw.Bolletjes = entiteitenBlauw.Bolletjes + 1;
        }
        private void Afteller_Tick(object sender, EventArgs e)
        {
            TimeSpan t = TimeSpan.FromSeconds(resterendeTijd);
            lblTijd.Content = String.Format("{0:D2}m:{1:D2}s", t.Minutes, t.Seconds);
            resterendeTijd--;
        }
        private void TijdOp() //Zet gameTijd op 0
        {
            AlleGebruikersLijst lijst = new AlleGebruikersLijst();

            for (int i = 0; i < lijst.Count; i++)
            {
                if (lijst[i].Id.Equals(actieveGebruiker.Id))
                {
                    lijst[i].SetGameTijdOp0();
                }
            }
            lijst.SchrijfLijst();
        }
        //Methods
        private void BindLijsten()
        {
            //Binding b = new Binding();
            //b.Source = speler.Bolletjes;
            //b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //b.Path = new PropertyPath("Bolletjes");
            //txtbRoodB.SetBinding(TextBlock.TextProperty, b);

            //b = new Binding();
            //b.Source = speler.Vierkantjes;
            //b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //b.Path = new PropertyPath("Vierkantjes");
            //txtbRoodV.SetBinding(TextBlock.TextProperty, b);

            //b = new Binding();
            //b.Source = computer.Bolletjes;
            //b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //b.Path = new PropertyPath("Bolletjes");
            //txtbBlauwB.SetBinding(TextBlock.TextProperty, b);

            //b = new Binding();
            //b.Source = computer.Vierkantjes;
            //b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //b.Path = new PropertyPath("Vierkantjes");
            //txtbBlauwV.SetBinding(TextBlock.TextProperty, b);
        }
        //Properties
        public HoofdspelSpeler Speler { get; set; }
        public HoofdspelSpeler Computer { get; set; }
    }
}
