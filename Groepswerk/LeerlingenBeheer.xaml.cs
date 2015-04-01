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
    /// Interaction logic for LeerlingenBeheer.xaml
    /// </summary>
    public partial class LeerlingenBeheer : Page
    {
        private List<String> klasLijst;
        private List<Gebruiker> gebruikersLijst;

        //Constructors

        public LeerlingenBeheer(Gebruiker actieveGebruiker)
        {
            InitializeComponent();
            ActieveGebruiker = actieveGebruiker;
            maakKlasLijst();
            boxKlas.ItemsSource = klasLijst;
            maakGebruikersLijst();
            boxAccounts.ItemsSource = gebruikersLijst;
        }

        //Events
        private void boxKlas_Changed(object sender, SelectionChangedEventArgs e)
        {
            gebruikersLijst.Clear();
            maakGebruikersLijst();
            boxAccounts.ItemsSource = gebruikersLijst;
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
            StreamReader bestandLezer = File.OpenText(@"C:\Users\11400938\Source\Repos\Groepswerk\Groepswerk\bin\Debug\Accounts.txt");
            string oudBestand = bestandLezer.ReadToEnd();
            bestandLezer.Close();
            string nieuweGebruiker = String.Format("lln; {0}; {1}; {2}; ", Convert.ToString(boxKlas.SelectedItem), txtbNaam.Text, pswBox.Password);
            StreamWriter schrijfBestand = File.AppendText(@"C:\Users\11400938\Source\Repos\Groepswerk\Groepswerk\bin\Debug\Accounts.txt");
            schrijfBestand.WriteLine(Environment.NewLine + nieuweGebruiker);
            schrijfBestand.Close();
        }
        //Methods

        private void maakKlasLijst()
        {
            klasLijst = new List<String>();
            StreamReader bestandKlas = File.OpenText(@"C:\Users\11400938\Source\Repos\Groepswerk\Groepswerk\bin\Debug\Klassen.txt");
            string regel = bestandKlas.ReadLine();

            while (regel != null)
            {
                klasLijst.Add(regel.Trim());
                regel = bestandKlas.ReadLine();
            }
            bestandKlas.Close();
        }

        private void maakGebruikersLijst()
        {
            gebruikersLijst = new List<Gebruiker>();
            StreamReader bestandAcc = File.OpenText(@"C:\Users\11400938\Source\Repos\Groepswerk\Groepswerk\bin\Debug\Accounts.txt");
            string regel = bestandAcc.ReadLine();
            char[] scheiding = { ';', ',' };

            while (regel != null)
            {
                string[] woorden = regel.Split(scheiding);
                for (int i = 0; i < woorden.Length; i++)
                {
                    woorden[i] = woorden[i].Trim();
                }

                Gebruiker gebruiker = new Gebruiker(woorden[0], woorden[1], woorden[2], woorden[3]);

                string selectedKlas = Convert.ToString(boxKlas.SelectedItem);

                if ((gebruiker.Klas).Equals(selectedKlas))
                {
                    gebruikersLijst.Add(gebruiker);
                }

                regel = bestandAcc.ReadLine();
            }
            bestandAcc.Close();
        }

        //Properties

        public Gebruiker ActieveGebruiker { get; set; }







    }
}
