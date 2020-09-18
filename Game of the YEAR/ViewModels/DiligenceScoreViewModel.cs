﻿using Game_of_the_YEAR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Game_of_the_YEAR.ViewModels
{
    class DiligenceScoreViewmodel : Base.BaseViewModel
    {

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
        public ICommand ButtonCommand { get; set; }

        public void InputToOutput()
        {
            DiligenceScore1Player = "NVM";
            DiligenceScore2Player = "BOB";
            DiligenceScore3Player = "SUD";
            DiligenceScore4Player = "LOL";
            DiligenceScore5Player = "BRU";
            DiligenceScore1Rounds = "101";
            DiligenceScore2Rounds = "88";
            DiligenceScore3Rounds = "86";
            DiligenceScore4Rounds = "65";
            DiligenceScore5Rounds = "4";

        }

        public DiligenceScoreViewmodel()
        {
            ButtonCommand = new RelayCommand(InputToOutput);
        }

    }
}
