using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    public class HoofdSpelLijstBlauw : List<HoofdSpelEntiteit>
    {
        public void Move()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Move(this);
            }
        }

        public void CheckHit()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].CheckHit();
            }
        }

    }
}
