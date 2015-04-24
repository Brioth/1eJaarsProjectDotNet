using Groepswerk.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Groepswerk
{    /* --AccountLijst--
      * Klasse die lijst van alle klassen
      * Methode SchrijfLijst() om (aangepaste) lijst naar txtbestand te schrijven
      * Author: Carmen Celen
      * Date: 03/04/2015
      */
    public class Klaslijst : List<string>
    {
        //Lokale variabelen

        //Constructors
        public Klaslijst()
        {
            try
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
            catch (FileNotFoundException)
            {
                MessageBox.Show("Bestand Klassen.txt niet gevonden");
            }
        }
        //Events

        //Methods
        public void SchrijfLijst()
        {
            File.WriteAllText(@"Klassen.txt", String.Empty);
            StreamWriter schrijver = File.AppendText(@"Klassen.txt");
            foreach (string item in this)
            {
                schrijver.WriteLine(item);
            }
            schrijver.Close();
        }
        //Properties

    }
}
