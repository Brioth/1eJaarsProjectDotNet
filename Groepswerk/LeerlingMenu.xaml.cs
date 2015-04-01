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

        private MenuItem aangepastMenu;
        //Constructors

        public LeerlingMenu(Gebruiker actievegebruiker)
        {
            InitializeComponent();
            ActieveGebruiker = actievegebruiker;
            aangepastMenu = new AanpasbaarMenu(ActieveGebruiker.Type);
        }

        //Events

        //Methods

        //Properties

        public Gebruiker ActieveGebruiker { get; set; }
        public MenuItem AangepastMenu
        {
            get { return aangepastMenu; }
        }
    }
}
