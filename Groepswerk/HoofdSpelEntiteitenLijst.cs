using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    public abstract class HoofdSpelEntiteitenLijst : List<HoofdSpelEntiteit>
    {
        public void Move()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Move();
            }
        }
        public void DisplayOn()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].DisplayOn();
            }
        }
        public abstract int Bolletjes { get; set; }
        public abstract int Vierkantjes { get; set; }

    }
}
