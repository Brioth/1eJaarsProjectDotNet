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
    /// Interaction logic for oefWoMakkelijk.xaml
    /// </summary>
    /// //author: Seppe Vandezande
    /// //Date:28/04/2015
    public partial class OefWoMakkelijk : Page
    {
        private Gebruiker actieveGebruiker;
        private OefeningLijst lijstOefeningen;
        private string moeilijkheidsgraad = "MAK";
        private string[] tempOpgave, tempOplossing1;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag;
        private IList<string> oefLijst;
        private int oefCorrect = 0;
        private IList<int> oefeningNummerLijst;
        private int totaalTijd;
        private Stopwatch tijdTeller;
       
        public OefWoMakkelijk( Gebruiker actieveGebruiker){
            
          InitializeComponent();
          tijdTeller = new Stopwatch();//stopwatch initialiseren en starten
          tijdTeller.Start();
          this.actieveGebruiker = actieveGebruiker;
            lijstOefeningen = new OefeningLijst("WoMakkelijk");//lijst vullen met oef uit txt file
            oefeningNummerLijst = new List<int>();

            tempOpgave = new string[5];
            tempOplossing1 = new string[5];

            for (int i = 0; i < 5; i++)//5 random opgaven selecteren voor de oefening.
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
       
        private void SchrijfPunten() {//punten wegschrijven naar txtfile
            ResultatenLijst lijst = new ResultatenLijst("resultaatWoMakkelijk.txt");
            Resultaat nieuw = new Resultaat(actieveGebruiker.Id,oefCorrect*2,totaalTijd, lijst);
            
            if (nieuw.IndexOud == -1)
            {
                lijst.Add(nieuw);
            }
            else {
                lijst.Add(nieuw);
                lijst.RemoveAt(nieuw.IndexOud);
            }
            lijst.SchrijfLijst("resultaatWoMakkelijk.txt");
        }
        
        private void Controleer_Click(object sender, RoutedEventArgs e)//antwoorden controleren en punten doorsturen
        {
            controleer.IsEnabled = false;
            tijdTeller.Stop();//teller stopzetten en converteren naar seconden
            totaalTijd = Convert.ToInt32(tijdTeller.ElapsedMilliseconds / 1000);

            if (!((textbox1.Text).Equals (lijstOefeningen[oefeningNummerLijst[0]].oplossing)))
            {
               textbox1.Background=Brushes.Red;
               antwoord1.Content = lijstOefeningen[oefeningNummerLijst[0]].oplossing;
            }
            else
            {
                oefCorrect++;
                 textbox1.Background=Brushes.Green;
            }

            if (!((textbox2.Text).Equals(lijstOefeningen[oefeningNummerLijst[1]].oplossing)))
                {
                   textbox2.Background=Brushes.Red;
                   antwoord2.Content = lijstOefeningen[oefeningNummerLijst[1]].oplossing;
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
                {
                    item.SetGameTijd(oefCorrect * 2, moeilijkheidsgraad);//gewonnen gametijd berekenen en opslaan
                }
            }
            lijst.SchrijfLijst();
            SchrijfPunten();
            Score.Content = Convert.ToString(oefCorrect) + "/5";
           
            }
        

        private void TerugButton_Click(object sender, RoutedEventArgs e)//terugkeren naar llnmenu
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

        private void OpnieuwButton_Click(object sender, RoutedEventArgs e)//oefening vernieuwen
        {
            OefWoMakkelijk makkelijk = new OefWoMakkelijk(actieveGebruiker);
            this.NavigationService.Navigate(makkelijk);
        }
        }
    }

