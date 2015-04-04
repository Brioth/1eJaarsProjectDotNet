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
    public class Klaslijst : List<string>
    {
        public Klaslijst()
        {
            {
                StreamReader bestandKlas = File.OpenText(@"Klassen.txt");
                string regel = bestandKlas.ReadLine();

                while (regel != null)
                {
                    this.Add(regel.Trim());
                    regel = bestandKlas.ReadLine();
                }
                bestandKlas.Close();
            }
        }

    }
}
