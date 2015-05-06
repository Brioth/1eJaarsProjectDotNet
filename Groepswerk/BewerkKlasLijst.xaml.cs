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
        private Klas selectedKlas;

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
            if (lboxKlasLijst.SelectedIndex != -1)
            {
                selectedKlas = (Klas)lboxKlasLijst.SelectedItem;
                txtbOmschr.Text = selectedKlas.Naam;
                chboxZombie.IsChecked = selectedKlas.Zombie;
                txtbIndex.Text = "" + (lboxKlasLijst.SelectedIndex + 1);
            }
        }
        private void BtnNieuw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(txtbIndex.Text) - 1;
                if (index > klasLijst.Count)
                {
                    index = klasLijst.Count;
                }
                Klas nieuweKlas = new Klas(txtbOmschr.Text, Convert.ToBoolean(chboxZombie.IsChecked));
                klasLijst.Insert(index, nieuweKlas);
                klasLijst.SchrijfLijst();
                UpdateLijst();
            }
            catch (FormatException)
            {
                MessageBox.Show("De index moet een cijfer zijn");
            }
        }
        private void BtnPasAan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(txtbIndex.Text);
                if (index > klasLijst.Count)
                {
                    index = klasLijst.Count;
                }
                Klas aangepasteKlas = new Klas(txtbOmschr.Text, Convert.ToBoolean(chboxZombie.IsChecked));
                PasKlasGebruikersAan(aangepasteKlas);
                klasLijst.Insert(index, aangepasteKlas);
                klasLijst.Remove(selectedKlas);
                klasLijst.SchrijfLijst();
                UpdateLijst();
            }
            catch (FormatException)
            {
                MessageBox.Show("De index moet een cijfer zijn");
            }
        }
        private void PasKlasGebruikersAan(Klas nieuweKlas)
        {
            AlleGebruikersLijst lijst = new AlleGebruikersLijst();
            foreach (Gebruiker gebruiker in lijst)
            {
                if (gebruiker.Klas.Naam.Equals(selectedKlas.Naam))
                {
                    gebruiker.Klas = nieuweKlas;
                }
            }
            lijst.SchrijfLijst();
        }
        private void BtnVerwijder_Click(object sender, RoutedEventArgs e)
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
        private void chboxZombie_Checked(object sender, RoutedEventArgs e)
        {
            //Moet hier blijven staan want anders werkt checkbox niet
        }

        //Properties
    }
}
