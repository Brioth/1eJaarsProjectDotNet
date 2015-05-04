using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{

    //author: Vincent Vandoninck 
    //date: 03/05/2015

    // de gegevens uit het bestand lezen zodat je deze kan gebruiken in oefeningWiskunde.

    class OefeningLijstWiskunde : List<OefeningWiskunde>
    {
        public OefeningLijstWiskunde(string moeilijkheid)
        {
            switch (moeilijkheid)
            {
                
                //case ("gemiddeld"):

                //    StreamReader bestandOefeningGemiddeld = File.OpenText(@"oefnWiskundeGemiddeld.txt");
                //    string regelGemiddeld = bestandOefeningGemiddeld.ReadLine();
                //    char[] scheidingGemiddeld = { ';' };

                //    while (regelGemiddeld != null)
                //    {
                //        string[] deel = regelGemiddeld.Split(scheidingGemiddeld);

                //        OefeningWiskunde oefeningWiskunde = new OefeningWiskunde(deel[0], deel[1]);
                //        this.Add  (oefeningWiskunde);
                //        regelGemiddeld = bestandOefeningGemiddeld.ReadLine();
                //    }
                //    bestandOefeningGemiddeld.Close();
                //    break;

               


             
            }
        }
    }
}