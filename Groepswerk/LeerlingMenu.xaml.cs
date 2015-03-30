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
    /// <summary>
    /// Interaction logic for LeerlingMenu.xaml
    /// </summary>
    public partial class LeerlingMenu : Page
    {
        private Gebruiker gebruikerLln;
        public LeerlingMenu()
        {
            InitializeComponent();
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.NavigationService.Navigate(login);
        }

        public Gebruiker GebruikerLln { get; set; }
    }
}
