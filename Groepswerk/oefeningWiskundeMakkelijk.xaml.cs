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
            opgaveblock1.Text = tempOpgaveWiskunde1[1];
            opgaveblock2.Text = tempOpgaveWiskunde1[2];
            opgaveblock3.Text = tempOpgaveWiskunde1[3];
            opgaveblock4.Text = tempOpgaveWiskunde1[4];
            opgaveblock5.Text = tempOpgaveWiskunde1[5];
            opgaveblock6.Text = tempOpgaveWiskunde1[6];
            opgaveblock7.Text = tempOpgaveWiskunde1[7];
            opgaveblock8.Text = tempOpgaveWiskunde1[8];
            opgaveblock9.Text = tempOpgaveWiskunde1[9];
            opgaveblock10.Text = tempOpgaveWiskunde1[10];

            
            
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

            antwoordlabel1.Text = lijstOpgaves[1];
            antwoordlabel2.Text = lijstOpgaves[2];
            antwoordlabel3.Text = lijstOpgaves[3];
            antwoordlabel4.Text = lijstOpgaves[4];
            antwoordlabel5.Text = lijstOpgaves[5];
            antwoordlabel6.Text = lijstOpgaves[6];
            antwoordlabel7.Text = lijstOpgaves[7];
            antwoordlabel8.Text = lijstOpgaves[8];
            antwoordlabel9.Text = lijstOpgaves[9];
            antwoordlabel10.Text = lijstOpgaves[10];

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
            //gesleepte uitkomst vergelijken met de uitkomst van de bijhorende oefn.
        }

        private void sleepLabel1_DragLeave(object sender, DragEventArgs e)
        {

        }
    }
}
