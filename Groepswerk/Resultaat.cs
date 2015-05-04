using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    //aangepast 3/5/2015 door carmen
    //Constructor zonder datum om nieuw resultaat te maken met huidige datum, en met resultatenlijst om te checken of datum+id al bestaat
    //Constructor met datum om oud resultaat in te lezen
    public class Resultaat
    {
        //Lokale variabelen
        private int totaalPunten, gespendeerdeTijd, aantalOefeningen = 0, indexOud;
        //Constructors
        public Resultaat(int id, DateTime datum, int punt, int aantalOefeningen, int gespendeerdeTijd) //Constructor om resultaat op te halen
        {
            Id = id;
            Datum = datum;
            this.aantalOefeningen = aantalOefeningen;
            totaalPunten = punt;
            this.gespendeerdeTijd = gespendeerdeTijd;
        }
        public Resultaat(int id, int puntOef, int gespendeerdeTijdOef, ResultatenLijst lijst) //Constructor om nieuw resultaat te maken
        {
            Id = id;
            Datum = DateTime.Today;
            indexOud = -1; 
            for (int i = 0; i < lijst.Count; i++)
            {              
                if (lijst[i].Id.Equals(this.Id) && (lijst[i].Datum.Equals(DateTime.Today)))
                {
                    totaalPunten = lijst[i].TotaalPunten;
                    gespendeerdeTijd = lijst[i].GespendeerdeTijd;
                    aantalOefeningen = lijst[i].AantalOefeningen;
                    this.AddPunten(puntOef);
                    this.AddTime(gespendeerdeTijdOef);
                    this.aantalOefeningen++;
                    indexOud = i;
                }
            }
            if (indexOud == -1)
            {
                totaalPunten = puntOef;
                gespendeerdeTijd = gespendeerdeTijdOef;
                aantalOefeningen = 1;
            }


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
            return (Id + ";" + Datum + ";" + TotaalPunten + ";" + AantalOefeningen + ";" + GespendeerdeTijd);
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
        public int IndexOud
        {
            get { return indexOud; }
        }
    }
}
