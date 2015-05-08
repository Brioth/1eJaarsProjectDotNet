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
    //aangepast op 8/05/2015 door Carmen Celen

    // De ingevoerde informatie uitschrijven in oefnWiskundeGemiddeld.txt en deze gebruiken als de nieuwe waarden in de oefening.
    public partial class OefWiskundeAanpassen : Page
    {
        private string[,] rangesMulti = new string[3,2];

        public OefWiskundeAanpassen(Gebruiker actieveGebruiker)
        {
            InitializeComponent();
            VulOrgineleWaarden();
        }

        private void VulOrgineleWaarden()
        {
            //Lees waarden uit file
            StreamReader lezer = File.OpenText(@"rangesWiskunde.txt");
            string regel = lezer.ReadLine();
            char[] scheiding = { ';' };


            int i = 0;
            while (regel != null)
            {
                string[] woorden = regel.Split(scheiding);
                for (int j = 0; j < woorden.Length; j++)
                {
                    woorden[j] = woorden[j].Trim();

                }

                rangesMulti[i,0] = woorden[1];
                rangesMulti[i,1] = woorden[2];

                i++;

                regel = lezer.ReadLine();
            }
            lezer.Close();


            //Vul vakjes in
            bereikMin1.Text = rangesMulti[0, 0];
            bereikMax1.Text = rangesMulti[0, 1];
            bereikMin2.Text = rangesMulti[1, 0];
            bereikMax2.Text = rangesMulti[1, 1];
            bereikMin3.Text = rangesMulti[2, 0];
            bereikMax3.Text = rangesMulti[2, 1];
        }

        // De wiskunde oefeningen zijn aanpasbaar.
        // 
        private void AanpasKnop_Click(object sender, RoutedEventArgs e)
        {
            if (bereikMin1.Text.Equals("") || bereikMax1.Text.Equals("") || bereikMin2.Text.Equals("") || bereikMax2.Text.Equals("") || bereikMin3.Text.Equals("") || bereikMax3.Text.Equals(""))
            {
                MessageBox.Show("Gelieve alle vakjes in te vullen");
            }
            else
            {
                try
                {

                    if (!(Convert.ToInt32(bereikMin1.Text) > Convert.ToInt32(bereikMax1.Text) || Convert.ToInt32(bereikMin2.Text) > Convert.ToInt32(bereikMax2.Text) || Convert.ToInt32(bereikMin3.Text) > Convert.ToInt32(bereikMax3.Text)))
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
                    else
                    {
                        MessageBox.Show("minimum mag niet groter zijn dan maximum");
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
}
