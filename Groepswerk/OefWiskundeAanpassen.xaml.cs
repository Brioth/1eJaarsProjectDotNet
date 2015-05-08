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
    //Author: Vincent Vandoninck
    //Date: 06/05/2015

    // De ingevoerde informatie uitschrijven in oefnWiskundeGemiddeld.txt en deze gebruiken als de nieuwe waarden in de oefening.
    public partial class OefWiskundeAanpassen : Page
    {
       

        public OefWiskundeAanpassen(Gebruiker actieveGebruiker)
        {
            InitializeComponent();
        }

        // De wiskunde oefeningen zijn aanpasbaar.
        // 
        private void AanpasKnop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(bereikMin1.Text) < 0 | Convert.ToInt32(bereikMin2.Text) < 0 | Convert.ToInt32(bereikMin3.Text) < 0 |
                    Convert.ToInt32(bereikMax1.Text) < 0 | Convert.ToInt32(bereikMax2.Text) < 0 | Convert.ToInt32(bereikMax3.Text) < 0)
                {
                    MessageBox.Show("Range mag niet kleiner zijn dan 0");

                }
                else
                {
                    String[] ranges = new string[3];
                    ranges[0] = ("makkelijk" + ";" + bereikMin1.Text + ";" + bereikMax1.Text);
                    ranges[1] = ("gemiddeld" + ";" + bereikMin2.Text + ";" + bereikMax2.Text);
                    ranges[2] = ("moeilijk" + ";" + bereikMin3.Text + ";" + bereikMax3.Text);

                    File.WriteAllText(@"rangesWiskunde.txt", String.Empty);
                    StreamWriter writer = File.AppendText(@"rangesWiskunde.txt");
                    foreach (String item in ranges)
                    {
                        writer.WriteLine(item);
                    }
                    writer.Close();

                    MessageBox.Show("U heeft nu de moeilijkheid van de oefeningen aangepast");
                }
            }
            // Negatieve getallen getallen en letters worden niet aanvaard.
            catch (FormatException)
            {
                MessageBox.Show("Enkel cijfers en positieve getallen gebruiken");
            }


        }
    }
}
