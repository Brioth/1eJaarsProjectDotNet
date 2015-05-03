using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    class Resultaat
    {
        public string id { get; set; }
        public double gespendeerdeTijd { get; set; }
        public DateTime datum { get; set; }
        public int punten { get; set; }
        public Resultaat(string id, DateTime datum, int punt, double gespendeerdeTijd)
        {
            this.id = id;
            this.gespendeerdeTijd = gespendeerdeTijd;
            this.datum = datum;
            punten=punten+punt;
        }

        public Resultaat(int punt, double gespendeerdeTijd)
        {
            punten=punten+punt;
            this.gespendeerdeTijd = this.gespendeerdeTijd + gespendeerdeTijd;
        }
    }
}
