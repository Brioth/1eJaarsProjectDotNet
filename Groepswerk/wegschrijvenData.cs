using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    class wegschrijvenData
    {
        //author: Thomas Cox
        //
        public wegschrijvenData(string sleutelwoord, string nieuwId, double nieuwGespendeerdeTijd, DateTime nieuwDatum, int nieuwPunten)
        {
            switch(sleutelwoord){
                case "oefNederlandsMakkelijk":
                    StreamReader oefNederlandsMakkelijkResultaten = File.OpenText(@"OefNederlands1MakkelijkResultaten.txt");
                    string regel = oefNederlandsMakkelijkResultaten.ReadLine();
                    char[] scheiding = { ';' };

                    while (regel != null)
                    {

                    }
                    break;
                case "oefNederlandsGemiddeld":
                    StreamReader oefNederlandsGemiddeldResultaten = File.OpenText(@"OefNederlands1GemiddeldResultaten.txt");
                    break;
                case "oefNederlandsMoeilijk":
                    StreamReader OefNederlandsMoeilijkResultaten = File.OpenText(@"OefNederlands1MoeilijkResultaten.txt");
                    break;
                    //Voeg uw eigen cases toe aub
        }

    }
    }
}