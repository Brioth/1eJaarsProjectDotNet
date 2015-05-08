using Groepswerk.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Groepswerk
{
    /* --AccountBeheer--
     * Gebruiker aanpassen of verwijderen
     * Hier textbox ipv passwordbox want tekens moeten weergegeven worden
     * Author: Carmen Celen
     * Date: 01/04/2015
     */
    public partial class AccountBeheer : Page
    {
        //Lokale variabelen
        private Klaslijst klasLijst;
        private Accountlijst accountlijst;
        private Klas selectedKlas;
        private Gebruiker selectedGebruiker;
        private AlleGebruikersLijst alleGebruikersLijst;

        //Constructors
        public AccountBeheer()
        {
            InitializeComponent();
            klasLijst = new Klaslijst();
            boxKlas.ItemsSource = klasLijst;
            boxNieuweKlas.ItemsSource = klasLijst;
            boxKlas.SelectedIndex = 0;
        }

        //Events
        private void BoxKlas_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (accountlijst != null)
            {
                accountlijst.Clear();
            }

            txtboxAchternaam.Text = "";
            txtbVoornaam.Text = "";
            pswBox.Text = "";
            boxNieuweKlas.SelectedIndex = boxKlas.SelectedIndex;

            selectedKlas = (Klas)boxKlas.SelectedItem;
            accountlijst = new Accountlijst(selectedKlas);
            boxAccounts.ItemsSource = accountlijst;
            boxAccounts.SelectedIndex = 0;

        }
        private void BoxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)//Vincent
        {
            if (boxAccounts.SelectedIndex != -1)
            {
                selectedGebruiker = (Gebruiker)boxAccounts.SelectedItem;
                txtbVoornaam.Text = selectedGebruiker.Voornaam;
                txtboxAchternaam.Text = selectedGebruiker.Achternaam;
                pswBox.Text = selectedGebruiker.Psw;
                boxNieuweKlas.SelectedIndex = boxKlas.SelectedIndex;
            }
        }
        private void BtnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult verwijderen = MessageBox.Show(String.Format("Ben je zeker dat je {0} wilt verwijderen?", selectedGebruiker), "Delete", MessageBoxButton.YesNo);
            switch (verwijderen)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    VerwijderGebruiker();
                    MessageBox.Show(string.Format("U hebt gebruiker {0} verwijderd", selectedGebruiker));
                    UpdateListbox();
                    boxKlas.SelectedItem = selectedKlas;
                    break;
                default:
                    break;
            }
        }
        private void BtnPasAan_Click(object sender, RoutedEventArgs e)
        {
            if (txtbVoornaam.Text.Equals("") || txtboxAchternaam.Text.Equals("") || pswBox.Text.Equals("") || boxNieuweKlas.SelectedIndex == -1)
            {
                MessageBox.Show("Gelieve alle velden in te vullen");
            }
            else
            {
                selectedGebruiker.Voornaam = txtbVoornaam.Text;
                selectedGebruiker.Achternaam = txtboxAchternaam.Text;
                selectedGebruiker.Psw = pswBox.Text;
                selectedGebruiker.Klas = (Klas)boxNieuweKlas.SelectedItem;
                WisselGebruiker();
                MessageBox.Show(String.Format("U hebt gebruiker {0} aangepast", selectedGebruiker));
                UpdateListbox();
            }
        }

        //Methods
        private void VerwijderGebruiker()
        {
            alleGebruikersLijst = new AlleGebruikersLijst();

            ResultatenLijst lijstNedMak = new ResultatenLijst("OefNederlands1MakkelijkResultaten.txt");
            List<Resultaat> dummieNedMak = new List<Resultaat>();
            ResultatenLijst lijstNedMed = new ResultatenLijst("OefNederlands1GemiddeldResultaten.txt");
            List<Resultaat> dummieNedMed = new List<Resultaat>();
            ResultatenLijst lijstNedMoe = new ResultatenLijst("OefNederlands1MoeilijkResultaten.txt");
            List<Resultaat> dummieNedMoe = new List<Resultaat>();
            ResultatenLijst lijstWiskMak = new ResultatenLijst("OefResultatenWiskMak.txt");
            List<Resultaat> dummieWiskMak = new List<Resultaat>();
            ResultatenLijst lijstWiskMed = new ResultatenLijst("OefResultatenWiskGem.txt");
            List<Resultaat> dummieWiskMed = new List<Resultaat>();
            ResultatenLijst lijstWiskMoe = new ResultatenLijst("OefResultatenWiskMoe.txt");
            List<Resultaat> dummieWiskMoe = new List<Resultaat>();
            ResultatenLijst lijstWoMak = new ResultatenLijst("resultaatWoMakkelijk.txt");
            List<Resultaat> dummieWoMak = new List<Resultaat>();
            ResultatenLijst lijstWoMed = new ResultatenLijst("resultaatWoGemiddeld.txt");
            List<Resultaat> dummieWoMed = new List<Resultaat>();
            ResultatenLijst lijstWoMoe = new ResultatenLijst("resultaatWoMoeilijk.txt");
            List<Resultaat> dummieWoMoe = new List<Resultaat>();

            //Verwijder resultaten
            foreach (Resultaat item in lijstNedMak)
            {
                if (!(item.Id.Equals(selectedGebruiker.Id)))
                {
                    dummieNedMak.Add(item);
                }
            }
            foreach (Resultaat item in lijstNedMed)
            {
                if (!(item.Id.Equals(selectedGebruiker.Id)))
                {
                    dummieNedMed.Add(item);
                }
            }
            foreach (Resultaat item in lijstNedMoe)
            {
                if (!(item.Id.Equals(selectedGebruiker.Id)))
                {
                    dummieNedMoe.Add(item);
                }
            }
            foreach (Resultaat item in lijstWiskMak)
            {
                if (!(item.Id.Equals(selectedGebruiker.Id)))
                {
                    dummieWiskMak.Add(item);
                }
            }
            foreach (Resultaat item in lijstWiskMed)
            {
                if (!(item.Id.Equals(selectedGebruiker.Id)))
                {
                    dummieWiskMed.Add(item);
                }
            }
            foreach (Resultaat item in lijstWiskMoe)
            {
                if (!(item.Id.Equals(selectedGebruiker.Id)))
                {
                    dummieWiskMoe.Add(item);
                }
            }
            foreach (Resultaat item in lijstWoMak)
            {
                if (!(item.Id.Equals(selectedGebruiker.Id)))
                {
                    dummieWoMak.Add(item);
                }
            }
            foreach (Resultaat item in lijstWoMed)
            {
                if (!(item.Id.Equals(selectedGebruiker.Id)))
                {
                    dummieWoMed.Add(item);
                }
            }
            foreach (Resultaat item in lijstWoMoe)
            {
                if (!(item.Id.Equals(selectedGebruiker.Id)))
                {
                    dummieWoMoe.Add(item);
                }
            }

            ResultatenLijst nieuwNedMak = new ResultatenLijst(dummieNedMak);
            nieuwNedMak.SchrijfLijst("OefNederlands1MakkelijkResultaten.txt");

            ResultatenLijst nieuwNedMed = new ResultatenLijst(dummieNedMed);
            nieuwNedMed.SchrijfLijst("OefNederlands1GemiddeldResultaten.txt");

            ResultatenLijst nieuwNedMoe = new ResultatenLijst(dummieNedMoe);
            nieuwNedMoe.SchrijfLijst("OefNederlands1MoeilijkResultaten.txt");

            ResultatenLijst nieuwWiskMak = new ResultatenLijst(dummieWiskMak);
            nieuwWiskMak.SchrijfLijst("OefResultatenWiskMak.txt");

            ResultatenLijst nieuwWiskMed = new ResultatenLijst(dummieWiskMed);
            nieuwNedMed.SchrijfLijst("OefResultatenWiskMed.txt");

            ResultatenLijst nieuwWiskMoe = new ResultatenLijst(dummieWiskMoe);
            nieuwNedMoe.SchrijfLijst("OefResultatenWiskMoe.txt");

            ResultatenLijst nieuwWoMak = new ResultatenLijst(dummieWoMak);
            nieuwWoMak.SchrijfLijst("resultaatWoMakkelijk.txt");

            ResultatenLijst nieuwWoMed = new ResultatenLijst(dummieWoMak);
            nieuwWoMed.SchrijfLijst("resultaatWoGemiddeld.txt");

            ResultatenLijst nieuwWoMoe = new ResultatenLijst(dummieWoMoe);
            nieuwWoMoe.SchrijfLijst("resultaatWoMoeilijk.txt");

            //Verwijder uit alleGebruikerslijst
            for (int i = 0; i < alleGebruikersLijst.Count; i++)
            {
                if (alleGebruikersLijst[i].Id == selectedGebruiker.Id)
                {
                    alleGebruikersLijst.RemoveAt(i);
                }
            }
            alleGebruikersLijst.SchrijfLijst();
        }
        private void WisselGebruiker()
        {
            alleGebruikersLijst = new AlleGebruikersLijst();
            for (int i = 0; i < alleGebruikersLijst.Count; i++)
            {
                if (alleGebruikersLijst[i].Id == selectedGebruiker.Id)
                {
                    alleGebruikersLijst[i] = selectedGebruiker;
                }
            }
            alleGebruikersLijst.SchrijfLijst();
        }
        private void UpdateListbox()
        {
            accountlijst = new Accountlijst(selectedKlas);
            boxAccounts.ItemsSource = accountlijst;
            boxAccounts.SelectedIndex = 0;
        }

        //Properties
    }
}
