using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Groepswerk
{
    public class AanpasbaarMenu : MenuItem
    {

        //Constructors
        public AanpasbaarMenu(string gebrType)
        {            
                maakMenu(gebrType);
        }

        //Events

        //Methods
        private void maakMenu (string type)
        {
            MenuItem menu = new MenuItem();
            MenuItem exit = new MenuItem();
            MenuItem loginscherm = new MenuItem();
            menu.Header="Menu";
            exit.Header="Stop";
            loginscherm.Header="Log uit";
            menu.Items.Add(loginscherm);
            menu.Items.Add(exit);

            this.Items.Add(menu);
           /* if (type.Equals("lln")){
                maakLlnMenu(hoofdMenu);
            }
            else if (type.Equals("lk")){
                hoofdMenu=maakLkMenu(hoofdMenu);
            }

            return hoofdMenu;*/
        }

        private Menu maakLlnMenu(Menu basis){



            return basis;
        }

        private Menu maakLkMenu(Menu basis){
            MenuItem beheerAcc = new MenuItem();
            beheerAcc.Header="AccountBeheer";
            MenuItem statis = new MenuItem();
            statis.Header="Statistieken";
            MenuItem statInd = new MenuItem();
            statInd.Header = "Individueel";
            MenuItem statKlas = new MenuItem();
            statKlas.Header = "Klassikaal";
            MenuItem opgAanp = new MenuItem();
            opgAanp.Header = "Opgaven aanpassen";
            statis.Items.Add(statInd);
            statis.Items.Add(statKlas);
            basis.Items.Add(beheerAcc);
            basis.Items.Add(statis);
            basis.Items.Add(opgAanp);

            return basis;
        }

        //Properties

    }
}
