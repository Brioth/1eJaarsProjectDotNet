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
            speler.CheckHit();
            computer.CheckHit();
        }

        private void spawnComputer_Tick(object sender, EventArgs e)
        {
            Point spawnPunt = new Point(127.0, 65.0);
            ZombieSpelHuman humanComputer = new ZombieSpelHuman(spawnPunt, "#13737C");
            computer.HumansComputer.Add(humanComputer);
            humanComputer.DisplayOn(spelCanvas);
        }

        private void spawnSpeler_Tick(object sender, EventArgs e)
        {
            Point spawnPunt = new Point(127.0, 235.0);
            ZombieSpelHuman humanSpeler = new ZombieSpelHuman(spawnPunt, "#CB2611");
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

    }
}
