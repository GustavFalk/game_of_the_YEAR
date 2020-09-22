using System;
using System.Collections.Generic;
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
using static Game_of_the_YEAR.Repositories.DBRepo;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;


namespace Game_of_the_YEAR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Page page = new Views.LoadingPageOne(); //LoadingPageOne();
        public MediaPlayer menuMusic = new MediaPlayer();
        public MediaPlayer coinDrop = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            Main.Content = page;
            menuMusic.Open(new Uri(@".\Assets\Sound\455017__annoyedcactus__8bit-music-for-game.wav", UriKind.Relative));
            coinDrop.Open(new Uri(@".\Assets\Sound\coindrop.wav", UriKind.Relative));
        }       
    }
}
