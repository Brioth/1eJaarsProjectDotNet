﻿using System;
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
using System.Windows.Shapes;

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for oefWoGemiddeld.xaml
    /// </summary>
    public partial class oefWoGemiddeld : Page
    {
        private Gebruiker actieveGebruiker;
        private OefeningLijst lijstOefeningen;
        private string[] tempOpgave, tempOplossing1;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag;
        private IList<string> oefLijst;
        private int oefCorrect = 0;
        private IList<int> oefeningNummerLijst;
        private long totaalTijd;
        private Stopwatch tijdTeller;

        public oefWoGemiddeld( Gebruiker actieveGebruiker){
          
          InitializeComponent();
          tijdTeller.Start();
          this.actieveGebruiker = actieveGebruiker;
            lijstOefeningen = new OefeningLijst("WoGemiddeld");
            oefeningNummerLijst = new List<int>();

            tempOpgave = new string[5];
            tempOplossing1 = new string[5];

            for (int i = 0; i < 5; i++)
            {
                oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, (lijstOefeningen.Count )));

                while (oefeningNummerLijst.Contains(oefeningenNummerOpslag))
                {
                    oefeningenNummerOpslag = Convert.ToInt32(oefeningenNummer.Next(0, lijstOefeningen.Count));
                }
                tempOpgave[i] = lijstOefeningen[oefeningenNummerOpslag].opgave;
                tempOplossing1[i] = lijstOefeningen[oefeningenNummerOpslag].oplossing1;
                oefeningNummerLijst.Add(oefeningenNummerOpslag);
            }

            label1.Content= tempOpgave[0];
            label2.Content = tempOpgave[1];
            label3.Content = tempOpgave[2];
            labbel4.Content = tempOpgave[3];
            label5.Content = tempOpgave[4];
           
            

        }  

        
        private void controleer_Click(object sender, RoutedEventArgs e)
        {
            tijdTeller.Stop();
            totaalTijd = tijdTeller.ElapsedMilliseconds * 1000;

            if (!((textbox1.Text).Equals (lijstOefeningen[oefeningNummerLijst[0]].oplossing)))
            {
               textbox1.Background=Brushes.Red;
            }
            else
            {
                oefCorrect++;
                 textbox1.Background=Brushes.Green;
            }

            if (!((textbox2.Text).Equals(lijstOefeningen[oefeningNummerLijst[1]].oplossing)))
                {
                   textbox2.Background=Brushes.Red;
                }
            else
                {
                    oefCorrect++;
                 textbox2.Background=Brushes.Green;
                }

            if (!((textbox3.Text).Equals(lijstOefeningen[oefeningNummerLijst[2]].oplossing)))
                {
                   textbox3.Background=Brushes.Red;
                }
            else
                {
                    oefCorrect++;
                 textbox3.Background=Brushes.Green;
                }

            if (!((textbox4.Text).Equals(lijstOefeningen[oefeningNummerLijst[3]].oplossing)))
                {
                    textbox4.Background=Brushes.Red;
            }
            else
                {
                    oefCorrect++;
                 textbox4.Background=Brushes.Green;
                }

            if (!((textbox5.Text).Equals(lijstOefeningen[oefeningNummerLijst[4]].oplossing)))
                {
                   textbox5.Background=Brushes.Red;
                }
            else
                {
                    oefCorrect++;
                textbox5.Background=Brushes.Green;
                }
           
            }

        private void terugButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult terug = MessageBox.Show("Ben je zeker dat je terug wilt naar het leerlingenmenu?", "Terug", MessageBoxButton.YesNo);
            switch (terug)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    LeerlingMenu terugMenu = new LeerlingMenu(actieveGebruiker);
                    this.NavigationService.Navigate(terugMenu);
                    break;
                default:
                    break;
            }
        }
        }
    }

