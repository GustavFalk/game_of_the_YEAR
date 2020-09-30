using Game_of_the_YEAR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;
using static Game_of_the_YEAR.ViewModels.Base.Soundengine;

namespace Game_of_the_YEAR.ViewModels
{
    class GamePageViewModel : Base.BaseViewModel
    {
        #region Variables

        private int clueIndex = 0;

        #endregion

        #region Properties

        public int TimePoints { get; set; } = 99999;
        public bool CountDown { get; set; } = true;
        public string Hint { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Number3 { get; set; }
        public string Number4 { get; set; }
        public int Answer { get; set; }
        public Visibility NotNumberVisibility { get; set; } = Visibility.Hidden;
        public ICommand OKBtn { get; set; }
        public string GuessNumber { get; set; }

        #endregion

        #region Constructors
        public GamePageViewModel()
        {
            MediaPlayerLoad(sounds.gamemusic);
            OpenPage();
            OKBtn = new RelayCommand(OKButton);
        }

        #endregion

        #region Methods

        public async void CountDownPoints()
        {
            while (TimePoints > 0)
            {
                NextClue();
                TimePoints -= 47;
                await Task.Delay(1);
                if (CountDown == false)
                {
                    break;
                }
            }
            if (TimePoints < 0)
            {
                TimePoints = 0;
            }
        }

        public void StopCountDown()
        {
            CountDown = false;
        }

        public void CurrentGuessNumber()
        {
            GuessNumber = $"{CurrentGame.CurrentQuestion +1}/{CurrentGame.Questions.Count}";
        }

        public async Task TypeClueSlower(int clueIndex)
        {
            Hint = "";
            string fullHint = CurrentGame.Questions[CurrentGame.CurrentQuestion].Clues[clueIndex];

            foreach (var letter in fullHint)
            {

                Hint += char.ToUpper(letter);
                await Task.Delay(30);
            }
        }
        public void NextClue()
        {
            if (clueIndex == 0 && TimePoints < 68000)
            {
                clueIndex++;
                _ = TypeClueSlower(clueIndex);
            }
            else if (clueIndex == 1 && TimePoints < 35000)
            {
                clueIndex++;
                _ =TypeClueSlower(clueIndex);
            }
        }

        public async void OpenPage()
        {
            CurrentGuessNumber();
            await TypeClueSlower(clueIndex);
            MediaPlayerPlay();
            CountDownPoints();
        }

        public bool MakeAnswerToInt()
        {
            bool isNumber;
            int intAnswer;
            string stringAnswer = $"{Number1}{Number2}{Number3}{Number4}";
            isNumber = int.TryParse(stringAnswer, out intAnswer);
            Answer = intAnswer;
            return isNumber;
        }
        public void OKButton()
        {
            if (MakeAnswerToInt() == false)
            {
                NotNumberVisibility = Visibility.Visible;
            }
            else
            {
                StopCountDown();
                CurrentGame.UserAnswer = Answer;
                CurrentGame.TimePoints = TimePoints;
                MediaPlayerPause();
                GoToCheckAnswerPage();
            }
        }
        #endregion
    }

}
