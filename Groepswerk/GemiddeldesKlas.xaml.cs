using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /* --GemiddeldesKlas--
     * Pagina waar je als eerste terechtkomt als leerkracht
     * Algemeene statistieken per klas
     * Ook hier was een datagrid mogelijk
     * Aangepast op 03/05/2015 door Carmen Celen
     * Author: Thomas Cox
     * Date: 5/04/2015
    */
    public partial class GemiddeldesKlas : Page
    {
        //Lokale Variabelen
        private Klaslijst lijstKlas;
        private Accountlijst lijstAccounts;
        private List<DetailsGebruiker> detailsGebruikers;
        private List<Label> labels;

        //Constructors
        public GemiddeldesKlas()
        {
            InitializeComponent();
            lijstKlas = new Klaslijst();
            detailsGebruikers = new List<DetailsGebruiker>();
            labels = new List<Label>();
            selecteerKlas.ItemsSource = lijstKlas;
            selecteerKlas.SelectedIndex = 0;
        }

        //Events
        private void selecteerKlas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lijstAccounts = new Accountlijst((Klas)selecteerKlas.SelectedItem);
            detailsGebruikers.Clear();

            foreach (Gebruiker gebruiker in lijstAccounts)
            {
                detailsGebruikers.Add(new DetailsGebruiker(gebruiker.Id, gebruiker.ToString()));
            }

            MaakGrid(lijstAccounts);

            for (int i = 0; i < detailsGebruikers.Count; i++)
            {
                double gemNed = BerekenGem("Ned", i);
                double gemWisk = BerekenGem("Wisk", i);
                double gemWO = BerekenGem("WO", i);

                for (int j = 0; j < 4; j++)
                {
                    Label lbl = new Label();
                    lbl.Margin = new Thickness(20, 10, 20, 10);
                    switch (j)
                    {
                        case 0:
                            lbl.Content = detailsGebruikers[i].Naam;
                            break;
                        case 1:
                            lbl.Content = gemNed;
                            break;
                        case 2:
                            lbl.Content = gemWisk;
                            break;
                        case 3:
                            lbl.Content = gemWO;
                            break;
                    }
                    Grid.SetColumn(lbl, j);
                    Grid.SetRow(lbl, i + 1);
                    resultatenGrid.Children.Add(lbl);
                    labels.Add(lbl);
                }
            }
        }

        //Methods
        private double BerekenGem(string vak, int index)
        {
            int totaalPunten, totaalOefeningen;
            double gemiddelde;

            switch (vak)
            {
                case "Ned":
                    totaalPunten = detailsGebruikers[index].GemNedMak[0] + detailsGebruikers[index].GemNedMed[0] + detailsGebruikers[index].GemNedMoe[0];
                    totaalOefeningen = detailsGebruikers[index].GemNedMak[2] + detailsGebruikers[index].GemNedMed[2] + detailsGebruikers[index].GemNedMoe[2];

                    gemiddelde = Math.Round(totaalPunten / Convert.ToDouble(totaalOefeningen), 2);
                    break;
                case "Wisk":
                    totaalPunten = detailsGebruikers[index].GemWiskMak[0] + detailsGebruikers[index].GemWiskMed[0] + detailsGebruikers[index].GemWiskMoe[0];
                    totaalOefeningen = detailsGebruikers[index].GemWiskMak[2] + detailsGebruikers[index].GemWiskMed[2] + detailsGebruikers[index].GemWiskMoe[2];

                    gemiddelde = Math.Round(totaalPunten / Convert.ToDouble(totaalOefeningen), 2);
                    break;
                case "WO":
                    totaalPunten = detailsGebruikers[index].GemWoMak[0] + detailsGebruikers[index].GemWoMed[0] + detailsGebruikers[index].GemWoMoe[0];
                    totaalOefeningen = detailsGebruikers[index].GemWoMak[2] + detailsGebruikers[index].GemWoMed[2] + detailsGebruikers[index].GemWoMoe[2];

                    gemiddelde = Math.Round(totaalPunten / Convert.ToDouble(totaalOefeningen), 2);
                    break;
                default:
                    gemiddelde = 0;
                    break;
            }

            if (double.IsNaN(gemiddelde))
            {
                gemiddelde = 0;
            }

            return gemiddelde;
        }
        private void MaakGrid(Accountlijst lijstAccounts)
        {
            foreach (Label item in labels)
            {
                resultatenGrid.Children.Remove(item);
            }
            labels.Clear();
            if (resultatenGrid.RowDefinitions.Count > 1)
            {
                resultatenGrid.RowDefinitions.RemoveRange(1, resultatenGrid.RowDefinitions.Count - 1);
            }
            foreach (Gebruiker item in lijstAccounts)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                resultatenGrid.RowDefinitions.Add(row);
            }
        }
    }
}
