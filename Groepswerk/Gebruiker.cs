using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    public class Gebruiker //Gebruikers staan in formaat: type(lln of lk);klas;ID;voornaam;achternaam;psw;gemWisk;gemNed;gemWO;tijdVoorSpelInSec
    {
        //Constructors
        public Gebruiker(string type, string klas, int id, string voornaam, string achternaam, string psw, int gemWisk, int gemNed, int gemWO, int gameTijdSec)
        {
            Voornaam = voornaam;
            Id = id;
            Achternaam = achternaam;
            Klas = klas;
            Type = type;
            Psw = psw;
            GemNed = gemNed;
            GemWisk = gemWisk;
            GemWO = gemWO;
            GameTijdSec = gameTijdSec;
        }

     /*   public Gebruiker(Gebruiker oudeGebruiker)             --> copy constructor nodig?
        {
            Naam = oudeGebruiker.Naam;
            Klas = oudeGebruiker.Klas;
            Type = oudeGebruiker.Type;
            Psw = oudeGebruiker.Psw;
        }*/                     

        //Events

        //Methods

        public override string ToString()
        {
            return Voornaam+" "+Achternaam;
        }

        //Properties
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Klas { get; set; }
        public string Type { get; set; }
        public string Psw { get; set; }
        public int GemWisk { get; set; }
        public int GemNed { get; set; }
        public int GemWO { get; set; }
        public int GameTijdSec { get; set; }
    }
}