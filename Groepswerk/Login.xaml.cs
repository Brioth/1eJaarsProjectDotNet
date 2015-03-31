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
        private Gebruiker gebruikerLogin;
        private bool leerkracht = false;
        private string selectedKlas;
        private List<String> accountLijst;
        private List<String> pswLijst;
        private List<String> klasLijst;
        
        //Constructors

        public Login()
        {
            InitializeComponent();
            maakKlasLijst();
            boxKlas.ItemsSource = klasLijst;
            maakAccountLijst(leerkracht);
            boxLogin.ItemsSource = accountLijst;
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
            bool pswOk = checkPsw(boxLogin.SelectedIndex, pswBox.Password);
            if (pswOk == true)
            {
                if (leerkracht)
                {
                    LeerkrachtMenu lkMenu = new LeerkrachtMenu();
                    lkMenu.GebruikerLk = new Gebruiker();//("naam")
                    this.NavigationService.Navigate(lkMenu);
                }
                else
                {
                    LeerlingMenu llnMenu = new LeerlingMenu();
                    llnMenu.GebruikerLln = new Gebruiker();//("naam")
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
            accountLijst = new List<String>();
            pswLijst = new List<String>();
            StreamReader bestandAcc = File.OpenText(@"C:\Users\11400938\Source\Repos\Groepswerk\Groepswerk\bin\Debug\Accounts.txt");
            string regel = bestandAcc.ReadLine();
            char[] scheiding = { ';', ',' };

            while (regel != null)
            {
                string[] woorden = regel.Split(scheiding);
                string type = woorden[0].Trim();

                if (leerkracht == true && type.Equals("lk"))
                {
                    accountLijst.Add(woorden[1].Trim());
                    pswLijst.Add(woorden[2].Trim());
                }
                else if (leerkracht == false && type.Equals("lln"))
                {
                    selectedKlas = Convert.ToString(boxKlas.SelectedItem);
                    string klasLln = woorden[1].Trim();

                    if (selectedKlas.Equals(klasLln))
                    {
                        accountLijst.Add(woorden[2].Trim());
                        pswLijst.Add(woorden[3].Trim());
                    }
                }
                regel = bestandAcc.ReadLine();
            }
            bestandAcc.Close();
        }

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

        private bool checkPsw(int nrPersoon, string gok)
        {
            string psw = pswLijst[nrPersoon];
            if (psw.Equals(gok))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Properties

        public Gebruiker GebruikerLogin
        {
            get { return gebruikerLogin; }
            set { gebruikerLogin = value; }
        }








    }
}
