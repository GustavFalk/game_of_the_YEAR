using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.ViewModels
{
    class CheckAnswerViewModel : Base.BaseViewModel
    {
        #region Number Properties

        public int UserAnswer { get; set; } = 1986;
        public int CorrectAnswer { get; set; } = 1983;
        public int DifferanceAnswers { get; set; } = 3;
        public string Deduction { get; set; } = "3 X 1000";
        public int TimePoints { get; set; } = 33307;
        public int PointsGained { get; set; } = 99999;
        public int TotalPoints { get; set; } = 183456;

        #endregion

        #region Visibility Properties

        public Visibility VisibilityFirstView { get; set; } = Visibility.Visible;
        public Visibility VisibilitySecondView { get; set; } = Visibility.Hidden;
        public Visibility VisibilityUserAnswer { get; set; } = Visibility.Hidden;
        public Visibility VisibilityCorrectAnswer { get; set; } = Visibility.Hidden;
        public Visibility VisibilityTimePoints { get; set; } = Visibility.Hidden;
        public Visibility VisibilityDifferance { get; set; } = Visibility.Hidden;
        public Visibility VisibilityDeduction { get; set; } = Visibility.Hidden;
        public Visibility VisibilityPointsGained { get; set; } = Visibility.Hidden;
        public Visibility VisibilityTotalPoints { get; set; } = Visibility.Hidden;
        public ImageSource BackgroundImage { get; set; }

        #endregion
        
        MediaPlayer mediaPlayer = new MediaPlayer();

        #region Constructor

        public CheckAnswerViewModel()
        {
            ShowOrder();

        }

        #endregion

        #region Methods/Tasks

        public async void ShowOrder()
        {
            mediaPlayer.Open(new Uri(@".\Assets\Sound\320181__dland__hint.wav", UriKind.Relative));
            await Task.Delay(1000);
            mediaPlayer.Play();
            VisibilityUserAnswer = Visibility.Visible;
            await Task.Delay(1000);
            await FlashLightning(); 
            VisibilityCorrectAnswer = Visibility.Visible;
            await Task.Delay(4000);
            VisibilityFirstView = Visibility.Hidden;
            VisibilitySecondView = Visibility.Visible;
            await Task.Delay(500);
            mediaPlayer.Open(new Uri(@".\Assets\Sound\320181__dland__hint.wav", UriKind.Relative));
            mediaPlayer.Play();
            VisibilityTimePoints = Visibility.Visible;
            await Task.Delay(500);
            PlaySoundFromZero();
            VisibilityDifferance = Visibility.Visible;
            await Task.Delay(500);
            PlaySoundFromZero();
            VisibilityDeduction = Visibility.Visible;
            await Task.Delay(500);
            PlaySoundFromZero();
            VisibilityPointsGained = Visibility.Visible;
            await Task.Delay(500);
            PlaySoundFromZero();
            VisibilityTotalPoints = Visibility.Visible;
            await Task.Delay(500);
            ConvertToTotalPoints();

        }

        public async Task FlashLightning()
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@".\Assets\Sound\donnerre2.mp3", UriKind.Relative));
            mediaPlayer.Play();
            for (int i = 0; i < 3; i++)
            {
                BackgroundImage = new BitmapImage(new Uri(@".\Assets\Images\BackgroundBlixt_Test_Black.png", UriKind.Relative));
                await Task.Delay(100);
                BackgroundImage = new BitmapImage(new Uri(@".\Assets\Images\BackgroundBlixt_Test_white.png", UriKind.Relative));
                await Task.Delay(100);
                BackgroundImage = null;
                await Task.Delay(100);
            }
        }

        public async void ConvertToTotalPoints()
        {
            mediaPlayer.Open(new Uri(@".\Assets\Sound\194182__theatomicbrain__high-score-fill-descending-faster.wav", UriKind.Relative));
            mediaPlayer.Play();
            while (PointsGained > 0)
            {
                if(PointsGained > 1133)
                {
                    PointsGained -= 333;
                    TotalPoints += 333;
                    await Task.Delay(1);
                }
                else if (PointsGained > 133)
                {
                    PointsGained -= 133;
                    TotalPoints += 133;
                    await Task.Delay(1);
                }
                else
                {
                    PointsGained --;
                    TotalPoints ++;
                    await Task.Delay(1);
                }
            }
            mediaPlayer.Stop();
        }

        public void PlaySoundFromZero()
        {
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
        }


        #endregion

    }
}
