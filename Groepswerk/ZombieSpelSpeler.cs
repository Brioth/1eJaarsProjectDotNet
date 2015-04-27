using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Groepswerk
{
    public class ZombieSpelSpeler : IBeweegbaar
    {
        //Lokale variabelen

        //Constructors
        public ZombieSpelSpeler()
        {


            Dead = false;

            HumansSpeler = new List<ZombieSpelHuman>();
            ZombiesSpeler = new List<ZombieSpelZombie>();
        }

        //Methods


        public void Beweeg(Canvas drawingCanvas)
        {
            //foreach (ZombieSpelHuman human in HumansSpeler)
            //{
            //    human.Beweeg();
            //}
            //foreach (ZombieSpelZombie zombie in ZombiesSpeler)
            //{
            //    zombie.Beweeg();
            //}
        }
        public void CheckHit()
        {
            //for (int i = 0; i < HumansSpeler.Count; i++)
            //{
            //    HumansSpeler[i].CheckHit();
            //    if (HumansSpeler[i].Geraakt)
            //    {
            //        //wordt zombie
            //    }
            //}
            //for (int i = 0; i < ZombiesSpeler.Count; i++)
            //{
            //    ZombiesSpeler[i].CheckHit();
            //    if (ZombiesSpeler[i].GeraaktDoorEigen)
            //    {
            //        //wordt human
            //    }
            //    if (ZombiesSpeler[i].GeraaktDoorVijand)
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
        public List<ZombieSpelHuman> HumansSpeler { get; set; }
        public List<ZombieSpelZombie> ZombiesSpeler { get; set; }

    }
}
