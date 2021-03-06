﻿using Groepswerk.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Groepswerk
{
    /* --AccountLijst--
     * Klasse die lijst van gebruikers van meegegeven klas maakt
     * Methode SchrijfLijst() om (aangepaste) lijst naar txtbestand te schrijven
     * Author: Carmen Celen
     * Date: 03/04/2015
     */
    public class Accountlijst : List<Gebruiker>
    {
        //Lokale variabelen

        //Constructors
        public Accountlijst(Klas klas)
        {
            try
            {
                StreamReader bestandAcc = File.OpenText(@"Accounts.txt");
                string regel = bestandAcc.ReadLine();
                char[] scheiding = { ';' };

                while (regel != null)
                {
                    string[] woorden = regel.Split(scheiding);
                    for (int i = 0; i < woorden.Length; i++)
                    {
                        woorden[i] = woorden[i].Trim();
                    }

                    Gebruiker gebruiker = new Gebruiker(woorden[0], woorden[1], Convert.ToInt32(woorden[2]), woorden[3], woorden[4], woorden[5], Convert.ToInt32(woorden[6]));

                    if (gebruiker.Klas.Naam.Equals(klas.Naam)) //filter op gebruikers in meegegeven klas
                    {
                        this.Add(gebruiker);
                    }

                    regel = bestandAcc.ReadLine();
                }
                bestandAcc.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Bestand Accounts.txt niet gevonden");
            }

            //Events

            //Methods

            //Properties
        }
    }
}
