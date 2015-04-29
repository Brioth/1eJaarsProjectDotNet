using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Groepswerk
{
    public class ZombieSpelSpeler : IBeweegbaar
    {
        //Lokale variabelen
        private static Random richtingRandom = new Random();

        //Constructors
        public ZombieSpelSpeler()
        {
            HumansSpeler = new List<ZombieSpelHuman>();
            ZombiesSpeler = new List<ZombieSpelZombie>();
        }

        //Methods


        public void Beweeg(Canvas drawingCanvas)
        {
            for (int i = 0; i < HumansSpeler.Count; i++) //Laat humans bewegen
            {
                double richtingX = BepaalRichting() * HumansSpeler[i].Snelheid;
                double richtingY = BepaalRichting() * HumansSpeler[i].Snelheid;

                double nieuweX = HumansSpeler[i].X + richtingX;
                double nieuweY = HumansSpeler[i].Y + richtingY;

                if (!(nieuweX <= 0 || nieuweX+30 >= drawingCanvas.ActualWidth))
                {
                    HumansSpeler[i].X = nieuweX;
                }
                if (!(nieuweY <= 0 || nieuweY+30 >= drawingCanvas.ActualHeight))
                {
                    HumansSpeler[i].Y = nieuweY;
                }

            }
            for (int i = 0; i < ZombiesSpeler.Count; i++) //Laat zombies bewegen
            {
                double richtingX = BepaalRichting() * ZombiesSpeler[i].Snelheid;
                double richtingY = BepaalRichting() * ZombiesSpeler[i].Snelheid;

                double nieuweX = ZombiesSpeler[i].X + richtingX;
                double nieuweY = ZombiesSpeler[i].Y + richtingY;

                if (!(nieuweX <= 0 || nieuweX+30 >= drawingCanvas.ActualWidth))
                {
                    HumansSpeler[i].X = nieuweX;
                }
                if (!(nieuweY <= 0 || nieuweY+30 >= drawingCanvas.ActualHeight))
                {
                    HumansSpeler[i].Y = nieuweY;
                }
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
        public void CheckHit(List<ZombieSpelHuman> lijstTegenstanderHumans, List<ZombieSpelZombie> lijstTegenstanderZombies)
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
                    if (ZombiesSpeler[i].Doelvierkant.IntersectsWith(eigenZombie.Doelvierkant))
                    {
                        ZombiesSpeler[i].GeraaktDoorEigen = true;
                    }
                }
            }
        }
        public void MaakVrij()
        {

        }
        //Properties
        public List<ZombieSpelHuman> HumansSpeler { get; set; }
        public List<ZombieSpelZombie> ZombiesSpeler { get; set; }

    }
}
