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
    class DiligenceScoreViewmodel : Base.BaseViewModel
    {
        #region Properties
        public string DiligenceScore1Player { get; set; }
        public string DiligenceScore2Player { get; set; }
        public string DiligenceScore3Player { get; set; }
        public string DiligenceScore4Player { get; set; }
        public string DiligenceScore5Player { get; set; }
        public string DiligenceScore1Rounds { get; set; }
        public string DiligenceScore2Rounds { get; set; }
        public string DiligenceScore3Rounds { get; set; }
        public string DiligenceScore4Rounds { get; set; }
        public string DiligenceScore5Rounds { get; set; }
        public string CurrentPlayerName { get; set; }
        public Int64 GameRounds { get; set; }
        public Int64 Placement { get; set; }

        public ICommand HighScorePageBTN { get; set; }
        public ICommand NewGameBTN { get; set; }

        List<DiligenceScore> diligenceScores = new List<DiligenceScore>();

        #endregion

        #region Clue Methods/Tasks
        public void InputToOutput()
        {
            DiligenceScore1Player = $"{diligenceScores[0].PlayerNickName}";
            DiligenceScore2Player = $"{diligenceScores[1].PlayerNickName}";
            DiligenceScore3Player = $"{diligenceScores[2].PlayerNickName}";
            DiligenceScore4Player = $"{diligenceScores[3].PlayerNickName}";
            DiligenceScore5Player = $"{diligenceScores[4].PlayerNickName}";
            DiligenceScore1Rounds = $"{diligenceScores[0].GameRounds}";
            DiligenceScore2Rounds = $"{diligenceScores[1].GameRounds}";
            DiligenceScore3Rounds = $"{diligenceScores[2].GameRounds}";
            DiligenceScore4Rounds = $"{diligenceScores[3].GameRounds}";
            DiligenceScore5Rounds = $"{diligenceScores[4].GameRounds}";           

        }
        #endregion

        #region Constructors
        public DiligenceScoreViewmodel()
        {
            diligenceScores = GetDiligenceScores();
            InputToOutput();
            CurrentPlayerName = CurrentGame.CurrentPlayer.Nickname;
            GameRounds = GetDiligence(CurrentGame.CurrentPlayer.PlayerID);
            Placement = GetPlacementDiligence(GameRounds);
            HighScorePageBTN = new RelayCommand(GoToHighScorePage);
            NewGameBTN = new RelayCommand(GoToStartGamePage);
        }
        #endregion
    }
}
