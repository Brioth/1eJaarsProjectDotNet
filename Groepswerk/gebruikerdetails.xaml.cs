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
    /// Interaction logic for gebruikerdetails.xaml
    /// </summary>
    public partial class Gebruikerdetails : Page
    {
        //variabelen
        private List<Gebruiker> accountLijst;
        private List<Klas> klasLijst;
        private Klas selectedKlas;
        private Gebruiker selectedGebruiker;
        private DetailsGebruiker details;
        //Constructors
        public Gebruikerdetails()
        {
            InitializeComponent(); // laad u formulier
            klasLijst = new Klaslijst();
            klasKeuze.ItemsSource = klasLijst;
            // de bron van deze box is de lijst
            klasKeuze.SelectedIndex = 0;
        }

        //events
        private void klasKeuze_Changed(object sender, SelectionChangedEventArgs e)
        {

            if (accountLijst != null)
            {
                accountLijst = null;
            }

            selectedKlas = (Klas)klasKeuze.SelectedItem;
            accountLijst = new Accountlijst(selectedKlas);
            boxLln.ItemsSource = accountLijst;
            // elke student in de lijst is nu zchtbaar want de hele lijst is de source
            boxLln.SelectedIndex = 0;
            // om het netjes te houden begin je bij de eerste al als geselecteerde waarde
            
        }
        // methodes


        private void boxLln_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedGebruiker = (Gebruiker)boxLln.SelectedItem;
            details = new DetailsGebruiker(selectedGebruiker.Id);
            //vul datagrid algemeen gemiddelde
            boxOef.SelectedIndex = 0;
        }

        private void boxOef_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //zet gem oef en details 
            
        }
       
        //properties



    } 
}
