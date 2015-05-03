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
    /* Author: Thomas Cox
     * Date: 5/04/2015
     * 
     * Aangepast op 3/5 door Carmen
     * 
    */
    public partial class GemiddeldesKlas : Page
    {
        private Klaslijst lijstKlas;
        private Accountlijst lijstAccounts;
        private List<DetailsGebruiker> detailsGebruikers;

        public GemiddeldesKlas()
        {
            InitializeComponent();
            lijstKlas = new Klaslijst();
            detailsGebruikers = new List<DetailsGebruiker>();
            selecteerKlas.ItemsSource = lijstKlas;
            selecteerKlas.SelectedIndex = 0;

        }

        private void selecteerKlas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lijstAccounts = new Accountlijst((Klas)selecteerKlas.SelectedItem);
            foreach (Gebruiker gebruiker in lijstAccounts)
            {
                detailsGebruikers.Add(new DetailsGebruiker(gebruiker.Id));
            }

            resultatenGrid.ItemsSource = detailsGebruikers;





            //MaakGrid();
            //string gemiddeldesText = gemiddeldes.Text;
            //gemiddeldes.Text = "Naam leerling" + '\t' + "Gemiddelde Wiskunde" + '\t' + "Gemiddelde Nederlands" + '\t' + "Gemiddelde WO";



            //for (int i = 0; i < (lijstAccounts.Count); i++)
            //{
            //    gemiddeldesText = gemiddeldes.Text;
            //    //gemiddeldesText = gemiddeldesText + '\n' + lijstAccount[i].Voornaam + " " + lijstAccount[i].Achternaam + '\t' + '\t' + lijstAccount[i].GemWisk + '\t' + '\t' + '\t' + lijstAccount[i].GemNed + '\t' + '\t' + '\t' + lijstAccount[i].GemWO;
            //    gemiddeldes.Text = gemiddeldesText;
            //}
            
        }


 
    } 
}
