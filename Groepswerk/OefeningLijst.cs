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
        public OefeningLijst()
        {
            StreamReader bestandOefening = File.OpenText(@"OefNederlands1.txt");
            string regel = bestandOefening.ReadLine();
            char[] scheiding = { ';' };

            while (regel != null)
            {
                string[] deel= regel.Split(scheiding);

                Oefening oefeningNederlands = new Oefening(Convert.ToInt32(deel[0]), deel[1], deel[2], deel[3], deel[4], deel[5],deel[6]);
                this.Add(oefeningNederlands);
                regel = bestandOefening.ReadLine();
            }
            bestandOefening.Close();
        }

        public void OefeningLijstWiskunde1()
        //Author: vincent vandoninck
        //Date: 19/04/2015
        {
            StreamReader bestandOefening = File.OpenText(@"oefnWiskunde1.txt");
            string regel = bestandOefening.ReadLine();
            char[] scheiding = { ';' };

            while (regel != null)
            {
                string[] deel = regel.Split(scheiding);

                Oefening oefeningWiskunde = new Oefening(deel[0], deel[1]);
                this.Add(oefeningWiskunde);
                regel = bestandOefening.ReadLine();
            }
            bestandOefening.Close();
        }
        
    }
}