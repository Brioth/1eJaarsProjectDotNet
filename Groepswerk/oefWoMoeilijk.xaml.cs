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
using System.Windows.Shapes;

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for oefWoMoeilijk.xaml
    /// </summary>
    public partial class oefWoMoeilijk : Page
    {
        private WoLijst lijstOefeningen;
        private string[] tempOpgave, tempOplossing1, tempOplossing2, tempOplossing3;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag;
        private IList<string> oefLijst;
        private int oefCorrect = 0;
        private IList<int> oefeningNummerLijst;
        public oefWoMoeilijk()
        {
            InitializeComponent();
            lijstOefeningen = new WoLijst("moeilijk");

            for (int i = 0; i > 5; i++)
            {
                oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, (lijstOefeningen.Count - 1)));

                while (oefeningNummerLijst.Contains(oefeningenNummerOpslag))
                {
                    oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(1, lijstOefeningen.Count));
                }
                tempOpgave[i] = lijstOefeningen[oefeningenNummerOpslag].opgave;
                tempOplossing1[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing;
                oefeningNummerLijst.Add(oefeningenNummerOpslag);
            }
            label1.Content = tempOpgave[1];
            oefLijst.Add(tempOplossing1[1]);


            for (int i = 0; i > 3; i++)
            {
                oefLijst.RemoveAt(i);
            }

            label2.Content = tempOpgave[2];
            oefLijst.Add(tempOplossing1[2]);

            for (int i = 0; i > 3; i++)
            {
                oefLijst.RemoveAt(i);
            }

            label5.Content = tempOpgave[3];
            oefLijst.Add(tempOplossing1[3]);

            for (int i = 0; i > 3; i++)
            {
                oefLijst.RemoveAt(i);
            }

            labbel4.Content = tempOpgave[4];
            oefLijst.Add(tempOplossing1[4]);

            for (int i = 0; i > 3; i++)
            {
                oefLijst.RemoveAt(i);
            }
            label5.Content = tempOpgave[5];
            oefLijst.Add(tempOplossing1[5]);

            for (int i = 0; i > 3; i++)
            {
                oefLijst.RemoveAt(i);
            }
        }


        private void controleer_Click(object sender, RoutedEventArgs e)
        {
            if (!((textbox1.Text).Equals(lijstOefeningen[1].oplossing)))
            {
                textbox1.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                textbox1.Background = Brushes.Green;
            }

            if (!((textbox2.Text).Equals(lijstOefeningen[2].oplossing)))
            {
                textbox1.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                textbox1.Background = Brushes.Green;
            }

            if (!((textbox3.Text).Equals(lijstOefeningen[3].oplossing)))
            {
                textbox1.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                textbox1.Background = Brushes.Green;
            }

            if (!((textbox4.Text).Equals(lijstOefeningen[4].oplossing)))
            {
                textbox1.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                textbox1.Background = Brushes.Green;
            }

            if (!((textbox5.Text).Equals(lijstOefeningen[5].oplossing)))
            {
                textbox1.Background = Brushes.Red;
            }
            else
            {
                oefCorrect++;
                textbox1.Background = Brushes.Green;
            }
            
        }
    }
}
