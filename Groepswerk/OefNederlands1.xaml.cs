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
    /// Interaction logic for OefNederlands1.xaml
    /// </summary>
    public partial class OefNederlands1 : Page
    {
        private Oefening tempOefening;
        private OefeningLijst lijstOefeningen;
        private string[] tempOpgave, tempOplossing1, tempOplossing2, tempOplossing3;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag;
        public OefNederlands1()
        {
            InitializeComponent();
            lijstOefeningen = new OefeningLijst();
            for (int i = 0; i > lijstOefeningen.Count; i++)
            {
                tempOpgave[i] = lijstOefeningen[i].opgave;
                tempOplossing1[i] = lijstOefeningen[i].oplossing1;
                tempOplossing2[i] = lijstOefeningen[i].oplossing2;
                tempOplossing3[i] = lijstOefeningen[i].oplossing3;
            }

            oefeningenNummerOpslag = oefeningenNummer.Next(1,lijstOefeningen.Count);
            //oefeningenNummerOpslag in list zetten zodat je kan checken of dit nummer al genomen is?
            opgave1.Text= tempOpgave[1];
            //Oplossing1.Add(tempOplossing1[1]); //IK HAAT LIJSTEN, morgen fixen >:(


            opgave2.Text = tempOpgave[2];
            //placeholder voor lijsten
            opgave3.Text = tempOpgave[3];
            //placeholder
            opgave4.Text = tempOpgave[4];
            //placeholder
            opgave5.Text = tempOpgave[5];
            //placeholder
        }

        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            //checken of Convert.ToString(Oplossing1.selectedItem).equals(correcteOplossing[1]), zoniet label veranderen in juisteAntwoordCompleet[1]
            //te moe om nu te doen.
        }

        
    }
}
