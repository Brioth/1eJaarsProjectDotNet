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
            switch (moeilijkheid)
            {
                case ("makkelijk"):

                    StreamReader bestandOefeningMakkelijk = File.OpenText(@"OefNederlands1Makkelijk.txt");
                    string regelMakkelijk = bestandOefeningMakkelijk.ReadLine();
                    char[] scheidingMakkelijk = { ';' };

                    while (regelMakkelijk != null)
                    {
                        string[] deel = regelMakkelijk.Split(scheidingMakkelijk);
                        Oefening oefeningNederlands = new Oefening(deel[0], deel[1], deel[2], deel[3], deel[4], deel[5]);
                        this.Add(oefeningNederlands);
                        regelMakkelijk = bestandOefeningMakkelijk.ReadLine();
                    }
                    bestandOefeningMakkelijk.Close();
                    break;
                case ("gemiddeld"):

                    StreamReader bestandOefeningGemiddeld = File.OpenText(@"OefNederlands1Gemiddeld.txt");
                    string regelGemiddeld = bestandOefeningGemiddeld.ReadLine();
                    char[] scheidingGemiddeld = { ';' };

                    while (regelGemiddeld != null)
                    {
                        string[] deel = regelGemiddeld.Split(scheidingGemiddeld);

                        Oefening oefeningNederlands = new Oefening(deel[0], deel[1], deel[2], deel[3], deel[4], deel[5]);
                        this.Add(oefeningNederlands);
                        regelGemiddeld = bestandOefeningGemiddeld.ReadLine();
                    }
                    bestandOefeningGemiddeld.Close();
                    break;

                case ("moeilijk"):

                    StreamReader bestandOefeningMoeilijk = File.OpenText(@"OefNederlands1Moeilijk.txt");
                    string regelMoeilijk = bestandOefeningMoeilijk.ReadLine();
                    char[] scheidingMoeilijk = { ';' };

                    while (regelMoeilijk != null)
                    {
                        string[] deel = regelMoeilijk.Split(scheidingMoeilijk);

                        Oefening oefeningNederlands = new Oefening(deel[0], deel[1], deel[2], deel[3], deel[4], deel[5]);
                        this.Add(oefeningNederlands);
                        regelMoeilijk = bestandOefeningMoeilijk.ReadLine();
                    }
                    bestandOefeningMoeilijk.Close();
                    break;


             
            }
        }
    }
}