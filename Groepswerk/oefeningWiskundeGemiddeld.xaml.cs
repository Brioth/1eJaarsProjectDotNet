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

namespace Groepswerk{
 /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class oefeningWiskundeGemiddeld : Page
    {
        private int oefeningPunten;
        private Random RandomTest = new Random();
        private int randomGetal1;
        private int randomGetal2;
        private int randomGetal3;
        private int randomTeken1;
        private String[] OpgaveLijst = new String[10];
        private int[] oplossingLijst = new int[10];
        private List<int> randomLijst = new List<int>();

        public oefeningWiskundeGemiddeld()
        {
            InitializeComponent();
            // of 2 random getallen tss 10 laten maken en die uitkomst ervan laten berekenen en opslaan in lijst (txt bestand)
            // lijst vergelijken met de user input
            for (int i = 0; i < 10; i++)
            {
                randomGetal1 = RandomTest.Next(1, 11);
                randomGetal2 = RandomTest.Next(1, 11);
                randomGetal3 = RandomTest.Next(1, 11);
                randomTeken1 = RandomTest.Next(0, 2);

                // eerst uitkomst berekenen en die opslaan in labels
                // uitkomst ingeven als gebruiker en testen met verbeterknop

                if (randomTeken1 == 1)
                {
                    oplossingLijst[i] = randomGetal1 * randomGetal2 + randomGetal3;
                    randomLijst.Add(oplossingLijst[i]);

                    //randomGetal1.ToString();
                    //randomGetal2.ToString();
                    //randomGetal3.ToString();

                    OpgaveLijst[i] = (randomGetal1.ToString() + " x " + (randomGetal2.ToString()) + " + " + (randomGetal3.ToString()));

                }
                else
                {
                    oplossingLijst[i] = randomGetal1 * randomGetal2 - randomGetal3;
                    randomLijst.Add(oplossingLijst[i]);

                    //randomGetal1.ToString();
                    //randomGetal2.ToString();
                    //randomGetal3.ToString();

                    OpgaveLijst[i] = (randomGetal1.ToString() + " x " + (randomGetal2.ToString()) + " - " + randomGetal3.ToString());
                }

                opgaveblock1.Content = OpgaveLijst[0];
                opgaveblock2.Content = OpgaveLijst[1];
                opgaveblock3.Content = OpgaveLijst[2];
                opgaveblock4.Content = OpgaveLijst[3];
                opgaveblock5.Content = OpgaveLijst[4];
                opgaveblock6.Content = OpgaveLijst[5];
                opgaveblock7.Content = OpgaveLijst[6];
                opgaveblock8.Content = OpgaveLijst[7];
                opgaveblock9.Content = OpgaveLijst[8];
                opgaveblock10.Content = OpgaveLijst[9];
            }
        }
        //author: Vincent Vandoninck
        //date: 28/04/2015
        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            oefeningPunten = 0;
            {
                try
                {
                    if ((oplossingLijst[0]) == Convert.ToInt32(dropLabel1.Text))
                    {
                        oefeningPunten++;
                    }
                    if ((oplossingLijst[1]) == Convert.ToInt32(dropLabel2.Text))
                    {
                        oefeningPunten++;
                    }
                    if ((oplossingLijst[2]) == Convert.ToInt32(dropLabel3.Text))
                    {
                        oefeningPunten++;
                    }
                    if ((oplossingLijst[3]) == Convert.ToInt32(dropLabel4.Text))
                    {
                        oefeningPunten++;
                    }
                    if ((oplossingLijst[4]) == Convert.ToInt32(dropLabel5.Text))
                    {
                        oefeningPunten++;
                    }
                    if ((oplossingLijst[5]) == Convert.ToInt32(dropLabel6.Text))
                    {
                        oefeningPunten++;
                    }
                    if ((oplossingLijst[6]) == Convert.ToInt32(dropLabel7.Text))
                    {
                        oefeningPunten++;
                    }
                    if ((oplossingLijst[7]) == Convert.ToInt32(dropLabel8.Text))
                    {
                        oefeningPunten++;
                    }
                    if ((oplossingLijst[8]) == Convert.ToInt32(dropLabel9.Text))
                    {
                        oefeningPunten++;
                    }
                    if ((oplossingLijst[9]) == Convert.ToInt32(dropLabel10.Text))
                    {
                        oefeningPunten++;
                    }
                    Punten.Text = ("u heeft  " + oefeningPunten + " behaald. ");
                }

                catch (FormatException exceptionObject)
                {
                    MessageBox.Show("zet 0 als je het antwoord niet weet");
                }
            }
        }
    }
}
