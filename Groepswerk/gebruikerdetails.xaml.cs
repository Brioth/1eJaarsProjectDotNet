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
        private List<String> klasLijst;
        private string selectedKlas;
        private Gebruiker selectedGebruiker;

        //Constructors
        public Gebruikerdetails(Gebruiker actieveGebruiker)
        {
            InitializeComponent(); // laad u formulier
            ActieveGebruiker = actieveGebruiker;
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

            selectedKlas = Convert.ToString(klasKeuze.SelectedItem);
            accountLijst = new Accountlijst(selectedKlas);
            listBox_llnLijst.ItemsSource = accountLijst;
            // elke student in de lijst is nu zchtbaar want de hele lijst is de source
            listBox_llnLijst.SelectedIndex = 0;
            // om het netjes te houden begin je bij de eerste al als geselecteerde waarde
            
        }

        private void listBox_llnLijst_Changed(object sender, SelectionChangedEventArgs e)
        // als je in de listbox nu een andere waarde selecteerd wordt deze event aangeroepen.
        {
            if (listBox_llnLijst.SelectedIndex==-1)
            {
                listBox_llnLijst.SelectedIndex = 0;
            }
            selectedGebruiker = (Gebruiker)listBox_llnLijst.SelectedItem;
                                // casten naar gebruiker         
            VakjesVullen();

        }



        // methodes
        private void VakjesVullen(){
            voornaambox.Text = selectedGebruiker.Voornaam;
            naambox.Text = selectedGebruiker.Achternaam;
            leerlingId.Text = Convert.ToString(selectedGebruiker.Id);
            gemNedGeg.Text = Convert.ToString(selectedGebruiker.GemNed);
            gemWiskGeg.Text = Convert.ToString(selectedGebruiker.GemWisk);
            gemWoGeg.Text = Convert.ToString(selectedGebruiker.GemWO);
         
        }
       
        //propertys
        public Gebruiker ActieveGebruiker { get; set; }


    } 
}
