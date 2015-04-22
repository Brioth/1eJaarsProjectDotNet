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
    /// <summary>
    /// Interaction logic for oefWoGemiddeld.xaml
    /// </summary>
    public partial class oefWoGemiddeld : Window
    {
       private wo lijstOefeningen;
        private string[] tempOpgave, tempOplossing1, tempOplossing2, tempOplossing3;
        private Random oefeningenNummer = new Random();
        private int oefeningenNummerOpslag;
        private IList<string> oefLijst;
        private int oefCorrect = 0;
        private IList<int> oefeningNummerLijst;
        public oefWoGemiddeld()
        {
            InitializeComponent();
            lijstOefeningen = new wo("gemiddeld");
        }

        private void controleer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
