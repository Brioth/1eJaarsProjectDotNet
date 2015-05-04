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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Groepswerk
{
    //Author: Vincent Vandoninck
    //Date: 03/05/2015

    // De ingevoerde informatie uitschrijven in oefnWiskundeGemiddeld.txt en deze gebruiken als de nieuwe waarden in de oefening.

    /// <summary>
    /// Interaction logic for OefWiskundeAanpGemiddelde.xaml
    /// </summary>
    public partial class OefWiskundeAanpGemiddelde : Page
    {
        private int cijferBereik1Min, cijferBereik2Min, cijferBereik3Min, cijferBereik1Max, cijferBereik2Max, cijferBereik3Max;
        

        public OefWiskundeAanpGemiddelde()
        {
            InitializeComponent();

            //lijstOefeningen = new OefeningLijstWiskunde("gemiddeld");
            //
        }
        private void AanpasKnop_Click(object sender, RoutedEventArgs e)
        {
            //File.WriteAllText(@"oefnWiskundeGemiddeld.txt", String.Empty);
            //StreamWriter writer = File.AppendText(@"oefnWiskundeGemiddeld.txt");
            //foreach (Oefening oef in lijstOefeningen)
            //{

            //    writer.WriteLine(    + ";"+    );
            //}
            //writer.Close();
        }
    }
}
