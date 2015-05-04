//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Groepswerk
//{
//    //Author: Thomas Cox
//    //Date: 28/04/2015
//    class wegschrijvenData
//    {
//        //Datum wegschrijven HOORT TE GEBEUREN ENKEL OP DATUM, NIET OP TIJDSTIP (makkelijker te controleren) - Thomas
        
//        public wegschrijvenData(string sleutelwoord, string nieuwId, double nieuwGespendeerdeTijd, DateTime nieuwDatum, int nieuwPunten)
//        {
//            Boolean inLijst;

//            switch(sleutelwoord){
//                case "OefNederlandsMakkelijk":
//                    ResultatenLijst lijstResultaten = new ResultatenLijst("Makkelijk");
//                    StreamReader oefNederlandsMakkelijkResultaten = File.OpenText(@"OefNederlands1MakkelijkResultaten.txt");

//                    for (int i = 0; i > lijstResultaten.Count; i++)
//                    {
//                        if (!(lijstResultaten[i].datum.Equals(DateTime.Today)&&(lijstResultaten[i].id.Equals(nieuwId))))
//                        {
//                            inLijst=false;
//                        }
//                        else
//                        {
//                            inLijst=true;
//                        }
//                    }
//                    //txtfile clearen en alles terug wegschrijven. Hoort wel te lukken

//                        break;
//                case "oefNederlandsGemiddeld":
//                    StreamReader oefNederlandsGemiddeldResultaten = File.OpenText(@"OefNederlands1GemiddeldResultaten.txt");
//                    break;
//                case "oefNederlandsMoeilijk":
//                    StreamReader OefNederlandsMoeilijkResultaten = File.OpenText(@"OefNederlands1MoeilijkResultaten.txt");
//                    break;
//                    //Voeg uw eigen cases toe aub
//        }

//    }
//    }
//}