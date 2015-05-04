using System;
using System.Collections.Generic;
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
        void CheckHit(List<HoofdSpelBolletje> bolletjesTegenstander, List<HoofdSpelVierkantje> vierkantjesTegenstander);
    }
}
