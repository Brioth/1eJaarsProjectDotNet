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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private Accountlijst accountLijst;
        private Klaslijst klasLijst;
        private Gebruiker actieveGebruiker;
        //Constructors

        public Login()
        {
            InitializeComponent();
            klasLijst = new Klaslijst();
            boxKlas.ItemsSource = klasLijst;
            boxKlas.SelectedIndex = 0;
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

        private void boxKlas_Changed(object sender, SelectionChangedEventArgs e)
        {
            SelectedKlas =Convert.ToString(boxKlas.SelectedItem);
            if (accountLijst != null)
            {
                accountLijst.Clear();
            }
            accountLijst = new Accountlijst(SelectedKlas);
            boxLogin.ItemsSource = accountLijst;
            boxLogin.SelectedIndex = 0;
        }


        //Methods

        private void loginHandler()
        {
            Gebruiker selectedGebruiker = (Gebruiker)boxLogin.SelectedItem;
            bool pswOk = checkPsw(selectedGebruiker);
            if (pswOk == true)
            {
                actieveGebruiker = selectedGebruiker;
                if (actieveGebruiker.Type.Equals("lk"))
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

        //Properties
        public string SelectedKlas { get; set; }
    }
}
