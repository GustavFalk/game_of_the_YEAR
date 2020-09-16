using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.ViewModels
{
    public class StartGameCountdownModelView : Base.BaseViewModel
    {
        public int Countdown { get; set; } = 3;
        public StartGameCountdownModelView()
        {
            StartUpPage();
        }
        public async Task StartCountdown()
        {
            while (Countdown >= 1)
            {
                await Task.Delay(1100);
                Countdown --;
            }

        }
        public async void StartUpPage()
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@".\Assets\Sound\Mario_Kart_Race_Start_-_Gaming_Sound_Effect.mp3", UriKind.Relative));
            await Task.Delay(1000);
            mediaPlayer.Play();
            await StartCountdown();
            await Task.Delay(1500);
            GoToGamePage();
        }
    }
}
