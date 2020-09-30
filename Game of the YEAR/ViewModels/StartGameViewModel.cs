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
        #region Properties
        public ICommand StartGameBtn { get; set; }
        public ICommand RulesBtn { get; set; }
        public ICommand LogOutBtn { get; set; }
        #endregion
        #region Methods
        public void StartGame()
        {
            MediaPlayerPause();
            MediaPlayerLoad(sounds._321go);
            GoToStartGameCountdownPage();
        }
        #endregion
        #region Constructor
        public StartGameViewModel()
        {
            GameEngine.ResetGame();
            StartGameBtn = new RelayCommand(StartGame);
            RulesBtn = new RelayCommand(GoToRulePage);
            LogOutBtn = new RelayCommand(GoToLoadingPageOne);
        }
        #endregion

    }
}
