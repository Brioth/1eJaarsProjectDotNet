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
            Dead = false;

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

                if (HumansComputer[i].X <= 0 || HumansComputer[i].X >= drawingCanvas.Width)
                {
                    richtingX = -richtingX;
                }
                if (HumansComputer[i].Y <= 0 || HumansComputer[i].X >= drawingCanvas.Height)
                {
                    richtingY = -richtingY;
                }

                HumansComputer[i].X = HumansComputer[i].X + richtingX;
                HumansComputer[i].Y = HumansComputer[i].Y + richtingY;

            }
            for (int i = 0; i < ZombiesComputer.Count; i++) //Laat zombies bewegen
            {
                double richtingX = BepaalRichting() * ZombiesComputer[i].Snelheid;
                double richtingY = BepaalRichting() * ZombiesComputer[i].Snelheid;

                if (ZombiesComputer[i].X <= 0 || ZombiesComputer[i].X >= drawingCanvas.Width)
                {
                    richtingX = -richtingX;
                }
                if (ZombiesComputer[i].Y <= 0 || ZombiesComputer[i].X >= drawingCanvas.Height)
                {
                    richtingY = -richtingY;
                }

                ZombiesComputer[i].X = ZombiesComputer[i].X + richtingX;
                ZombiesComputer[i].Y = ZombiesComputer[i].Y + richtingY;
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
        public void CheckHit()
        {
            //for (int i = 0; i < HumansComputer.Count; i++)
            //{
            //    HumansComputer[i].CheckHit();
            //    if (HumansComputer[i].Geraakt)
            //    {
            //        //wordt zombie
            //    }
            //}
            //for (int i = 0; i < ZombiesComputer.Count; i++)
            //{
            //    ZombiesComputer[i].CheckHit();
            //    if (ZombiesComputer[i].GeraaktDoorEigen)
            //    {
            //        //wordt human
            //    }
            //    if (ZombiesComputer[i].GeraaktDoorVijand)
            //    {
            //        //ga dood, bool
            //    }
            //}
        }
        public void MaakVrij()
        {

        }
        //Properties
        public bool Dead { get; set; }
        public List<ZombieSpelHuman> HumansComputer { get; set; }
        public List<ZombieSpelZombie> ZombiesComputer { get; set; }
    }
}
