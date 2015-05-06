using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    class Oefening //voor constructors ivm oefeningen! Feel free to add, zou ik zo zeggen! -Thomas
    {
        //author: Thomas Cox
        //date: 14/04/2015


        public Oefening(string opgave, string oplossing1, string oplossing2, string oplossing3, string correcteOplossing, string juisteAntwoordCompleet)
        {
            this.opgave = opgave;
            this.oplossing1 = oplossing1;
            this.oplossing2 = oplossing2;
            this.oplossing3 = oplossing3;
            this.correcteOplossing = correcteOplossing;
            this.juisteAntwoordCompleet = juisteAntwoordCompleet;
        }

        public Oefening(string opgave, string oplossing, string juisteAntwoordCompleet)
        {
            this.opgave = opgave;
            this.oplossing = oplossing;
            this.juisteAntwoordCompleet = juisteAntwoordCompleet;
            
        }
        public Oefening(string opgave, string oplossing)
        {
            this.opgave = opgave;
            this.oplossing = oplossing;
        }
        public String SchrijfStringTaal(string sleutelwoord)
        {
            switch (sleutelwoord) 
            { 
                case "taal1":
                    return (opgave + ";" + oplossing1 + ";" + oplossing2 + ";" + oplossing3 + ";" + correcteOplossing + ";" + juisteAntwoordCompleet);
                break;
                case "taal2":
                    return (opgave + ";" + correcteOplossing + ";" + juisteAntwoordCompleet);
                break;
            }
        }
        public String SchrijfString()
        {
            return (opgave + ";" + oplossing);
        }

        public override string ToString() 
        {
            return opgave;
        }
      
        public string opgave { get; set; }
        public string oplossing { get; set; }
        public string oplossing1 { get; set; }
        public string oplossing2 { get; set; }
        public string oplossing3 { get; set; }
       
        public string correcteOplossing { get; set; }
        public string juisteAntwoordCompleet { get; set; }
    }

}
