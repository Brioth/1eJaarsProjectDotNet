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
        private IList<string> opgaves, correcteOplossing;
        private int geselecteerdeIndex;
        public OefNederlands1AanpassenMoeilijk()
        {
            InitializeComponent();
            lijstOefeningen = new OefeningLijst("moeilijk");
            for (int i = 0; i < lijstOefeningen.Count; i++)
            {
                opgaves.Add(lijstOefeningen[i].opgave);
                correcteOplossing.Add(lijstOefeningen[i].correcteOplossing);
            }
            OpgaveSelecteren.ItemsSource = opgaves;
        }
        private void OpgaveSelecteren_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            geselecteerdeIndex = OpgaveSelecteren.SelectedIndex;
            Opgave.Text = opgaves[geselecteerdeIndex];
            CorrecteOplossing.Text = correcteOplossing[geselecteerdeIndex];
        }

        private void AanpasKnop_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"OefNederlands1Moeilijk.txt", String.Empty);
            StreamWriter writer= File.AppendText(@"OefNederlands1Moeilijk.txt");
            foreach (Oefening oef in lijstOefeningen){
            
                writer.WriteLine(oef.opgave + ";" + oef.correcteOplossing);
            }
            writer.Close();
        }

        private void TerugKnop_Click(object sender, RoutedEventArgs e)
        {
            //navigation. Ik snap da dus echt nie eh... this.Frame.Navigate(typeof(Programma));
        }

        
    }
    
}
