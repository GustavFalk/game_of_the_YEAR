using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Game_of_the_YEAR.Models;
using static Game_of_the_YEAR.Repositories.DBRepo;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;
using static Game_of_the_YEAR.ViewModels.Base.Soundengine;

namespace Game_of_the_YEAR.ViewModels
{
    public class StartGameCountdownModelView : Base.BaseViewModel
    {
        public int Countdown { get; set; } = 3;
        public StartGameCountdownModelView()
        {
            StartUpPage();
            LoadQuestionsToGame();
            
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
            MediaPlayerLoad(sounds._321go);
            await Task.Delay(1000);
            MediaPlayerPlay();
            await StartCountdown();
            await Task.Delay(1500);
            GoToGamePage();
        }
        public void LoadQuestionsToGame()
        {
            CurrentGame.Questions = null;
            CurrentGame.Questions = GetQuestions();
            CurrentGame.CurrentQuestion = 0;
        }
    }
}
