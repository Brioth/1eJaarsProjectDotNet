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
            if (oplossing1.Text.Equals(lijstOefeningen[oefeningNummerLijst[0]].correcteOplossing))
            {
                opgave1.Text = lijstOefeningen[oefeningNummerLijst[0]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (oplossing2.Text.Equals(lijstOefeningen[oefeningNummerLijst[1]].correcteOplossing))
            {
                opgave2.Text = lijstOefeningen[oefeningNummerLijst[1]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (oplossing3.Text.Equals(lijstOefeningen[oefeningNummerLijst[2]].correcteOplossing))
            {
                opgave3.Text = lijstOefeningen[oefeningNummerLijst[2]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (oplossing4.Text.Equals(lijstOefeningen[oefeningNummerLijst[3]].correcteOplossing))
            {
                opgave4.Text = lijstOefeningen[oefeningNummerLijst[3]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (Oplossing5.Text.Equals(lijstOefeningen[oefeningNummerLijst[4]].correcteOplossing))
            {
                opgave5.Text = lijstOefeningen[oefeningNummerLijst[4]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }
            Punten.Text = Convert.ToString(oefCorrect) + "/5";
        }


    }
}
