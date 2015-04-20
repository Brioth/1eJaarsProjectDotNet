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
            if(moeilijkheid.Equals("makkelijk")){
            StreamReader bestandOefening = File.OpenText(@"OefNederlands1Makkelijk.txt");
            string regel = bestandOefening.ReadLine();
            char[] scheiding = { ';' };

            while (regel != null)
            {
                string[] deel= regel.Split(scheiding);

                Oefening oefeningNederlands = new Oefening(deel[0], deel[1], deel[2], deel[3], deel[4], deel[5]);
                this.Add(oefeningNederlands);
                regel = bestandOefening.ReadLine();
            }
            bestandOefening.Close();
        }
            if (moeilijkheid.Equals("gemiddeld"))
            {
                StreamReader bestandOefening = File.OpenText(@"OefNederlands1Gemiddeld.txt");
                string regel = bestandOefening.ReadLine();
                char[] scheiding = { ';' };

                while (regel != null)
                {
                    string[] deel = regel.Split(scheiding);

                    Oefening oefeningNederlands = new Oefening(deel[0], deel[1], deel[2], deel[3], deel[4], deel[5]);
                    this.Add(oefeningNederlands);
                    regel = bestandOefening.ReadLine();
                }
                bestandOefening.Close();
            }

                if (moeilijkheid.Equals("moeilijk"))
            {
                StreamReader bestandOefening = File.OpenText(@"OefNederlands1Moeilijk.txt");
                string regel = bestandOefening.ReadLine();
                char[] scheiding = { ';' };

                while (regel != null)
                {
                    string[] deel = regel.Split(scheiding);

                    Oefening oefeningNederlands = new Oefening(deel[0], deel[1], deel[2]);
                this.Add(oefeningNederlands);
                regel = bestandOefening.ReadLine();
            }
            bestandOefening.Close();
        }

        
    }
}