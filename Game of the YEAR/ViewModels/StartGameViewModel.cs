using Game_of_the_YEAR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;
using static Game_of_the_YEAR.ViewModels.Base.Soundengine;


namespace Game_of_the_YEAR.ViewModels
{
    class StartGameViewModel : Base.BaseViewModel
    {
        public ICommand StartGameBtn { get; set; }
        public ICommand RulesBtn { get; set; }

        public void StartGame()
        {
            MediaPlayerPause();
            MediaPlayerLoad("321go.mp3");
            GoToStartGameCountdownPage();
        }
        public StartGameViewModel()
        {
            GameEngine.ResetGame();
            StartGameBtn = new RelayCommand(StartGame);
            RulesBtn = new RelayCommand(GoToRulePage);
        }      

    }
}
