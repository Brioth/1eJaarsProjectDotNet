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
    // Author: Thomas Cox
    // Date: 18/04 
    public partial class OefNederlands1Gemiddeld : Page
    {
        private OefeningLijst lijstOefeningen;
        private string[] tempOpgave, tempOplossing1, tempOplossing2, tempOplossing3;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag;
        private IList<string> oefLijst1, oefLijst2, oefLijst3, oefLijst4, oefLijst5;
        private int oefCorrect;
        private IList<int> oefeningNummerLijst;
        public OefNederlands1Gemiddeld()
        {
            InitializeComponent();
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

            for (int i = 0; i > 5; i++)
            {
                oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, (lijstOefeningen.Count + 1)));

                while (oefeningNummerLijst.Contains(oefeningenNummerOpslag))
                {
                    oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(1, lijstOefeningen.Count));
                }
                tempOpgave[i] = lijstOefeningen[oefeningenNummerOpslag].opgave;
                tempOplossing1[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing1;
                tempOplossing2[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing2;
                tempOplossing3[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing3;
                oefeningNummerLijst.Add(oefeningenNummerOpslag);
            }


            Opgave1.Text = tempOpgave[1];
            oefLijst1.Add(tempOplossing1[1]);
            oefLijst1.Add(tempOplossing2[1]);
            oefLijst1.Add(tempOplossing3[1]);
            Oplossing1.ItemsSource = oefLijst1;

            Opgave2.Text = tempOpgave[2];
            oefLijst2.Add(tempOplossing1[2]);
            oefLijst2.Add(tempOplossing2[2]);
            oefLijst2.Add(tempOplossing3[2]);
            Oplossing2.ItemsSource = oefLijst2;

            Opgave3.Text = tempOpgave[3];
            oefLijst3.Add(tempOplossing1[3]);
            oefLijst3.Add(tempOplossing2[3]);
            oefLijst3.Add(tempOplossing3[3]);
            Oplossing3.ItemsSource = oefLijst3;
            
            Opgave4.Text = tempOpgave[4];
            oefLijst4.Add(tempOplossing1[4]);
            oefLijst4.Add(tempOplossing2[4]);
            oefLijst4.Add(tempOplossing3[4]);
            Oplossing4.ItemsSource = oefLijst4;

            Opgave5.Text = tempOpgave[5];
            oefLijst5.Add(tempOplossing1[5]);
            oefLijst5.Add(tempOplossing2[5]);
            oefLijst5.Add(tempOplossing3[5]);
            Oplossing5.ItemsSource = oefLijst5;
            
        }

        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            oefCorrect = 0;
            if (!(Convert.ToString(Oplossing1.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[0]].correcteOplossing)))
            {
                Opgave1.Text = lijstOefeningen[oefeningNummerLijst[0]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(Oplossing2.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[1]].correcteOplossing)))
            {
                Opgave2.Text = lijstOefeningen[oefeningNummerLijst[1]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(Oplossing3.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[2]].correcteOplossing)))
            {
                Opgave3.Text = lijstOefeningen[oefeningNummerLijst[2]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(Oplossing4.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[3]].correcteOplossing)))
            {
                Opgave4.Text = lijstOefeningen[oefeningNummerLijst[3]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(Oplossing5.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[4]].correcteOplossing)))
            {
                Opgave5.Text = lijstOefeningen[oefeningNummerLijst[4]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }
            Punten.Text = Convert.ToString(oefCorrect) + "/5";
        }


        }
    
}
