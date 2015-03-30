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
        private List<String> accountLijst;
        private List<String> pswLijst;
       //Constructors
        public Login()
        {
            InitializeComponent();
            maakAccountLijst(leerkracht);
            boxLogin.ItemsSource = accountLijst;
        }
            

        //Events
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool pswOk = checkPsw(boxLogin.SelectedIndex, pswBox.Password);
            if (pswOk ==true)
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
                MessageBox.Show("Het wachtwoord is foutief","Foutief wachtwoord",MessageBoxButton.OK, MessageBoxImage.Stop);
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
        
       //Methods
        private void maakAccountLijst(bool lk)
        {
            accountLijst = new List<string>();
            pswLijst = new List<String>();
            StreamReader bestand = File.OpenText("Accounts.txt");
            string regel = bestand.ReadLine();
            char[] scheiding={';', ','};

            while (regel != null)
            {
                string[] woorden = regel.Split(scheiding);
                string type = woorden[0];
                if (leerkracht == true && type == "lk")
                {
                    accountLijst.Add(woorden[1].Trim());
                    pswLijst.Add(woorden[2].Trim());
                }
                else if (leerkracht == false && type == "lln"){
                    accountLijst.Add(woorden[1].Trim());
                    pswLijst.Add(woorden[2].Trim());
                }
                regel = bestand.ReadLine();
            }
            bestand.Close();            
        }

        private bool checkPsw(int nrPersoon, string gok)
        {
            string psw = pswLijst[nrPersoon];
            if (psw == gok)
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
