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
    /// Author: Thomas Cox
    /// Date: 14/04/2015
    public partial class OefNederlands : Page
    {
        private Boolean makkelijkFlag { get; set; }
        private Boolean gemiddeldFlag { get; set; }
        private Boolean moeilijkFlag { get; set; }
        public OefNederlands()
        {
            InitializeComponent();
            makkelijkFlag = false;
            gemiddeldFlag = false;
            moeilijkFlag = false;
        }

        private void Gemakkelijk_Click(object sender, RoutedEventArgs e)
        {
            makkelijkFlag = true;
            //navigation naar oefeningNederlands1
        }

        private void Gemiddeld_Click(object sender, RoutedEventArgs e)
        {
            gemiddeldFlag = true;
            //navigation naar oefeningNederlands1
        }

        private void Moeilijk_Click(object sender, RoutedEventArgs e)
        {
            moeilijkFlag = true;
            //navigation naar oefeningNederlands1
        }

        private void TerugKnop_Click(object sender, RoutedEventArgs e)
        {
            //navigation naar hoofdmenu
        }

    }
}
