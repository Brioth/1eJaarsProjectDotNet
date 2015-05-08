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
using System.Windows.Shapes;

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for WoMakkelijkAanpassen.xaml
    /// </summary>
    /// 
    public partial class WoMakkelijkAanpassen : Page
    {
        private OefeningLijst oeflijst;
        private Oefening oefening;
        private string bestand = "oefWoMakkelijk.txt";
        private string moeilijkheid = "WoMakkelijk";
        public WoMakkelijkAanpassen()
        {
            InitializeComponent();
            oeflijst = new OefeningLijst(moeilijkheid);
            lboxItemsLijst.ItemsSource = oeflijst;
            lboxItemsLijst.SelectedIndex = 0;
        }
        private void ItemsLijst_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (lboxItemsLijst.SelectedIndex != -1)
            {
                oefening = (Oefening)lboxItemsLijst.SelectedItem;
                txtbLand.Text = oefening.opgave;
                txtbHoofdstad.Text = oefening.oplossing;
            }
        }
        private void BtnNieuw_Click(object sender, RoutedEventArgs e)
        {
            if (txtbLand.Text.Equals("") || txtbHoofdstad.Text.Equals(""))
            {
                MessageBox.Show("Gelieve alle velden in te vullen");
            }
            else
            {
                Oefening nieuwItem = new Oefening(txtbLand.Text, txtbHoofdstad.Text);
                oeflijst.Add(nieuwItem);
                oeflijst.SchrijfLijst(bestand);
                UpdateLijst();
            }


        }

        private void UpdateLijst()
        {
            oeflijst = new OefeningLijst(moeilijkheid);
            lboxItemsLijst.ItemsSource = oeflijst;
            lboxItemsLijst.SelectedIndex = 0;
        }

        private void BtnPasAan_Click(object sender, RoutedEventArgs e)
        {
            if (txtbLand.Text.Equals("") || txtbHoofdstad.Text.Equals(""))
            {
                MessageBox.Show("Gelieve alle velden in te vullen");
            }
            else
            {
                Oefening aangepasteOef = new Oefening(txtbLand.Text, txtbHoofdstad.Text);
                oeflijst.Add(aangepasteOef);
                oeflijst.Remove(oefening);
                oeflijst.SchrijfLijst(bestand);
                UpdateLijst();
            }

        }
        private void BtnVerwijder_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult stoppen = MessageBox.Show("Bent u zeker dat u dit wilt verwijderen ?", "Stop", MessageBoxButton.YesNo);
            switch (stoppen)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    oeflijst.Remove(oefening);
                    oeflijst.SchrijfLijst(bestand);
                    UpdateLijst();
                    break;
                default:
                    break;

            }

        }
    }
}
