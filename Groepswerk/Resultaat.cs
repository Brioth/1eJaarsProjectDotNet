using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    //aangepast 3/5/2015 door carmen
    //Constructor zonder datum om nieuw resultaat te maken met huidige datum
    //Constructor met datum om oud resultaat in te lezen
    //constructor add tijd in #seconden via AddTime
    //constructor add punten via AddPunten
    class Resultaat
    {
        //Lokale variabelen
        private int totaalPunten, gespendeerdeTijd, aantalOefeningen = 0;
        //Constructors
        public Resultaat(int id, DateTime datum , int gespendeerdeTijd, int punt) //Constructor om resultaat op te halen
        {
            Id = id;
            AddTime(gespendeerdeTijd);
            Datum = datum;
            AddPunten(punt);
            aantalOefeningen++;
        }
        public Resultaat(int id, int gespendeerdeTijd, int punt) //Constructor om nieuw resultaat te maken
        {
            Id = id;
            AddTime(gespendeerdeTijd);
            Datum = DateTime.Today;
            AddPunten(punt);
            aantalOefeningen++;
        }
        //Events
        //Methods
        public void AddTime(int seconden)
        {
            gespendeerdeTijd = gespendeerdeTijd + seconden;
        }
        public void AddPunten(int punten) 
        {
            totaalPunten = totaalPunten + punten;
        }
        public String SchrijfString()
        {
            return (Id + ";" + Datum + ";" + TotaalPunten + ";" + GespendeerdeTijd + ";" + aantalOefeningen);
        }
        //Properties
        public int Id { get; set; }
        public int GespendeerdeTijd
        {
            get { return gespendeerdeTijd; } 
        }        
        public DateTime Datum { get; set; }
        public int TotaalPunten 
        {
            get { return totaalPunten; }  
        }
        public int AantalOefeningen
        {
            get { return aantalOefeningen; }
        }
    }
}
