using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Groepswerk
{
    /* --IBeweegbaarZombie--
     * Verplichte interface voor spel
     * Geen idee wat men bedoelde met MaakVrij, hier geïmplementeerd als "verander pion of delete"
     * Author: Carmen Celen
     * Date: 04/05/2015
     */
    interface IBeweegbaarHoofdSpel
    {
        //Methods
        void Beweeg(Canvas drawingCanvas);
        void MaakVrij(Canvas drawingCanvas, string kleur);
        void CheckHit(ObservableCollection<HoofdSpelBolletje> bolletjesTegenstander, ObservableCollection<HoofdSpelVierkantje> vierkantjesTegenstander);
    }
}
