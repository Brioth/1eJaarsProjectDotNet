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
    /// <summary>
    /// Interaction logic for WoAanpassenGemiddeld.xaml
    /// </summary>
    public partial class WoAanpassenGemiddeld : Page
    {
     private OefeningLijst lijstOefeningen;
        private IList<string> opgaves, oplossing;
        private int geselecteerdeIndex;
        public WoAanpassenGemiddeld()
        {
            InitializeComponent();
            opgaves = new List<string>();
            oplossing = new List<string>();
            lijstOefeningen = new OefeningLijst("WoGemiddeld");
            for (int i = 0; i < lijstOefeningen.Count; i++)
            {
                opgaves.Add(lijstOefeningen[i].opgave);
                oplossing.Add(lijstOefeningen[i].oplossing); 
            }
            Landbox.ItemsSource = opgaves;
        }

        private void Landbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            geselecteerdeIndex = Landbox.SelectedIndex;
            Stadbox.Text = oplossing[geselecteerdeIndex];
          
        }
        private void Aanpassen_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"oefWoGemiddeld.txt", String.Empty);
            StreamWriter writer = File.AppendText(@"oefWoGemiddeld.txt");
            foreach (Oefening oef in lijstOefeningen)
            {

                writer.WriteLine(oef.opgave + ";" + oef.oplossing);
            }
            writer.Close();
        }
    }
}
