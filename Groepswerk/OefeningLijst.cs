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
            switch (moeilijkheid){
            
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


                //Author: Vincent Vandoninck
                //Date: 24/04/2015

                //       case("makkelijk2"):

                //   StreamReader bestandOefeningMakkelijk2 = File.OpenText(@"oefnWiskundeMakkelijk.txt");
                //   string regelMakkelijk2 = bestandOefeningMakkelijk2.ReadLine();
                //   char[] scheidingmakkelijk2 = { ';' };

                //   while (regelMakkelijk2 != null)
                //        {
                //            string[] deel = regelMakkelijk2.Split(scheidingmakkelijk2);

                //            Oefening oefeningWiskundeMakkelijk2 = new Oefening(Convert.ToString(deel[0]), Convert.ToString(deel[1]));
                //            this.Add(oefeningWiskundeMakkelijk2);
                //            regelMakkelijk2 = bestandOefeningMakkelijk2.ReadLine();
                //        }
                //   bestandOefeningMakkelijk2.Close();
                //    break;

                //       case("gemiddeld2"):

                //        StreamReader bestandOefeningGemiddeld2 = File.OpenText(@"oefnWiskundeGemiddeld.txt");
                //        string regelGemiddeld2 = bestandOefeningGemiddeld2.ReadLine();
                //        char[] scheidingGemiddeld2 = { ';' };

                //        while (regelGemiddeld2 != null)
                //        {
                //            string[] deel = regelGemiddeld2.Split(scheidingGemiddeld2);

                //            Oefening oefeningWiskundeGemiddeld2 = new Oefening(Convert.ToString(deel[0]), Convert.ToString(deel[1]));
                //            this.Add(oefeningWiskundeGemiddeld2);
                //            regelGemiddeld2 = bestandOefeningGemiddeld2.ReadLine();
                //        }
                //        bestandOefeningGemiddeld2.Close();
                //        break;

                //       case ("moeilijk2"):

                //        StreamReader bestandOefeningMoeilijk2 = File.OpenText(@"oefnWiskundeMoeilijk.txt");
                //        string regelMoeilijk2 = bestandOefeningMoeilijk2.ReadLine();
                //        char[] scheidingMoeilijk2 = { ';' };

                //        while (regelMoeilijk2 != null)
                //        {
                //            string[] deel = regelMoeilijk2.Split(scheidingMoeilijk2);

                //            Oefening oefeningWiskundeMoeilijk2 = new Oefening(Convert.ToString(deel[0]), Convert.ToString(deel[1]));
                //            this.Add(oefeningWiskundeMoeilijk2);
                //            regelMoeilijk2 = bestandOefeningMoeilijk2.ReadLine();
                //        }
                //        bestandOefeningMoeilijk2.Close();
                //        break;

                //}

            }
        }
    }
}