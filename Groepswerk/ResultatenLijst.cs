using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    class ResultatenLijst : List<Resultaat>
    {
        public ResultatenLijst(string sleutelwoord)
        {
            switch (sleutelwoord) { 
                case("Makkelijk"):

                StreamReader bestandResultatenMakkelijk = File.OpenText(@"OefNederlands1MakkelijkResultaten.txt");
                string regelMakkelijk = bestandResultatenMakkelijk.ReadLine();
                char[] scheidingMakkelijk = { ';' };

                while (regelMakkelijk != null)
                {
                        string[] deel = regelMakkelijk.Split(scheidingMakkelijk);

                        Resultaat oefeningNederlandsResultaten = new Resultaat(deel[0], Convert.ToDouble(deel[1]), Convert.ToDateTime(deel[2]), Convert.ToInt32(deel[3]));
                        this.Add(oefeningNederlandsResultaten);
                        regelMakkelijk = bestandResultatenMakkelijk.ReadLine();
                }

                    bestandResultatenMakkelijk.Close();
                    break;

                case("Gemiddeld"):
                    StreamReader bestandResultatenGemiddeld = File.OpenText(@"OefNederlands1GemiddeldResultaten.txt");
                    string regelGemiddeld = bestandResultatenGemiddeld.ReadLine();
                    char[] scheidingGemiddeld = { ';' };

                    while (regelGemiddeld != null)
                    {
                        string[] deel = regelGemiddeld.Split(scheidingGemiddeld);

                        Resultaat oefeningNederlands = new Resultaat(deel[0], Convert.ToDouble(deel[1]), Convert.ToDateTime(deel[2]), Convert.ToInt32(deel[3]));
                        this.Add(oefeningNederlands);
                        regelMakkelijk = bestandResultatenGemiddeld.ReadLine();
                    }

                    bestandResultatenGemiddeld.Close();
                    break;

                case ("Moeilijk"):
                    StreamReader bestandResultatenMoeilijk = File.OpenText(@"OefNederlands1MoeilijkResultaten.txt");
                    string regelMoeilijk = bestandResultatenMoeilijk.ReadLine();
                    char[] scheidingMoeilijk = { ';' };

                    while (regelMoeilijk != null)
                    {
                        string[] deel = regelMoeilijk.Split(scheidingMoeilijk);

                        Resultaat oefeningNederlands = new Resultaat(deel[0], Convert.ToDouble(deel[1]), Convert.ToDateTime(deel[2]), Convert.ToInt32(deel[3]));
                        this.Add(oefeningNederlands);
                        regelMoeilijk = bestandResultatenMoeilijk.ReadLine();
                    }

                    bestandResultatenMoeilijk.Close();
                    break;
            }
    }
    }
}