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

namespace Groepswerk
{
    /* --HighScores--
     * Top 5 van de klas wordt weergegeven
     * Indien zombiespel niet speelbaar is worden deze ook niet weergegeven
     * Author: Carmen Celen
     * Date: 6/05/2015
     */
    public partial class HighScores : Page
    {
        //Lokale variabelen
        private Accountlijst lijst;
        private int[] scoreB, scoreZ;
        private string[] idB, idZ;
        private Gebruiker actieveGebruiker;

        //Constructors
        public HighScores(Gebruiker actieveGebruiker)
        {
            InitializeComponent();

            this.actieveGebruiker = actieveGebruiker;
            lijst = new Accountlijst(actieveGebruiker.Klas);

            idB = new string[5];
            idZ = new string[5];
            scoreB = new int[5];
            scoreZ = new int[5];

            MaakLijsten();
            VulTot5();
            VulVakjes();
        }

        //Events
        private void terugButton_Click(object sender, RoutedEventArgs e)
        {
            LeerlingMenu terugMenu = new LeerlingMenu(actieveGebruiker);
            this.NavigationService.Navigate(terugMenu);
        }

        //Methods
        private void VulTot5()
        {
            for (int i = 0; i < 5; i++)
            {
                if (scoreB[i] == 0)
                {
                    idB[i] = "-";
                }
                if (scoreZ[i] == 0)
                {
                    idZ[i] = "-";
                }
            }

        }
        private void VulVakjes()
        {
            b1.Text = "1. " + idB[0] + " : " + scoreB[0];
            b2.Text = "2. " + idB[1] + " : " + scoreB[1];
            b3.Text = "3. " + idB[2] + " : " + scoreB[2];
            b4.Text = "4. " + idB[3] + " : " + scoreB[3];
            b5.Text = "5. " + idB[4] + " : " + scoreB[4];

            if (actieveGebruiker.Klas.Zombie)
            {
                z1.Text = "1. " + idZ[0] + " : " + scoreZ[0];
                z2.Text = "2. " + idZ[1] + " : " + scoreZ[1];
                z3.Text = "3. " + idZ[2] + " : " + scoreZ[2];
                z4.Text = "4. " + idZ[3] + " : " + scoreZ[3];
                z5.Text = "5. " + idZ[4] + " : " + scoreZ[4];
            }
            else
            {
                lblZombie.Visibility = Visibility.Collapsed;
                colZombie.Width = new GridLength(0, GridUnitType.Star);
                colSpatie.Width = new GridLength(0, GridUnitType.Star);
            }
        }
        private void MaakLijsten()
        {
            //Maak arrays van Hoofdspel

            StreamReader lezerB = File.OpenText(@"HighscoresBolletjes.txt");
            string regel = lezerB.ReadLine();
            char[] scheiding = { ';' };


            int i = 0;
            while (regel != null)
            {
                string[] woorden = regel.Split(scheiding);
                for (int j = 0; j < woorden.Length; j++)
                {
                    woorden[j] = woorden[j].Trim();
                }

                foreach (Gebruiker item in lijst)
                {
                    if (Convert.ToString(item.Id).Equals(woorden[0]) && i < 5)
                    {
                        idB[i] = item.ToString();
                        scoreB[i] = Convert.ToInt32(woorden[1]);
                        i++;
                    }
                }

                regel = lezerB.ReadLine();
            }
            lezerB.Close();

            Array.Sort(scoreB, idB); //Sorteert de arrays
            Array.Reverse(scoreB);
            Array.Reverse(idB);

            //Maak arrays van ZombieEdition
            StreamReader lezerZ = File.OpenText(@"HighscoresZombies.txt");
            regel = lezerZ.ReadLine();

            i = 0;
            while (regel != null)
            {
                string[] woorden = regel.Split(scheiding);
                for (int j = 0; j < woorden.Length; j++)
                {
                    woorden[j] = woorden[j].Trim();
                }

                foreach (Gebruiker item in lijst)
                {
                    if (Convert.ToString(item.Id).Equals(woorden[0]) && i < 5)
                    {
                        idZ[i] = item.ToString();
                        scoreZ[i] = Convert.ToInt32(woorden[1]);
                        i++;
                    }
                }

                regel = lezerZ.ReadLine();
            }
            lezerZ.Close();

            Array.Sort(scoreZ, idZ); //Sorteert de arrays
            Array.Reverse(scoreZ);
            Array.Reverse(idZ);
        }
        //Properties

    }
}
