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
    /// <summary>
    /// Interaction logic for LeerlingenBeheer.xaml
    /// </summary>
    public partial class LeerlingenBeheer : Page
    {
        private Klaslijst klasLijst;
        private Accountlijst accountlijst;
        private string selectedKlas;
        private Gebruiker selectedGebruiker;
        private AlleGebruikersLijst alleGebruikersLijst;
        //Constructors

        public LeerlingenBeheer(Gebruiker actieveGebruiker)
        {
            InitializeComponent();
            ActieveGebruiker = actieveGebruiker;
            klasLijst = new Klaslijst();
            boxKlas.ItemsSource = klasLijst;
            boxKlas.SelectedIndex = 0;
            boxCommands.SelectedIndex = 0;

           /* Window mainWindow = Application.Current.MainWindow;
            Menu mainMenu = (Menu) mainWindow.FindName("mainMenu");
            MenuItem i = new MenuItem();
            i.Header = "test";
            mainMenu.Items.Add(i);*/
            
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

        private void boxCommands_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (boxCommands.SelectedIndex == 0)//Nieuwe gebruiker
            {
               /* btnPasAan.Visibility = Visibility.Hidden;
                btnVerwijder.Visibility = Visibility.Hidden;
                boxNieuweKlas.Visibility = Visibility.Hidden;
                boxAccounts.Visibility = Visibility.Hidden;
                btnVoegToe.Visibility = Visibility.Visible;*/
            }
            else if (boxCommands.SelectedIndex == 1)//Verwijderen en aanpassen
            {
                btnPasAan.Visibility = Visibility.Visible;
                btnVerwijder.Visibility = Visibility.Visible;
                boxNieuweKlas.Visibility = Visibility.Visible;
                boxAccounts.Visibility = Visibility.Visible;
                btnVoegToe.Visibility = Visibility.Hidden;

                boxNieuweKlas.ItemsSource = klasLijst;
                alleGebruikersLijst = new AlleGebruikersLijst();
            }
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

        private void btnVoegToe_Click(object sender, RoutedEventArgs e)
        {
            string type;
            if (selectedKlas.Equals("Leerkracht"))
            {
                type = "lk";
            }
            else
        	{
                type = "lln";
        	}

            Gebruiker nieuweGebruiker = new Gebruiker(type, selectedKlas, txtbVoornaam.Text, txtboxAchternaam.Text, pswBox.Password);
            string stringGebruiker = nieuweGebruiker.SchrijfString();
            StreamWriter schrijfBestand = File.AppendText(@"Accounts.txt");
            schrijfBestand.WriteLine();
            schrijfBestand.Write(stringGebruiker);
            schrijfBestand.Close();
            MessageBox.Show(String.Format("{0} {1} is toegevoegd aan {2}", nieuweGebruiker.Type, nieuweGebruiker, nieuweGebruiker.Klas));
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
            SchrijfLijst();
            MessageBox.Show(String.Format("U hebt gebruiker {0} aangepast", selectedGebruiker));
        }
        //Methods
        private void VerwijderGebruiker()
        {
            alleGebruikersLijst.Remove(selectedGebruiker);
            SchrijfLijst();

        }

        private void SchrijfLijst()
        {
            File.WriteAllText(@"Accounts.txt", String.Empty);
            StreamWriter schrijver = File.AppendText(@"Accounts.txt");
            foreach (Gebruiker item in alleGebruikersLijst)
            {
                schrijver.WriteLine(item.SchrijfString());
            }
            schrijver.Close();
        }

        //Properties

        public Gebruiker ActieveGebruiker { get; set; }





    }
}
