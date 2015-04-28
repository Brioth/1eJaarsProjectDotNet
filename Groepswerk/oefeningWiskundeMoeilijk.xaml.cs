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
    /// Interaction logic for oefeningWiskundeMoeilijk.xaml
    /// </summary>
    public partial class oefeningWiskundeMakkelijk : Page
    {
        private Oefening tempOefening3;
        private OefeningLijst  lijstOefeningenWiskunde3;
        private string[] tempOpgaveWiskunde3, tempOplossing3;
        private Random oefeningenNummer3 = new Random();
        private int oefeningenNummerOpslag3;
        private IList<int> oefeningenNummerLijst3;
        private string[] lijstOpgaves3;
        private int oefeningPunten3;

        public oefeningWiskundeMakkelijk()
        {
            InitializeComponent();

            //bestand maken met opgave en antwoord per lijn
            // in lijst inlezen
            // random getal tss lijst.count
            //opgave van de geselecteerde oefn in opgave boxen zettenù
            // antwoorden opslaan in andere lijst en ermee vergelijken

            // of 2 random getallen tss 10 laten maken en die uitkomst ervan laten berekenen en opslaan in lijst
            // lijst vergelijken met de user input
            //

            lijstOefeningenWiskunde3 = new OefeningLijst("moeilijk2" );
            for (int i = 0; i > lijstOefeningenWiskunde3.Count; i++)
            {
                tempOpgaveWiskunde3[i] = lijstOefeningenWiskunde3[i].opgave;

                tempOplossing3[i] = lijstOefeningenWiskunde3[i].oplossing;

            }
            opgaveblock1.Content = tempOpgaveWiskunde3[0];
            opgaveblock2.Content = tempOpgaveWiskunde3[1];
            opgaveblock3.Content = tempOpgaveWiskunde3[2];
            opgaveblock4.Content = tempOpgaveWiskunde3[3];
            opgaveblock5.Content = tempOpgaveWiskunde3[4];
            opgaveblock6.Content = tempOpgaveWiskunde3[5];
            opgaveblock7.Content = tempOpgaveWiskunde3[6];
            opgaveblock8.Content = tempOpgaveWiskunde3[7];
            opgaveblock9.Content = tempOpgaveWiskunde3[8];
            opgaveblock10.Content = tempOpgaveWiskunde3[9];



            for (int i = 0; i < 10; i++)
            {
                oefeningenNummerOpslag3 = oefeningenNummer3.Next(0, 9);
                //if (!(oefeningenNummerLijst.Contains(oefeningenNummerOpslag)))
                //{
                //    lijstOpgaves[i] = tempOplossing[oefeningenNummerOpslag];

                //}
                //else
                //{
                while (oefeningenNummerLijst3.Contains(oefeningenNummerOpslag3))
                {
                    oefeningenNummerOpslag3 = oefeningenNummer3.Next(0, 9);
                }
                lijstOpgaves3[i] = tempOplossing3[oefeningenNummerOpslag3];
                //}
            }

            antwoordlabel1.Content = lijstOpgaves3[0];
            antwoordlabel2.Content = lijstOpgaves3[1];
            antwoordlabel3.Content = lijstOpgaves3[2];
            antwoordlabel4.Content = lijstOpgaves3[3];
            antwoordlabel5.Content = lijstOpgaves3[4];
            antwoordlabel6.Content = lijstOpgaves3[5];
            antwoordlabel7.Content = lijstOpgaves3[6];
            antwoordlabel8.Content = lijstOpgaves3[7];
            antwoordlabel9.Content = lijstOpgaves3[8];
            antwoordlabel10.Content = lijstOpgaves3[9];
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





        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            oefeningPunten3 = 0;

            {

                if ((lijstOefeningenWiskunde1[1].correcteOplossing).Equals(dropLabel1.Content))
                {
                    oefeningPunten3++;
                }
                if ((lijstOefeningenWiskunde1[2].correcteOplossing).Equals(dropLabel2.Content))
                {
                    oefeningPunten3++;
                }
                if ((lijstOefeningenWiskunde1[3].correcteOplossing).Equals(dropLabel3.Content))
                {
                    oefeningPunten3++;
                }
                if ((lijstOefeningenWiskunde1[4].correcteOplossing).Equals(dropLabel4.Content))
                {
                    oefeningPunten3++;
                }
                if ((lijstOefeningenWiskunde1[5].correcteOplossing).Equals(dropLabel5.Content))
                {
                    oefeningPunten3++;
                }
                if ((lijstOefeningenWiskunde1[6].correcteOplossing).Equals(dropLabel6.Content))
                {
                    oefeningPunten3++;
                }
                if ((lijstOefeningenWiskunde1[7].correcteOplossing).Equals(dropLabel7.Content))
                {
                    oefeningPunten3++;
                }
                if ((lijstOefeningenWiskunde1[8].correcteOplossing).Equals(dropLabel8.Content))
                {
                    oefeningPunten3++;
                }
                if ((lijstOefeningenWiskunde1[9].correcteOplossing).Equals(dropLabel9.Content))
                {
                    oefeningPunten3++;
                }
                if ((lijstOefeningenWiskunde1[10].correcteOplossing).Equals(dropLabel10.Content))
                {
                    oefeningPunten3++;
                }

                Punten.Text = "u heeft  " + oefeningPunten3 + " behaald.";
                oefeningPunten3++;


            }
        }


    }
}
