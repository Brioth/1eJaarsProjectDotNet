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
    public class ZombieSpelComputer : IBeweegbaar
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
                double richtingX = BepaalRichting() * HumansComputer[i].Snelheid;
                double richtingY = BepaalRichting() * HumansComputer[i].Snelheid;

                double nieuweX = HumansComputer[i].X + richtingX;
                double nieuweY = HumansComputer[i].Y + richtingY;

                if (!(nieuweX <= 0 || nieuweX+30 >= drawingCanvas.ActualWidth))
                {
                    HumansComputer[i].X = nieuweX;
                }
                if (!(nieuweY <= 0 || nieuweY+30 >= drawingCanvas.ActualHeight))
                {
                    HumansComputer[i].Y = nieuweY;
                }

            }
            for (int i = 0; i < ZombiesComputer.Count; i++) //Laat zombies bewegen
            {
                double richtingX = BepaalRichting() * ZombiesComputer[i].Snelheid;
                double richtingY = BepaalRichting() * ZombiesComputer[i].Snelheid;

                double nieuweX = ZombiesComputer[i].X + richtingX;
                double nieuweY = ZombiesComputer[i].Y + richtingY;

                if (!(nieuweX <= 0 || nieuweX+30 >= drawingCanvas.ActualWidth))
                {
                    HumansComputer[i].X = nieuweX;
                }
                if (!(nieuweY <= 0 || nieuweY+30 >= drawingCanvas.ActualHeight))
                {
                    HumansComputer[i].Y = nieuweY;
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
                    if (ZombiesComputer[i].Doelvierkant.IntersectsWith(eigenZombie.Doelvierkant))
                    {
                        ZombiesComputer[i].GeraaktDoorEigen = true;
                    }
                }
            }
        }
        public void MaakVrij()
        {

        }
        //Properties
        public List<ZombieSpelHuman> HumansComputer { get; set; }
        public List<ZombieSpelZombie> ZombiesComputer { get; set; }
    }
}
