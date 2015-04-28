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
    /// Interaction logic for oefnWisk1.xaml
    /// 
    /// //author: Vincent Vandoninck
    //date: 15/04/2015
    /// </summary>
    public partial class oefeningWiskundeMakkelijk : Page
    {
        private Oefening tempOefening1;
        private OefeningLijst lijstOefeningenWiskunde1;
        private string[] tempOpgaveWiskunde1, tempOplossing1;
        private Random oefeningenNummer1 = new Random();
        private int oefeningenNummerOpslag1;
        private IList<int> oefeningenNummerLijst1;
        private string[] lijstOpgaves1;
        private int oefeningPunten;

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

            lijstOefeningenWiskunde1 = new OefeningLijst("makkelijk2");
            for (int i = 0; i > lijstOefeningenWiskunde1.Count; i++)
            {
                tempOpgaveWiskunde1[i] = lijstOefeningenWiskunde1[i].opgave;

                tempOplossing1[i] = lijstOefeningenWiskunde1[i].oplossing;

            }
            opgaveblock1.Content = tempOpgaveWiskunde1[0];
            opgaveblock2.Content = tempOpgaveWiskunde1[1];
            opgaveblock3.Content = tempOpgaveWiskunde1[2];
            opgaveblock4.Content = tempOpgaveWiskunde1[3];
            opgaveblock5.Content = tempOpgaveWiskunde1[4];
            opgaveblock6.Content = tempOpgaveWiskunde1[5];
            opgaveblock7.Content = tempOpgaveWiskunde1[6];
            opgaveblock8.Content = tempOpgaveWiskunde1[7];
            opgaveblock9.Content = tempOpgaveWiskunde1[8];
            opgaveblock10.Content = tempOpgaveWiskunde1[9];



            for (int i = 0; i < 10; i++)
            {
                oefeningenNummerOpslag1 = oefeningenNummer.Next(0, 9);
                //if (!(oefeningenNummerLijst.Contains(oefeningenNummerOpslag)))
                //{
                //    lijstOpgaves[i] = tempOplossing[oefeningenNummerOpslag];

                //}
                //else
                //{
                while (oefeningenNummerLijst.Contains(oefeningenNummerOpslag1))
                {
                    oefeningenNummerOpslag1 = oefeningenNummer.Next(0, 9);
                }
                lijstOpgaves[i] = tempOplossing1[oefeningenNummerOpslag1];
                //}
            }

            antwoordlabel1.Content = lijstOpgaves1[0];
            antwoordlabel2.Content = lijstOpgaves1[1];
            antwoordlabel3.Content = lijstOpgaves1[2];
            antwoordlabel4.Content = lijstOpgaves1[3];
            antwoordlabel5.Content = lijstOpgaves1[4];
            antwoordlabel6.Content = lijstOpgaves1[5];
            antwoordlabel7.Content = lijstOpgaves1[6];
            antwoordlabel8.Content = lijstOpgaves1[7];
            antwoordlabel9.Content = lijstOpgaves1[8];
            antwoordlabel10.Content = lijstOpgaves1[9];
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

                if ((lijstOefeningenWiskunde1[1].correcteOplossing).Equals(dropLabel1.Content))
                {
                    oefeningPunten++;
                }
                if ((lijstOefeningenWiskunde1[2].correcteOplossing).Equals(dropLabel2.Content))
                {
                    oefeningPunten++;
                }
                if ((lijstOefeningenWiskunde1[3].correcteOplossing).Equals(dropLabel3.Content))
                {
                    oefeningPunten++;
                }
                if ((lijstOefeningenWiskunde1[4].correcteOplossing).Equals(dropLabel4.Content))
                {
                    oefeningPunten++;
                }
                if ((lijstOefeningenWiskunde1[5].correcteOplossing).Equals(dropLabel5.Content))
                {
                    oefeningPunten++;
                }
                if ((lijstOefeningenWiskunde1[6].correcteOplossing).Equals(dropLabel6.Content))
                {
                    oefeningPunten++;
                }
                if ((lijstOefeningenWiskunde1[7].correcteOplossing).Equals(dropLabel7.Content))
                {
                    oefeningPunten++;
                }
                if ((lijstOefeningenWiskunde1[8].correcteOplossing).Equals(dropLabel8.Content))
                {
                    oefeningPunten++;
                }
                if ((lijstOefeningenWiskunde1[9].correcteOplossing).Equals(dropLabel9.Content))
                {
                    oefeningPunten++;
                }
                if ((lijstOefeningenWiskunde1[10].correcteOplossing).Equals(dropLabel10.Content))
                {
                    oefeningPunten++;
                }

                Punten.Text = "u heeft  " + oefeningPunten + " behaald.";
            }
        }
        
    }
}
