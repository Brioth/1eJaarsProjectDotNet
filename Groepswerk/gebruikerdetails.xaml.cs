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
    /// <summary>
    /// Interaction logic for gebruikerdetails.xaml
    /// </summary>
    public partial class gebruikerdetails : Page
    {
        private Gebruiker actieveGebruiker;
        private List<Gebruiker> accountLijst;
        private List<String> klasLijst;
        private string selectedKlas;
        private bool leerkracht = false;

        //Constructors
        public gebruikerdetails(Gebruiker ActieveGebruiker)
        {
            // TODO: Complete member initialization
            this.ActieveGebruiker = ActieveGebruiker;
        }

       /* public void gebruikerkeuze() 
        {
            InitializeComponent();
            maakKlasLijst();
            //accountLijst.Clear();
            klasKeuze.ItemsSource = klasLijst;
            selectedKlas = Convert.ToString(klasKeuze.SelectedItem);
        }*/


  /*      private void maakAccountLijst(bool lk)
        {
            accountLijst = new List<Gebruiker>();
            StreamReader bestandAcc = File.OpenText(@"Accounts.txt");
            string regel = bestandAcc.ReadLine();
            char[] scheiding = {';'};

            while (regel != null)
            {
                string[] woorden = regel.Split(scheiding);
                for (int i = 0; i < woorden.Length; i++)
                {
                    woorden[i] = woorden[i].Trim();
                }

                Gebruiker gebruiker = new Gebruiker(woorden[0], woorden[1], woorden[2], woorden[3]);

                if (leerkracht == true && (gebruiker.Type).Equals("lk"))
                {
                    accountLijst.Add(gebruiker);
                }
                else if (leerkracht == false)
                {
                    selectedKlas = Convert.ToString(klasKeuze.SelectedItem);

                    if ((gebruiker.Klas).Equals(selectedKlas))
                    {
                        accountLijst.Add(gebruiker);
                    }
                }
                regel = bestandAcc.ReadLine();
            }
            bestandAcc.Close();
        }*/
        
      
        private void maakKlasLijst()
        {
            klasLijst = new List<String>();
            StreamReader bestandKlas = File.OpenText(@"Klassen.txt");
            string regel = bestandKlas.ReadLine();

            while (regel != null)
            {
                klasLijst.Add(regel.Trim());
                regel = bestandKlas.ReadLine();
            }
            bestandKlas.Close();
        }

/*        private String derdeWaarde(String naam,string voornaam)
        {
            // 3rde waarde van string opvragen
            StreamReader regel = File.OpenText(@"Klassen.txt");
            string derde = regel.ReadLine();

            while (regel != null)
            {
               regel = .ReadLine();
            }
            return regel;
           regel.Close();
        }*/

       private void keuzeBtn_Click(object sender, RoutedEventArgs e)
        {
        /*  leerlingId.Text= //3de locatie van textfilelezen?
                            derdeWaarde (String naambox.Text,string voornaambox.text);
          paswoordGeg.Text =
          gemWiskGeg.Text =
          gemNedGeg.Text =
          gemWoGeg.Text =
*/

        }
        
                   
        



        public gebruikerdetails()
        {
            // TODO: Complete member initialization
        }

      

        public Gebruiker ActieveGebruiker { get; set; }

        private void klasKeuze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    } 
}
