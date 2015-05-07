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
   /* Author: Vincent Vandoninck
    * Date: 03/05/2015
    * Op 28/04/2015 werd duidelijk dat de oefening niet ging werken in het project, dus ben opnieuw begonnen.
    *
    *Random getallen genereren en gebruiken om oefeningen te berekenen. De uitkomst hiervan opslaan in een lijst.
    *Deze lijst vergelijken met de ingevoerde antwoorden van de gebruiker en het aantal juiste antwoorden weergeven als punten.
    *gespendeerde tijd wordt bijgehouden
    */
    public partial class OefeningWiskundeGemiddeld : Page
    {
        //Lokale variabelen
        Gebruiker actieveGebruiker;
        private int oefeningPunten;
        private Random randomTest = new Random();
        private int randomGetal1, randomGetal2, randomGetal3;
        private int randomTeken1;
        private String[] opgaveLijst = new String[10];
        private int[] oplossingLijst = new int[10];
        private List<int> randomLijst = new List<int>();
        private int beginBereik, eindBereik;
        private int totaalTijd;
        private Stopwatch tijdTeller;
        private string moeilijkheidsgraad = "MED";
       
        //constructors
        public OefeningWiskundeGemiddeld(Gebruiker actieveGebruiker)
        {
           
            InitializeComponent();
            this.actieveGebruiker = actieveGebruiker;
            tijdTeller = new Stopwatch();
            tijdTeller.Start();

            VulRanges();

            for (int i = 0; i < 10; i++)
            {
                randomGetal1 = randomTest.Next(beginBereik, eindBereik +1);
                randomGetal2 = randomTest.Next(beginBereik, eindBereik +1);
                randomGetal3 = randomTest.Next(beginBereik, eindBereik +1);
                randomTeken1 = randomTest.Next(0, 2);

                if (randomTeken1 == 1)
                {
                    oplossingLijst[i] = randomGetal1 * randomGetal2 + randomGetal3;
                    randomLijst.Add(oplossingLijst[i]);


                    opgaveLijst[i] = (randomGetal1.ToString() + " x " + (randomGetal2.ToString()) + " + " + (randomGetal3.ToString()));

                }
                else
                {
                    oplossingLijst[i] = randomGetal1 * randomGetal2 - randomGetal3;
                    randomLijst.Add(oplossingLijst[i]);

                    opgaveLijst[i] = (randomGetal1.ToString() + " x " + (randomGetal2.ToString()) + " - " + randomGetal3.ToString());
                }

                opgaveblock1.Content = opgaveLijst[0];
                opgaveblock2.Content = opgaveLijst[1];
                opgaveblock3.Content = opgaveLijst[2];
                opgaveblock4.Content = opgaveLijst[3];
                opgaveblock5.Content = opgaveLijst[4];
                opgaveblock6.Content = opgaveLijst[5];
                opgaveblock7.Content = opgaveLijst[6];
                opgaveblock8.Content = opgaveLijst[7];
                opgaveblock9.Content = opgaveLijst[8];
                opgaveblock10.Content = opgaveLijst[9];
            }
        }
        //methodes

        // Het bereik van de oefening wordt hier berekend.
        private void VulRanges()
        {
            StreamReader reader = File.OpenText(@"rangesWiskunde.txt");
            string gelezen = reader.ReadLine();
            char[] scheiding = { ';' };

            while (gelezen != null)
            {
                string[] deel = gelezen.Split(scheiding);
                if (deel[0].Equals("gemiddeld"))
                {
                    beginBereik = Convert.ToInt32( deel[1]);
                    eindBereik = Convert.ToInt32(deel[2]);
            }
                gelezen = reader.ReadLine();
            }
            reader.Close();
        }

        // Gegevens over hoe goed de leerling de oefening gemaakt heeft worden hier weggeschreven naar .txt-bestand
        private void Schrijfpunten()
        {
            ResultatenLijst lijst = new ResultatenLijst("OefResultatenWiskGem.txt");
            Resultaat behaaldResultaat = new Resultaat(actieveGebruiker.Id, oefeningPunten, totaalTijd, lijst);

            if (behaaldResultaat.IndexOud == -1)
            {
                lijst.Add(behaaldResultaat);
            }
            else
            {
                lijst.Add(behaaldResultaat);
                lijst.RemoveAt(behaaldResultaat.IndexOud);
            }
            lijst.SchrijfLijst("OefResultatenWiskGem.txt");
        }

        //author: Vincent Vandoninck
        //date: 28/04/2015

        //events

        // Punten worden eerst terug op 0 gezet, opnieuw berekend en toonbaar gemaakt. 
        // De ingegeven oplossingen worden vergelekekn met de oplossingen die in de lijst staan opgeslagen.
        // De achtergrond van de label's veranderd aan de hand of deze correct is of niet. 
        // De behaalde punten en tijd wordt opgeslagen.

        private void VerbeterButton_Click(object sender, RoutedEventArgs e)
        {
            oefeningPunten = 0;
            tijdTeller.Stop();
            totaalTijd = Convert.ToInt32(tijdTeller.ElapsedMilliseconds / 1000);
            {
                try
                {
                    if ((oplossingLijst[0]).Equals(dropLabel1.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel1.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel1.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[1]).Equals(dropLabel2.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel2.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel2.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[2]).Equals(dropLabel3.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel3.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel3.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[3]).Equals(dropLabel4.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel4.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel4.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[4]).Equals(dropLabel5.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel5.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel5.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[5]).Equals(dropLabel6.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel6.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel6.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[6]).Equals(dropLabel7.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel7.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel7.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[7]).Equals(dropLabel8.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel8.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel8.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[8]).Equals(dropLabel9.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel9.Background = Brushes.Green;
                    }

                    else
                    {
                        dropLabel9.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[9]).Equals(dropLabel10.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel10.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel10.Background = Brushes.Red;
                    }
                    Punten.Text = ("u heeft  " + oefeningPunten + " punten behaald. ");
                    Schrijfpunten();
                 
                    verbeterButton.IsEnabled = false;
                    AlleGebruikersLijst lijst = new AlleGebruikersLijst();
                     foreach (Gebruiker item in lijst)
                      {
                        if (actieveGebruiker.Id.Equals(item.Id))
                        {
                           item.SetGameTijd(oefeningPunten , moeilijkheidsgraad);
                        }
                      }
                    lijst.SchrijfLijst();
                     
                }
                   
                    // Deze catch zorgt ervoor dat er altijd een antwoord moet ingevuld worden.
                    // Als er letters worden ingegeven in plaats van cijfers worden deze als fout beschouwd.
                catch (FormatException)
                {
                    MessageBox.Show("zet 0 als je het antwoord niet weet");
                }
            }
        }
        //author: Vincent Vandoninck
        //date: 04/05/2015

        // Navigatie terug naar het leerlingenmenu.
        private void TerugButton_Click(object sender, RoutedEventArgs e)
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

        // Er wordt een nieuwe pagina geladen.
        // De gebruiker merkt dit niet, deze merkt enkel dat de oefeningen veranderen.
        private void OpnieuwButton_Click(object sender, RoutedEventArgs e)
        {
            OefeningWiskundeGemiddeld oefWiskundeGemiddeldPagina = new OefeningWiskundeGemiddeld(actieveGebruiker);
            this.NavigationService.Navigate(oefWiskundeGemiddeldPagina);
        }
    }
}
