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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace Groepswerk
{
    /* --LeerlingenMenu--
    * Leerlingen navigeren naar oefeningen
    * Spel wordt zichtbaar gezet indien deze week elk vak 1x gespeeld is, eventueel ook zombiespel als flag van klas op true staat
    * Author: Carmen Celen
    * Date: 29/03/2015
    */
    public partial class LeerlingMenu : Page
    {
        //Lokale variabelen

        //Constructors
        public LeerlingMenu(Gebruiker actievegebruiker)
        {
            InitializeComponent();
            UpdateGebruiker(actievegebruiker);
            lblBegroeting.Content = String.Format("Dag {0}, je hebt {1} seconden speltijd", ActieveGebruiker.Voornaam, ActieveGebruiker.GameTijdSec);
            btnSpel.IsEnabled = false;
            btnZombie.Visibility = Visibility.Hidden;
            CheckButton();
        }

        //Events
        private void BtnSpel_Click(object sender, RoutedEventArgs e)
        {
            HoofdSpel hoofdSpel = new HoofdSpel(ActieveGebruiker);
            this.NavigationService.Navigate(hoofdSpel);
        }
        private void BtnZombie_Click(object sender, RoutedEventArgs e)
        {
            ZombieSpel zombieSpel = new ZombieSpel(ActieveGebruiker);
            this.NavigationService.Navigate(zombieSpel);
        }
        //Author: Vincent Vandoninck
        //Date: 04/05/2015
        private void btnRekenenMak_Click(object sender, RoutedEventArgs e)
        {
            OefeningWiskundeMakkelijk oefWiskundeMakkelijkPagina = new OefeningWiskundeMakkelijk(ActieveGebruiker);
            this.NavigationService.Navigate(oefWiskundeMakkelijkPagina);
        }
        private void btnRekenenGem_Click(object sender, RoutedEventArgs e)
        {
            OefeningWiskundeGemiddeld oefWiskundeGemiddeldPagina = new OefeningWiskundeGemiddeld(ActieveGebruiker);
            this.NavigationService.Navigate(oefWiskundeGemiddeldPagina);
        }
        private void btnRekenenMoe_Click(object sender, RoutedEventArgs e)
        {
            OefeningWiskundeMoeilijk oefWiskundeMoeilijkPagina = new OefeningWiskundeMoeilijk(ActieveGebruiker);
            this.NavigationService.Navigate(oefWiskundeMoeilijkPagina);
        }

        //Buttons Seppe
        private void btnWOMak_Click(object sender, RoutedEventArgs e)
        {
            OefWoMakkelijk makkelijk = new OefWoMakkelijk(ActieveGebruiker);
            this.NavigationService.Navigate(makkelijk);
        }
        private void btnWoGem_Click(object sender, RoutedEventArgs e)
        {
            OefWoGemiddeld gemiddeld = new OefWoGemiddeld(ActieveGebruiker);
            this.NavigationService.Navigate(gemiddeld);
        }
        private void btnWoMoe_Click(object sender, RoutedEventArgs e)
        {
            OefWoMoeilijk moeilijk = new OefWoMoeilijk(ActieveGebruiker);
            this.NavigationService.Navigate(moeilijk);
        }
        //Buttons Thomas
        private void btnTaalMak_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1Makkelijk makkelijk = new OefNederlands1Makkelijk(ActieveGebruiker);
            this.NavigationService.Navigate(makkelijk);
        }

        private void btnTaalGem_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1Gemiddeld gemiddeld = new OefNederlands1Gemiddeld(ActieveGebruiker);
            this.NavigationService.Navigate(gemiddeld);
        }

        private void btnTaalMoe_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1Moeilijk moeilijk = new OefNederlands1Moeilijk(ActieveGebruiker);
            this.NavigationService.Navigate(moeilijk);
        }

        //Methods
        private void CheckButton() //check of gebruiker afgelopen week alles 1 maal gespeeld heeft
        {
            bool flagNed = false;
            bool flagWisk = false;
            bool flagWo = false;

            DetailsGebruiker details = new DetailsGebruiker(ActieveGebruiker.Id, ActieveGebruiker.ToString());
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            System.Globalization.Calendar cal = dfi.Calendar;

            foreach (Resultaat item in details.ResultatenNedMak)
            {
                if (cal.GetWeekOfYear(item.Datum, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).Equals(cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)))
                {
                    flagNed = true;
                }
            }
            foreach (Resultaat item in details.ResultatenNedMed)
            {
                if (cal.GetWeekOfYear(item.Datum, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).Equals(cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)))
                {
                    flagNed = true;
                }
            }
            foreach (Resultaat item in details.ResultatenNedMoe)
            {
                if (cal.GetWeekOfYear(item.Datum, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).Equals(cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)))
                {
                    flagNed = true;
                }
            }
            foreach (Resultaat item in details.ResultatenWiskMak)
            {
                if (cal.GetWeekOfYear(item.Datum, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).Equals(cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)))
                {
                    flagWisk = true;
                }
            }
            foreach (Resultaat item in details.ResultatenWiskMed)
            {
                if (cal.GetWeekOfYear(item.Datum, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).Equals(cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)))
                {
                    flagWisk = true;
                }
            }
            foreach (Resultaat item in details.ResultatenWiskMoe)
            {
                if (cal.GetWeekOfYear(item.Datum, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).Equals(cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)))
                {
                    flagWisk = true;
                }
            }
            foreach (Resultaat item in details.ResultatenWoMak)
            {
                if (cal.GetWeekOfYear(item.Datum, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).Equals(cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)))
                {
                    flagWo = true;
                }
            }
            foreach (Resultaat item in details.ResultatenWoMed)
            {
                if (cal.GetWeekOfYear(item.Datum, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).Equals(cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)))
                {
                    flagWo = true;
                }
            }
            foreach (Resultaat item in details.ResultatenWoMoe)
            {
                if (cal.GetWeekOfYear(item.Datum, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).Equals(cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)))
                {
                    flagWo = true;
                }
            }


            if (flagNed&&flagWisk&&flagWo)
            {
                btnSpel.IsEnabled = true;
                if (ActieveGebruiker.Klas.Zombie)
                {
                    btnZombie.Visibility = Visibility.Visible;
                }
            }
        }
        private void UpdateGebruiker(Gebruiker actievegebruiker)
        {
            AlleGebruikersLijst lijst = new AlleGebruikersLijst();
            foreach (Gebruiker item in lijst)
            {
                if (actievegebruiker.Id.Equals(item.Id))
                {
                    ActieveGebruiker = item;
                }
            }
        }
        //Properties
        public Gebruiker ActieveGebruiker { get; set; }

        
    }
}
