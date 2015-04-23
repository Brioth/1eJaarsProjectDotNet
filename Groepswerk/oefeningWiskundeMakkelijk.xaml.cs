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
        private Oefening tempOefening;
        private OefeningLijst lijstOefeningenWiskunde1;
        private string[] tempOpgaveWiskunde1, tempOplossing;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag;
        private IList<int> oefeningenNummerLijst;
        private string[] lijstOpgaves;
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

            lijstOefeningenWiskunde1 = new OefeningLijst();
            for (int i = 0; i > lijstOefeningenWiskunde1.Count; i++)
            {
                tempOpgaveWiskunde1[i] = lijstOefeningenWiskunde1[i].opgave;

                tempOplossing[i] = lijstOefeningenWiskunde1[i].oplossing;
               
            }
            opgaveblock1.Text = tempOpgaveWiskunde1[0];
            opgaveblock2.Text = tempOpgaveWiskunde1[1];
            opgaveblock3.Text = tempOpgaveWiskunde1[2];
            opgaveblock4.Text = tempOpgaveWiskunde1[3];
            opgaveblock5.Text = tempOpgaveWiskunde1[4];
            opgaveblock6.Text = tempOpgaveWiskunde1[5];
            opgaveblock7.Text = tempOpgaveWiskunde1[6];
            opgaveblock8.Text = tempOpgaveWiskunde1[7];
            opgaveblock9.Text = tempOpgaveWiskunde1[8];
            opgaveblock10.Text = tempOpgaveWiskunde1[9];

            
            
            for (int i = 0; i < 10; i++)
            {
                oefeningenNummerOpslag = oefeningenNummer.Next(0, 9);
                //if (!(oefeningenNummerLijst.Contains(oefeningenNummerOpslag)))
                //{
                //    lijstOpgaves[i] = tempOplossing[oefeningenNummerOpslag];

                //}
                //else
                //{
                    while (oefeningenNummerLijst.Contains(oefeningenNummerOpslag))
                    {
                        oefeningenNummerOpslag = oefeningenNummer.Next(0, 9);
                    }
                    lijstOpgaves[i] = tempOplossing[oefeningenNummerOpslag];
                //}
            }

            antwoordlabel1.Content = lijstOpgaves[0];
            antwoordlabel2.Content = lijstOpgaves[1];
            antwoordlabel3.Content = lijstOpgaves[2];
            antwoordlabel4.Content = lijstOpgaves[3];
            antwoordlabel5.Content = lijstOpgaves[4];
            antwoordlabel6.Content = lijstOpgaves[5];
            antwoordlabel7.Content = lijstOpgaves[6];
            antwoordlabel8.Content = lijstOpgaves[7];
            antwoordlabel9.Content = lijstOpgaves[8];
            antwoordlabel10.Content = lijstOpgaves[9];

                //if (!(oefeningenNummerLijst.Contains(oefeningenNummerOpslag)))
                //{
                //    antwoordlabel1.Text = tempOplossing[oefeningenNummerOpslag];

                //}
                //else
                //{
                //    while (oefeningenNummerLijst.Contains(oefeningenNummerOpslag))
                //    {
                //        oefeningenNummerOpslag = oefeningenNummer.Next(0, 9);
                //    }
                //    antwoordlabel1.Text = tempOplossing[oefeningenNummerOpslag];
                //}

            

        }
            
      
          //  oefeningenNummerOpslag = oefeningenNummer.Next(1, lijstOefeningen.Count);
            //oefeningenNummerOpslag in list zetten zodat je kan checken of dit nummer al genomen is?
          //  opgave1.Text = tempOpgave[1];
            //Oplossing1.Add(tempOplossing1[1]); 

        private void sleepLabel1_DragLeave()
        {
        }
        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            //oefeningPunten=0;
            //if ((lijstOefeningenWiskunde1[1].correcteOplossing).Equals(het erbij gesleepte))
            //{
            //     oefeningPunten++;
            //}
        }

        private void sleepLabel1_DragLeave(object sender, DragEventArgs e)
        {

        }
    }
}
