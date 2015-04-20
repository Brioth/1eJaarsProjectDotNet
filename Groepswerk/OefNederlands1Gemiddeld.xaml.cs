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
        private IList<string> oefLijst;
        private int oefCorrect;
        private IList<int> oefeningNummerLijst;
        public OefNederlands1Gemiddeld()
        {
            InitializeComponent();
            lijstOefeningen = new OefeningLijst("gemiddeld");



            for (int i = 0; i > 5; i++)
            {
                oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, (lijstOefeningen.Count-1)));
             
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


            opgave1.Text = tempOpgave[1];
            oefLijst.Add(tempOplossing1[1]);
            oefLijst.Add(tempOplossing2[1]);
            oefLijst.Add(tempOplossing3[1]);
            Oplossing1.ItemsSource = oefLijst;
            for (int i = 0; i > 3; i++)
            {
                oefLijst.RemoveAt(i);
            }

            opgave2.Text = tempOpgave[2];
            oefLijst.Add(tempOplossing1[2]);
            oefLijst.Add(tempOplossing2[2]);
            oefLijst.Add(tempOplossing3[2]);
            Oplossing2.ItemsSource = oefLijst;
            for (int i = 0; i > 3; i++)
            {
                oefLijst.RemoveAt(i);
            }

            opgave3.Text = tempOpgave[3];
            oefLijst.Add(tempOplossing1[3]);
            oefLijst.Add(tempOplossing2[3]);
            oefLijst.Add(tempOplossing3[3]);
            Oplossing2.ItemsSource = oefLijst;
            for (int i = 0; i > 3; i++)
            {
                oefLijst.RemoveAt(i);
            }

            opgave4.Text = tempOpgave[4];
            oefLijst.Add(tempOplossing1[4]);
            oefLijst.Add(tempOplossing2[4]);
            oefLijst.Add(tempOplossing3[4]);
            Oplossing2.ItemsSource = oefLijst;
            for (int i = 0; i > 3; i++)
            {
                oefLijst.RemoveAt(i);
            }
            opgave5.Text = tempOpgave[5];
            oefLijst.Add(tempOplossing1[5]);
            oefLijst.Add(tempOplossing2[5]);
            oefLijst.Add(tempOplossing3[5]);
            Oplossing2.ItemsSource = oefLijst;
            for (int i = 0; i > 3; i++)
            {
                oefLijst.RemoveAt(i);
            }
        }

        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            oefCorrect = 0;
            if (!(Convert.ToString(Oplossing1.SelectionBoxItem).Equals(lijstOefeningen[1].correcteOplossing)))
            {
                opgave1.Text = lijstOefeningen[1].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }
            if (!(Convert.ToString(Oplossing2.SelectionBoxItem).Equals(lijstOefeningen[2].correcteOplossing)))
                {
                    opgave2.Text = lijstOefeningen[2].juisteAntwoordCompleet;
                }
            else
                {
                    oefCorrect++;
                }

            if (!(Convert.ToString(Oplossing3.SelectionBoxItem).Equals(lijstOefeningen[3].correcteOplossing)))
                {
                    opgave3.Text = lijstOefeningen[3].juisteAntwoordCompleet;
                }
            else
                {
                    oefCorrect++;
                }

            if (!(Convert.ToString(Oplossing4.SelectionBoxItem).Equals(lijstOefeningen[4].correcteOplossing)))
                {
                    opgave3.Text = lijstOefeningen[4].juisteAntwoordCompleet;
                }
            else
                {
                    oefCorrect++;
                }

            if (!(Convert.ToString(Oplossing5.SelectionBoxItem).Equals(lijstOefeningen[5].correcteOplossing)))
                {
                    opgave3.Text = lijstOefeningen[5].juisteAntwoordCompleet;
                }
            else
                {
                    oefCorrect++;
                }
                Punten.Text = Convert.ToString(oefCorrect) + "/5";
            }


        }
    
}
