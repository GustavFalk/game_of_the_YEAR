using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static Game_of_the_YEAR.Repositories.DBRepo;



namespace Game_of_the_YEAR
{
    public class MainWindowViewModel : Game_of_the_YEAR.ViewModels.Base.BaseViewModel
    {
        public int AmountOutput { get; set; }

        public ICommand MuteCommand { get; set; }

        public ImageSource MuteImage { get; set; } = new BitmapImage(new Uri(@".\Assets\Images\icons8-low-volume-50.png", UriKind.Relative));

        public MainWindowViewModel()
        {
            MuteCommand = new RelayCommand(ChangeMute);
            
        }

        public void Amount()
        {
            //AmountOutput = GetAmountOfYears();
        }

        public void ChangeMute()
        {
            if (((MainWindow)System.Windows.Application.Current.MainWindow).menuMusic.Volume == 0)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).menuMusic.Volume = 0.5;
                MuteImage = new BitmapImage(new Uri(@".\Assets\Images\icons8-low-volume-50.png", UriKind.Relative));
            }
            else
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).menuMusic.Volume = 0;
                MuteImage = new BitmapImage(new Uri(@".\Assets\Images\icons8-low-volume-off.png", UriKind.Relative));
                
            }
        }

    }
}
