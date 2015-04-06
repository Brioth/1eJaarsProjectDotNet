using Groepswerk.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    public class Accountlijst : List<Gebruiker> //Lijst met Gebruikers per klas
    {
        public Accountlijst(string klas){
            StreamReader bestandAcc = File.OpenText(@"Accounts.txt");
            string regel = bestandAcc.ReadLine();
            char[] scheiding = {';'};

            while (regel != null)
            {
                string[] woorden = regel.Split(scheiding);
                for (int i = 0; i < woorden.Length; i++)
                {
                    woorden[i] = woorden[i].Trim();
                }

                Gebruiker gebruiker = new Gebruiker(woorden[0], woorden[1], Convert.ToInt32(woorden[2]), woorden[3], woorden[4], woorden[5], Convert.ToInt32(woorden[6]), Convert.ToInt32(woorden[7]), Convert.ToInt32(woorden[8]), Convert.ToInt32(woorden[9]));

                if ((gebruiker.Klas).Equals(klas))
                {
                    this.Add(gebruiker);
                }

                regel = bestandAcc.ReadLine();
            }
            bestandAcc.Close();
        }
        
    }
}
