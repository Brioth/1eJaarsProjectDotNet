using Groepswerk.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    /* --Gebruiker--
     * Klasse Gebruiker om makkelijk om te gaan met de gegevens van diverse lln en lk
     * Formaat Accounts: type(lln of lk);klas;ID;voornaam;achternaam;psw;gemWisk;gemNed;gemWO;tijdVoorSpelInSec
     * Author: Carmen Celen
     * Date: 30/03/2015
     */
    public class Gebruiker
    {
        //Constructors
        public Gebruiker(string type, string klas, string voornaam, string achternaam, string psw, int gemWisk = 0, int gemNed = 0, int gemWO = 0, int gameTijdSec = 0)
        {
            //Constructor om nieuwe gebruiker met nieuw id te maken
            Voornaam = voornaam;
            Id = KenIDToe() + 1;
            Achternaam = achternaam;
            Klas = klas;
            Type = type;
            Psw = psw;
            GemNed = gemNed;
            GemWisk = gemWisk;
            GemWO = gemWO;
            GameTijdSec = gameTijdSec;
        }
        public Gebruiker(string type, string klas, int id, string voornaam, string achternaam, string psw, int gemWisk = 0, int gemNed = 0, int gemWO = 0, int gameTijdSec = 0)
        {
            //Constructor om bestaande gebruiker te lezen (met id)
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

        //Events

        //Methods
        public override string ToString()
        {
            return Voornaam + " " + Achternaam;
        }
        private int KenIDToe()
        {
            int laatsteID;
            AlleGebruikersLijst lijst = new AlleGebruikersLijst();
            Gebruiker laatsteGebruiker = lijst[lijst.Count - 1];
            laatsteID = laatsteGebruiker.Id;
            return laatsteID;
        }
        public string SchrijfString()
        {
            return (Type + ";" + Klas + ";" + Id + ";" + Voornaam + ";" + Achternaam + ";" + Psw + ";" + GemWisk + ";" + GemNed + ";" + GemWO + ";" + GameTijdSec);
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