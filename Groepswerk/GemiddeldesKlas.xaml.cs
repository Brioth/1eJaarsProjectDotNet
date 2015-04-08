﻿using System;
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
    /// Interaction logic for GemiddeldesKlas.xaml
    /// </summary>
    /* Author: Thomas Cox
     * Date: 5/04/2015
    */
    public partial class GemiddeldesKlas : Page
    {
        private Klaslijst lijstKlas;
        private Accountlijst lijstAccount;
        private String geselecteerdeKlas;
        private Gebruiker[] naamGemiddelde;

        public GemiddeldesKlas()
        {
            InitializeComponent();
            lijstKlas = new Klaslijst();
            selecteerKlas.ItemsSource = lijstKlas;
            selecteerKlas.SelectedIndex = 0;
        }

        private void selecteerKlas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            gemiddeldes.Text = "Naam leerling" + '\t' + "Gemiddelde Wiskunde" + '\t' + "Gemiddelde Nederlands" + '\t' + "Gemiddelde WO";
            geselecteerdeKlas = Convert.ToString(selecteerKlas.SelectedItem);
           lijstAccount = new Accountlijst(geselecteerdeKlas);
        
          for(int i=0; i<(lijstAccountCount); i++){
            string gemiddeldesText=gemiddeldes.Text;
            gemiddeldesText=gemiddeldesText+lijstAccount[i].Voornaam + " " + lijstAccount[i].Achternaam + '\t' +  lijstAccount[i].GemWisk + '\t' + lijstAccount[i].GemNed + '\t' + lijstAccount[i].GemWO;
          }
        
    }
    } //was je vergeten
}
}