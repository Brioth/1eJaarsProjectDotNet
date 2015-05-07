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

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for OefNederlands1.xaml
    /// </summary>
    public partial class OefNederlands1Moeilijk : Page
    {
        private OefeningLijst lijstOefeningen;
        private string[] tempOpgave;
        private const string moeilijkheidsgraad = "MOE";
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag, oefCorrect;
        private IList<string> oefLijst;
        private IList<int> oefeningNummerLijst;
        Gebruiker actieveGebruiker;
        public OefNederlands1Moeilijk(Gebruiker actieveGebruiker)
        {
            this.actieveGebruiker = actieveGebruiker;
            InitializeComponent();

            tempOpgave = new string[5];

            oefLijst = new List<string>();
            oefeningNummerLijst = new List<int>();

            lijstOefeningen = new OefeningLijst("moeilijk");
            for (int i = 0; i < 5; i++)
            {
                oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, (lijstOefeningen.Count)));

                while (oefeningNummerLijst.Contains(oefeningenNummerOpslag))
                {
                    oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, lijstOefeningen.Count));
                }
                tempOpgave[i] = lijstOefeningen[oefeningenNummerOpslag].opgave;
                oefeningNummerLijst.Add(oefeningenNummerOpslag);
            }

            oefeningenNummerOpslag = oefeningenNummer.Next(1, lijstOefeningen.Count);

            opgave1.Text = tempOpgave[0];

            opgave2.Text = tempOpgave[1];

            opgave3.Text = tempOpgave[2];

            opgave4.Text = tempOpgave[3];

            opgave5.Text = tempOpgave[4];
            
        }

        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            oefCorrect = 0;
            if (!(oplossing1.Text.Equals(lijstOefeningen[oefeningNummerLijst[0]].oplossing)))
            {
                opgave1.Text = lijstOefeningen[oefeningNummerLijst[0]].juisteAntwoordCompleet;
                opgave1.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                opgave1.Background = Brushes.Green;
            }

            if (!(oplossing2.Text.Equals(lijstOefeningen[oefeningNummerLijst[1]].oplossing)))
            {
                opgave2.Text = lijstOefeningen[oefeningNummerLijst[1]].juisteAntwoordCompleet;
                opgave2.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                opgave2.Background = Brushes.Green;
            }

            if (!(oplossing3.Text.Equals(lijstOefeningen[oefeningNummerLijst[2]].oplossing)))
            {
                opgave3.Text = lijstOefeningen[oefeningNummerLijst[2]].juisteAntwoordCompleet;
                opgave3.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                opgave3.Background = Brushes.Green;
            }

            if (!(oplossing4.Text.Equals(lijstOefeningen[oefeningNummerLijst[3]].oplossing)))
            {
                opgave4.Text = lijstOefeningen[oefeningNummerLijst[3]].juisteAntwoordCompleet;
                opgave4.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                opgave4.Background = Brushes.Green;
            }

            if (!(Oplossing5.Text.Equals(lijstOefeningen[oefeningNummerLijst[4]].oplossing)))
            {
                opgave5.Text = lijstOefeningen[oefeningNummerLijst[4]].juisteAntwoordCompleet;
                opgave5.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                opgave5.Background = Brushes.Green;
            }
            Punten.Text = Convert.ToString(oefCorrect) + "/5";

            AlleGebruikersLijst lijst = new AlleGebruikersLijst();
            foreach (Gebruiker item in lijst)
            {
                if (actieveGebruiker.Id.Equals(item.Id))
                    actieveGebruiker.SetGameTijd(oefCorrect * 2, moeilijkheidsgraad);
            }
            lijst.SchrijfLijst();

            SchrijfPunten();
        }

        private void SchrijfPunten()
        {
            ResultatenLijst lijst = new ResultatenLijst("resultaatNederlands1Gemiddeld.txt");
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
            lijst.SchrijfLijst("resultaatNederlands1Gemiddeld.txt");
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
            OefNederlands1Moeilijk moeilijk = new OefNederlands1Moeilijk(actieveGebruiker);
            this.NavigationService.Navigate(moeilijk);
        }
    }
}
