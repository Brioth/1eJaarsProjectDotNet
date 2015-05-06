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
        private OefeningLijst lijstOefeningen;
        private List<string> opgaves, oplossing;
        private int geselecteerdeIndex;
        private Gebruiker actieveGebruiker;
        public OefNederlands1AanpassenMoeilijk(Gebruiker actieveGebruiker)
        {
            InitializeComponent();

            opgaves = new List<string>();
            oplossing = new List<string>();
            this.actieveGebruiker = actieveGebruiker;

            lijstOefeningen = new OefeningLijst("moeilijk");
            for (int i = 0; i < lijstOefeningen.Count; i++)
            {
                opgaves.Add(lijstOefeningen[i].opgave);
                oplossing.Add(lijstOefeningen[i].oplossing);
            }
            OpgaveSelecteren.ItemsSource = opgaves;
            OpgaveSelecteren.SelectedIndex = 0;
        }
        private void OpgaveSelecteren_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            geselecteerdeIndex = OpgaveSelecteren.SelectedIndex;
            Opgave.Text = opgaves[geselecteerdeIndex];
            CorrecteOplossing.Text = oplossing[geselecteerdeIndex];
        }

        private void AanpasKnop_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"OefNederlands1Moeilijk.txt", String.Empty);
            StreamWriter writer= File.AppendText(@"OefNederlands1Moeilijk.txt");
            foreach (Oefening oef in lijstOefeningen){
            
                writer.WriteLine(oef.opgave + ";" + oef.oplossing);
            }
            writer.Close();
        }

        private void TerugKnop_Click(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
    
}
