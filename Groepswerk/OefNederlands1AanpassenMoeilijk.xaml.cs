using System;
using System.Collections.Generic;
using System.IO;
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
    // Author: Thomas Cox
    // Date: 19/04/2015
    public partial class OefNederlands1AanpassenMoeilijk : Page
    {
        //Lokale variabelen
        private OefeningLijst lijstOefeningen;
        private Oefening selectedOefening;
        private string bestand = "OefNederlands1Moeilijk.txt";

        //Constructor
        public OefNederlands1AanpassenMoeilijk(Gebruiker actieveGebruiker)
        {
            InitializeComponent();

            lijstOefeningen = new OefeningLijst("moeilijk");
            OpgaveSelecteren.ItemsSource = lijstOefeningen;
            OpgaveSelecteren.SelectedIndex = 0;

        }

        //Events
        private void OpgaveSelecteren_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OpgaveSelecteren.SelectedIndex != -1)
            {
                selectedOefening = (Oefening)OpgaveSelecteren.SelectedItem;
                opgaveBox.Text = selectedOefening.opgave;
                correcteOplossingBox.Text = selectedOefening.correcteOplossing;
                juisteAntwoordCompleetBox.Text = selectedOefening.juisteAntwoordCompleet;

            }
        }

        private void AanpasKnop_Click(object sender, RoutedEventArgs e)
        {
            if ((opgaveBox.Text.Contains(';')) || (correcteOplossingBox.Text.Contains(';')) || (juisteAntwoordCompleetBox.Text.Contains(';')))
            {
                MessageBox.Show("Gelieve geen ';' in uw zinnen te zetten.");
            }//end if
            else
            
                if ((opgaveBox.Text.Equals(""))||(correcteOplossingBox.Text.Equals("")))
                    {
                        MessageBox.Show("Gelieve geen lege oplossingen of opgave in te geven");
                    }
                    else
                    {
                Oefening nieuwItem = new Oefening(opgaveBox.Text, correcteOplossingBox.Text, juisteAntwoordCompleetBox.Text);
                lijstOefeningen.Add(nieuwItem);
                lijstOefeningen.Remove(selectedOefening);
                lijstOefeningen.SchrijfLijstTaal(bestand, "taal1");
                UpdateLijst();
                }
        }
            
        private void toevoegKnop_Click(object sender, RoutedEventArgs e)
        {
            Oefening nieuwOefening = new Oefening(opgaveBox.Text, correcteOplossingBox.Text, juisteAntwoordCompleetBox.Text);
            lijstOefeningen.Add(nieuwOefening);
            lijstOefeningen.SchrijfLijstTaal(bestand, "taal2");
            UpdateLijst();
        }

        private void verwijderKnop_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult stoppen = MessageBox.Show("Bent u zeker dat u dit wilt verwijderen ?", "Stop", MessageBoxButton.YesNo);
            switch (stoppen)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    lijstOefeningen.Remove(selectedOefening);
                    lijstOefeningen.SchrijfLijstTaal(bestand, "taal2");
                    UpdateLijst();
                    break;
                default:
                    break;

            }
        }
            //Methods
        private void UpdateLijst()
        {
            lijstOefeningen = new OefeningLijst("gemiddeld");
            OpgaveSelecteren.ItemsSource = lijstOefeningen;
            OpgaveSelecteren.SelectedIndex = -1;
            OpgaveSelecteren.SelectedIndex = 0;
        }

        }

    }

