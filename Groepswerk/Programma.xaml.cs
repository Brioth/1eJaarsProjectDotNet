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

        //Constructors

        public Programma()
        {
            InitializeComponent();
            programma.WindowState = WindowState.Maximized;
            Login login = new Login();
            framePages.Navigate(login);
        }

        //Events
        
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult stoppen = MessageBox.Show("Ben je zeker dat je wilt stoppen?","Stop", MessageBoxButton.YesNo);
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

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult home = MessageBox.Show("Wil je terug naar het login scherm gaan?", "Home", MessageBoxButton.YesNo);
            switch (home)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    Login login = new Login();
                    framePages.NavigationService.Navigate(login);
                    break;
                default:
                    break;
            }
        }

        //Methods

        

        //Properties
        public Gebruiker ActieveGebruiker { get; set; }
    }
}
