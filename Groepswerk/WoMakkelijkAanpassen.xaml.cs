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
        private OefeningLijst Oeflijst;
        private Oefening Oefening;
        private string bestand = "oefWoMakkelijk.txt";
        public WoMakkelijkAanpassen()
        {
            InitializeComponent();
            Oeflijst = new OefeningLijst("WoMakkelijk");
            lboxItemsLijst.ItemsSource = Oeflijst;
            lboxItemsLijst.SelectedIndex = 0;
        }
        private void ItemsLijst_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (lboxItemsLijst.SelectedIndex != -1)
            {
                Oefening = (Oefening)lboxItemsLijst.SelectedItem;
                txtbLand.Text = Oefening.opgave;
                txtbHoofdstad.Text = Oefening.oplossing;
            }
        }
        private void BtnNieuw_Click(object sender, RoutedEventArgs e)
        {
            Oefening nieuwItem = new Oefening(txtbLand.Text, txtbHoofdstad.Text);
            Oeflijst.Add(nieuwItem);
            Oeflijst.SchrijfLijst(bestand);
            UpdateLijst();


        }

        private void UpdateLijst()
        {
            Oeflijst = new OefeningLijst("WoMakkelijk");
            lboxItemsLijst.ItemsSource = Oeflijst;
            lboxItemsLijst.SelectedIndex = 0;
        }

        private void BtnPasAan_Click(object sender, RoutedEventArgs e)
        {

            Oefening aangepasteOef = new Oefening(txtbLand.Text, txtbHoofdstad.Text);
            Oeflijst.Add(aangepasteOef);
            Oeflijst.Remove(Oefening);
            Oeflijst.SchrijfLijst(bestand);
            UpdateLijst();


        }
        private void BtnVerwijder_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult stoppen = MessageBox.Show("Bent u zeker dat u dit wilt verwijderen ?", "Stop", MessageBoxButton.YesNo);
            switch (stoppen)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    Oeflijst.Remove(Oefening);
                    Oeflijst.SchrijfLijst(bestand);
                    UpdateLijst();
                    break;
                default:
                    break;

            }

        }
    }
}
