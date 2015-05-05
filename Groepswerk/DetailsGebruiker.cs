using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groepswerk
{
    /*
     * 
     * 
     * 
     * Author: Carmen Celen
     * Date: 3/05/2015
     */
    public class DetailsGebruiker
    {
        //Lokale variabelen
        private string naam;
        private List<Resultaat> nedMak, nedGem, nedMoe, wiskMak, wiskGem, wiskMoe, woMak, woGem, woMoe;
        //Constructors
        public DetailsGebruiker(int id, string naam)
        {
            Id = id;
            this.naam = naam;
            nedMak = MaakLijst("OefNederlands1MakkelijkResultaten.txt");
            nedGem = MaakLijst("OefNederlands1GemiddeldResultaten.txt");
            nedMoe = MaakLijst("OefNederlands1MoeilijkResultaten.txt");
            wiskMak = MaakLijst("OefResultatenWiskMak.txt");
            wiskGem = MaakLijst("OefResultatenWiskGem.txt");
            wiskMoe = MaakLijst("OefResultatenWiskMoe.txt");
            woMak = MaakLijst("OefResultatenWoMak.txt");
            woGem = MaakLijst("OefResultatenWoMed.txt");
            woMoe = MaakLijst("OefResultatenWoMoe.txt");
        }

        private List<Resultaat> MaakLijst(string bestand)
        {
            ResultatenLijst resLijst = new ResultatenLijst(bestand);
            List<Resultaat> gemiddeldeLijst = new List<Resultaat>();
            foreach (Resultaat item in resLijst)
            {
                if (this.Id.Equals(item.Id))
                {
                    gemiddeldeLijst.Add(item);
                }
            }
            return gemiddeldeLijst;
        }
        public int[] MaakGemiddelde(List<Resultaat> lijst)
        {
            int totaalPunten = 0;
            int totaalSeconden = 0;
            int totaalOefeningen = 0;
            foreach (Resultaat item in lijst)
            {
                totaalPunten = totaalPunten + item.TotaalPunten;
                totaalSeconden = totaalSeconden + item.GespendeerdeTijd;
                totaalOefeningen = totaalOefeningen + item.AantalOefeningen;
            }

            int[] gemiddelde = { totaalPunten, totaalSeconden, totaalOefeningen };

            return gemiddelde;
        }

        public int Id { get; set; }
        public string Naam { get { return naam; } }
        public List<Resultaat> ResultatenNedMak { get { return nedMak; } }
        public List<Resultaat> ResultatenNedMed { get { return nedGem; } }
        public List<Resultaat> ResultatenNedMoe { get { return nedMoe; } }
        public List<Resultaat> ResultatenWiskMak { get { return wiskMak; } }
        public List<Resultaat> ResultatenWiskMed { get { return wiskGem; } }
        public List<Resultaat> ResultatenWiskMoe { get { return wiskMoe; } }
        public List<Resultaat> ResultatenWoMak { get { return woMak; } }
        public List<Resultaat> ResultatenWoMed { get { return woGem; } }
        public List<Resultaat> ResultatenWoMoe { get { return woMoe; } }
        public int[] GemNedMak { get { return MaakGemiddelde(ResultatenNedMak); } }
        public int[] GemNedMed { get { return MaakGemiddelde(ResultatenNedMed); } }
        public int[] GemNedMoe { get { return MaakGemiddelde(ResultatenNedMoe); } }
        public int[] GemWiskMak { get { return MaakGemiddelde(ResultatenWiskMak); } }
        public int[] GemWiskMed { get { return MaakGemiddelde(ResultatenWiskMed); } }
        public int[] GemWiskMoe { get { return MaakGemiddelde(ResultatenWiskMoe); } }
        public int[] GemWoMak { get { return MaakGemiddelde(ResultatenWoMak); } }
        public int[] GemWoMed { get { return MaakGemiddelde(ResultatenWoMed); } }
        public int[] GemWoMoe { get { return MaakGemiddelde(ResultatenWoMoe); } }



    }
}
