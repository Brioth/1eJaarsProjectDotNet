using System;
using System.Collections.Generic;
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
    /* --ZombieSpel--
     * 
     * 
     * Timers:
     * spelTijdTimer: hoe lang het spel duurt op basis van gewonnen seconden
     * spawnerSpeler/spawnerComputer: Hoe snel er nieuwe humans spawnen
     * animationTimer: timer bewegingen
     * minuutTimer: elke minuut increased de spawnsnelheid van de computer om het spel moeilijker te maken
     * vijfSecondenTimer: Skill 2 en 4 duren 5 seconden
     * skill6Timer: skill 6 kan je 2x 5 seconden, 2x 4 seconden en 2x 3 seconden gebruiker
     * cooldownTimer: cooldown van 10 seconden eer je weer een skill kan gebruiken
     * Author: Carmen Celen
     * Date: 24/04/2015
     */
    public partial class ZombieSpel : Page
    {
        //Lokale variabelen
        private DispatcherTimer spelTijdTimer, spawnerSpeler, spawnerComputer, animationTimer, minuutTimer, vijfSecondenTimer, skill6Timer, cooldownTimer, aftelTimerSpel;
        private Gebruiker actieveGebruiker;
        private Point puntSpeler, puntComputer;
        private int skill1Aantal = 5;
        private int skill6Aantal = 2;
        private int skill6Tijd = 5;
        private int resterendeTijd, cooldown;
        //Constructors
        public ZombieSpel(Gebruiker actieveGebruiker)
        {
            InitializeComponent();
          
            this.actieveGebruiker = actieveGebruiker;
            Speler = new ZombieSpelSpeler();
            Computer = new ZombieSpelComputer();

            Binding BSpeler = new Binding("HumansSpeler.Count");
            BSpeler.Source = Speler;
            txtbRoodB.SetBinding(TextBlock.TextProperty, BSpeler);

            Binding VSpeler = new Binding("ZombiesSpeler.Count");
            VSpeler.Source = Speler;
            txtbRoodV.SetBinding(TextBlock.TextProperty, VSpeler);

            Binding BComputer = new Binding("HumansComputer.Count");
            BComputer.Source = Computer;
            txtbBlauwB.SetBinding(TextBlock.TextProperty, BComputer);

            Binding VComputer = new Binding("ZombiesComputer.Count");
            VComputer.Source = Computer;
            txtbBlauwV.SetBinding(TextBlock.TextProperty, VComputer);

            spelTijdTimer = new DispatcherTimer();
            spelTijdTimer.Interval = TimeSpan.FromSeconds(this.actieveGebruiker.GameTijdSec);
            spelTijdTimer.Tick += EindeSpel_Tick;
            spelTijdTimer.Start();

            minuutTimer = new DispatcherTimer();
            minuutTimer.Interval = TimeSpan.FromMinutes(1);
            minuutTimer.Tick += MinuutTimer_Tick;
            minuutTimer.Start();

            spawnerSpeler = new DispatcherTimer();
            spawnerSpeler.Interval = TimeSpan.FromSeconds(1);
            spawnerSpeler.Tick += SpawnSpeler_Tick;
            spawnerSpeler.Start();

            spawnerComputer = new DispatcherTimer();
            spawnerComputer.Interval = TimeSpan.FromMilliseconds(3000);
            spawnerComputer.Tick += SpawnComputer_Tick;
            spawnerComputer.Start();

            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(50);
            animationTimer.Tick += Animation_Tick;
            animationTimer.Start();

            vijfSecondenTimer = new DispatcherTimer();
            vijfSecondenTimer.Interval = TimeSpan.FromSeconds(5);
            vijfSecondenTimer.Stop();

            skill6Timer = new DispatcherTimer();
            skill6Timer.Tick += Skill6_Tick;
            skill6Timer.Stop();

            cooldownTimer = new DispatcherTimer();
            cooldownTimer.Interval = TimeSpan.FromSeconds(10);
            cooldownTimer.Tick += Cooldown_Tick;
            cooldownTimer.Stop();

            resterendeTijd = this.actieveGebruiker.GameTijdSec;

            aftelTimerSpel = new DispatcherTimer();
            aftelTimerSpel.Interval = TimeSpan.FromSeconds(1);
            aftelTimerSpel.Tick += Afteller_Tick;
            aftelTimerSpel.Start();
        }
        //Events
        private void MinuutTimer_Tick(object sender, EventArgs e)
        {
            int nieuweTijd = Convert.ToInt32(spawnerComputer.Interval.TotalMilliseconds) - 500;
            spawnerComputer.Interval = TimeSpan.FromMilliseconds(nieuweTijd);
        }
        private void Animation_Tick(object sender, EventArgs e)
        {
            Speler.Beweeg(spelCanvas);
            Computer.Beweeg(spelCanvas);
            Speler.CheckHit(Computer.HumansComputer, Computer.ZombiesComputer);
            Computer.CheckHit(Speler.HumansSpeler, Speler.ZombiesSpeler);
            Speler.MaakVrij(spelCanvas);
            Computer.MaakVrij(spelCanvas);
        }
        private void SpawnComputer_Tick(object sender, EventArgs e)
        {           
                ZombieSpelHuman humanComputer = new ZombieSpelHuman(puntComputer, "#13737C");
                Computer.HumansComputer.Add(humanComputer);
                humanComputer.DisplayOn(spelCanvas);            
        }
        private void SpawnSpeler_Tick(object sender, EventArgs e)
        {
                ZombieSpelHuman humanSpeler = new ZombieSpelHuman(puntSpeler, "#CB2611");
                Speler.HumansSpeler.Add(humanSpeler);
                humanSpeler.DisplayOn(spelCanvas);
        }
        private void BtnSkill1_Click(object sender, RoutedEventArgs e)
        {
            DisableSkills();
            Random richtingRandom = new Random();
            for (int i = 0; i < skill1Aantal; i++)
            {
                double x = richtingRandom.Next(Convert.ToInt32(spelCanvas.ActualWidth));
                double y = richtingRandom.Next(Convert.ToInt32(spelCanvas.ActualHeight));
                Point randomPunt = new Point(x, y);
                ZombieSpelHuman humanSpeler = new ZombieSpelHuman(randomPunt, "#CB2611");
                Speler.HumansSpeler.Add(humanSpeler);
                humanSpeler.DisplayOn(spelCanvas);
            }
            if (skill1Aantal > 1)
            {
                skill1Aantal--;
            }
        }
        private void BtnSkill2_Click(object sender, RoutedEventArgs e)
        {
            DisableSkills();
            vijfSecondenTimer.Tick += ResetSkill2_Tick;
            vijfSecondenTimer.Start();
            int nieuweTijd = Convert.ToInt32(spawnerSpeler.Interval.TotalMilliseconds)*10;
            spawnerSpeler.Interval = TimeSpan.FromMilliseconds(nieuweTijd);
        }
        private void ResetSkill2_Tick(object sender, EventArgs e)
        {
            vijfSecondenTimer.Stop();
            int oudeTijd = Convert.ToInt32(spawnerSpeler.Interval.TotalMilliseconds) / 10;
            spawnerSpeler.Interval = TimeSpan.FromMilliseconds(oudeTijd);
        }
        private void BtnSkill3_Click(object sender, RoutedEventArgs e)
        {
            DisableSkills();
            Random generator = new Random();
            int randomIndex = generator.Next(Speler.ZombiesSpeler.Count);
            Speler.ZombiesSpeler[randomIndex].GeraaktDoorEigen = true;
        }
        private void BtnSkill4_Click(object sender, RoutedEventArgs e)
        {
            DisableSkills();
            vijfSecondenTimer.Tick += ResetSkill4_Tick;
            vijfSecondenTimer.Start();
            int nieuweTijd = Convert.ToInt32(spawnerComputer.Interval.TotalMilliseconds) / 10;
            spawnerComputer.Interval = TimeSpan.FromMilliseconds(nieuweTijd);
        }
        private void ResetSkill4_Tick(object sender, EventArgs e)
        {
            vijfSecondenTimer.Stop();
            int oudeTijd = Convert.ToInt32(spawnerComputer.Interval.TotalMilliseconds) * 10;
            spawnerComputer.Interval = TimeSpan.FromMilliseconds(oudeTijd);
        }
        private void BtnSkill5_Click(object sender, RoutedEventArgs e)
        {
            DisableSkills();
            Random generator = new Random();
            int randomIndex = generator.Next(Computer.HumansComputer.Count);
            Computer.HumansComputer[randomIndex].Geraakt = true;
        }
        private void BtnSkill6_Click(object sender, RoutedEventArgs e)
        {
            DisableSkills();
            skill6Timer.Interval = TimeSpan.FromSeconds(skill6Tijd);
            skill6Timer.Start();
            spawnerComputer.IsEnabled = false;
        }
        private void Skill6_Tick(object sender, EventArgs e)
        {
            spawnerComputer.IsEnabled = true;
            if (skill6Aantal == 2)
            {
                skill6Aantal--;
            }
            else if (skill6Aantal == 1 )
            {
                skill6Aantal = 2;
                if (skill6Tijd <= 3)
                {
                    skill6Tijd = 0;
                }
                else
                {
                    skill6Tijd--;
                }
            }
        }
        private void Cooldown_Tick(object sender, EventArgs e)
        {
            cooldownTimer.Stop();
            btnSkill1.IsEnabled = true;
            btnSkill2.IsEnabled = true;
            btnSkill3.IsEnabled = true;
            btnSkill4.IsEnabled = true;
            btnSkill5.IsEnabled = true;
            btnSkill6.IsEnabled = true;
        }
        private void EindeSpel_Tick(object sender, EventArgs e)
        {
            spelTijdTimer.Stop();
            aftelTimerSpel.Stop();
            spawnerSpeler.Stop();
            spawnerComputer.Stop();
            animationTimer.Stop();
            minuutTimer.Stop();
            DisableSkills();
            cooldownTimer.Stop();

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
            StreamReader lezer = File.OpenText(@"HighscoresZombies.txt");
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
                if (scores[i][0] == actieveGebruiker.Id)
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
                int[] nieuweScore = { actieveGebruiker.Id, score };
                scores.Add(nieuweScore);
            }

            //Schrijf lijst
            File.WriteAllText(@"HighscoresZombies.txt", String.Empty);
            StreamWriter schrijver = File.AppendText(@"HighscoresZombies.txt");
            for (int i = 0; i < scores.Count; i++)
            {
                schrijver.WriteLine(scores[i][0] + ";" + scores[i][1]);
            }
            schrijver.Close();

        }

        private int BerekenScore()
        {
            int eigen = Speler.HumansSpeler.Count * 4 + Speler.ZombiesSpeler.Count * 2;
            int computer = Computer.HumansComputer.Count * 2 + Computer.ZombiesComputer.Count;
            return eigen - computer;
        }
        private void SpelCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            puntSpeler = new Point(spelCanvas.ActualWidth / 2, spelCanvas.ActualHeight - 75);
            puntComputer = new Point(spelCanvas.ActualWidth / 2, 25);
            Canvas.SetLeft(imgSpeler, puntSpeler.X);
            Canvas.SetTop(imgSpeler, puntSpeler.Y);
            Canvas.SetLeft(imgComputer, puntComputer.X);
            Canvas.SetTop(imgComputer, puntComputer.Y);
        }
        private void Afteller_Tick(object sender, EventArgs e)
        {
            TimeSpan t = TimeSpan.FromSeconds(resterendeTijd);
            lblTijd.Content = String.Format("{0:D2}m:{1:D2}s", t.Minutes, t.Seconds);
            resterendeTijd--;
        }
        //Methods
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
        private void DisableSkills()
        {
            cooldownTimer.Start();
            btnSkill1.IsEnabled = false;
            btnSkill2.IsEnabled = false;
            btnSkill3.IsEnabled = false;
            btnSkill4.IsEnabled = false;
            btnSkill5.IsEnabled = false;
            btnSkill6.IsEnabled = false;
        }
        //Properties
        public ZombieSpelSpeler Speler { get; set; }
        public ZombieSpelComputer Computer { get; set; }
    }
}
