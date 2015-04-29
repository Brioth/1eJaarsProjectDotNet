using System;
using System.Collections.Generic;
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
     * Author: Carmen Celen
     * Date: 24/04/2015
     */
    public partial class ZombieSpel : Page
    {
        //Lokale variabelen
        private ZombieSpelSpeler speler;
        private ZombieSpelComputer computer;
        private DispatcherTimer spelTijdTimer, spawnerSpeler, spawnerComputer, animationTimer;
        private Gebruiker actieveGebruiker;
        private Point puntSpeler, puntComputer;
        //Constructors
        public ZombieSpel(Gebruiker actieveGebruiker)
        {
            InitializeComponent();
          
            this.actieveGebruiker = actieveGebruiker;
            speler = new ZombieSpelSpeler();
            computer = new ZombieSpelComputer();

            spelTijdTimer = new DispatcherTimer();
            spelTijdTimer.Interval = TimeSpan.FromSeconds(this.actieveGebruiker.GameTijdSec);
            spelTijdTimer.Tick += eindeSpel_Tick;
            spelTijdTimer.IsEnabled = true;

            spawnerSpeler = new DispatcherTimer();
            spawnerSpeler.Interval = TimeSpan.FromSeconds(1);
            spawnerSpeler.Tick += spawnSpeler_Tick;
            spawnerSpeler.IsEnabled = true;

            spawnerComputer = new DispatcherTimer();
            spawnerComputer.Interval = TimeSpan.FromSeconds(3);
            spawnerComputer.Tick += spawnComputer_Tick;
            spawnerComputer.IsEnabled = true;

            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(50);
            animationTimer.Tick += animation_Tick;
            animationTimer.IsEnabled = true;

        }

        private void animation_Tick(object sender, EventArgs e)
        {
            speler.Beweeg(spelCanvas);
            computer.Beweeg(spelCanvas);
            speler.CheckHit(computer.HumansComputer, computer.ZombiesComputer);
            computer.CheckHit(speler.HumansSpeler, speler.ZombiesSpeler);
            VeranderSprites();
            DoodSprites();
        }

        private void DoodSprites()
        {
            for (int i = 0; i < speler.HumansSpeler.Count; i++)
            {
                if (speler.HumansSpeler[i].Geraakt)
                {
                    spelCanvas.Children.Remove(speler.HumansSpeler[i]);
                    speler.HumansSpeler.RemoveAt(i);
                }
            }
            for (int i = 0; i < speler.ZombiesSpeler.Count; i++)
            {
                if (speler.ZombiesSpeler[i].GeraaktDoorEigen || speler.ZombiesSpeler[i].GeraaktDoorVijand)
                {
                    spelCanvas.Children.Remove(speler.ZombiesSpeler[i]);
                    speler.ZombiesSpeler.RemoveAt(i);
                }
            }
            for (int i = 0; i < computer.HumansComputer.Count; i++)
            {
                if (computer.HumansComputer[i].Geraakt)
                {
                    spelCanvas.Children.Remove(computer.HumansComputer[i]);
                    computer.HumansComputer.RemoveAt(i);
                }
            }
            for (int i = 0; i < speler.ZombiesSpeler.Count; i++)
            {
                if (computer.ZombiesComputer[i].GeraaktDoorEigen || computer.ZombiesComputer[i].GeraaktDoorVijand)
                {
                    spelCanvas.Children.Remove(computer.ZombiesComputer[i]);
                    computer.ZombiesComputer.RemoveAt(i);
                }
            }
        }

        private void VeranderSprites()
        {
            for (int i = 0; i < speler.HumansSpeler.Count; i++)
            {
                if (speler.HumansSpeler[i].Geraakt) //als human geraakt door vijand maak zombie
                {
                    Point positie = speler.HumansSpeler[i].Positie;
                    ZombieSpelZombie zombieSpeler = new ZombieSpelZombie(positie, "#CB2611");
                    speler.ZombiesSpeler.Add(zombieSpeler);
                    zombieSpeler.DisplayOn(spelCanvas);
                }
            }
            for (int i = 0; i < speler.ZombiesSpeler.Count; i++) //als zombie geraakt door eigen maak human
            {
                if (speler.ZombiesSpeler[i].GeraaktDoorEigen)
                {
                    Point positie = speler.ZombiesSpeler[i].Positie;
                    ZombieSpelHuman humanSpeler = new ZombieSpelHuman(positie, "#CB2611");
                    speler.HumansSpeler.Add(humanSpeler);
                    humanSpeler.DisplayOn(spelCanvas);
                }
            }
            for (int i = 0; i < computer.HumansComputer.Count; i++)
            {
                if (computer.HumansComputer[i].Geraakt) //als human geraakt door vijand maak zombie
                {
                    Point positie = computer.HumansComputer[i].Positie;
                    ZombieSpelZombie zombieComputer = new ZombieSpelZombie(positie, "#13737C");
                    computer.ZombiesComputer.Add(zombieComputer);
                    zombieComputer.DisplayOn(spelCanvas);
                }
            }
            for (int i = 0; i < computer.ZombiesComputer.Count; i++) //als zombie geraakt door eigen maak human
            {
                if (computer.ZombiesComputer[i].GeraaktDoorEigen)
                {
                    Point positie = computer.ZombiesComputer[i].Positie;
                    ZombieSpelHuman humanComputer = new ZombieSpelHuman(positie, "#13737C");
                    computer.HumansComputer.Add(humanComputer);
                    humanComputer.DisplayOn(spelCanvas);
                }
            }
        }

        private void spawnComputer_Tick(object sender, EventArgs e)
        {
            ZombieSpelHuman humanComputer = new ZombieSpelHuman(puntComputer, "#13737C");
            computer.HumansComputer.Add(humanComputer);
            humanComputer.DisplayOn(spelCanvas);
        }

        private void spawnSpeler_Tick(object sender, EventArgs e)
        {
            ZombieSpelHuman humanSpeler = new ZombieSpelHuman(puntSpeler, "#CB2611");
            speler.HumansSpeler.Add(humanSpeler);
            humanSpeler.DisplayOn(spelCanvas);
        }
        //Events
        private void btnSkill1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSkill2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSkill3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSkill4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSkill5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSkill6_Click(object sender, RoutedEventArgs e)
        {

        }
        private void eindeSpel_Tick(object sender, EventArgs e)
        {
            //spelTijdTimer.IsEnabled = false;
            //spawnerSpeler.IsEnabled = false;
            //spawnerComputer.IsEnabled = false;
            //animationTimer.IsEnabled = false;

            //MessageBox.Show("Tijd is op");
            ////scores weergeven en wegschrijven
            //TijdOp(); //Zet gameTijd op 0


        }
        //Methods
        private void TijdOp() //Zet gameTijd op 0
        {
            AlleGebruikersLijst lijst = new AlleGebruikersLijst();

            for (int i = 0; i < lijst.Count; i++)
            {
                if (lijst[i].Id == actieveGebruiker.Id)
                {
                    lijst[i].SetGameTijdOp0();
                }
            }
            lijst.SchrijfLijst();
        }

        private void spelCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            puntSpeler = new Point(spelCanvas.ActualWidth / 2, spelCanvas.ActualHeight - 75);
            puntComputer = new Point(spelCanvas.ActualWidth / 2, 25);
            Canvas.SetLeft(imgSpeler, puntSpeler.X);
            Canvas.SetTop(imgSpeler, puntSpeler.Y);
            Canvas.SetLeft(imgComputer, puntComputer.X);
            Canvas.SetTop(imgComputer, puntComputer.Y);
        }

    }
}
