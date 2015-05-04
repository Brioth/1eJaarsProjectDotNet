using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    //Author: Vincent Vandoninck
    //Date: 03/05/2015

    /// <summary>
    /// Interaction logic for oefeningWiskundeMoeilijk.xaml
    /// </summary>
    public partial class oefeningWiskundeMoeilijk : Page
    {
        //Lokale variabelen
        Gebruiker actieveGebruiker;
        private int oefeningPunten;
        private Random RandomTest = new Random();
        private int randomGetal1;
        private int randomGetal2;
        private int randomGetal3;
        private int randomGetal4;
        private int randomTeken1;
        private String[] OpgaveLijst = new String[10];
        private int[] oplossingLijst = new int[10];
        private List<int> randomLijst = new List<int>();
        private int begin, eind;
        private long totaalTijd;
        private Stopwatch tijdTeller;

        //Constructors
        public oefeningWiskundeMoeilijk(Gebruiker actieveGebruiker)
        {
            this.actieveGebruiker = actieveGebruiker;
            tijdTeller.Start();

            InitializeComponent();
            // of 2 random getallen tss 10 laten maken en die uitkomst ervan laten berekenen en opslaan in lijst (txt bestand)
            // lijst vergelijken met de user input

            VulRanges();

            for (int i = 0; i < 10; i++)
            {
                randomGetal1 = RandomTest.Next(begin, eind + 1);
                randomGetal2 = RandomTest.Next(begin, eind + 1);
                randomGetal3 = RandomTest.Next(begin, eind + 1);
                randomGetal4 = RandomTest.Next(begin, eind + 1);
                randomTeken1 = RandomTest.Next(0, 2);

                // eerst uitkomst berekenen en die opslaan in labels
                // uitkomst ingeven als gebruiker en testen met verbeterknop

                if (randomTeken1 == 1)
                {
                    oplossingLijst[i] = randomGetal1 * randomGetal2 + randomGetal3 * randomGetal4;
                    randomLijst.Add(oplossingLijst[i]);
                    OpgaveLijst[i] = (randomGetal1.ToString() + " x " + (randomGetal2.ToString()) + " + " + (randomGetal3.ToString()) + " x " + (randomGetal4.ToString()));
                }
                else
                {
                    oplossingLijst[i] = randomGetal1 * randomGetal2 - randomGetal3 * randomGetal4;
                    randomLijst.Add(oplossingLijst[i]);
                    OpgaveLijst[i] = (randomGetal1.ToString() + " x " + (randomGetal2.ToString()) + " - " + randomGetal3.ToString() + " x " + (randomGetal4.ToString()));
                }

                opgaveblock1.Content = OpgaveLijst[0];
                opgaveblock2.Content = OpgaveLijst[1];
                opgaveblock3.Content = OpgaveLijst[2];
                opgaveblock4.Content = OpgaveLijst[3];
                opgaveblock5.Content = OpgaveLijst[4];
                opgaveblock6.Content = OpgaveLijst[5];
                opgaveblock7.Content = OpgaveLijst[6];
                opgaveblock8.Content = OpgaveLijst[7];
                opgaveblock9.Content = OpgaveLijst[8];
                opgaveblock10.Content = OpgaveLijst[9];
            }
        }

        private void VulRanges()
        {
            StreamReader reader = File.OpenText(@"rangesWiskunde.txt");
            string gelezen = reader.ReadLine();
            char[] scheiding = { ';' };

            while (gelezen != null)
            {
                string[] deel = gelezen.Split(scheiding);
                if (deel[0].Equals("moeilijk"))
                {
                    begin = Convert.ToInt32(deel[1]);
                    eind = Convert.ToInt32(deel[2]);
                }
                gelezen = reader.ReadLine();
            }
            reader.Close();
        }

        //author: Vincent Vandoninck
        //date: 28/04/2015

        //events
        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            oefeningPunten = 0;
            tijdTeller.Stop();
            totaalTijd = tijdTeller.ElapsedMilliseconds * 1000;
            {
                try
                {
                    if ((oplossingLijst[0]) == Convert.ToInt32(dropLabel1.Text))
                    {
                        oefeningPunten++;
                        dropLabel1.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel1.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[1]) == Convert.ToInt32(dropLabel2.Text))
                    {
                        oefeningPunten++;
                        dropLabel2.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel2.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[2]) == Convert.ToInt32(dropLabel3.Text))
                    {
                        oefeningPunten++;
                        dropLabel3.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel3.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[3]) == Convert.ToInt32(dropLabel4.Text))
                    {
                        oefeningPunten++;
                        dropLabel4.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel4.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[4]) == Convert.ToInt32(dropLabel5.Text))
                    {
                        oefeningPunten++;
                        dropLabel5.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel5.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[5]) == Convert.ToInt32(dropLabel6.Text))
                    {
                        oefeningPunten++;
                        dropLabel6.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel6.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[6]) == Convert.ToInt32(dropLabel7.Text))
                    {
                        oefeningPunten++;
                        dropLabel7.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel7.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[7]) == Convert.ToInt32(dropLabel8.Text))
                    {
                        oefeningPunten++;
                        dropLabel8.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel8.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[8]) == Convert.ToInt32(dropLabel9.Text))
                    {
                        oefeningPunten++;
                        dropLabel9.Background = Brushes.Green;
                    }

                    else
                    {
                        dropLabel9.Background = Brushes.Red;
                    } 
                    if ((oplossingLijst[9]) == Convert.ToInt32(dropLabel10.Text))
                    {
                        oefeningPunten++;
                        dropLabel10.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel10.Background = Brushes.Red;
                    }
                    Punten.Text = ("u heeft  " + oefeningPunten + " behaald. ");
                }

                   
                catch (FormatException)
                {
                    MessageBox.Show("zet 0 als je het antwoord niet weet");
                }
            }
        }
        private void terugButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult terug = MessageBox.Show("Ben je zeker dat je terug wilt naar het leerlingenmenu?", "Terug", MessageBoxButton.YesNo);
            switch (terug)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    LeerlingMenu terugMenu = new LeerlingMenu(actieveGebruiker);
                    this.NavigationService.Navigate(terugMenu);
                    break;
                default:
                    break;
            }
        }
        private void opnieuwButton_Click(object sender, RoutedEventArgs e)
        {
            oefeningWiskundeMoeilijk oefWiskundeMoeilijkPagina = new oefeningWiskundeMoeilijk(actieveGebruiker);
            this.NavigationService.Navigate(oefWiskundeMoeilijkPagina);
        }
    }
}
