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
using System.Windows.Shapes;

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for WoMakkelijkAanpassen.xaml
    /// </summary>
    public partial class WoMakkelijkAanpassen : Page
    {
        private OefeningLijst lijstOefeningen;
        private IList<string> opgaves, oplossing;
        private int geselecteerdeIndex;
        public WoMakkelijkAanpassen()
        {
            InitializeComponent();
            opgaves = new List<string>();
            oplossing = new List<string>();
            lijstOefeningen = new OefeningLijst("WoMakkelijk");
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
            Oefening oefening = new Oefening(Convert.ToString(Landbox.SelectedValue), Stadbox.Text);
            lijstOefeningen.Add(oefening);
            lijstOefeningen.RemoveAt(Landbox.SelectedIndex);

            File.WriteAllText(@"oefWoMakkelijk.txt", String.Empty);
            StreamWriter writer = File.AppendText(@"oefWoMakkelijk.txt");
            foreach (Oefening oef in lijstOefeningen)
            {
                writer.WriteLine(oef.opgave + ";" + oef.oplossing );
            }
            writer.Close();


            lijstOefeningen = new OefeningLijst("WoMakkelijk");

            opgaves.Clear();
            oplossing.Clear();
            
            for (int i = 0; i < lijstOefeningen.Count; i++)
            {
                opgaves.Add(lijstOefeningen[i].opgave);
                oplossing.Add(lijstOefeningen[i].oplossing);
                Landbox.ItemsSource = opgaves;
               
            }
            
            
        }
    }
}
