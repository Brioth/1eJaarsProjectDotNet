using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public void CheckHit(HoofdSpelLijstRood lijstTegenstander)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].CheckHit(lijstTegenstander);
            }
        }
        public void DisplayOn(Canvas drawingCanvas)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].DisplayOn(drawingCanvas);
            }
        }

    }
}
