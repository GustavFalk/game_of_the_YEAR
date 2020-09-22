﻿using Game_of_the_YEAR.Models;
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
        public ICommand DiligenceScorePageBTN { get; set; }
        public ICommand NewGameBTN { get; set; }

        List<Highscore> highscores = new List<Highscore>();

        public void InputToOutput()
        {
            HighScore1Player = $"{highscores[0].PlayerNickName}";
            HighScore2Player = $"{highscores[1].PlayerNickName}";
            HighScore3Player = $"{highscores[2].PlayerNickName}";
            HighScore4Player = $"{highscores[3].PlayerNickName}";
            HighScore5Player = $"{highscores[4].PlayerNickName}";
            HighScore1Points = $"{highscores[0].Points}";
            HighScore2Points = $"{highscores[1].Points}";
            HighScore3Points = $"{highscores[2].Points}";
            HighScore4Points = $"{highscores[3].Points}";
            HighScore5Points = $"{highscores[4].Points}";

        }

        public HighScoreViewModel()
        {
            highscores = GetHighscores();
            InputToOutput();
            DiligenceScorePageBTN = new RelayCommand(GoToDiligenceScorePage);
            NewGameBTN = new RelayCommand(GoToLoadingPageOne);
        }
    }
}
