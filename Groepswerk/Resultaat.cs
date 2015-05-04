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
        public Resultaat(int id, DateTime datum, int aantalOefeningen, int punt, int gespendeerdeTijd) //Constructor om resultaat op te halen
        {
            Id = id;
            Datum = datum;
            this.aantalOefeningen = aantalOefeningen;
            totaalPunten = punt;
            gespendeerdeTijd = this.gespendeerdeTijd;
        }
        public Resultaat(int id, int punt, int gespendeerdeTijd, ResultatenLijst lijst) //Constructor om nieuw resultaat te maken
        {
            Id = id;
            Datum = DateTime.Today;
            for (int i = 0; i < lijst.Count; i++)
            {
                if (lijst[i].Id.Equals(this.Id) && (lijst[i].Datum.Equals(DateTime.Today)))
                {
                    this.totaalPunten = lijst[i].TotaalPunten;
                    this.gespendeerdeTijd = lijst[i].GespendeerdeTijd;
                    this.aantalOefeningen = lijst[i].AantalOefeningen;
                    this.AddPunten(punt);
                    this.AddTime(gespendeerdeTijd);
                    this.aantalOefeningen++;
                    indexOud = i;
                }
                else
                {
                    totaalPunten = punt;
                    this.gespendeerdeTijd = gespendeerdeTijd;
                    aantalOefeningen = 1;
                    indexOud = -1;
                }
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
