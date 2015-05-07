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
     * Date: 28/04/2015
     * Op 28/04/2015 werd duidelijk dat de oefening niet ging werken in het project, dus ben opnieuw begonnen.
     * 
     * Random getallen genereren en gebruiken om oefeningen te berekenen. De uitkomst hiervan opslaan in een lijst.
     * Deze lijst vergelijken met de ingevoerde antwoorden van de gebruiker en het aantal juiste antwoorden weergeven als punten.
     * gespendeerde tijd wordt bijgehouden.
    */



    public partial class OefeningWiskundeMakkelijk : Page
    {
        // lokale variabelen
        Gebruiker actieveGebruiker;
        private int oefeningPunten;
        private Random randomTest = new Random();
        private int randomGetal1,randomGetal2;
        private String[] opgaveLijst = new String[10];
        private int[] oplossingLijst = new int[10];
        private List<int> randomLijst = new List<int>();
        private int beginBereik, eindBereik;
        private int totaalTijd;
        private Stopwatch tijdTeller;
        private string moeilijkheidsgraad = "MAK";

        //Constructors
        public OefeningWiskundeMakkelijk(Gebruiker actieveGebruiker)
        {
           
            InitializeComponent();
            this.actieveGebruiker = actieveGebruiker;
            tijdTeller = new Stopwatch();
            tijdTeller.Start();

            VulRanges();

            for (int i = 0; i < 10; i++)
            {
                randomGetal1 = randomTest.Next(beginBereik, eindBereik + 1);
                randomGetal2 = randomTest.Next(beginBereik, eindBereik + 1);

                // eerst uitkomst berekenen en die opslaan in labels
                // uitkomst ingeven als gebruiker en testen met verbeterknop
                //
                //
                oplossingLijst[i] = randomGetal1 * randomGetal2;
                randomLijst.Add(oplossingLijst[i]);

                randomGetal1.ToString();
                randomGetal2.ToString();


                opgaveLijst[i] = (randomGetal1.ToString() + " x " + (randomGetal2.ToString()));

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


            int randomGetal = randomTest.Next(randomLijst.Count());

            antwoordlabel1.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = randomTest.Next(randomLijst.Count());
            antwoordlabel2.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = randomTest.Next(randomLijst.Count());
            antwoordlabel3.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = randomTest.Next(randomLijst.Count());
            antwoordlabel4.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = randomTest.Next(randomLijst.Count());
            antwoordlabel5.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = randomTest.Next(randomLijst.Count());
            antwoordlabel6.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = randomTest.Next(randomLijst.Count());
            antwoordlabel7.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = randomTest.Next(randomLijst.Count());
            antwoordlabel8.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = randomTest.Next(randomLijst.Count());
            antwoordlabel9.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = randomTest.Next(randomLijst.Count());
            antwoordlabel10.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

        }

        // Methodes

        // Het bereik van de oefening wordt hier uit het .txt-bestand gelezen.
        private void VulRanges()
        {
            StreamReader reader = File.OpenText(@"rangesWiskunde.txt");
            string gelezen = reader.ReadLine();
            char[] scheiding = { ';' };

            while (gelezen != null)
            {
                string[] deel = gelezen.Split(scheiding);
                if (deel[0].Equals("makkelijk"))
                {
                    beginBereik = Convert.ToInt32(deel[1]);
                    eindBereik = Convert.ToInt32(deel[2]);
                }
                gelezen = reader.ReadLine();
            }
            reader.Close();
        }

        // Gegevens over hoe goed de leerling de oefening gemaakt heeft worden hier weggeschreven naar .txt-bestand
        private void Schrijfpunten()
        {
            ResultatenLijst lijst = new ResultatenLijst("OefResultatenWiskMak.txt");
            Resultaat behaaldResultaat = new Resultaat(actieveGebruiker.Id, oefeningPunten, totaalTijd,lijst);

            if (behaaldResultaat.IndexOud == -1)
            {
                lijst.Add(behaaldResultaat);
            }
            else
            {
                lijst.Add(behaaldResultaat);
                lijst.RemoveAt(behaaldResultaat.IndexOud);
            }
            lijst.SchrijfLijst("OefResultatenWiskMak.txt");
        }

    /* Author: Vincent Vandoninck
     * Date: 01/05/2015
     * Op 28/04/2015 werd duidelijk dat de oefening niet ging werken in het project, dus ben opnieuw begonnen.
    */

        //Events

        // http://stackoverflow.com/questions/17872707/wpf-c-sharp-drag-and-drop
        // Voor elke "drop" actie wordt de inhoud verwijderd voor de inhoud gedropped wordt. 
        private void TboxPreviewDrop(object sender, DragEventArgs e)
        {
            (sender as TextBox).Text = String.Empty;
        }

        //http://wpf.2000things.com/tag/drag-and-drop/
        //https://msdn.microsoft.com/en-us/library/ms742859(v=vs.110).aspx
        // De inhoud van de bron (antwoordLabel[0-9]) wordt tjdelijk opgeslagen als data en naar het object (dropTextbox[0-9]) doorgegeven.
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject(DataFormats.Text, ((Label)e.Source).Content);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Move);
        }

        private void LabelDrop(object sender, DragEventArgs e)
        {
            ((Label)e.Source).Content = (string)e.Data.GetData(DataFormats.Text);
        }

        // als je boven een object staat waar je kan op droppen veranderd je cursor.
        private void LabelGiveFeedback(object sender, GiveFeedbackEventArgs e)
        
        {
            if (e.Effects == DragDropEffects.Move)
            {
                e.UseDefaultCursors = false;
                Mouse.SetCursor(Cursors.Hand);
            }
            else
                e.UseDefaultCursors = true;

            e.Handled = true;
        }


        //author: Vincent Vandoninck
        //date: 28/04/2015

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
                    if ((oplossingLijst[0]) == Convert.ToInt32(dropTextbox1.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropTextbox1.Background = Brushes.Green;
                    }
                    else
                    {
                        dropTextbox1.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[1]) == Convert.ToInt32(dropTextbox2.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropTextbox2.Background = Brushes.Green;
                    }
                    else
                    {
                        dropTextbox2.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[2]) == Convert.ToInt32(dropTextbox3.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropTextbox3.Background = Brushes.Green;
                    }
                    else
                    {
                        dropTextbox3.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[3]) == Convert.ToInt32(dropTextbox4.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropTextbox4.Background = Brushes.Green;
                    }
                    else
                    {
                        dropTextbox4.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[4]) == Convert.ToInt32(dropTextbox5.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropTextbox5.Background = Brushes.Green;
                    }
                    else
                    {
                        dropTextbox5.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[5]) == Convert.ToInt32(dropTextbox6.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropTextbox6.Background = Brushes.Green;
                    }
                    else
                    {
                        dropTextbox6.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[6]) == Convert.ToInt32(dropTextbox7.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropTextbox7.Background = Brushes.Green;
                    }
                    else
                    {
                        dropTextbox7.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[7]) == Convert.ToInt32(dropTextbox8.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropTextbox8.Background = Brushes.Green;
                    }
                    else
                    {
                        dropTextbox8.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[8]) == Convert.ToInt32(dropTextbox9.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropTextbox9.Background = Brushes.Green;
                    }
                    else
                    {
                        dropTextbox9.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[9]) == Convert.ToInt32(dropTextbox10.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropTextbox10.Background = Brushes.Green;
                    }
                    else
                    {
                        dropTextbox10.Background = Brushes.Red;
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
            OefeningWiskundeMakkelijk oefWiskundeMakkelijkPagina = new OefeningWiskundeMakkelijk(actieveGebruiker);
            this.NavigationService.Navigate(oefWiskundeMakkelijkPagina);
        }

    }
}
