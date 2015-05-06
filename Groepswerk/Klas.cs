using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    /* --Klas--
     * Om klassen te behandelen, met property naam en flag voor zombiespel
     * Author: Carmen Celen
     * Date: 02/05/2015
     */
    public class Klas
    {
        //Lokale variabelen

        //Constructors
        public Klas(String naam, bool zombie = false)
        {
            Naam = naam;
            Zombie = zombie;
        }

        //Events

        //Methods
        public String SchrijfString()
        {
            return (Naam + ";" + Zombie);
        }

        //Properties
        public String Naam { get; set; }
        public bool Zombie { get; set; }
        public override string ToString()
        {
            return Naam;
        }
    }
}
