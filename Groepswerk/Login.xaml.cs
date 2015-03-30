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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();

        }

        private void btnLlnLogin_Click(object sender, RoutedEventArgs e)
        {
            LeerlingMenu llnMenu = new LeerlingMenu();
            this.NavigationService.Navigate(llnMenu);
            
        }

        private void btnLkLogin_Click(object sender, RoutedEventArgs e)
        {
            LeerkrachtMenu lkMenu = new LeerkrachtMenu();
            this.NavigationService.Navigate(lkMenu);
        }
    }
}
