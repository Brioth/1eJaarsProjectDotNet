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
        private Accountlijst lijstAccount;
        private Klas geselecteerdeKlas;


        public GemiddeldesKlas()
        {
            InitializeComponent();
            lijstKlas = new Klaslijst();
            selecteerKlas.ItemsSource = lijstKlas;
            selecteerKlas.SelectedIndex = 0;
        }

        private void selecteerKlas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string gemiddeldesText = gemiddeldes.Text;
            gemiddeldes.Text = "Naam leerling" + '\t' + "Gemiddelde Wiskunde" + '\t' + "Gemiddelde Nederlands" + '\t' + "Gemiddelde WO";
            geselecteerdeKlas = (Klas)selecteerKlas.SelectedItem;
            lijstAccount = new Accountlijst(geselecteerdeKlas);

            for (int i = 0; i < (lijstAccount.Count); i++)
            {
                gemiddeldesText = gemiddeldes.Text;
                //gemiddeldesText = gemiddeldesText + '\n' + lijstAccount[i].Voornaam + " " + lijstAccount[i].Achternaam + '\t' + '\t' + lijstAccount[i].GemWisk + '\t' + '\t' + '\t' + lijstAccount[i].GemNed + '\t' + '\t' + '\t' + lijstAccount[i].GemWO;
                gemiddeldes.Text = gemiddeldesText;
            }
            
        }
        private void BerekenGemiddeldeNed(int id)
        {
            int[] nedMak = BerekenGemiddelde(id, "blabla");
            int[] nedGem = BerekenGemiddelde(id, "blabla");
            int[] nedMoe = BerekenGemiddelde(id, "blabla");
        }
        private void BerekenGemiddeldeWisk(int id)
        {
            int[] wiskMak = BerekenGemiddelde(id, "blabla");
            int[] wiskGem = BerekenGemiddelde(id, "blabla");
            int[] wiskMoe = BerekenGemiddelde(id, "blabla");
        }
        private void BerekenGemiddeldeWO(int id)
        {
            int[] woMak = BerekenGemiddelde(id, "blabla");
            int[] woGem = BerekenGemiddelde(id, "blabla");
            int[] woMoe = BerekenGemiddelde(id, "blabla");
        }
        private int[] BerekenGemiddelde(int id, string bestand)
        {
            ResultatenLijst lijst = new ResultatenLijst(bestand);
            int totaalPunten = 0;
            int totaalSeconden = 0;
            int totaalOefeningen = 0;
            foreach (Resultaat item in lijst)
            {
                if (item.Id == id)
                {
                    totaalPunten = totaalPunten + item.TotaalPunten;
                    totaalSeconden = totaalSeconden + item.GespendeerdeTijd;
                    totaalOefeningen = totaalOefeningen + item.TotaalPunten;
                }
            }
            int[] berekeningen = {totaalPunten, totaalOefeningen, totaalSeconden};
            return berekeningen;
        }
    } 
}
