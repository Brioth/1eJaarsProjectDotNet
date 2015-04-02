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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private bool leerkracht = false;
        private List<Gebruiker> accountLijst;
        private List<String> klasLijst;
        private MenuItem aangepastMenu;
        private string selectedKlas;
        private Gebruiker actieveGebruiker;
        //Constructors

        public Login()
        {
            InitializeComponent();
            maakKlasLijst();
            boxKlas.ItemsSource = klasLijst;
            maakAccountLijst(leerkracht);
            boxLogin.ItemsSource = accountLijst;
            aangepastMenu = new AanpasbaarMenu("standaard");
        }

        //Events

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            loginHandler();

        }

        private void pswBox_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                loginHandler();
            }
        }

        private void chkLk_Checked(object sender, RoutedEventArgs e)
        {
            leerkracht = true;
            accountLijst.Clear();
            maakAccountLijst(leerkracht);
            boxLogin.ItemsSource = accountLijst;
        }

        private void chkLk_Unchecked(object sender, RoutedEventArgs e)
        {
            leerkracht = false;
            accountLijst.Clear();
            maakAccountLijst(leerkracht);
            boxLogin.ItemsSource = accountLijst;
        }

        private void boxKlas_Changed(object sender, SelectionChangedEventArgs e)
        {
            accountLijst.Clear();
            selectedKlas = Convert.ToString(boxKlas.SelectedItem);
            maakAccountLijst(leerkracht);
            boxLogin.ItemsSource = accountLijst;
        }

        
        //Methods

        private void loginHandler()
        {
            Gebruiker selectedGebruiker = checkSelectedGebruiker();
            bool pswOk = checkPsw(selectedGebruiker);
            if (pswOk == true)
            {
                actieveGebruiker = new Gebruiker(selectedGebruiker);
                if (leerkracht)
                {
                    LeerkrachtMenu lkMenu = new LeerkrachtMenu(actieveGebruiker);
                    this.NavigationService.Navigate(lkMenu);
                }
                else
                {
                    LeerlingMenu llnMenu = new LeerlingMenu(actieveGebruiker);
                    this.NavigationService.Navigate(llnMenu);
                    
                }

            }
            else
            {
                MessageBox.Show("Het wachtwoord is foutief", "Foutief wachtwoord", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void maakAccountLijst(bool lk)
        {
            accountLijst = new List<Gebruiker>();
            StreamReader bestandAcc = File.OpenText(@"C:\Users\Vincent\Source\Repos\Groepswerk\Groepswerk\bin\Debug\Accounts.txt");
            string regel = bestandAcc.ReadLine();
            char[] scheiding = {';'};

            while (regel != null)
            {
                string[] woorden = regel.Split(scheiding);
                for (int i = 0; i < woorden.Length; i++)
                {
                    woorden[i] = woorden[i].Trim();
                }

                Gebruiker gebruiker = new Gebruiker(woorden[0], woorden[1], woorden[2], woorden[3]);

                if (leerkracht == true && (gebruiker.Type).Equals("lk"))
                {
                    accountLijst.Add(gebruiker);
                }
                else if (leerkracht == false)
                {
                    selectedKlas = Convert.ToString(boxKlas.SelectedItem);

                    if ((gebruiker.Klas).Equals(selectedKlas))
                    {
                        accountLijst.Add(gebruiker);
                    }
                }
                regel = bestandAcc.ReadLine();
            }
            bestandAcc.Close();
        }

        private void maakKlasLijst()
        {
            klasLijst = new List<String>();
            StreamReader bestandKlas = File.OpenText(@"C:\Users\Vincent\Source\Repos\Groepswerk\Groepswerk\bin\Debug\Klassen.txt");
            string regel = bestandKlas.ReadLine();

            while (regel != null)
            {
                klasLijst.Add(regel.Trim());
                regel = bestandKlas.ReadLine();
            }
            bestandKlas.Close();
        }

        private bool checkPsw(Gebruiker selectedGebruiker)
        {
            string gok = pswBox.Password;
            if (selectedGebruiker.Psw.Equals(gok))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Gebruiker checkSelectedGebruiker()
        {
            Gebruiker selectedGebruiker = new Gebruiker((Gebruiker)boxLogin.SelectedItem);
            return selectedGebruiker;
        }

        //Properties

        public MenuItem AangepastMenu
        {
            get { return aangepastMenu; }
        }

    }
}
