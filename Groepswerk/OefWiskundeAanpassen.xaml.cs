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
    //Date: 03/05/2015

    // De ingevoerde informatie uitschrijven in oefnWiskundeGemiddeld.txt en deze gebruiken als de nieuwe waarden in de oefening.

    /// <summary>
    /// Interaction logic for OefWiskundeAanpassen.xaml
    /// </summary>
    public partial class OefWiskundeAanpassen : Page
    {
        public OefWiskundeAanpassen()
        {
            InitializeComponent();

            //lijstOefeningen = new OefeningLijstWiskunde("gemiddeld");
            //
        }
        private void AanpasKnop_Click(object sender, RoutedEventArgs e)
        {
            String [] ranges = new string[3];
            ranges[0] = ("makkelijk"+";"+ bereikMin1.Text +";"+bereikMax1.Text);
            ranges[1] = ("gemiddeld" + ";" + bereikMin2.Text + ";" + bereikMax2.Text);
            ranges[2] = ("moeilijk" + ";" + bereikMin3.Text + ";" + bereikMax3.Text);

            File.WriteAllText(@"rangesWiskunde.txt", String.Empty);
            StreamWriter writer = File.AppendText(@"rangesWiskunde.txt");
            foreach (String item in ranges)
            {
                writer.WriteLine( item );
            }
            writer.Close();
        }
    }
}
