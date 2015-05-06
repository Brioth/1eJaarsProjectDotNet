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
        private string moeilijkheid;
        public OefeningLijst(string moeilijkheid)
        {
            this.moeilijkheid = moeilijkheid;
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

                        Oefening oefeningNederlands = new Oefening(deel[0], deel[1]);
                        this.Add(oefeningNederlands);
                        regelMoeilijk = bestandOefeningMoeilijk.ReadLine();
                    }
                    bestandOefeningMoeilijk.Close();
                    break;

                case ("WoMakkelijk"):
                     StreamReader bestandOefeningMakkelijkWo = File.OpenText(@"oefWoMakkelijk.txt");
                    string regelMakkelijkWo = bestandOefeningMakkelijkWo.ReadLine();
                    char[] scheiding = { ';' };

                    while (regelMakkelijkWo != null)
                     {
                    string[] deel = regelMakkelijkWo.Split(scheiding);

                    Oefening oefWo = new Oefening(deel[0], deel[1]);
                    this.Add(oefWo);
                    regelMakkelijkWo = bestandOefeningMakkelijkWo.ReadLine();
                     }
                     bestandOefeningMakkelijkWo.Close();
                     break;

                case ("WoGemiddeld"):

                     StreamReader bestandOefeningGemiddeldWo = File.OpenText(@"OefWoGemiddeld.txt");
                     string regelGemiddeldWo = bestandOefeningGemiddeldWo.ReadLine();
                     char[] scheidingGemiddeldWo = { ';' };

                     while (regelGemiddeldWo != null)
                    {
                    string[] deel = regelGemiddeldWo.Split(scheidingGemiddeldWo);

                    Oefening oefWo = new Oefening(deel[0], deel[1]);
                    this.Add(oefWo);
                    regelGemiddeldWo = bestandOefeningGemiddeldWo.ReadLine();
                    }
                     bestandOefeningGemiddeldWo.Close();

                     break;

                case ("WoMoeilijk"):
                    StreamReader bestandOefeningMoeilijkWo = File.OpenText(@"OefWoMoeilijk.txt");
                    string regelMoeilijkWo = bestandOefeningMoeilijkWo.ReadLine();
                    char[] scheidingMoeilijkWo = { ';' };

                    while (regelMoeilijkWo != null)
                    {
                    string[] deel = regelMoeilijkWo.Split(scheidingMoeilijkWo);

                    Oefening oefWo = new Oefening(deel[0], deel[1]);
                    this.Add(oefWo);
                    regelMoeilijkWo = bestandOefeningMoeilijkWo.ReadLine();
                    }
                    bestandOefeningMoeilijkWo.Close();
                     break;

             
            }
        }
        public void SchrijfLijst(string bestand)
        {
            File.WriteAllText(bestand, String.Empty);
            StreamWriter schrijver = File.AppendText(bestand);
            foreach (Oefening item in this)
            {
                schrijver.WriteLine(item.SchrijfString());
            }
            schrijver.Close();
        }

        public void SchrijfLijstTaal(string bestand)
        {
            File.WriteAllText(bestand, String.Empty);
            StreamWriter schrijver = File.AppendText(bestand);
            foreach (Oefening item in this)
            {
                schrijver.WriteLine(item.SchrijfStringTaal());
            }
            schrijver.Close();
        }
      
        }


       

    }
