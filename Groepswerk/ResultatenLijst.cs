using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    class ResultatenLijst: List<Resultaat>
    {
        public ResultatenLijst(string sleutelwoord)
        {
            StreamReader bestandResultaten = File.OpenText(@"OefNederlands1MakkelijkResultaten.txt");
            string regel = bestandResultaten.ReadLine();
            char[] scheiding = { ';' };

            while (regel != null)
            {
                string[] deel = regel.Split(scheiding);

                Oefening oefeningNederlands = new Oefening(deel[0], deel[1], deel[2], deel[3], deel[4], deel[5]);
                this.Add(oefeningNederlands);
                regel = bestandResultaten.ReadLine();
            }
            bestandResultaten.Close();
        }
    }
}