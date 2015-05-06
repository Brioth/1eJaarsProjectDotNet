using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

            Binding BSpeler = new Binding("Bolletjes.Count");
            BSpeler.Source = Speler;
            txtbRoodB.SetBinding(TextBlock.TextProperty, BSpeler);

            Binding VSpeler = new Binding("Vierkantjes.Count");
            VSpeler.Source = Speler;
            txtbRoodV.SetBinding(TextBlock.TextProperty, VSpeler);

            Binding BComputer = new Binding("Bolletjes.Count");
            BComputer.Source = Computer;
            txtbBlauwB.SetBinding(TextBlock.TextProperty, BComputer);

            Binding VComputer = new Binding("Vierkantjes.Count");
            VComputer.Source = Computer;
            txtbBlauwV.SetBinding(TextBlock.TextProperty, VComputer);

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
            int score = BerekenScore();

            MessageBox.Show("Proficiat, je score is " + score);
            SchrijfScore(score);
            //scores weergeven en wegschrijven
            TijdOp(); //Zet gameTijd op 0
        }

        private void SchrijfScore(int score)
        {
            List<int[]> scores = new List<int[]>();

            //oude scores inlezen
            StreamReader lezer = File.OpenText(@"HighscoresBolletjes.txt");
            string regel = lezer.ReadLine();
            char[] scheiding = { ';' };

            while (regel != null)
            {
                string[] deel = regel.Split(scheiding);
                int[] getallen = { Convert.ToInt32(deel[0].Trim()), Convert.ToInt32(deel[1].Trim()) };
                scores.Add(getallen);
                regel = lezer.ReadLine();
            }

            lezer.Close();


            //nieuwe vervangen/toevoegen
            bool nieuw = false;
 
            for (int i = 0; i < scores.Count; i++)
            {
                if (scores[i][0]==actieveGebruiker.Id)
                {
                    if (scores[i][1] < score)
                    {
                        scores[i][1] = score;
                    }
                    nieuw = true;
                }
            }
            if (nieuw == false)
            {
                int[] nieuweScore = {actieveGebruiker.Id, score};
                scores.Add(nieuweScore);
            }

            //Schrijf lijst
            File.WriteAllText(@"HighscoresBolletjes.txt", String.Empty);
            StreamWriter schrijver = File.AppendText(@"HighscoresBolletjes.txt");
            for (int i = 0; i < scores.Count; i++)
            {
                schrijver.WriteLine(scores[i][0] + ";" + scores[i][1]);
            }
            schrijver.Close();

        }

        private int BerekenScore()
        {
            int eigen = Speler.Bolletjes.Count * 4 + Speler.Vierkantjes.Count * 2;
            int computer = Computer.Bolletjes.Count * 2 + Computer.Vierkantjes.Count;
            return eigen - computer;
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
      

            HoofdSpelBolletje bolletjeBlauw = new HoofdSpelBolletje("#13737C", drawingCanvas);
            Computer.Bolletjes.Add(bolletjeBlauw);
            bolletjeBlauw.DisplayOn(drawingCanvas);
            
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
       
        //Properties
        public HoofdspelSpeler Speler { get; set; }
        public HoofdspelSpeler Computer { get; set; }
    }
}
