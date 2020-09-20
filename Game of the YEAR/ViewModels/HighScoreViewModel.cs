using Game_of_the_YEAR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;
using static Game_of_the_YEAR.Repositories.DBRepo;
using Npgsql;
using System.Linq.Expressions;

namespace Game_of_the_YEAR.ViewModels
{
    class HighScoreViewModel:Base.BaseViewModel
    {
        public string HighScore1Player { get; set; }
        public string HighScore2Player { get; set; }
        public string HighScore3Player { get; set; }
        public string HighScore4Player { get; set; }
        public string HighScore5Player { get; set; }
        public string HighScore1Points { get; set; }
        public string HighScore2Points { get; set; }
        public string HighScore3Points { get; set; }
        public string HighScore4Points { get; set; }
        public string HighScore5Points { get; set; }
        public ICommand ButtonCommand { get; set; }

        public void InputToOutput()
        {
            HighScore1Player = "NVM";
            HighScore2Player = "BOB";
            HighScore3Player = "SUD";
            HighScore4Player = "LOL";
            HighScore5Player = "BRU";
            HighScore1Points = "98992";
            HighScore2Points = "77948";
            HighScore3Points = "71993";
            HighScore4Points = "58448";
            HighScore5Points = "22291";

        }

        public void GetHighScores()
        {

        }

        public HighScoreViewModel()
        {
            ButtonCommand = new RelayCommand(InputToOutput);
        }
    }
}
