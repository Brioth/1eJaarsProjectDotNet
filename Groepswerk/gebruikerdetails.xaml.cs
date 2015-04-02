using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for gebruikerdetails.xaml
    /// </summary>
    public partial class gebruikerdetails : Page
    {
        private Gebruiker actieveGebruiker;
        private List<Gebruiker> accountLijst;
        private List<String> klasLijst;
        private string selectedKlas;
        private Gebruiker ActieveGebruiker;

        //Constructors


        public void gebruikerkeuze()
        {
            InitializeComponent();
            maakKlasLijst();
            //accountLijst.Clear();
            klasKeuze.ItemsSource = klasLijst;
            selectedKlas = Convert.ToString(klasKeuze.SelectedItem);
        }

        
      
        private void maakKlasLijst()
        {
            klasLijst = new List<String>();
            StreamReader bestandKlas = File.OpenText(@"C:\Users\Vincent\Source\Repos\Groepswerk\Groepswerk\bin\Debug\Klassen.txt");
            string regel = bestandKlas.ReadLine();

            while (regel != null)
            {
                klasLijst.Add(regel.Trim());
                regel = bestandKlas.ReadLine();
            }
            bestandKlas.Close();
        }

        private void keuzeBtn_Click(object sender, RoutedEventArgs e)
        {
            loginHandler();
        }

        private void loginHandler()
        {

            gebruikerdetails testmenu= new gebruikerdetails();
                    this.NavigationService.Navigate(testmenu);
        }
    } 
}
