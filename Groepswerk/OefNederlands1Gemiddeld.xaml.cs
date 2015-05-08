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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Groepswerk
{
    // Author: Thomas Cox
    // Date: 18/04 
    public partial class OefNederlands1Gemiddeld : Page
    {
        private OefeningLijst lijstOefeningen;
        private string[] tempOpgave, tempOplossing1, tempOplossing2, tempOplossing3;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag, oefCorrect, gespendeerdeTijd;
        private const string moeilijkheidsgraad = "MED";
        private List<string> oefLijst1, oefLijst2, oefLijst3, oefLijst4, oefLijst5;
        private List<int> oefeningNummerLijst;
        private Gebruiker actieveGebruiker;
        private Stopwatch tijdGespendeerd;
        public OefNederlands1Gemiddeld(Gebruiker actieveGebruiker)
        {
            this.actieveGebruiker = actieveGebruiker;
            InitializeComponent();
            tijdGespendeerd = new Stopwatch();
            tijdGespendeerd.Start();
            lijstOefeningen = new OefeningLijst("gemiddeld");

            tempOpgave = new string[5];
            tempOplossing1 = new string[5];
            tempOplossing2 = new string[5];
            tempOplossing3 = new string[5];

            oefLijst1 = new List<string>();
            oefLijst2 = new List<string>();
            oefLijst3 = new List<string>();
            oefLijst4 = new List<string>();
            oefLijst5 = new List<string>();

            oefeningNummerLijst = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, lijstOefeningen.Count));

                while (oefeningNummerLijst.Contains(oefeningenNummerOpslag))
                {
                    oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, lijstOefeningen.Count));
                }
                tempOpgave[i] = lijstOefeningen[oefeningenNummerOpslag].opgave;
                tempOplossing1[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing1;
                tempOplossing2[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing2;
                tempOplossing3[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing3;
                oefeningNummerLijst.Add(oefeningenNummerOpslag);
            }


            opgave1.Text = tempOpgave[0];
            oefLijst1.Add(tempOplossing1[0]);
            oefLijst1.Add(tempOplossing2[0]);
            oefLijst1.Add(tempOplossing3[0]);
            oplossing1.ItemsSource = oefLijst1;

            opgave2.Text = tempOpgave[1];
            oefLijst2.Add(tempOplossing1[1]);
            oefLijst2.Add(tempOplossing2[1]);
            oefLijst2.Add(tempOplossing3[1]);
            oplossing2.ItemsSource = oefLijst2;

            opgave3.Text = tempOpgave[2];
            oefLijst3.Add(tempOplossing1[2]);
            oefLijst3.Add(tempOplossing2[2]);
            oefLijst3.Add(tempOplossing3[2]);
            oplossing3.ItemsSource = oefLijst3;
            
            opgave4.Text = tempOpgave[3];
            oefLijst4.Add(tempOplossing1[3]);
            oefLijst4.Add(tempOplossing2[3]);
            oefLijst4.Add(tempOplossing3[3]);
            oplossing4.ItemsSource = oefLijst4;

            opgave5.Text = tempOpgave[4];
            oefLijst5.Add(tempOplossing1[4]);
            oefLijst5.Add(tempOplossing2[4]);
            oefLijst5.Add(tempOplossing3[4]);
            oplossing5.ItemsSource = oefLijst5;
            
        }
        private void SchrijfPunten()
        {
            ResultatenLijst lijst = new ResultatenLijst("OefNederlands1GemiddeldResultaten.txt");
            Resultaat nieuw = new Resultaat(actieveGebruiker.Id, oefCorrect * 2, gespendeerdeTijd, lijst);

            if (nieuw.IndexOud == -1)
            {
                lijst.Add(nieuw);
            }
            else
            {
                lijst.Add(nieuw);
                lijst.RemoveAt(nieuw.IndexOud);
            }
            lijst.SchrijfLijst("OefNederlands1GemiddeldResultaten.txt");
        }

        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            tijdGespendeerd.Stop();
            gespendeerdeTijd = Convert.ToInt32(tijdGespendeerd.ElapsedMilliseconds / 1000);
            oefCorrect = 0;
            verbeterButton.IsEnabled = false;

            if (!(Convert.ToString(oplossing1.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[0]].correcteOplossing)))
            {
                opgave1.Text = lijstOefeningen[oefeningNummerLijst[0]].juisteAntwoordCompleet;
                opgave1.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                opgave1.Background = Brushes.Green;
            }

            if (!(Convert.ToString(oplossing2.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[1]].correcteOplossing)))
            {
                opgave2.Text = lijstOefeningen[oefeningNummerLijst[1]].juisteAntwoordCompleet;
                opgave2.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                opgave2.Background = Brushes.Green;
            }

            if (!(Convert.ToString(oplossing3.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[2]].correcteOplossing)))
            {
                opgave3.Text = lijstOefeningen[oefeningNummerLijst[2]].juisteAntwoordCompleet;
                opgave3.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                opgave3.Background = Brushes.Green;
            }

            if (!(Convert.ToString(oplossing4.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[3]].correcteOplossing)))
            {
                opgave4.Text = lijstOefeningen[oefeningNummerLijst[3]].juisteAntwoordCompleet;
                opgave4.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                opgave4.Background = Brushes.Green;
            }

            if (!(Convert.ToString(oplossing5.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[4]].correcteOplossing)))
            {
                opgave5.Text = lijstOefeningen[oefeningNummerLijst[4]].juisteAntwoordCompleet; 
                opgave5.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                opgave5.Background = Brushes.Green;
            }
            
            AlleGebruikersLijst lijst = new AlleGebruikersLijst();
            foreach (Gebruiker item in lijst)
            {
                if (actieveGebruiker.Id.Equals(item.Id))
                {
                    item.SetGameTijd(oefCorrect * 2, moeilijkheidsgraad);
                }
            }

            lijst.SchrijfLijst();

            SchrijfPunten();

            Punten.Text = Convert.ToString(oefCorrect) + "/5";
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
            OefNederlands1Gemiddeld gemiddeld = new OefNederlands1Gemiddeld(actieveGebruiker);
            this.NavigationService.Navigate(gemiddeld);
        }


        }
    
}
