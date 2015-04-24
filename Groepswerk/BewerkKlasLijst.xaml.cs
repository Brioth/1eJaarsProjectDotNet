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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Groepswerk
{
    /* --BewerkKlasLijst--
     * Pagina om klassen aan te passen/verwijderen/toe te voegen
     * Author: Carmen Celen
     * Date: 20/04/015
     */
    public partial class BewerkKlasLijst : Page
    {
        //Lokale variabelen
        private Klaslijst klasLijst;
        private String selectedKlas;

        //Constructors
        public BewerkKlasLijst()
        {
            InitializeComponent();
            klasLijst = new Klaslijst();
            lboxKlasLijst.ItemsSource = klasLijst;
            lboxKlasLijst.SelectedIndex = 0;
        }

        //Events
        private void KlasLijst_Changed(object sender, SelectionChangedEventArgs e)
        {
            selectedKlas = Convert.ToString(lboxKlasLijst.SelectedItem);
            txtbOmschr.Text = selectedKlas;
            txtbIndex.Text = ""+(lboxKlasLijst.SelectedIndex + 1);
        }
        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            string nieuweKlas = txtbOmschr.Text;
            int index = Convert.ToInt32(txtbIndex.Text) - 1 ;
            if (index > klasLijst.Count)
            {
                index = klasLijst.Count;
            }
            klasLijst.Insert(index, nieuweKlas);
            klasLijst.SchrijfLijst();
            UpdateLijst();
            }
            catch (FormatException)
            {
                MessageBox.Show("De index moet een cijfer zijn");
            }


        }
        private void btnPasAan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nieuweNaam = txtbOmschr.Text;
                int index = Convert.ToInt32(txtbIndex.Text) - 1;
                if (index>klasLijst.Count)  
                {
                    index = klasLijst.Count;
                }
                klasLijst.Remove(selectedKlas);
                klasLijst.Insert(index, nieuweNaam);
                klasLijst.SchrijfLijst();
                UpdateLijst();
            }
            catch (FormatException)
            {
                MessageBox.Show("De index moet een cijfer zijn");
            }

        }
        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            klasLijst.Remove(selectedKlas);
            klasLijst.SchrijfLijst();
            UpdateLijst();
        }

        //Methods
        private void UpdateLijst()
        {
            klasLijst = new Klaslijst();
            lboxKlasLijst.ItemsSource = klasLijst;
            lboxKlasLijst.SelectedIndex = 0;
        }

        //Properties
    }
}
