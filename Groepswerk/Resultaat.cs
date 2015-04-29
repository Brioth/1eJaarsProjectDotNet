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
        public List<int> punten { get; set; }
        public Resultaat(string id, double gespendeerdeTijd, DateTime datum, int punt)
        {
            this.id = id;
            this.gespendeerdeTijd = gespendeerdeTijd;
            this.datum = datum;
            punten.Add(punt);
        }

        public Resultaat(int punt)
        {
            punten.Add(punt);
        }
    }
}
