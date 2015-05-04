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
    //Author: Thomas Cox
    //Date: 14/05/2015
    public partial class OefNederlands1Makkelijk : Page
    {
        private OefeningLijst lijstOefeningen;
        private string[] tempOpgave, tempOplossing1, tempOplossing2, tempOplossing3;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag;
        private List<string> oefLijst;
        private int oefCorrect = 0;
        private List<int> oefeningNummerLijst;
        public OefNederlands1Makkelijk()
        {
            InitializeComponent();
            lijstOefeningen = new OefeningLijst("makkelijk");
            tempOpgave = new string[5];
            tempOplossing1 = new string[5];
            tempOplossing2 = new string[5];
            tempOplossing3 = new string[5];

            oefLijst = new List<string>();
            oefeningNummerLijst = new List<int>();


            for (int i = 0; i < 5; i++)
            {
                oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, (lijstOefeningen.Count)));

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
            Opgave1.Text = tempOpgave[0];
            oefLijst.Add(tempOplossing1[0]);
            oefLijst.Add(tempOplossing2[0]);
            oefLijst.Add(tempOplossing3[0]);
            Oplossing1.ItemsSource = oefLijst;

            for (int i = 0; i < 3; i++)
            {
                oefLijst.RemoveAt(i);
            }

            Opgave2.Text = tempOpgave[1];
            oefLijst.Add(tempOplossing1[1]);
            oefLijst.Add(tempOplossing2[1]);
            oefLijst.Add(tempOplossing3[1]);
            Oplossing2.ItemsSource = oefLijst;
            for (int i = 0; i < 3; i++)
            {
                oefLijst.RemoveAt(i);
            }

            Opgave3.Text = tempOpgave[2];
            oefLijst.Add(tempOplossing1[2]);
            oefLijst.Add(tempOplossing2[2]);
            oefLijst.Add(tempOplossing3[2]);
            Oplossing2.ItemsSource = oefLijst;
            for (int i = 0; i < 3; i++)
            {
                oefLijst.RemoveAt(i);
            }

            Opgave4.Text = tempOpgave[3];
            oefLijst.Add(tempOplossing1[3]);
            oefLijst.Add(tempOplossing2[3]);
            oefLijst.Add(tempOplossing3[3]);
            Oplossing2.ItemsSource = oefLijst;
            for (int i = 0; i < 3; i++)
            {
                oefLijst.RemoveAt(i);
            }
            Opgave5.Text = tempOpgave[4];
            oefLijst.Add(tempOplossing1[4]);
            oefLijst.Add(tempOplossing2[4]);
            oefLijst.Add(tempOplossing3[4]);
            Oplossing2.ItemsSource = oefLijst;
            for (int i = 0; i < 3; i++)
            {
                oefLijst.RemoveAt(i);
            }
        }

        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(Convert.ToString(Oplossing1.SelectionBoxItem).Equals(lijstOefeningen[0].correcteOplossing)))
            {
                Opgave1.Text = lijstOefeningen[0].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(Oplossing2.SelectionBoxItem).Equals(lijstOefeningen[1].correcteOplossing)))
            {
                Opgave2.Text = lijstOefeningen[1].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(Oplossing3.SelectionBoxItem).Equals(lijstOefeningen[2].correcteOplossing)))
            {
                Opgave3.Text = lijstOefeningen[2].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(Oplossing4.SelectionBoxItem).Equals(lijstOefeningen[3].correcteOplossing)))
            {
                Opgave3.Text = lijstOefeningen[3].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(Oplossing5.SelectionBoxItem).Equals(lijstOefeningen[4].correcteOplossing)))
            {
                Opgave3.Text = lijstOefeningen[4].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }
            Punten.Text = Convert.ToString(oefCorrect) + "/5";
        }

        private void TerugKnop_Click(object sender, RoutedEventArgs e)
        {
            
        }
        }
    }

