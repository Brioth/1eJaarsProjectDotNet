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
    public partial class oefeningWiskunde1 : Page
    {
      private Oefening tempOefening;
        private OefeningLijst lijstOefeningen;
        private string[] tempOpgave, tempOplossing1, tempOplossing2, tempOplossing3, tempOplossing4, tempOplossing5, 
            tempOplossing6, tempOplossing7, tempOplossing8, tempOplossing9, tempOplossing10;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag;

        public oefeningWiskunde1()
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

            lijstOefeningen = new OefeningLijst();
            for (int i = 0; i > lijstOefeningen.Count; i++)
            {
                tempOpgave[i] = lijstOefeningen[i].opgave1;
                tempOpgave[i] = lijstOefeningen[i].opgave2;
                tempOpgave[i] = lijstOefeningen[i].opgave3;
                tempOpgave[i] = lijstOefeningen[i].opgave4;
                tempOpgave[i] = lijstOefeningen[i].opgave5;
                tempOpgave[i] = lijstOefeningen[i].opgave6;
                tempOpgave[i] = lijstOefeningen[i].opgave7;
                tempOpgave[i] = lijstOefeningen[i].opgave8;
                tempOpgave[i] = lijstOefeningen[i].opgave9;
                tempOpgave[i] = lijstOefeningen[i].opgave10;

                tempOplossing1[i] = lijstOefeningen[i].oplossing1;
                tempOplossing2[i] = lijstOefeningen[i].oplossing2;
                tempOplossing3[i] = lijstOefeningen[i].oplossing3;
                tempOplossing4[i] = lijstOefeningen[i].oplossing4;
                tempOplossing5[i] = lijstOefeningen[i].oplossing5;
                tempOplossing6[i] = lijstOefeningen[i].oplossing6;
                tempOplossing7[i] = lijstOefeningen[i].oplossing7;
                tempOplossing8[i] = lijstOefeningen[i].oplossing8;
                tempOplossing9[i] = lijstOefeningen[i].oplossing9;
                tempOplossing10[i] = lijstOefeningen[i].oplossing10;
            }

            oefeningenNummerOpslag = oefeningenNummer.Next(1, lijstOefeningen.Count);
            //oefeningenNummerOpslag in list zetten zodat je kan checken of dit nummer al genomen is?
            opgave1.Text = tempOpgave[1];
            //Oplossing1.Add(tempOplossing1[1]); 

        }


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
