using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    //Author: Thomas Cox
    //Date: 14/05/2015
    public partial class OefNederlands1Makkelijk : Page
    {
        private OefeningLijst lijstOefeningen;
        private string[] tempOpgave, tempOplossing1, tempOplossing2, tempOplossing3;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag, oefCorrect;
        private int gespendeerdeTijd;
        private List<string> oefLijst1, oefLijst2, oefLijst3, oefLijst4, oefLijst5;
        private Resultaat resultaat;
        private ResultatenLijst resultatenlijst;
        private List<int> oefeningNummerLijst;
        private Gebruiker actieveGebruiker;
        private Stopwatch tijdGespendeerd;
        public OefNederlands1Makkelijk(Gebruiker actieveGebruiker)
        {
            
            InitializeComponent();

            this.actieveGebruiker = actieveGebruiker;
            tijdGespendeerd.Start();
            
            lijstOefeningen = new OefeningLijst("makkelijk");
            

            tempOpgave = new string[5];
            tempOplossing1 = new string[5];
            tempOplossing2 = new string[5];
            tempOplossing3 = new string[5];

            oefLijst1 = new List<string>();
            oefLijst2 = new List<string>();
            oefLijst3 = new List<string>();
            oefLijst4 = new List<string>();
            oefLijst5 = new List<string>();

            oefeningNummerLijst = new List<int>();


            for (int i = 0; i < 5; i++)
            {
                oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, (lijstOefeningen.Count)));

                while (oefeningNummerLijst.Contains(oefeningenNummerOpslag))
                {
                    oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, lijstOefeningen.Count));
                }
                tempOpgave[i] = lijstOefeningen[oefeningenNummerOpslag].opgave;
                tempOplossing1[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing1;
                tempOplossing2[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing2;
                tempOplossing3[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing3;
                oefeningNummerLijst.Add(oefeningenNummerOpslag);
            }

            opgave1.Text = tempOpgave[0];
            oefLijst1.Add(tempOplossing1[0]);
            oefLijst1.Add(tempOplossing2[0]);
            oefLijst1.Add(tempOplossing3[0]);
            oplossing1.ItemsSource = oefLijst1;

            opgave2.Text = tempOpgave[1];
            oefLijst2.Add(tempOplossing1[1]);
            oefLijst2.Add(tempOplossing2[1]);
            oefLijst2.Add(tempOplossing3[1]);
            oplossing2.ItemsSource = oefLijst2;

            opgave3.Text = tempOpgave[2];
            oefLijst3.Add(tempOplossing1[2]);
            oefLijst3.Add(tempOplossing2[2]);
            oefLijst3.Add(tempOplossing3[2]);
            oplossing3.ItemsSource = oefLijst3;

            opgave4.Text = tempOpgave[3];
            oefLijst4.Add(tempOplossing1[3]);
            oefLijst4.Add(tempOplossing2[3]);
            oefLijst4.Add(tempOplossing3[3]);
            oplossing4.ItemsSource = oefLijst4;

            opgave5.Text = tempOpgave[4];
            oefLijst5.Add(tempOplossing1[4]);
            oefLijst5.Add(tempOplossing2[4]);
            oefLijst5.Add(tempOplossing3[4]);
            oplossing5.ItemsSource = oefLijst5;

        }

        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            tijdGespendeerd.Stop();
            gespendeerdeTijd = Convert.ToInt32(tijdGespendeerd.ElapsedMilliseconds * 1000);
            oefCorrect = 0;
            if (!(Convert.ToString(oplossing1.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[0]].correcteOplossing)))
            {
                opgave1.Text = lijstOefeningen[oefeningNummerLijst[0]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(oplossing2.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[1]].correcteOplossing)))
            {
                opgave2.Text = lijstOefeningen[oefeningNummerLijst[1]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(oplossing3.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[2]].correcteOplossing)))
            {
                opgave3.Text = lijstOefeningen[oefeningNummerLijst[2]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(oplossing4.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[3]].correcteOplossing)))
            {
                opgave4.Text = lijstOefeningen[oefeningNummerLijst[3]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }

            if (!(Convert.ToString(oplossing5.SelectionBoxItem).Equals(lijstOefeningen[oefeningNummerLijst[4]].correcteOplossing)))
            {
                opgave5.Text = lijstOefeningen[oefeningNummerLijst[4]].juisteAntwoordCompleet;
            }
            else
            {
                oefCorrect++;
            }
            Punten.Text = Convert.ToString(oefCorrect) + "/5";

            
        }

        private void TerugKnop_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void SchrijfPunten()
        {

            ResultatenLijst lijst = new ResultatenLijst("OefNederlands1MakkelijkResultaten.txt");
            Resultaat nieuw = new Resultaat(actieveGebruiker.Id, oefCorrect, gespendeerdeTijd, resultatenLijst);
        if(nieuw.IndexOud == -1)
        
        {
            lijst.Add(nieuw);

        } //end if
        else
        {
            lijst.Add(nieuw);
            lijst.RemoveAt(nieuw.IndexOud);
        } // end else
        lijst.SchrijfLijst("OefNederlands1MakkelijkResultaten.txt");

        }
        }
    }

