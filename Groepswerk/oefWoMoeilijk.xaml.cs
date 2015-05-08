using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for oefWoMoeilijk.xaml
    /// </summary>
    /// author: Seppe Vandezande
    /// date: 26/04/2015
    public partial class OefWoMoeilijk : Page
    {
        private Gebruiker actieveGebruiker;
        private string moeilijkheidsgraad = "MOE";
         private OefeningLijst lijstOefeningen;
        private string[] tempOpgave, tempOplossing1;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag;
        private IList<string> oefLijst;
        private int oefCorrect = 0;
        private IList<int> oefeningNummerLijst;
        private int totaalTijd;
        private Stopwatch tijdTeller;

        public OefWoMoeilijk( Gebruiker actieveGebruiker){
            
          InitializeComponent();
          this.actieveGebruiker = actieveGebruiker;
          //stopwatch initialiseren en starten, om gespeelde tijd te weten
          tijdTeller = new Stopwatch();
          tijdTeller.Start();
            lijstOefeningen = new OefeningLijst("WoMoeilijk");//lijst vullen met alle oefeningen
            oefeningNummerLijst = new List<int>();

            tempOpgave = new string[5];
            tempOplossing1 = new string[5];

            for (int i = 0; i < 5; i++)//5 willekeurige oefeningen kiezen
            {
                oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, (lijstOefeningen.Count )));

                while (oefeningNummerLijst.Contains(oefeningenNummerOpslag))
                {
                    oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, lijstOefeningen.Count));
                }
                tempOpgave[i] = lijstOefeningen[oefeningenNummerOpslag].opgave;
                tempOplossing1[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing1;
                oefeningNummerLijst.Add(oefeningenNummerOpslag);
            }

            label1.Content= tempOpgave[0];
            label2.Content = tempOpgave[1];
            label3.Content = tempOpgave[2];
            labbel4.Content = tempOpgave[3];
            label5.Content = tempOpgave[4];
           
            

        }

       
        private void SchrijfPunten() {//punten wegschrijven naar tekstfile
           
            ResultatenLijst lijst = new ResultatenLijst("resultaatWoMoeilijk.txt");
            Resultaat nieuw = new Resultaat(actieveGebruiker.Id, oefCorrect*2, totaalTijd, lijst);

            if (nieuw.IndexOud == -1)
            {
                lijst.Add(nieuw);
            }
            else
            {
                lijst.Add(nieuw);
                lijst.RemoveAt(nieuw.IndexOud);
            }
            lijst.SchrijfLijst("resultaatWoMoeilijk.txt");
        }
        
        private void controleer_Click(object sender, RoutedEventArgs e)//antwoorden controleren en score doorsturen
        {
            controleer.IsEnabled = false;
            tijdTeller.Stop();
            totaalTijd = Convert.ToInt32(tijdTeller.ElapsedMilliseconds / 1000);//timer stoppen en omzetten naar seconden.

            if (!((textbox1.Text).Equals (lijstOefeningen[oefeningNummerLijst[0]].oplossing)))
            {
               textbox1.Background=Brushes.Red;
                antwoord1.Content=lijstOefeningen[oefeningNummerLijst[0]].oplossing;
            }
            else
            {
                oefCorrect++;
                 textbox1.Background=Brushes.Green;
            }

            if (!((textbox2.Text).Equals(lijstOefeningen[oefeningNummerLijst[1]].oplossing)))
                {
                   textbox2.Background=Brushes.Red;
                 antwoord2.Content=lijstOefeningen[oefeningNummerLijst[1]].oplossing;
                }
            else
                {
                    oefCorrect++;
                 textbox2.Background=Brushes.Green;
                }

            if (!((textbox3.Text).Equals(lijstOefeningen[oefeningNummerLijst[2]].oplossing)))
                {
                   textbox3.Background=Brushes.Red;
                   antwoord3.Content = lijstOefeningen[oefeningNummerLijst[2]].oplossing;
                }
            else
                {
                    oefCorrect++;
                 textbox3.Background=Brushes.Green;
                }

            if (!((textbox4.Text).Equals(lijstOefeningen[oefeningNummerLijst[3]].oplossing)))
                {
                    textbox4.Background=Brushes.Red;
                    antwoord4.Content = lijstOefeningen[oefeningNummerLijst[3]].oplossing;
            }
            else
                {
                    oefCorrect++;
                 textbox4.Background=Brushes.Green;
                }

            if (!((textbox5.Text).Equals(lijstOefeningen[oefeningNummerLijst[4]].oplossing)))
                {
                   textbox5.Background=Brushes.Red;
                   antwoord5.Content = lijstOefeningen[oefeningNummerLijst[4]].oplossing;
                }
            else
                {
                    oefCorrect++;
                textbox5.Background=Brushes.Green;
                }

            AlleGebruikersLijst lijst = new AlleGebruikersLijst();
            foreach (Gebruiker item in lijst)
            {
                if (actieveGebruiker.Id.Equals(item.Id))
                    item.actieveGebruiker.SetGameTijd(oefCorrect * 2, moeilijkheidsgraad);//gewonnen gametijd berekenen
            }
            lijst.SchrijfLijst();

            SchrijfPunten();
            Score.Content = Convert.ToString(oefCorrect) + "/5";
        }

        private void TerugButton_Click(object sender, RoutedEventArgs e)//terugkeren naar het llnmenu
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

        private void OpnieuwButton_Click(object sender, RoutedEventArgs e)//oefening herstarten
        {
            OefWoMoeilijk moeilijk = new OefWoMoeilijk(actieveGebruiker);
            this.NavigationService.Navigate(moeilijk);
        }
        }
}
