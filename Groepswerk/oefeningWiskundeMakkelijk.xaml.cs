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
        private OefeningLijst lijstOefeningenWiskunde1;
        private string[] tempOpgaveWiskunde1, tempOplossing;
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

            lijstOefeningenWiskunde1 = new OefeningLijst();
            for (int i = 1; i > lijstOefeningenWiskunde1.Count; i++)
            {
                tempOpgaveWiskunde1[i] = lijstOefeningenWiskunde1[i].opgave;

                tempOplossing[i] = lijstOefeningenWiskunde1[i].oplossing;
            }
            
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
