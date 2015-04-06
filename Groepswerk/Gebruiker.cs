using Groepswerk.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    public class Gebruiker //Gebruikers staan in formaat: type(lln of lk);klas;ID;voornaam;achternaam;psw;gemWisk;gemNed;gemWO;tijdVoorSpelInSec
    {
        //Constructors

        //Constructor om nieuwe gebruiker met nieuw id te maken
        public Gebruiker(string type, string klas, string voornaam, string achternaam, string psw, int gemWisk=0, int gemNed=0, int gemWO=0, int gameTijdSec=0)
        {
            Voornaam = voornaam;
            Id = KenIDToe()+1;
            //???
            Achternaam = achternaam;
            Klas = klas;
            Type = type;
            Psw = psw;
            GemNed = gemNed;
            GemWisk = gemWisk;
            GemWO = gemWO;
            GameTijdSec = gameTijdSec;
        }

        //Constructor om te lezen met id
        public Gebruiker(string type, string klas, int id, string voornaam, string achternaam, string psw, int gemWisk = 0, int gemNed = 0, int gemWO = 0, int gameTijdSec = 0)
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

        private int KenIDToe()
        {
            int aantalAccounts = 0;
            StreamReader bestandslezer = File.OpenText(@"Accounts.txt");
            string regel = bestandslezer.ReadLine();
            while (regel != null)
            {
                aantalAccounts = aantalAccounts++;
                regel = bestandslezer.ReadLine();
            }
            bestandslezer.Close();
            return aantalAccounts;
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