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
    /* --GebruikerDetails
     * Pagina om individuele statistieken op te vragen per leerling.
     * Grid Details krijgt rijen in code bij afhankelijk hoeveel er nodig zijn
     * Ook mogelijk met Datagrids
     * Aangepast op 04/05/2015 door Carmen Celen
     * Author: Vincent Vandoninck
     * Date: 21/04/2015
     */
    public partial class Gebruikerdetails : Page
    {
        //Lokale Variabelen
        private List<Gebruiker> accountLijst;
        private List<Klas> klasLijst;
        private Klas selectedKlas;
        private Gebruiker selectedGebruiker;
        private DetailsGebruiker details;
        private List<Label> labels;

        //Constructors
        public Gebruikerdetails()
        {
            InitializeComponent(); // laad u formulier
            klasLijst = new Klaslijst();
            labels = new List<Label>();
            klasKeuze.ItemsSource = klasLijst;
            // de bron van deze box is de lijst
            klasKeuze.SelectedIndex = 0;
        }

        //Events
        private void klasKeuze_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (accountLijst != null)
            {
                accountLijst = null;
            }

            selectedKlas = (Klas)klasKeuze.SelectedItem;
            accountLijst = new Accountlijst(selectedKlas);

            boxLln.ItemsSource = accountLijst;
            // elke student in de lijst is nu zchtbaar want de hele lijst is de source
            boxLln.SelectedIndex = 0;
            // om het netjes te houden begin je bij de eerste al als geselecteerde waarde
        }
        private void boxLln_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (boxLln.SelectedIndex != -1)
            {
                selectedGebruiker = (Gebruiker)boxLln.SelectedItem;
                details = new DetailsGebruiker(selectedGebruiker.Id, selectedGebruiker.ToString());
                VulAlgemeenGemiddeldes();
                boxOef.SelectedIndex = -1; //Als die al op 0 stond veranderd hij niet en gaat hij niet naar boxOef_SelectionChanged
                boxOef.SelectedIndex = 0;
            }
        }

        // Methods
        private void VulAlgemeenGemiddeldes()
        {
            double tekst;

            tekst = Math.Round(details.GemNedMak[0] / Convert.ToDouble(details.GemNedMak[2]), 2);
            if (double.IsNaN(tekst))
            {
                tekst = 0;
            }
            lblNedMak.Content = tekst;
            tekst = Math.Round(details.GemNedMed[0] / Convert.ToDouble(details.GemNedMed[2]), 2);
            if (double.IsNaN(tekst))
            {
                tekst = 0;
            }
            lblNedMed.Content = tekst;
            tekst = Math.Round(details.GemNedMoe[0] / Convert.ToDouble(details.GemNedMoe[2]), 2);
            if (double.IsNaN(tekst))
            {
                tekst = 0;
            }
            lblNedMoe.Content = tekst;
            tekst = Math.Round(details.GemWiskMak[0] / Convert.ToDouble(details.GemWiskMak[2]), 2);
            if (double.IsNaN(tekst))
            {
                tekst = 0;
            }
            lblWiskMak.Content = tekst;
            tekst = Math.Round(details.GemWiskMed[0] / Convert.ToDouble(details.GemWiskMed[2]), 2);
            if (double.IsNaN(tekst))
            {
                tekst = 0;
            }
            lblWiskMed.Content = tekst;
            tekst = Math.Round(details.GemWiskMoe[0] / Convert.ToDouble(details.GemWiskMoe[2]), 2);
            if (double.IsNaN(tekst))
            {
                tekst = 0;
            }
            lblWiskMoe.Content = tekst;
            tekst = Math.Round(details.GemWoMak[0] / Convert.ToDouble(details.GemWoMak[2]), 2);
            if (double.IsNaN(tekst))
            {
                tekst = 0;
            }
            lblWoMak.Content = tekst;
            tekst = Math.Round(details.GemWoMed[0] / Convert.ToDouble(details.GemWoMed[2]), 2);
            if (double.IsNaN(tekst))
            {
                tekst = 0;
            }
            lblWoMed.Content = tekst;
            tekst = Math.Round(details.GemWoMoe[0] / Convert.ToDouble(details.GemWoMoe[2]), 2);
            if (double.IsNaN(tekst))
            {
                tekst = 0;
            }
            lblWoMoe.Content = tekst;
        }
        private void boxOef_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Resultaat> detailLijst = new List<Resultaat>();
            int aantal = 0;
            double gemPunten = 0, gemTijd = 0;

            switch (boxOef.SelectedIndex)
            {
                case 0:
                    detailLijst = details.ResultatenNedMak;
                    aantal = details.GemNedMak[2];
                    gemPunten = Math.Round(details.GemNedMak[0] / Convert.ToDouble(details.GemNedMak[2]), 2);
                    gemTijd = Math.Round(details.GemNedMak[1] / Convert.ToDouble(details.GemNedMak[2]), 2);
                    break;
                case 1:
                    detailLijst = details.ResultatenNedMed;
                    aantal = details.GemNedMed[2];
                    gemPunten = Math.Round(details.GemNedMed[0] / Convert.ToDouble(details.GemNedMed[2]), 2);
                    gemTijd = Math.Round(details.GemNedMed[1] / Convert.ToDouble(details.GemNedMed[2]), 2);
                    break;
                case 2:
                    detailLijst = details.ResultatenNedMoe;
                    aantal = details.GemNedMoe[2];
                    gemPunten = Math.Round(details.GemNedMoe[0] / Convert.ToDouble(details.GemNedMoe[2]), 2);
                    gemTijd = Math.Round(details.GemNedMoe[1] / Convert.ToDouble(details.GemNedMoe[2]), 2);
                    break;
                case 3:
                    detailLijst = details.ResultatenWiskMak;
                    aantal = details.GemWiskMak[2];
                    gemPunten = Math.Round(details.GemWiskMak[0] / Convert.ToDouble(details.GemWiskMak[2]), 2);
                    gemTijd = Math.Round(details.GemWiskMak[1] / Convert.ToDouble(details.GemWiskMak[2]), 2);
                    break;
                case 4:
                    detailLijst = details.ResultatenWiskMed;
                    aantal = details.GemWiskMed[2];
                    gemPunten = Math.Round(details.GemWiskMed[0] / Convert.ToDouble(details.GemWiskMed[2]), 2);
                    gemTijd = Math.Round(details.GemWiskMed[1] / Convert.ToDouble(details.GemWiskMed[2]), 2); ;
                    break;
                case 5:
                    detailLijst = details.ResultatenWiskMoe;
                    aantal = details.GemWiskMoe[2];
                    gemPunten = Math.Round(details.GemWiskMoe[0] / Convert.ToDouble(details.GemWiskMoe[2]), 2);
                    gemTijd = Math.Round(details.GemWiskMoe[1] / Convert.ToDouble(details.GemWiskMoe[2]), 2); ;
                    break;
                case 6:
                    detailLijst = details.ResultatenWoMak;
                    aantal = details.GemWoMak[2];
                    gemPunten = Math.Round(details.GemWoMak[0] / Convert.ToDouble(details.GemWoMak[2]), 2);
                    gemTijd = Math.Round(details.GemWoMak[1] / Convert.ToDouble(details.GemWoMak[2]), 2);
                    break;
                case 7:
                    detailLijst = details.ResultatenWoMed;
                    aantal = details.GemWoMed[2];
                    gemPunten = Math.Round(details.GemWoMed[0] / Convert.ToDouble(details.GemWoMed[2]), 2);
                    gemTijd = Math.Round(details.GemWoMed[1] / Convert.ToDouble(details.GemWoMed[2]), 2);
                    break;
                case 8:
                    detailLijst = details.ResultatenWoMoe;
                    aantal = details.GemWoMoe[2];
                    gemPunten = Math.Round(details.GemWoMoe[0] / Convert.ToDouble(details.GemWoMoe[2]), 2);
                    gemTijd = Math.Round(details.GemWoMoe[1] / Convert.ToDouble(details.GemWoMoe[2]), 2);
                    break;
            }

            if (double.IsNaN(gemPunten))
            {
                gemPunten = 0;
            }
            if (double.IsNaN(gemTijd))
            {
                gemTijd = 0;
            }

            lblAantal.Content = aantal;
            lblGem.Content = gemPunten + "/10";
            lblTijd.Content = gemTijd;

            MaakGrid(detailLijst);


            for (int i = 0; i < detailLijst.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Label lbl = new Label();
                    lbl.Margin = new Thickness(20, 10, 20, 10);
                    switch (j)
                    {
                        case 0:
                            lbl.Content = detailLijst[i].Datum;
                            break;
                        case 1:
                            lbl.Content = detailLijst[i].AantalOefeningen;
                            break;
                        case 2:
                            lbl.Content = detailLijst[i].TotaalPunten;
                            break;
                        case 3:
                            lbl.Content = detailLijst[i].GespendeerdeTijd;
                            break;
                    }
                    Grid.SetColumn(lbl, j);
                    Grid.SetRow(lbl, i + 1);
                    detailGrid.Children.Add(lbl);
                    labels.Add(lbl);

                }
            }
        }
        private void MaakGrid(List<Resultaat> lijst)
        {
            foreach (Label item in labels)
            {
                detailGrid.Children.Remove(item);
            }
            labels.Clear();
            if (detailGrid.RowDefinitions.Count > 1)
            {
                detailGrid.RowDefinitions.RemoveRange(1, detailGrid.RowDefinitions.Count - 1);
            }
            foreach (Resultaat item in lijst)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                detailGrid.RowDefinitions.Add(row);
            }
        }

        //properties
    }
}
