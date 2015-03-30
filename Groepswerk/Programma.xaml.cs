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
        private String gebruiker;
        public Programma()
        {
            InitializeComponent();
            windowProgramma.WindowState = WindowState.Maximized;
            gebruiker = "standaard";
            Login loginMenu = new Login();
        }

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
                    framePages.NavigationService.Navigate(new Uri("Login.xaml", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

        private void menuAanpassen(String gebruiker)
        {
            if (gebruiker.Equals("leerling"))
            {

            }
            else if (gebruiker.Equals("leerkracht"))
            {
                MenuItem beheerAcc = new MenuItem();
                MenuItem overzichtInd = new MenuItem();
                MenuItem overzichtKlas = new MenuItem();
                MenuItem opgAanp = new MenuItem();
                beheerAcc.Header = "AccountBeheer";
                overzichtInd.Header = "Individueel overzicht";
                overzichtKlas.Header = "Klassikaal overzicht";
                opgAanp.Header = "Opgaven aanpassen";

                menuDefault.Items.Add(beheerAcc);
                menuDefault.Items.Add(overzichtKlas);
                menuDefault.Items.Add(overzichtInd);
                menuDefault.Items.Add(opgAanp);

            }
            else
	        {

	        }
        }


        public String Gebruiker
        {
            get { return gebruiker;}
            set { gebruiker = value; }
        }

    }
}
