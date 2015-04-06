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
        private bool leerkracht = false;

        //Constructors
        public gebruikerdetails(Gebruiker ActieveGebruiker)
        {
            // TODO: Complete member initialization
            this.ActieveGebruiker = ActieveGebruiker;
        }

       /* public void gebruikerkeuze() 
        {
            InitializeComponent();
            maakKlasLijst();
            //accountLijst.Clear();
            klasKeuze.ItemsSource = klasLijst;
            selectedKlas = Convert.ToString(klasKeuze.SelectedItem);
        }*/


  /*      private void maakAccountLijst(bool lk)
        {
            accountLijst = new List<Gebruiker>();
           
        
      
        private void maakKlasLijst()
        {
            klasLijst = new List<String>();
          

       private void keuzeBtn_Click(object sender, RoutedEventArgs e)
        {
        /* 
          listbox.sourceitem(accountlijst)
          
*/

        }
   
        public gebruikerdetails()
        {
            // TODO: Complete member initialization
        }

      

        public Gebruiker ActieveGebruiker { get; set; }

        private void klasKeuze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    } 
}
