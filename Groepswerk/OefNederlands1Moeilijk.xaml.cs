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
        public OefNederlands1Moeilijk()
        {
            InitializeComponent();
            
            lijstOefeningen = new OefeningLijst("moeilijk");
            for (int i = 0; i > 5; i++)
            {
                oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, (lijstOefeningen.Count - 1)));

                while (oefeningNummerLijst.Contains(oefeningenNummerOpslag))
                {
                    oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(1, lijstOefeningen.Count));
                }
                tempOpgave[i] = lijstOefeningen[oefeningenNummerOpslag].opgave;
                oefeningNummerLijst.Add(oefeningenNummerOpslag);
            }

            oefeningenNummerOpslag = oefeningenNummer.Next(1, lijstOefeningen.Count);
            
            opgave1.Text = tempOpgave[1];

            opgave2.Text = tempOpgave[2];
            
            opgave3.Text = tempOpgave[3];
            
            opgave4.Text = tempOpgave[4];
            
            opgave5.Text = tempOpgave[5];
            
        }

        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            oefCorrect = 0;
            if (!(Convert.ToString(Oplossing1.Text).Equals(lijstOefeningen[1].correcteOplossing)))
            {
                opgave1.Text = lijstOefeningen[1].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect = oefCorrect + 1;
            }

            if (!(Convert.ToString(Oplossing2.Text).Equals(lijstOefeningen[2].correcteOplossing)))
            {
                opgave2.Text = lijstOefeningen[2].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect = oefCorrect + 1;
            }

            if (!(Convert.ToString(Oplossing3.Text).Equals(lijstOefeningen[3].correcteOplossing)))
            {
                opgave3.Text = lijstOefeningen[3].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect = oefCorrect + 1;
            }

            if (!(Convert.ToString(Oplossing4.Text).Equals(lijstOefeningen[4].correcteOplossing)))
            {
                opgave3.Text = lijstOefeningen[4].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect = oefCorrect + 1;
            }

            if (!(Convert.ToString(Oplossing5.Text).Equals(lijstOefeningen[5].correcteOplossing)))
            {
                opgave3.Text = lijstOefeningen[5].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect = oefCorrect + 1;
            }
            Punten.Text = Convert.ToString(oefCorrect) + "/5";
        }


    }
}
