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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LeerkrachtMenu : Page
    {
        private MenuItem aangepastMenu;

        //Constructors

        public LeerkrachtMenu(Gebruiker actieveGebruiker)
        {
            InitializeComponent();
            ActieveGebruiker = actieveGebruiker;
            aangepastMenu = new AanpasbaarMenu(actieveGebruiker.Type);
        }

        //Events

        private void btnLlnBeheer_Click(object sender, RoutedEventArgs e)
        {
            LeerlingenBeheer beheerMenu = new LeerlingenBeheer(ActieveGebruiker);
            this.NavigationService.Navigate(beheerMenu);
        }

        private void btnIndOv_Click(object sender, RoutedEventArgs e)
        {
            gebruikerdetails detailsMenu = new gebruikerdetails(ActieveGebruiker);
            this.NavigationService.Navigate(detailsMenu);
        }

        private void btnKlOv_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpgBew_Click(object sender, RoutedEventArgs e)
        {

        }


        //Methods

        //Properties

        public Gebruiker ActieveGebruiker { get; set; }

        public MenuItem AangepastMenu
        {
            get { return aangepastMenu; }
        }


    }
}
