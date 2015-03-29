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
    /// Interaction logic for LeerkrachtMenu.xaml
    /// </summary>
    public partial class LeerkrachtMenu : Page
    {
        public LeerkrachtMenu()
        {
            InitializeComponent();
        }

        private void btnLlnBeheer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIndOv_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnKlOv_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpgBew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Login.xaml", UriKind.Relative));
        }
    }
}
