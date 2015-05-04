using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    class OefeningWiskunde //voor constructors ivm oefeningen Wiskunde
    {
        //author: Vincent Vandoninck 
        //date: 03/05/2015

        // De gelezen gegevens vanuit OefeningLijstWiskunde in constructors gebruken

        public string cijferMinBereik, cijferMaxBereik;

        public OefeningWiskunde(string cijferMinBereik, string cijferMaxBereik)
        {
            this.cijferMinBereik = cijferMinBereik;
            this.cijferMaxBereik = cijferMaxBereik;

        }
    }

}
