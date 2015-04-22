using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    class wo : List<Oefening>
    {
    
        public wo(string moeilijkheid)
        {
            if (moeilijkheid.Equals("makkelijk"))
            {
                StreamReader bestandOefening = File.OpenText(@"oefWoMakkelijk.txt");
                string regel = bestandOefening.ReadLine();
                char[] scheiding = { ';' };

                while (regel != null)
                {
                    string[] deel = regel.Split(scheiding);

                    Oefening oefWo = new Oefening(deel[0], deel[1]);
                    this.Add(oefWo);
                    regel = bestandOefening.ReadLine();
                }
                bestandOefening.Close();
            }
            if (moeilijkheid.Equals("gemiddeld"))
            {
                StreamReader bestandOefening = File.OpenText(@"OefWoGemiddeld.txt");
                string regel = bestandOefening.ReadLine();
                char[] scheiding = { ';' };

                while (regel != null)
                {
                    string[] deel = regel.Split(scheiding);

                    Oefening oefWo = new Oefening(deel[0], deel[1]);
                    this.Add(oefWo);
                    regel = bestandOefening.ReadLine();
                }
                bestandOefening.Close();
            }

            if (moeilijkheid.Equals("moeilijk"))
            {
                StreamReader bestandOefening = File.OpenText(@"OefWoMoeilijk.txt");
                string regel = bestandOefening.ReadLine();
                char[] scheiding = { ';' };

                while (regel != null)
                {
                    string[] deel = regel.Split(scheiding);

                    Oefening oefWo = new Oefening(deel[0], deel[1]);
                    this.Add(oefWo);
                    regel = bestandOefening.ReadLine();
                }
                bestandOefening.Close();
            }


        }
    }
}
