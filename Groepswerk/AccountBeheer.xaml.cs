using Groepswerk.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Groepswerk
{
    /* --AccountBeheer--
     * Gebruiker aanpassen of verwijderen
     * Author: Carmen Celen
     * Date: 01/04/2015
     */
    public partial class AccountBeheer : Page
    {
        //Lokale variablen
        private Klaslijst klasLijst;
        private Accountlijst accountlijst;
        private string selectedKlas;
        private Gebruiker selectedGebruiker;
        private AlleGebruikersLijst alleGebruikersLijst;

        //Constructors
        public AccountBeheer(Gebruiker actieveGebruiker)
        {
            InitializeComponent();
            ActieveGebruiker = actieveGebruiker;
            klasLijst = new Klaslijst();
            boxKlas.ItemsSource = klasLijst;
            boxNieuweKlas.ItemsSource = klasLijst;
            boxKlas.SelectedIndex = 0;
        }

        //Events
        private void boxKlas_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (accountlijst != null)
            {
                accountlijst.Clear();
            }
            selectedKlas = Convert.ToString(boxKlas.SelectedItem);
            accountlijst = new Accountlijst(selectedKlas);
            boxAccounts.ItemsSource = accountlijst;
            boxAccounts.SelectedIndex = 0;
        }
        private void boxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)//Vincent
        {
            if (boxAccounts.SelectedIndex!=-1)
            {
                selectedGebruiker = (Gebruiker)boxAccounts.SelectedItem;
                txtbVoornaam.Text = selectedGebruiker.Voornaam;
                txtboxAchternaam.Text = selectedGebruiker.Achternaam;
                pswBox.Password = selectedGebruiker.Psw;
                boxNieuweKlas.SelectedItem = selectedGebruiker.Klas;
            }
        }       
        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult verwijderen = MessageBox.Show(String.Format("Ben je zeker dat je {0} wilt verwijderen?",selectedGebruiker), "Delete", MessageBoxButton.YesNo);
            switch (verwijderen)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    VerwijderGebruiker();
                    MessageBox.Show(string.Format("U hebt gebruiker {0} verwijderd", selectedGebruiker));
                    boxKlas.SelectedItem = selectedKlas;
                    break;
                default:
                    break;
            }
        }
        private void btnPasAan_Click(object sender, RoutedEventArgs e)
        {
            selectedGebruiker.Voornaam = txtbVoornaam.Text;
            selectedGebruiker.Achternaam = txtboxAchternaam.Text;
            selectedGebruiker.Psw = pswBox.Password;
            selectedGebruiker.Klas = Convert.ToString(boxNieuweKlas.SelectedItem);
            wisselGebruiker();
            MessageBox.Show(String.Format("U hebt gebruiker {0} aangepast", selectedGebruiker));
            updateListbox();
        }

        //Methods
        private void VerwijderGebruiker()
        {
            alleGebruikersLijst = new AlleGebruikersLijst();
            for (int i = 0; i < alleGebruikersLijst.Count; i++)
            {
                if (alleGebruikersLijst[i].Id == selectedGebruiker.Id)
                {
                    alleGebruikersLijst.RemoveAt(i);
                }
            }
            alleGebruikersLijst.SchrijfLijst();
            updateListbox();
        }
        private void wisselGebruiker()
        {
            alleGebruikersLijst = new AlleGebruikersLijst();
            for (int i = 0; i < alleGebruikersLijst.Count; i++)
            {
                if (alleGebruikersLijst[i].Id==selectedGebruiker.Id)
                {
                    alleGebruikersLijst[i] = selectedGebruiker;
                }
            }
            alleGebruikersLijst.SchrijfLijst();
        }
        private void updateListbox()
        {
            accountlijst = new Accountlijst(selectedKlas);
            boxAccounts.ItemsSource = accountlijst;
        }

        //Properties
        public Gebruiker ActieveGebruiker { get; set; }
    }
}
