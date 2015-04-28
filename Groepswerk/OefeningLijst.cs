using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    //Author: Thomas Cox
    //Date: 14/04/2015
    class OefeningLijst : List<Oefening> //alle oefeningen in een lijst gooien!
    {
       public OefeningLijst(string moeilijkheid)
       {
    //        if (moeilijkheid.Equals("makkelijk"))
    //        {
    //            StreamReader bestandOefening = File.OpenText(@"OefNederlands1Makkelijk.txt");
    //            string regel = bestandOefening.ReadLine();
    //            char[] scheiding = { ';' };

    //            while (regel != null)
    //            {
    //                string[] deel = regel.Split(scheiding);

    //                Oefening oefeningNederlands = new Oefening(deel[0], deel[1], deel[2], deel[3], deel[4], deel[5]);
    //                this.Add(oefeningNederlands);
    //                regel = bestandOefening.ReadLine();
    //            }
    //            bestandOefening.Close();
    //        }
    //        if (moeilijkheid.Equals("gemiddeld"))
    //        {
    //            StreamReader bestandOefening = File.OpenText(@"OefNederlands1Gemiddeld.txt");
    //            string regel = bestandOefening.ReadLine();
    //            char[] scheiding = { ';' };

    //            while (regel != null)
    //            {
    //                string[] deel = regel.Split(scheiding);

    //                Oefening oefeningNederlands = new Oefening(deel[0], deel[1], deel[2], deel[3], deel[4], deel[5]);
    //                this.Add(oefeningNederlands);
    //                regel = bestandOefening.ReadLine();
    //            }
    //            bestandOefening.Close();
    //        }

    //        if (moeilijkheid.Equals("moeilijk"))
    //        {
    //            StreamReader bestandOefening = File.OpenText(@"OefNederlands1Moeilijk.txt");
    //            string regel = bestandOefening.ReadLine();
    //            char[] scheiding = { ';' };

    //            while (regel != null)
    //            {
    //                string[] deel = regel.Split(scheiding);

    //                Oefening oefeningNederlands = new Oefening(deel[0], deel[1], deel[2], deel[3],deel[4],deel[5]);
    //                this.Add(oefeningNederlands);
    //                regel = bestandOefening.ReadLine();
    //            }
    //            bestandOefening.Close();
    //        }


            //Author: Vincent Vandoninck
            //Date: 24/04/2015

            if (moeilijkheid.Equals("makkelijk2"))
            {
                StreamReader bestandOefeningMak = File.OpenText(@"oefnWiskundeMakkelijk.txt");
                string regel = bestandOefeningMak.ReadLine();
                char[] scheiding = { ';' };

                while (regel != null)
                {
                    string[] deel = regel.Split(scheiding);

                    Oefening oefeningWiskundeMak = new Oefening(Convert.ToString(deel[0]) , Convert.ToString (deel[1]) );
                    this.Add(oefeningWiskundeMak);
                    regel = bestandOefeningMak.ReadLine();
                }
                bestandOefeningMak.Close();
            }

            if (moeilijkheid.Equals("gemiddeld2"))
            {
                StreamReader bestandOefeningGem = File.OpenText(@"oefnWiskundeGemiddeld.txt");
                string regel = bestandOefeningGem.ReadLine();
                char[] scheiding = { ';' };

                while (regel != null)
                {
                    string[] deel = regel.Split(scheiding);

                    Oefening oefeningWiskundeMoeil = new Oefening(Convert.ToString(deel[0]), Convert.ToString(deel[1])) ;
                    this.Add(oefeningWiskundeMoeil);
                    regel = bestandOefeningGem.ReadLine();
                }
                bestandOefeningGem.Close();
            }

            if (moeilijkheid.Equals("moeilijk2"))
            {
                StreamReader bestandOefeningMoeil = File.OpenText(@"oefnWiskundeMoeilijk.txt");
                string regel = bestandOefeningMoeil.ReadLine();
                char[] scheiding = { ';' };

                while (regel != null)
                {
                    string[] deel = regel.Split(scheiding);

                    Oefening oefeningWiskunde = new Oefening(Convert.ToString(deel[0]), Convert.ToString( deel[1]));
                    this.Add(oefeningWiskunde);
                    regel = bestandOefeningMoeil.ReadLine();
                }
                bestandOefeningMoeil.Close();
            }

        }
       
    }
     
}