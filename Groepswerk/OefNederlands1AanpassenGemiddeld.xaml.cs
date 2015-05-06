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
    public partial class OefNederlands1AanpassenGemiddeld : Page
    {
        private OefeningLijst lijstOefeningen;
        private List<string> opgaves, oplossing1, oplossing2, oplossing3, correcteOplossing, juisteAntwoordCompleet;
        private int geselecteerdeIndex;
        private Gebruiker actieveGebruiker;
        public OefNederlands1AanpassenGemiddeld(Gebruiker actieveGebruiker)
        {
            InitializeComponent();

            opgaves = new List<string>();
            oplossing1 = new List<string>();
            oplossing2 = new List<string>();
            oplossing3 = new List<string>();
            correcteOplossing = new List<string>();
            juisteAntwoordCompleet = new List<string>();
            this.actieveGebruiker = actieveGebruiker;
            lijstOefeningen = new OefeningLijst("gemiddeld");

            for (int i = 0; i < lijstOefeningen.Count; i++)
            {
                opgaves.Add(lijstOefeningen[i].opgave);
                oplossing1.Add(lijstOefeningen[i].oplossing1);
                oplossing2.Add(lijstOefeningen[i].oplossing2);
                oplossing3.Add(lijstOefeningen[i].oplossing3);
                correcteOplossing.Add(lijstOefeningen[i].correcteOplossing);
            }
            OpgaveSelecteren.ItemsSource = opgaves;
        }
        private void OpgaveSelecteren_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            geselecteerdeIndex = OpgaveSelecteren.SelectedIndex;
            Opgave.Text = opgaves[geselecteerdeIndex];
            Oplossing1.Text = oplossing1[geselecteerdeIndex];
            Oplossing2.Text = oplossing2[geselecteerdeIndex];
            Oplossing3.Text = oplossing3[geselecteerdeIndex];
            CorrecteOplossing.Text = correcteOplossing[geselecteerdeIndex];
            correctIngevuldeOpgave.Text = juisteAntwoordCompleet[geselecteerdeIndex];
        }

        private void AanpasKnop_Click(object sender, RoutedEventArgs e)
        {
            AanpasKnop.IsEnabled = false;
            Oefening oefening = new Oefening(Opgave.Text, Oplossing1.Text, Oplossing2.Text, Oplossing3.Text, CorrecteOplossing.Text, correctIngevuldeOpgave.Text);
            lijstOefeningen.RemoveAt(OpgaveSelecteren.SelectedIndex);
            lijstOefeningen.Insert(OpgaveSelecteren.SelectedIndex, oefening);

            File.WriteAllText(@"OefNederlands1Makkelijk.txt", String.Empty);
            StreamWriter writer = File.AppendText(@"OefNederlands1Makkelijk.txt");
            foreach (Oefening oef in lijstOefeningen)
            {
                writer.WriteLine(oef.opgave + ";" + oef.oplossing1 + ";" + oef.oplossing2 + ";" + oef.oplossing3 + ";" + oef.correcteOplossing + ";" + oef.juisteAntwoordCompleet);
            }
            writer.Close();

            lijstOefeningen = new OefeningLijst("makkelijk");

            opgaves.Clear();
            oplossing1.Clear();
            oplossing2.Clear();
            oplossing3.Clear();
            correcteOplossing.Clear();
            juisteAntwoordCompleet.Clear();

            for (int i = 0; i < lijstOefeningen.Count; i++)
            {
                opgaves.Add(lijstOefeningen[i].opgave);
                oplossing1.Add(lijstOefeningen[i].oplossing1);
                oplossing2.Add(lijstOefeningen[i].oplossing2);
                oplossing3.Add(lijstOefeningen[i].oplossing3);
                correcteOplossing.Add(lijstOefeningen[i].correcteOplossing);
                juisteAntwoordCompleet.Add(lijstOefeningen[i].juisteAntwoordCompleet);
            }
        }

        
    }
}
