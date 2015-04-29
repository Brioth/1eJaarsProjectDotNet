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

namespace Groepswerk
{
    /* --LeerlingenMenu--
    * Leerlingen navigeren naar oefeningen
    * Spel wordt zichtbaar gezet indien ok
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
            ActieveGebruiker = actievegebruiker;
            lblBegroeting.Content = String.Format("Dag {0}", ActieveGebruiker.Voornaam);
            CheckButton();
        }

        //Events
        private void BtnSpel_Click(object sender, RoutedEventArgs e)
        {
            HoofdSpel hoofdSpel = new HoofdSpel();
            this.NavigationService.Navigate(hoofdSpel);
        }
        private void BtnZombie_Click(object sender, RoutedEventArgs e)
        {
            ZombieSpel zombieSpel = new ZombieSpel(ActieveGebruiker);
            this.NavigationService.Navigate(zombieSpel);
        }

        //Methods
        private void CheckButton() //check of gebruiker afgelopen week alles 1 maal gespeeld heeft
        {
            if (true)
            {
                //zet button aan
            }
            else
            {
                //zet button disabled
            }
        }

        //Properties
        public Gebruiker ActieveGebruiker { get; set; }
    }
}
