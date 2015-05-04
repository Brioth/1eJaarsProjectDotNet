using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace Groepswerk
{
    public class ZombieSpelComputer : IBeweegbaarZombie
    {
        //Lokale variabelen
        private static Random richtingRandom = new Random();
        //Constructors
        public ZombieSpelComputer()
        {
            HumansComputer = new List<ZombieSpelHuman>();
            ZombiesComputer = new List<ZombieSpelZombie>();
        }

        //Methods

        public void Beweeg(Canvas drawingCanvas)
        {
            for (int i = 0; i < HumansComputer.Count; i++) //Laat humans bewegen
            {
                if (HumansComputer[i].X + 30 >= drawingCanvas.ActualWidth || HumansComputer[i].X < 0)
                {
                    HumansComputer[i].RichtingX = -(HumansComputer[i].RichtingX);
                    HumansComputer[i].RichtingY = BepaalRichting();
                }
                if (HumansComputer[i].Y + 30 >= drawingCanvas.ActualHeight || HumansComputer[i].Y < 0)
                {
                    HumansComputer[i].RichtingY = -(HumansComputer[i].RichtingY);
                    HumansComputer[i].RichtingX = BepaalRichting();
                }

                HumansComputer[i].Positie = new Point(HumansComputer[i].X + HumansComputer[i].RichtingX * HumansComputer[i].Snelheid, HumansComputer[i].Y + HumansComputer[i].RichtingY * HumansComputer[i].Snelheid);
            }
            for (int i = 0; i < ZombiesComputer.Count; i++) //Laat zombies bewegen
            {
                if (ZombiesComputer[i].X + 30 >= drawingCanvas.ActualWidth || ZombiesComputer[i].X < 0)
                {
                    ZombiesComputer[i].RichtingX = -(ZombiesComputer[i].RichtingX);
                    ZombiesComputer[i].RichtingY = BepaalRichting();
                }
                if (ZombiesComputer[i].Y + 30 >= drawingCanvas.ActualHeight || ZombiesComputer[i].Y < 0)
                {
                    ZombiesComputer[i].RichtingY = -(ZombiesComputer[i].RichtingY);
                    ZombiesComputer[i].RichtingX = BepaalRichting();
                }

                ZombiesComputer[i].Positie = new Point(ZombiesComputer[i].X + ZombiesComputer[i].RichtingX * ZombiesComputer[i].Snelheid, ZombiesComputer[i].Y + ZombiesComputer[i].RichtingY * ZombiesComputer[i].Snelheid);
            }
        }

        private int BepaalRichting() //0 is -, 1 is blijven staan en 2 is +
        {
            int gekozenrichting = richtingRandom.Next(3);
            int richting;

            switch (gekozenrichting)
            {
                case 0:
                    richting = -1;
                    break;
                case 1:
                    richting = 0;
                    break;
                case 2:
                    richting = 1;
                    break;
                default:
                    richting = 0;
                    MessageBox.Show("Richting is niet juist gegenereerd"); //Mag later weg, voor debug
                    break;
            }
            return richting;
        }
        public void CheckHit(List<ZombieSpelHuman> lijstTegenstanderHumans, List<ZombieSpelZombie> lijstTegenstanderZombies)
        {
            for (int i = 0; i < HumansComputer.Count; i++) //Humans geraakt door vijand
            {
                foreach (ZombieSpelHuman tegenstander in lijstTegenstanderHumans)
                {
                    if (HumansComputer[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        HumansComputer[i].Geraakt = true;
                    }
                }
                foreach (ZombieSpelZombie tegenstander in lijstTegenstanderZombies)
                {
                    if (HumansComputer[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        HumansComputer[i].Geraakt = true;
                    }
                }
            }
            for (int i = 0; i < ZombiesComputer.Count; i++)
            {
                foreach (ZombieSpelHuman tegenstander in lijstTegenstanderHumans) //zombies geraakt door vijand
                {
                    if (ZombiesComputer[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        ZombiesComputer[i].GeraaktDoorVijand = true;
                    }
                }
                foreach (ZombieSpelZombie tegenstander in lijstTegenstanderZombies)
                {
                    if (ZombiesComputer[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        ZombiesComputer[i].GeraaktDoorVijand = true;
                    }
                }
                foreach (ZombieSpelHuman eigenHuman in HumansComputer) //zombies geraakt door eigen partij
                {
                    if (ZombiesComputer[i].Doelvierkant.IntersectsWith(eigenHuman.Doelvierkant))
                    {
                        ZombiesComputer[i].GeraaktDoorEigen = true;
                    }
                }
                foreach (ZombieSpelZombie eigenZombie in ZombiesComputer)
                {
                    if ((!(eigenZombie.Equals(ZombiesComputer[i])))&&(ZombiesComputer[i].Doelvierkant.IntersectsWith(eigenZombie.Doelvierkant)))
                    {
                        ZombiesComputer[i].GeraaktDoorEigen = true;
                    }
                }
            }
        }
        public void MaakVrij(Canvas spelCanvas)
        {
            for (int i = 0; i < HumansComputer.Count; i++)
            {
                if (HumansComputer[i].Geraakt) //als human geraakt door vijand maak zombie
                {
                    Point positie = new Point(HumansComputer[i].X - HumansComputer[i].RichtingX * HumansComputer[i].Snelheid*5, HumansComputer[i].Y - HumansComputer[i].RichtingY * HumansComputer[i].Snelheid*5);
                    ZombieSpelZombie zombieComputer = new ZombieSpelZombie(positie, "#13737C");
                    HumansComputer[i].VerwijderHuman(spelCanvas);
                    HumansComputer.RemoveAt(i);
                    ZombiesComputer.Add(zombieComputer);
                    zombieComputer.DisplayOn(spelCanvas);
                }
            }
            for (int i = 0; i < ZombiesComputer.Count; i++) //als zombie geraakt door eigen maak human
            {
                if (ZombiesComputer[i].GeraaktDoorEigen)
                {
                    Point positie = new Point(ZombiesComputer[i].X - ZombiesComputer[i].RichtingX * ZombiesComputer[i].Snelheid*5, ZombiesComputer[i].Y - ZombiesComputer[i].RichtingY * ZombiesComputer[i].Snelheid*5);
                    ZombieSpelHuman humanComputer = new ZombieSpelHuman(positie, "#13737C");
                    ZombiesComputer[i].VerwijderZombie(spelCanvas);
                    ZombiesComputer.RemoveAt(i);
                    HumansComputer.Add(humanComputer);
                    humanComputer.DisplayOn(spelCanvas);
                }
                else if (ZombiesComputer[i].GeraaktDoorVijand)
                {
                    ZombiesComputer[i].VerwijderZombie(spelCanvas);
                    ZombiesComputer.RemoveAt(i);
                }
            }

        }
        //Properties
        public List<ZombieSpelHuman> HumansComputer { get; set; }
        public List<ZombieSpelZombie> ZombiesComputer { get; set; }
    }
}
