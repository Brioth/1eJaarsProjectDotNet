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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class oefeningWiskundeMakkelijk : Page
    {


        private int oefeningPunten;
        private Random RandomTest = new Random();
        private int randomGetal1;
        private int randomGetal2;
        private String[] OpgaveLijst = new String[10];
        private int[] oplossingLijst = new int[10];
        private List<int> randomLijst = new List<int>();

        public oefeningWiskundeMakkelijk()
        {
            InitializeComponent();

            // of 2 random getallen tss 10 laten maken en die uitkomst ervan laten berekenen en opslaan in lijst (txt bestand)
            // lijst vergelijken met de user input

            for (int i = 0; i < 10; i++)
            {
                randomGetal1 = RandomTest.Next(1, 11);
                randomGetal2 = RandomTest.Next(1, 11);

                // eerst uitkomst berekenen en die opslaan in labels
                // uitkomst ingeven als gebruiker en testen met verbeterknop
                //
                //
                oplossingLijst[i] = randomGetal1 * randomGetal2;
                randomLijst.Add(oplossingLijst[i]);

                randomGetal1.ToString();
                randomGetal2.ToString();


                OpgaveLijst[i] = (randomGetal1.ToString() + " x " + (randomGetal2.ToString()));

            }



            // nog verbinden (in array?)
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


            int randomGetal = RandomTest.Next(randomLijst.Count());

            antwoordlabel1.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = RandomTest.Next(randomLijst.Count());
            antwoordlabel2.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = RandomTest.Next(randomLijst.Count());
            antwoordlabel3.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = RandomTest.Next(randomLijst.Count());
            antwoordlabel4.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = RandomTest.Next(randomLijst.Count());
            antwoordlabel5.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = RandomTest.Next(randomLijst.Count());
            antwoordlabel6.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = RandomTest.Next(randomLijst.Count());
            antwoordlabel7.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = RandomTest.Next(randomLijst.Count());
            antwoordlabel8.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = RandomTest.Next(randomLijst.Count());
            antwoordlabel9.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

            randomGetal = RandomTest.Next(randomLijst.Count());
            antwoordlabel10.Content = randomLijst[randomGetal];
            randomLijst.RemoveAt(randomGetal);

        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject(DataFormats.Text, ((Label)e.Source).Content);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            //slepen
        }

        private void Label_Drop(object sender, DragEventArgs e)
        // hier wordt gedropped
        {
            ((Label)e.Source).Content = (string)e.Data.GetData(DataFormats.Text);
        }

        private void Label_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        // als je boven een drop object staat veranderd je cursor
        {
            if (e.Effects == DragDropEffects.Copy)
            {
                e.UseDefaultCursors = false;
                Mouse.SetCursor(Cursors.Hand);
            }
            else
                e.UseDefaultCursors = true;

            e.Handled = true;
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

        private void dropLabel1_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }



    }

}
