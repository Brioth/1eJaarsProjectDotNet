using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Groepswerk
{
    interface IBeweegbaarZombie
    {
        void Beweeg(Canvas drawingCanvas);
        void MaakVrij(Canvas drawingCanvas);
        void CheckHit(List<ZombieSpelHuman> humansTegenstander, List<ZombieSpelZombie> zombiesTegenstander);
    }
}
