using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Groepswerk
{
    /* --IBeweegbaarZombies--
     * Verplichte interface
     * Author: Carmen Celen
     * Date: 25/04/2015
     */
    interface IBeweegbaarZombie
    {
        //Methods
        void Beweeg(Canvas drawingCanvas);
        void MaakVrij(Canvas drawingCanvas);
        void CheckHit(ObservableCollection<ZombieSpelHuman> humansTegenstander, ObservableCollection<ZombieSpelZombie> zombiesTegenstander);
    }
}
