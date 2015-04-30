using Groepswerk.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Groepswerk
{
    /* --Gebruiker--
     * Klasse Gebruiker om makkelijk om te gaan met de gegevens van diverse lln en lk
     * Formaat Accounts: type(lln of lk);klas;ID;voornaam;achternaam;psw;gemWisk;gemNed;gemWO;tijdVoorSpelInSec
     * Gebruik SetGameTijd(int aantalVragenJuist, string codeMoeilijkheidsgraad) om gameTijd bij te geven
     * codes moeilijkheidsgraad zijn MAK, MED en MOE
     * 3 seconden per juist antwoord, *1 voor mak, *2 voor med en *3 voor moe
     * maximum gametijd te behalven is 6 minuten (360seconden), dit kan je behalen door 4 moeilijke oefeningen volledig juist te maken
     * Gebruik SchrijfString() om de string van de gebruiker te krijgen in het formaat nodig voor de txt-bestanden
     * psw'en worden weggeschreven als bytes
     * Author: Carmen Celen
     * Date: 30/03/2015
     */
    public class Gebruiker
    {
        //Lokale variabelen

        private int gameTijd;
        private string encrPsw;
        private int SLEUTEL = 70;

        //Constructors
        public Gebruiker(string type, string klas, string voornaam, string achternaam, string psw, int gemWisk = 0, int gemNed = 0, int gemWO = 0, int gameTijdSec = 0)
        {
            //Constructor om nieuwe gebruiker met nieuw id te maken
            Voornaam = voornaam;
            Id = KenIDToe() + 1;
            Achternaam = achternaam;
            Klas = klas;
            Type = type;
            encrPsw = psw;
            GemNed = gemNed;
            GemWisk = gemWisk;
            GemWO = gemWO;
            gameTijd = gameTijdSec;
        }
        public Gebruiker(string type, string klas, int id, string voornaam, string achternaam, string psw, int gemWisk = 0, int gemNed = 0, int gemWO = 0, int gameTijdSec = 0)
        {
            //Constructor om bestaande gebruiker te lezen (met id)
            Voornaam = voornaam;
            Id = id;
            Achternaam = achternaam;
            Klas = klas;
            Type = type;
            encrPsw = psw;
            GemNed = gemNed;
            GemWisk = gemWisk;
            GemWO = gemWO;
            gameTijd = gameTijdSec;
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
            return (Type + ";" + Klas + ";" + Id + ";" + Voornaam + ";" + Achternaam + ";" + encrPsw + ";" + GemWisk + ";" + GemNed + ";" + GemWO + ";" + GameTijdSec);
        }

        public void SetGameTijd(int vragenJuist, string moeilijkheidsgraad)
        {
            if (vragenJuist>10)
            {
                MessageBox.Show("vragenjuist moet liggen tussen 0 en 10");//mag later weg, voor debug
            }
            int verhoging;
            moeilijkheidsgraad = moeilijkheidsgraad.ToUpper();

            switch (moeilijkheidsgraad)
            {
                case "MAK":
                    verhoging = 1;
                    break;
                case "MED":
                    verhoging = 2;
                    break;
                case "MOE":
                    verhoging = 3;
                    break;
                default:
                    verhoging = 0;
                    MessageBox.Show("code moeilijkheidsgraad is niet goed, kies uit mak, med of moe");//mag later weg, voor debug
                    break;
            }
            gameTijd = GameTijdSec + vragenJuist * 3 * verhoging;
            if (gameTijd > 360)
            {
                gameTijd = 360;
            }
        }
        public void SetGameTijdOp0()
        {
            gameTijd = 0;
        }
        //Properties
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Klas { get; set; }
        public string Type { get; set; }
        public string Psw
        {
            get 
            {
                char[] chars = encrPsw.ToCharArray();
                int[] code = new int[chars.Length];
                for (int i = 0; i < chars.Length; i++)
			{
                code[i] = chars[i] - SLEUTEL;
                if (code[i] > 127)
                {
                    code[i] = chars[i]%128;
                }
                if (code[i]<0)
                {
                    code[i] = code[i] + 128;
                }
                chars[i] = Convert.ToChar(code[i]);
			}
                return new String(chars);

            }
            set 
            {

                char[] chars = value.ToCharArray();
                int[] code = new int[chars.Length];
                for (int i = 0; i < chars.Length; i++)
                {
                    code[i] = chars[i] + SLEUTEL;
                    if (code[i] > 127)
                    {
                        code[i] = chars[i] % 128;
                    }
                    if (code[i] <0)
                    {
                        code[i] = code[i] + 128;
                    }
                    chars[i] = Convert.ToChar(code[i]);
                }

                encrPsw = new String(chars);
            }
        }
        public int GemWisk { get; set; }
        public int GemNed { get; set; }
        public int GemWO { get; set; }
        public int GameTijdSec 
        {
            get { return gameTijd; }            
        }
    }
}