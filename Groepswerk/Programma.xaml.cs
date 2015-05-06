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
    /* --Programma--
     * MainWindow voor de hele toepassing
     * In het frame wordt de gekozen page weergegeven
     * In XAML de menuItems toevoegen en in code deze al dan niet zichtbaar maken afhankelijk of de gebruiker lln of lk is
     * In Code ook de click_events voor de menuItems
     * Programma heeft ook een actieve gebruiker propertie, deze wordt weergegeven in de titelbalk
     * Author: Carmen Celen
     * Date: 27/03/2015
     */
    public partial class Programma : Window
    {
        //Lokale variabelen
        private Gebruiker actieveGebruiker;

        //Constructors
        public Programma()
        {
            InitializeComponent();
            Login login = new Login();
            framePages.Navigate(login);
            MaakMenuLeeg();
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
                    this.ActieveGebruiker = null; //uitloggen
                    break;
                default:
                    break;
            }
        }

        //Author: Vincent Vandoninck
        //Date: 04/05/2015
        private void MnuWiskundeMakkelijk_Click(object sender, RoutedEventArgs e)
        {
            oefeningWiskundeMakkelijk oefWiskundeMakkelijk = new oefeningWiskundeMakkelijk(ActieveGebruiker);
            framePages.Navigate(oefWiskundeMakkelijk);
        }
        private void MnuWiskundeGemiddeld_Click(object sender, RoutedEventArgs e)
        {
            oefeningWiskundeGemiddeld oefWiskundeGemiddeld = new oefeningWiskundeGemiddeld(ActieveGebruiker);
            framePages.Navigate(oefWiskundeGemiddeld);
        }
        private void MnuWiskundeMoeilijk_Click(object sender, RoutedEventArgs e)
        {
            oefeningWiskundeMoeilijk oefWiskundeMoeilijk = new oefeningWiskundeMoeilijk(ActieveGebruiker);
            framePages.Navigate(oefWiskundeMoeilijk);
        }

        //Author: Thomas Cox
        //Date: 22/04/2015
        private void MnuTaalMakkelijk_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1Makkelijk oefNederlandsMakkelijk = new OefNederlands1Makkelijk(actieveGebruiker);
            framePages.Navigate(oefNederlandsMakkelijk);
        }
        private void MnuTaalGemiddeld_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1Gemiddeld oefNederlandsGemiddeld = new OefNederlands1Gemiddeld(actieveGebruiker);
            framePages.Navigate(oefNederlandsGemiddeld);
        }
        private void MnuTaalMoeilijk_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1Moeilijk oefNederlandsMoeilijk = new OefNederlands1Moeilijk(actieveGebruiker);
            framePages.Navigate(oefNederlandsMoeilijk);
        }

        //navigatie oefeningen
        //Author: Seppe
        private void MnuWoMakkelijk_Click(object sender, RoutedEventArgs e)
        {
            oefWoMakkelijk oefWoMakkelijk = new oefWoMakkelijk(ActieveGebruiker);
            framePages.Navigate(oefWoMakkelijk);
        }
        private void MnuWoGemiddeld_Click(object sender, RoutedEventArgs e)
        {
            oefWoGemiddeld oefWoGemiddeld = new oefWoGemiddeld(ActieveGebruiker);
            framePages.Navigate(oefWoGemiddeld);
        }
        private void MnuWoMoeilijk_Click(object sender, RoutedEventArgs e)
        {
            oefWoMoeilijk oefWoMoeilijk = new oefWoMoeilijk(ActieveGebruiker);
            framePages.Navigate(oefWoMoeilijk);
        }
        //aanpassen oefening
        //Author: Thomas Cox
        //Date: 22/04/2015
        private void MnuBewerkenMakkelijk_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1AanpassenMakkelijk oefNederlandsAanpassenMakkelijk = new OefNederlands1AanpassenMakkelijk(actieveGebruiker);
            framePages.Navigate(oefNederlandsAanpassenMakkelijk);
        }
        private void MnuBewerkenGemiddeld_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1AanpassenGemiddeld oefNederlandsAanpassenGemiddeld = new OefNederlands1AanpassenGemiddeld(actieveGebruiker);
            framePages.Navigate(oefNederlandsAanpassenGemiddeld);
        }
        private void MnuBewerkenMoeilijk_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1AanpassenMoeilijk nederlandsOefAanpassenMoeilijk = new OefNederlands1AanpassenMoeilijk(actieveGebruiker);
            framePages.Navigate(nederlandsOefAanpassenMoeilijk);
        }
        // navigatie aanpassen oefening WO
        //author: Seppe Vandezande
        //Date: 06/05/2015

        private void MnuWoBewerkenMakkelijk_Click(object sender, RoutedEventArgs e)
        {
            WoMakkelijkAanpassen WoMakkelijkAanpassen = new WoMakkelijkAanpassen();
            framePages.Navigate(WoMakkelijkAanpassen);
        }
        private void MnuWoBewerkenGemiddeld_Click(object sender, RoutedEventArgs e)
        {
            WoAanpassenGemiddeld WoAanpassenGemiddeld = new WoAanpassenGemiddeld();
            framePages.Navigate(WoAanpassenGemiddeld);
        }
        private void MnuWoBewerkenMoeilijk_Click(object sender, RoutedEventArgs e)
        {
            WoMoeilijkAanpassen WoMoeilijkAanpassen = new WoMoeilijkAanpassen();
            framePages.Navigate(WoMoeilijkAanpassen);
        }
        //Navigatie Leerkracht
        private void MnuIndOv_Click(object sender, RoutedEventArgs e)
        {
            Gebruikerdetails detailsMenu = new Gebruikerdetails();
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
            AccountBeheer accountBeheerMenu = new AccountBeheer();
            framePages.Navigate(accountBeheerMenu);
        }
        private void MnuKlaslijstBewerk_Click(object sender, RoutedEventArgs e)
        {
            BewerkKlasLijst bewerkKlasMenu = new BewerkKlasLijst();
            framePages.Navigate(bewerkKlasMenu);
        }

        //Methods
        private void PasBalkAan() //hier beschikbaarheid menu's aanpassen
        {
            if (ActieveGebruiker != null)
            {
                switch (ActieveGebruiker.Type)
                {
                    case "lln":
                        MaakMenuLeeg();
                        mnuAcc.Visibility = Visibility.Collapsed;
                        mnuOefBew.Visibility = Visibility.Collapsed;
                        mnuOefeningen.Visibility = Visibility.Visible;
                        mnuStat.Visibility = Visibility.Collapsed;
                        break;
                    case "lk":
                        MaakMenuLeeg();
                        mnuAcc.Visibility = Visibility.Visible;
                        mnuOefBew.Visibility = Visibility.Visible;
                        mnuOefeningen.Visibility = Visibility.Collapsed;
                        mnuStat.Visibility = Visibility.Visible;
                        break;
                    default:
                        MaakMenuLeeg();
                        break;
                }
            }
            else
            {
                MaakMenuLeeg();
            }
        }
        private void MaakMenuLeeg() //Standaard menu zonder gebruiker
        {
            mnuBasis.Visibility = Visibility.Visible;
            mnuAcc.Visibility = Visibility.Collapsed;
            mnuOefBew.Visibility = Visibility.Collapsed;
            mnuOefeningen.Visibility = Visibility.Collapsed;
            mnuStat.Visibility = Visibility.Collapsed;
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
                PasBalkAan();
            }
        }

       

        
    }
}
