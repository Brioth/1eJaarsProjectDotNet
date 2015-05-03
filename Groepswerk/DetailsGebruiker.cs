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

        //Constructors
        public DetailsGebruiker(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public List<Resultaat> ResultatenNedMak 
        { 
            get 
            {
                ResultatenLijst lijst = new ResultatenLijst("locatie");
                foreach (Resultaat item in lijst)
                {
                    if (this.Id.Equals(item.Id))
                    {
                        ResultatenNedMak.Add(item);
                    }
                }
                return ResultatenNedMak;
            }
                
        }
        public List<Resultaat> ResultatenNedMed
        {
            get
            {
                ResultatenLijst lijst = new ResultatenLijst("locatie");
                foreach (Resultaat item in lijst)
                {
                    if (this.Id.Equals(item.Id))
                    {
                        ResultatenNedMed.Add(item);
                    }
                }
                return ResultatenNedMed;
            }

        }
        public List<Resultaat> ResultatenNedMoe
        {
            get
            {
                ResultatenLijst lijst = new ResultatenLijst("locatie");
                foreach (Resultaat item in lijst)
                {
                    if (this.Id.Equals(item.Id))
                    {
                        ResultatenNedMoe.Add(item);
                    }
                }
                return ResultatenNedMoe;
            }

        }
        public List<Resultaat> ResultatenWiskMak
        {
            get
            {
                ResultatenLijst lijst = new ResultatenLijst("locatie");
                foreach (Resultaat item in lijst)
                {
                    if (this.Id.Equals(item.Id))
                    {
                        ResultatenWiskMak.Add(item);
                    }
                }
                return ResultatenWiskMak;
            }

        }
        public List<Resultaat> ResultatenWiskMed
        {
            get
            {
                ResultatenLijst lijst = new ResultatenLijst("locatie");
                foreach (Resultaat item in lijst)
                {
                    if (this.Id.Equals(item.Id))
                    {
                        ResultatenWiskMed.Add(item);
                    }
                }
                return ResultatenWiskMed;
            }

        }
        public List<Resultaat> ResultatenWiskMoe
        {
            get
            {
                ResultatenLijst lijst = new ResultatenLijst("locatie");
                foreach (Resultaat item in lijst)
                {
                    if (this.Id.Equals(item.Id))
                    {
                        ResultatenWiskMoe.Add(item);
                    }
                }
                return ResultatenWiskMoe;
            }

        }
        public List<Resultaat> ResultatenWoMak
        {
            get
            {
                ResultatenLijst lijst = new ResultatenLijst("locatie");
                foreach (Resultaat item in lijst)
                {
                    if (this.Id.Equals(item.Id))
                    {
                        ResultatenWoMak.Add(item);
                    }
                }
                return ResultatenWoMak;
            }

        }
        public List<Resultaat> ResultatenWoMed
        {
            get
            {
                ResultatenLijst lijst = new ResultatenLijst("locatie");
                foreach (Resultaat item in lijst)
                {
                    if (this.Id.Equals(item.Id))
                    {
                        ResultatenWoMed.Add(item);
                    }
                }
                return ResultatenWoMed;
            }

        }
        public List<Resultaat> ResultatenWoMoe
        {
            get
            {
                ResultatenLijst lijst = new ResultatenLijst("locatie");
                foreach (Resultaat item in lijst)
                {
                    if (this.Id.Equals(item.Id))
                    {
                        ResultatenWoMoe.Add(item);
                    }
                }
                return ResultatenWoMoe;
            }

        }
        public int[] GemNed 
        {
            get
            {
                int totaalPunten = 0;
                int totaalSeconden = 0;
                int totaalOefeningen = 0;
                foreach (Resultaat item in ResultatenNedMak)
                {
                    totaalPunten = totaalPunten + item.TotaalPunten;
                    totaalSeconden = totaalSeconden + item.GespendeerdeTijd;
                    totaalOefeningen = totaalOefeningen + item.TotaalPunten;
                }
                foreach (Resultaat item in ResultatenNedMed)
                {
                    totaalPunten = totaalPunten + item.TotaalPunten;
                    totaalSeconden = totaalSeconden + item.GespendeerdeTijd;
                    totaalOefeningen = totaalOefeningen + item.TotaalPunten;
                }
                foreach (Resultaat item in ResultatenNedMoe)
                {
                    totaalPunten = totaalPunten + item.TotaalPunten;
                    totaalSeconden = totaalSeconden + item.GespendeerdeTijd;
                    totaalOefeningen = totaalOefeningen + item.TotaalPunten;
                }
                int[] gemNed = { totaalPunten, totaalOefeningen, totaalSeconden };
                return gemNed;
            }
        }
        public int[] GemWisk
        {
            get
            {
                int totaalPunten = 0;
                int totaalSeconden = 0;
                int totaalOefeningen = 0;
                foreach (Resultaat item in ResultatenWiskMak)
                {
                    totaalPunten = totaalPunten + item.TotaalPunten;
                    totaalSeconden = totaalSeconden + item.GespendeerdeTijd;
                    totaalOefeningen = totaalOefeningen + item.TotaalPunten;
                }
                foreach (Resultaat item in ResultatenWiskMed)
                {
                    totaalPunten = totaalPunten + item.TotaalPunten;
                    totaalSeconden = totaalSeconden + item.GespendeerdeTijd;
                    totaalOefeningen = totaalOefeningen + item.TotaalPunten;
                }
                foreach (Resultaat item in ResultatenWiskMoe)
                {
                    totaalPunten = totaalPunten + item.TotaalPunten;
                    totaalSeconden = totaalSeconden + item.GespendeerdeTijd;
                    totaalOefeningen = totaalOefeningen + item.TotaalPunten;
                }
                int[] gemWisk = { totaalPunten, totaalOefeningen, totaalSeconden };
                return gemWisk;
            }
        }
        public int[] GemWO
        {
            get
            {
                int totaalPunten = 0;
                int totaalSeconden = 0;
                int totaalOefeningen = 0;
                foreach (Resultaat item in ResultatenWoMak)
                {
                    totaalPunten = totaalPunten + item.TotaalPunten;
                    totaalSeconden = totaalSeconden + item.GespendeerdeTijd;
                    totaalOefeningen = totaalOefeningen + item.TotaalPunten;
                }
                foreach (Resultaat item in ResultatenWoMed)
                {
                    totaalPunten = totaalPunten + item.TotaalPunten;
                    totaalSeconden = totaalSeconden + item.GespendeerdeTijd;
                    totaalOefeningen = totaalOefeningen + item.TotaalPunten;
                }
                foreach (Resultaat item in ResultatenWoMoe)
                {
                    totaalPunten = totaalPunten + item.TotaalPunten;
                    totaalSeconden = totaalSeconden + item.GespendeerdeTijd;
                    totaalOefeningen = totaalOefeningen + item.TotaalPunten;
                }
                int[] gemWo = { totaalPunten, totaalOefeningen, totaalSeconden };
                return gemWo;
            }
        }
    }
}
