using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static Game_of_the_YEAR.Repositories.DBRepo;
using static Game_of_the_YEAR.ViewModels.Base.Soundengine;



namespace Game_of_the_YEAR
{
    public class MainWindowViewModel : Game_of_the_YEAR.ViewModels.Base.BaseViewModel
    {
        #region Properties
        public int AmountOutput { get; set; }

        public ICommand MuteCommand { get; set; }

        public ImageSource MuteImage { get; set; } = new BitmapImage(new Uri(@".\Assets\Images\icons8-low-volume-50.png", UriKind.Relative));
        #endregion
        #region Constructor
        public MainWindowViewModel()
        {
            MuteCommand = new RelayCommand(ChangeMute);            
        }
        #endregion
        #region Methods
        public void ChangeMute()
        {
            if (((MainWindow)System.Windows.Application.Current.MainWindow).mediaPlayer.Volume == 0)
            {
                MediaPlayerVolume(0.2);
                MuteImage = new BitmapImage(new Uri(@".\Assets\Images\icons8-low-volume-50.png", UriKind.Relative));
            }
            else
            {
                MediaPlayerVolume(0);
                MuteImage = new BitmapImage(new Uri(@".\Assets\Images\icons8-low-volume-off.png", UriKind.Relative));
                
            }
        }
        #endregion

    }
}
