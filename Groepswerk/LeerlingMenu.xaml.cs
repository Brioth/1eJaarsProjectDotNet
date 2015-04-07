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
    /// <summary>
    /// Interaction logic for LeerlingMenu.xaml
    /// </summary>
    public partial class LeerlingMenu : Page
    {
        //Constructors

        public LeerlingMenu(Gebruiker actievegebruiker)
        {
            InitializeComponent();
            ActieveGebruiker = actievegebruiker;
            lblBegroeting.Content = String.Format("Dag {0}", ActieveGebruiker.Voornaam);
            checkButton();
        }

        //Events

        //Methods

        private void checkButton() //check of gebruiker afgelopen week alles 1 maal gespeeld heeft
        {
            if (true)
            {
                //zet button aan
            }
            else
            {
                //zet button disabled
            }
        }

        //Properties

        public Gebruiker ActieveGebruiker { get; set; }
    }
}
