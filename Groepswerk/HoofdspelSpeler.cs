using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Groepswerk
{
    public class HoofdspelSpeler : IBeweegbaarHoofdSpel
    {
        //Lokale variabelen
        private static Random richtingRandom = new Random();

        //Constructors
        public HoofdspelSpeler()
        {
            Bolletjes = new ObservableCollection<HoofdSpelBolletje>();
            Vierkantjes = new ObservableCollection<HoofdSpelVierkantje>();
        }
        //Methods

        public void Beweeg(Canvas drawingCanvas)
        {
            for (int i = 0; i < Bolletjes.Count; i++)
            {
                if (Bolletjes[i].X + 20 >= drawingCanvas.ActualWidth || Bolletjes[i].X <0)
                {
                    Bolletjes[i].RichtingX = -(Bolletjes[i].RichtingX);
                    Bolletjes[i].RichtingY = BepaalRichting();
                }
                if (Bolletjes[i].Y + 20 >= drawingCanvas.ActualHeight || Bolletjes[i].Y < 0)
                {
                    Bolletjes[i].RichtingX = BepaalRichting();
                    Bolletjes[i].RichtingY = -(Bolletjes[i].RichtingY);
                }
                Bolletjes[i].Positie = new Point(Bolletjes[i].X + Bolletjes[i].RichtingX * Bolletjes[i].Snelheid, Bolletjes[i].Y + Bolletjes[i].RichtingY * Bolletjes[i].Snelheid);

            }
            for (int i = 0; i < Vierkantjes.Count; i++)
            {
                if (Vierkantjes[i].X + 20 >= drawingCanvas.ActualWidth || Vierkantjes[i].X < 0)
                {
                    Vierkantjes[i].RichtingX = -(Vierkantjes[i].RichtingX);
                    Vierkantjes[i].RichtingY = BepaalRichting();
                }
                if (Vierkantjes[i].Y + 20 >= drawingCanvas.ActualHeight || Vierkantjes[i].Y < 0)
                {
                    Vierkantjes[i].RichtingX = BepaalRichting();
                    Vierkantjes[i].RichtingY = -(Vierkantjes[i].RichtingY);
                }
                Vierkantjes[i].Positie = new Point(Vierkantjes[i].X + Vierkantjes[i].RichtingX * Vierkantjes[i].Snelheid, Vierkantjes[i].Y + Vierkantjes[i].RichtingY * Vierkantjes[i].Snelheid);

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
        public void CheckHit(ObservableCollection<HoofdSpelBolletje> lijstTegenstanderBolletjes, ObservableCollection<HoofdSpelVierkantje> lijstTegenstanderVierkantjes)
        {
            for (int i = 0; i < Bolletjes.Count; i++) //Humans geraakt door vijand
            {
                foreach (HoofdSpelBolletje tegenstander in lijstTegenstanderBolletjes)
                {
                    if (Bolletjes[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        Bolletjes[i].Geraakt = true;
                    }
                }
                foreach (HoofdSpelVierkantje tegenstander in lijstTegenstanderVierkantjes)
                {
                    if (Bolletjes[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        Bolletjes[i].Geraakt = true;
                    }
                }
            }
            for (int i = 0; i < Vierkantjes.Count; i++)
            {
                foreach (HoofdSpelBolletje tegenstander in lijstTegenstanderBolletjes) //zombies geraakt door vijand
                {
                    if (Vierkantjes[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        Vierkantjes[i].GeraaktDoorVijand = true;
                    }
                }
                foreach (HoofdSpelVierkantje tegenstander in lijstTegenstanderVierkantjes)
                {
                    if (Vierkantjes[i].Doelvierkant.IntersectsWith(tegenstander.Doelvierkant))
                    {
                        Vierkantjes[i].GeraaktDoorVijand = true;
                    }
                }
                foreach (HoofdSpelBolletje eigenBolletje in Bolletjes) //zombies geraakt door eigen partij
                {
                    if (Vierkantjes[i].Doelvierkant.IntersectsWith(eigenBolletje.Doelvierkant))
                    {
                        Vierkantjes[i].GeraaktDoorEigen = true;
                    }
                }
                foreach (HoofdSpelVierkantje eigenVierkantje in Vierkantjes)
                {
                    if ((!(eigenVierkantje.Equals(Vierkantjes[i]))) && (Vierkantjes[i].Doelvierkant.IntersectsWith(eigenVierkantje.Doelvierkant)))
                    {
                        Vierkantjes[i].GeraaktDoorEigen = true;
                    }
                }
            }
        }
        public void MaakVrij(Canvas spelCanvas, string kleur)
        {
            for (int i = 0; i < Bolletjes.Count; i++)
            {
                if (Bolletjes[i].Geraakt) //als human geraakt wordt door vijand, maak zombie
                {
                    Point positie = new Point(Bolletjes[i].X - Bolletjes[i].RichtingX * Bolletjes[i].Snelheid * 5, Bolletjes[i].Y - Bolletjes[i].RichtingY * Bolletjes[i].Snelheid * 5);
                    HoofdSpelVierkantje vierkantje = new HoofdSpelVierkantje(positie, kleur, spelCanvas);
                    Bolletjes[i].VerwijderBolletje(spelCanvas);
                    Bolletjes.RemoveAt(i);
                    Vierkantjes.Add(vierkantje);
                    vierkantje.DisplayOn(spelCanvas);
                }
            }
            for (int i = 0; i < Vierkantjes.Count; i++) //als zombie geraakt door eigen maak human
            {
                if (Vierkantjes[i].GeraaktDoorEigen)
                {
                    Point positie = new Point(Vierkantjes[i].X - Vierkantjes[i].RichtingX * Vierkantjes[i].Snelheid * 5, Vierkantjes[i].Y + Vierkantjes[i].RichtingY * Vierkantjes[i].Snelheid * 5);
                    HoofdSpelBolletje bolletje = new HoofdSpelBolletje(positie, kleur, spelCanvas);
                    Vierkantjes[i].VerwijderVierkant(spelCanvas);
                    Vierkantjes.RemoveAt(i);
                    Bolletjes.Add(bolletje);
                    bolletje.DisplayOn(spelCanvas);
                }
                else if (Vierkantjes[i].GeraaktDoorVijand)
                {
                    Vierkantjes[i].VerwijderVierkant(spelCanvas);
                    Vierkantjes.RemoveAt(i);
                }
            }
        }
        //Properties
        public ObservableCollection<HoofdSpelBolletje> Bolletjes { get; set; }
        public ObservableCollection<HoofdSpelVierkantje> Vierkantjes { get; set; }

    }
}
