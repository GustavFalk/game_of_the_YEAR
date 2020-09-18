using System;
using System.Collections.Generic;
using System.Text;
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
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.Views
{
    /// <summary>
    /// Interaction logic for LoadingPageOne.xaml
    /// </summary>
    public partial class LoadingPageOne : Page
    {
        public LoadingPageOne()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }
        private bool BlinkOn = false;

        Brush typGul = (Brush)new BrushConverter().ConvertFromString("#CAC8B1");
        
        private static object BrushConverter()
        {
            throw new NotImplementedException();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (BlinkOn)
            {
                insertCoinLbl.Foreground = typGul;


            }
            else
            {
                insertCoinLbl.Foreground = Brushes.Transparent;
                
            }
            BlinkOn = !BlinkOn;
        }



       
    }
}
