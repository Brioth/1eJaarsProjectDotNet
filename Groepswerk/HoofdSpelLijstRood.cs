using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{    /* Author: Carmen Celen
     * Date: 10/04/2015
      * Inspired by: Cyber Invaders uit handboek
    */
    public class HoofdSpelLijstRood : List<HoofdSpelEntiteit>
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
