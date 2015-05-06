using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Groepswerk
{
    public class ZombieSpelSpeler : IBeweegbaarZombie
    {
        //Lokale variabelen
        private static Random richtingRandom = new Random();

        //Constructors
        public ZombieSpelSpeler()
        {
            HumansSpeler = new ObservableCollection<ZombieSpelHuman>();
            ZombiesSpeler = new ObservableCollection<ZombieSpelZombie>();
        }

        //Methods


        public void Beweeg(Canvas drawingCanvas)
        {
            for (int i = 0; i < HumansSpeler.Count; i++) //Laat humans bewegen
            {
                if (HumansSpeler[i].X + 30 >= drawingCanvas.ActualWidth || HumansSpeler[i].X < 0)
                {
                    HumansSpeler[i].RichtingX = -(HumansSpeler[i].RichtingX);
                    HumansSpeler[i].RichtingY = BepaalRichting();
                }
                if (HumansSpeler[i].Y + 30 >= drawingCanvas.ActualHeight || HumansSpeler[i].Y < 0)
                {
                    HumansSpeler[i].RichtingY = -(HumansSpeler[i].RichtingY);
                    HumansSpeler[i].RichtingX = BepaalRichting();
                }

                HumansSpeler[i].Positie = new Point(HumansSpeler[i].X + HumansSpeler[i].RichtingX * HumansSpeler[i].Snelheid, HumansSpeler[i].Y + HumansSpeler[i].RichtingY * HumansSpeler[i].Snelheid);

            }
            for (int i = 0; i < ZombiesSpeler.Count; i++) //Laat zombies bewegen
            {
                if (ZombiesSpeler[i].X + 30 >= drawingCanvas.ActualWidth || ZombiesSpeler[i].X < 0)
                {
                    ZombiesSpeler[i].RichtingX = -(ZombiesSpeler[i].RichtingX);
                    ZombiesSpeler[i].RichtingY = BepaalRichting();
                }
                if (ZombiesSpeler[i].Y + 30 >= drawingCanvas.ActualHeight || ZombiesSpeler[i].Y < 0)
                {
                    ZombiesSpeler[i].RichtingY = -(ZombiesSpeler[i].RichtingY);
                    ZombiesSpeler[i].RichtingX = BepaalRichting();
                }

                ZombiesSpeler[i].Positie = new Point(ZombiesSpeler[i].X + ZombiesSpeler[i].RichtingX * ZombiesSpeler[i].Snelheid, ZombiesSpeler[i].Y + ZombiesSpeler[i].RichtingY * ZombiesSpeler[i].Snelheid);

            }
        }
        private int BepaalRichting() //0 is -, 1 is blijven staan, 2 is +
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
        public void CheckHit(ObservableCollection<ZombieSpelHuman> lijstTegenstanderHumans, ObservableCollection<ZombieSpelZombie> lijstTegenstanderZombies)
        {
            for (int i = 0; i < HumansSpeler.Count; i++) //Humans geraakt door vijand
            {
                foreach (ZombieSpelHuman tegenstander in lijstTegenstanderHumans)
                {
                    if (HumansSpeler[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        HumansSpeler[i].Geraakt = true;
                    }
                }
                foreach (ZombieSpelZombie tegenstander in lijstTegenstanderZombies)
                {
                    if (HumansSpeler[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        HumansSpeler[i].Geraakt = true;
                    }
                }
            }
            for (int i = 0; i < ZombiesSpeler.Count; i++)
            {
                foreach (ZombieSpelHuman tegenstander in lijstTegenstanderHumans) //zombies geraakt door vijand
                {
                    if (ZombiesSpeler[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        ZombiesSpeler[i].GeraaktDoorVijand = true;
                    }
                }
                foreach (ZombieSpelZombie tegenstander in lijstTegenstanderZombies)
                {
                    if (ZombiesSpeler[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        ZombiesSpeler[i].GeraaktDoorVijand = true;
                    }
                }
                foreach (ZombieSpelHuman eigenHuman in HumansSpeler) //zombies geraakt door eigen partij
                {
                    if (ZombiesSpeler[i].Doelvierkant.IntersectsWith(eigenHuman.Doelvierkant))
                    {
                        ZombiesSpeler[i].GeraaktDoorEigen = true;
                    }
                }
                foreach (ZombieSpelZombie eigenZombie in ZombiesSpeler)
                {
                    if ((!(eigenZombie.Equals(ZombiesSpeler[i])))&& (ZombiesSpeler[i].Doelvierkant.IntersectsWith(eigenZombie.Doelvierkant)))
                    {
                        ZombiesSpeler[i].GeraaktDoorEigen = true;
                    }
                }
            }
        }
        public void MaakVrij(Canvas spelCanvas)
        {
            for (int i = 0; i < HumansSpeler.Count; i++)
            {
                if (HumansSpeler[i].Geraakt) //als human geraakt wordt door vijand, maak zombie
                {
                    Point positie = new Point(HumansSpeler[i].X - HumansSpeler[i].RichtingX * HumansSpeler[i].Snelheid*5, HumansSpeler[i].Y - HumansSpeler[i].RichtingY * HumansSpeler[i].Snelheid*5);
                    ZombieSpelZombie zombieSpeler = new ZombieSpelZombie(positie, "#CB2611");
                    HumansSpeler[i].VerwijderHuman(spelCanvas);
                    HumansSpeler.RemoveAt(i);
                    ZombiesSpeler.Add(zombieSpeler);
                    zombieSpeler.DisplayOn(spelCanvas);
                }
            }
            for (int i = 0; i < ZombiesSpeler.Count; i++) //als zombie geraakt door eigen maak human
            {
                if (ZombiesSpeler[i].GeraaktDoorEigen)
                {
                    Point positie = new Point(ZombiesSpeler[i].X - ZombiesSpeler[i].RichtingX * ZombiesSpeler[i].Snelheid*5, ZombiesSpeler[i].Y + ZombiesSpeler[i].RichtingY * ZombiesSpeler[i].Snelheid*5);
                    ZombieSpelHuman humanSpeler = new ZombieSpelHuman(positie, "#CB2611");
                    ZombiesSpeler[i].VerwijderZombie(spelCanvas);
                    ZombiesSpeler.RemoveAt(i);
                    HumansSpeler.Add(humanSpeler);
                    humanSpeler.DisplayOn(spelCanvas);
                }
                else if (ZombiesSpeler[i].GeraaktDoorVijand)
                {
                    ZombiesSpeler[i].VerwijderZombie(spelCanvas);
                    ZombiesSpeler.RemoveAt(i);
                }
            }
        }
        //Properties
        public ObservableCollection<ZombieSpelHuman> HumansSpeler { get; set; }
        public ObservableCollection<ZombieSpelZombie> ZombiesSpeler { get; set; }

    }
}
