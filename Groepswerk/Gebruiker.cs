using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    public class Gebruiker
    {
        //Constructors
        public Gebruiker(string type, string klas, string naam, string psw)//al de andere gegevens komen erbij
        {
            Naam = naam;
            Klas = klas;
            Type = type;
            Psw = psw;
        }

        public Gebruiker(Gebruiker oudeGebruiker)
        {
            Naam = oudeGebruiker.Naam;
            Klas = oudeGebruiker.Klas;
            Type = oudeGebruiker.Type;
            Psw = oudeGebruiker.Psw;
        }
        //Events
        //Methods

        public override string ToString()
        {
            return Naam;
        }

        //Properties
        public string Naam { get; set; }
        public string Klas { get; set; }
        public string Type { get; set; }
        public string Psw { get; set; }

    }
}