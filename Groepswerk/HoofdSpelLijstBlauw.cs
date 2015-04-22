﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Groepswerk
{
    public class HoofdSpelLijstBlauw : HoofdSpelEntiteitenLijst, INotifyPropertyChanged
    {
        private int bolletjes = 0;
        private int vierkantjes = 0;

        public void CheckHit(HoofdSpelLijstRood lijstTegenstander)
        {
            if (this!=null&& this.Count>0)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    this[i].CheckHit(lijstTegenstander);
                }
            }

        }

        public override int Bolletjes
        {
            get { return bolletjes; }
            set { bolletjes = value; OnPropertyChanged("Bolletjes"); }
        }
        public override int Vierkantjes
        {
            get { return vierkantjes; }
            set { vierkantjes = value; OnPropertyChanged("Vierkantjes"); }
        }
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
