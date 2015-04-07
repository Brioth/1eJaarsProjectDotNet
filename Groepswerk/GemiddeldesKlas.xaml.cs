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
using System.Windows.Shapes;

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for GemiddeldesKlas.xaml
    /// </summary>
    /* Author: Thomas Cox
     * Date: 5/04/2015
    */
    public partial class GemiddeldesKlas : Page
    {
        private Klaslijst klasLijst;
        private String geselecteerdeKlas;
        private Gebruiker[] naamGemiddelde;

        public GemiddeldesKlas()
        {
            InitializeComponent();
            klasLijst = new Klaslijst();
            selecteerKlas.ItemsSource = klasLijst;
            selecteerKlas.SelectedIndex = 0;
        }

        private void selecteerKlas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           //labels clearen
            geselecteerdeKlas=Convert.ToString(selecteerKlas.SelectedItem);
           
           
           // Gebruiker[i]=Accountlijst(string geselecteerdeKlas); 
           // For each loop
           // Accountlijst zet een boolean naar false zodra de while loop moet stoppen?
           // Naam en punten leerling1 in labels zetten
           // vb: naamLeerling1=Gebruiker[i].getNaam; gemiddeldeW1=Gebruiker[i].getGemiddeldeWiskunde
           // TextBLock ipv labels gebruiken
           
        }


    }
}
