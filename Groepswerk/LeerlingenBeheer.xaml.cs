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
        //Constructors

        public LeerlingenBeheer(Gebruiker actieveGebruiker)
        {
            InitializeComponent();
            ActieveGebruiker = actieveGebruiker;
            klasLijst = new Klaslijst();
            boxKlas.ItemsSource = klasLijst;
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
            boxAccounts.SelectedIndex = 0;
        }

        private void boxCommands_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (boxCommands.SelectedIndex == 0)
            {
                boxKlas.Visibility = Visibility.Visible;
                boxAccounts.Visibility = Visibility.Hidden;

            }
            else if (boxCommands.SelectedIndex == 1)
            {
                boxKlas.Visibility = Visibility.Visible;
                boxAccounts.Visibility = Visibility.Visible;

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
        //Methods

        //Properties

        public Gebruiker ActieveGebruiker { get; set; }

    }
}
