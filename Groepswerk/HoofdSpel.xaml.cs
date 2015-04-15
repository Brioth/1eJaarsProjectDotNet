using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for HoofdSpel.xaml
    /// </summary>
    public partial class HoofdSpel : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private HoofdSpelLijstRood entiteitenRood;
        private HoofdSpelLijstBlauw entiteitenBlauw;

        private DispatcherTimer animationTimer;//Wnr alles beweegt
        private DispatcherTimer roodTimer;//Wnr nieuw bolletje user spawnt
        private DispatcherTimer blauwTimer;//Wnr nieuw bolletje tegenstander spawnt

        private int bolletjesRood, bolletjesBlauw, vierkantjesRood, vierkantjesBlauw;
        public HoofdSpel()
        {
            InitializeComponent();
            this.DataContext = this;

            entiteitenRood = new HoofdSpelLijstRood();
            entiteitenBlauw = new HoofdSpelLijstBlauw();

            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(50);
            animationTimer.Tick += animationTimer_Tick;
            animationTimer.IsEnabled = true;

            roodTimer = new DispatcherTimer();
            roodTimer.Interval = TimeSpan.FromSeconds(2);
            roodTimer.Tick += roodTimer_Tick;
            roodTimer.IsEnabled = true;

            blauwTimer = new DispatcherTimer();
            blauwTimer.Interval = TimeSpan.FromSeconds(2);
            blauwTimer.Tick += blauwTimer_Tick;
            blauwTimer.IsEnabled = true;

            BolletjesBlauw = 0;
            BolletjesRood = 0;
            VierkantjesBlauw = 0;
            VierkantjesRood = 0;
            
        }
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            entiteitenRood.Move();
            entiteitenBlauw.Move();
            entiteitenRood.CheckHit(entiteitenBlauw);
            entiteitenBlauw.CheckHit(entiteitenRood);
            //entiteitenRood.DisplayOn(drawingCanvas);
            //entiteitenBlauw.DisplayOn(drawingCanvas);
        }
        private void roodTimer_Tick(object sender, EventArgs e)
        {
            if (entiteitenRood.Count <= 20)
            {
                HoofdSpelBolletje bolletje = new HoofdSpelBolletje(entiteitenRood);
                entiteitenRood.Add(bolletje);
                bolletje.DisplayOn(drawingCanvas);
            }

        }
        private void blauwTimer_Tick(object sender, EventArgs e)
        {
            if (entiteitenBlauw.Count <= 20)
            {
                HoofdSpelBolletje bolletje = new HoofdSpelBolletje(entiteitenBlauw);
                entiteitenBlauw.Add(bolletje);
                bolletje.DisplayOn(drawingCanvas);
            }

        }
        public HoofdSpelLijstBlauw LijstBlauw
        {
            get { return entiteitenBlauw; }
            set
            {
                entiteitenBlauw = value;
                BolletjesBlauw = 0;
                VierkantjesBlauw = 0;
                foreach (HoofdSpelEntiteit entiteit in entiteitenBlauw)
                {
                    if (entiteit is HoofdSpelBolletje)
                    {
                        BolletjesBlauw = BolletjesBlauw++;
                    }
                    if (entiteit is HoofdSpelVierkantje)
                    {
                        VierkantjesBlauw = VierkantjesBlauw++;
                    }
                }
            }
        }
        public HoofdSpelLijstRood LijstRood
        {
            get { return entiteitenRood; }
            set
            {
                entiteitenRood = value;
                BolletjesRood = 0;
                VierkantjesRood = 0;
                foreach (HoofdSpelEntiteit entiteit in entiteitenRood)
                {
                    if (entiteit is HoofdSpelBolletje)
                    {
                        BolletjesRood = BolletjesRood++;
                    }
                    if (entiteit is HoofdSpelVierkantje)
                    {
                        VierkantjesRood = VierkantjesRood++;
                    }
                }
            }
        }
        public int BolletjesRood
        {
            get { return bolletjesRood; }
            set { bolletjesRood = value; NotifyPropertyChanged("BolletjesRood"); }
        }
        public int VierkantjesRood
        {
            get { return vierkantjesRood; }
            set { vierkantjesRood = value; NotifyPropertyChanged("VierkantjesRood"); }
        }
        public int BolletjesBlauw
        {
            get { return bolletjesBlauw; }
            set { bolletjesBlauw = value; NotifyPropertyChanged("BolletjesBlauw"); }
        }
        public int VierkantjesBlauw
        {
            get { return vierkantjesBlauw; }
            set { vierkantjesBlauw = value; NotifyPropertyChanged("VierkantjesBlauw"); }
        }

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        
    }
}
