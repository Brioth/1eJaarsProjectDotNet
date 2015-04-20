using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Groepswerk
{    /* Author: Carmen Celen
     * Date: 10/04/2015
      * Inspired by: Cyber Invaders uit handboek
    */
    public class HoofdSpelLijstRood : ObservableCollection<HoofdSpelEntiteit>, INotifyPropertyChanged
    {
        private int bolletjes = 0;
        private int vierkantjes = 0;
        public void Move()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Move();
            }
        }

        public void CheckHit(HoofdSpelLijstBlauw lijstTegenstander)
        {
            if (this != null && this.Count>0)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    this[i].CheckHit(lijstTegenstander);
                }
            }

        }

        public void DisplayOn(Canvas drawingCanvas)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].DisplayOn(drawingCanvas);
            }

        }
        public int Bolletjes
        {
            get { return bolletjes; }
            set { bolletjes = value; NotifyPropertyChanged("BolletjesRood"); }
        }
        public int Vierkantjes
        {
            get { return vierkantjes; }
            set { vierkantjes = value; NotifyPropertyChanged("VierkantjesRood"); }
        }
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
