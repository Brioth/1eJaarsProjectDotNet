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
            listbLogin.ItemsSource = accountLijst;
        }
            

        //Events
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //lees naam, check type

            if (gebruikerLogin.Type == "leerkracht")
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
        private void chkLk_Checked(object sender, RoutedEventArgs e)
        {
            leerkracht = true;
        }
       //Methods
        private void maakAccountLijst(bool lk)
        {
            accountLijst = new List<string>();
            pswLijst = new List<String>();
            StreamReader bestand = File.OpenText(@"C:\Users\11400938\Source\Repos\Groepswerk\Groepswerk\Accounts.txt");
            string regel = bestand.ReadLine();
            char[] scheiding={';', ','};

            while (regel != null)
            {
                string[] woorden = regel.Split(scheiding);
                accountLijst.Add(woorden[1].Trim());
                regel = bestand.ReadLine();
            }
            bestand.Close();

            
        }



       //Properties
        public Gebruiker GebruikerLogin
        {
            get { return gebruikerLogin; }
            set { gebruikerLogin = value; }
        }

        
    }
}
