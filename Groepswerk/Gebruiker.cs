using Groepswerk.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    /* --Gebruiker--
     * Klasse Gebruiker om makkelijk om te gaan met de gegevens van diverse lln en lk
     * Formaat Accounts: type(lln of lk);klas;ID;voornaam;achternaam;psw;gemWisk;gemNed;gemWO;tijdVoorSpelInSec
     * Gebruik SetGameTijd(int aantalVragenJuist, string codeMoeilijkheidsgraad) om gameTijd bij te geven
     * codes moeilijkheidsgraad zijn MAK, MED en MOE
     * Gebruik SchrijfString() om de string van de gebruiker te krijgen in het formaat nodig voor de txt-bestanden
     * Author: Carmen Celen
     * Date: 30/03/2015
     */
    public class Gebruiker
    {
        //Lokale variabelen

        private int gameTijd;

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
            Psw = psw;
            GemNed = gemNed;
            GemWisk = gemWisk;
            GemWO = gemWO;
            gameTijd = gameTijdSec;
        }

        //Events

        //Methods
        public static class StringCipher
        {
            //encrypteren van het wachtwoord
            private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

            // This constant is used to determine the keysize of the encryption algorithm.
            private const int keysize = 256;
            public static string Encrypt(string plainText, string passPhrase)
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    byte[] cipherTextBytes = memoryStream.ToArray();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }
        }
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

        public void SetGameTijd(int vragenJuist, string moeilijkheidsgraad)
        {
            double percentage;
            moeilijkheidsgraad = moeilijkheidsgraad.ToUpper();

            switch (moeilijkheidsgraad)
            {
                case "MAK":
                    percentage = 1.0;
                    break;
                case "MED":
                    percentage = 1.50;
                    break;
                case "MOE":
                    percentage = 2.00;
                    break;
                default:
                    percentage = 0.13; //Om een gek getal uit te komen en aan te geven code is fout
                    break;
            }
            gameTijd = GameTijdSec + Convert.ToInt32(vragenJuist * 10 * percentage + 0.5);
        }
        //Properties
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Klas { get; set; }
        public string Type { get; set; }
        public string Psw
        {
            get { }
            set { }
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