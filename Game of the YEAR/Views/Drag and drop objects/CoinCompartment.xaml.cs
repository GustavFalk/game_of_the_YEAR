using System;
using System.Collections.Generic;
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
using static Game_of_the_YEAR.ViewModels.Base.Soundengine;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.Views.Drag_and_drop_objects
{
    /// <summary>
    /// Interaction logic for CoinCompartment.xaml
    /// </summary>
    public partial class CoinCompartment : UserControl
    {
        ImageSource backgroundImage;
        public CoinCompartment()
        {
            InitializeComponent();
            backgroundImage = new BitmapImage(new Uri(@".\Assets\Images\coindrop1.png", UriKind.Relative));
            this.Background = new ImageBrush(backgroundImage);

        }

        

        private async void UserControl_Drop(object sender, DragEventArgs e)
        {
            
            MediaPlayerLoad("coindrop.wav");
            MediaPlayerPlay();
            await Task.Delay(2500);
            GoToLoadingPageTwo();
            MediaPlayerLoad("menumusic.wav");
            MediaPlayerPlay();
        }



        private void UserControl_DragEnter(object sender, DragEventArgs e)
        {
            backgroundImage  = new BitmapImage(new Uri(@".\Assets\Images\coindrop2.png", UriKind.Relative));
            this.Background = new ImageBrush(backgroundImage);
        }

        private void UserControl_DragLeave(object sender, DragEventArgs e)
        {
            backgroundImage = new BitmapImage(new Uri(@".\Assets\Images\coindrop1.png", UriKind.Relative));
            this.Background = new ImageBrush(backgroundImage);
        }
    }
}
