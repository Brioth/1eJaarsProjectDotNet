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
using System.Windows.Shapes;

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for Programma.xaml
    /// </summary>
    public partial class Programma : Window
    {
        private Gebruiker actieveGebruiker;
        //Constructors

        public Programma()
        {
            InitializeComponent();
            programma.WindowState = WindowState.Maximized;
            Login login = new Login();
            framePages.Navigate(login);
            maakMenuLeeg();
        }

        //Events

        private void MnuStop_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult stoppen = MessageBox.Show("Ben je zeker dat je wilt stoppen?", "Stop", MessageBoxButton.YesNo);
            switch (stoppen)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    Application.Current.Shutdown();
                    break;
                default:
                    break;
            }
        }

        private void MnuHome_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult home = MessageBox.Show("Wil je terug naar het login scherm gaan?", "Home", MessageBoxButton.YesNo);
            switch (home)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    Login login = new Login();
                    framePages.Navigate(login);
                    this.ActieveGebruiker = null;
                    break;
                default:
                    break;
            }
        }

        private void MnuRekenen_Click(object sender, RoutedEventArgs e)
        {
            //Vincent
        }
        private void MnuTaal_Click(object sender, RoutedEventArgs e)
        {
            //Thomas
        }
        private void MnuWO_Click(object sender, RoutedEventArgs e)
        {
            //Seppe
        }
        private void MnuIndOv_Click(object sender, RoutedEventArgs e)
        {
            Gebruikerdetails detailsMenu = new Gebruikerdetails(ActieveGebruiker);
            framePages.Navigate(detailsMenu);
        }
        private void MnuKlasOver_Click(object sender, RoutedEventArgs e)
        {
            GemiddeldesKlas klasGemMenu = new GemiddeldesKlas();
            framePages.Navigate(klasGemMenu);
        }
        private void MnuNieuweGebr_Click(object sender, RoutedEventArgs e)
        {
            NieuweGebruiker nieuweGebruikerMenu = new NieuweGebruiker();
            framePages.Navigate(nieuweGebruikerMenu);
        }
        private void MnuAccBewerk_Click(object sender, RoutedEventArgs e)
        {
            AccountBeheer accountBeheerMenu = new AccountBeheer(ActieveGebruiker);
            framePages.Navigate(accountBeheerMenu);
        }
        private void MnuKlaslijstBewerk_Click(object sender, RoutedEventArgs e)
        {

        }
        //Methods
        private void pasBalkAan()
        {
            if (ActieveGebruiker!=null)
            {
                switch (ActieveGebruiker.Type)
                {
                    case "lln":
                        maakMenuLeeg();
                        mnuAcc.IsEnabled = false;
                        mnuOefBew.IsEnabled = false;
                        mnuOefeningen.IsEnabled = true;
                        mnuStat.IsEnabled = false;
                        break;
                    case "lk":
                        maakMenuLeeg();
                        mnuAcc.IsEnabled = true;
                        mnuOefBew.IsEnabled = true;
                        mnuOefeningen.IsEnabled = false;
                        mnuStat.IsEnabled = true;
                        break;
                    default:
                        maakMenuLeeg();
                        break;
                }
            }
            else
            {
                maakMenuLeeg();
            }

        }

        private void maakMenuLeeg()
        {
            mnuBasis.IsEnabled = true;
            mnuAcc.IsEnabled = false;
            mnuOefBew.IsEnabled = false;
            mnuOefeningen.IsEnabled = false;
            mnuStat.IsEnabled = false;
        }

        //Properties
        public Gebruiker ActieveGebruiker
        {
            get 
            {
                return actieveGebruiker;
            }
            set
            {
                actieveGebruiker = value;
                this.Title = Convert.ToString(ActieveGebruiker);
                pasBalkAan();
            }
        }



    }
}
