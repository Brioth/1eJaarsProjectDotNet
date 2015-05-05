using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Groepswerk
{
    interface IBeweegbaarHoofdSpel
    {
        void Beweeg(Canvas drawingCanvas);
        void MaakVrij(Canvas drawingCanvas, string kleur);
        void CheckHit(ObservableCollection<HoofdSpelBolletje> bolletjesTegenstander, ObservableCollection<HoofdSpelVierkantje> vierkantjesTegenstander);
    }
}
