using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.ViewModels
{
    class GamePageViewModel : Base.BaseViewModel
    {
        #region Properties

        public int Points { get; set; } = 99999;
        public bool CountDown { get; set; } = true;
        public string Hint { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Number3 { get; set; }
        public string Number4 { get; set; }
        public int Answer { get; set; }
        public Visibility NotNumberVisibility { get; set; } = Visibility.Hidden;
        public ICommand OKCommand { get; set; }

        #endregion

        #region Constructors
        public GamePageViewModel()
        {
            mediaPlayer.Open(new Uri(@".\Assets\Sound\morton_gould_1913_1996_spirituals_for_strings_choir_and_orchestra_1959_1_2_1959050878275738400.wav", UriKind.Relative));
            OpenPage();
            OKCommand = new RelayCommand(OKButton);
        }

        #endregion

        #region Points Counter Methods

        public async void CountDownPoints()
        {
            while (Points > 0)
            {
                Points -= 47;
                await Task.Delay(1);
                if (CountDown == false)
                {
                    break;
                }
            }
            if (Points < 0)
            {
                Points = 0;
            }
        }

        public void StopCountDown()
        {
            CountDown = false;
        }

        #endregion

        #region Clue Methods/Tasks

        public async Task TypeClueSlower()
        {
            string fullHint = "Långfredagsavtalet signerades mellan England och Irland detta år";

            foreach (var letter in fullHint)
            {

                Hint += char.ToUpper(letter);
                await Task.Delay(30);
            }
        }

        #endregion


        public async void OpenPage()
        {
            await TypeClueSlower();

            mediaPlayer.Play();
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
                mediaPlayer.Stop();
                GoToCheckAnswerPage();
            }
        }
        private MediaPlayer mediaPlayer = new MediaPlayer();



    } 
           
}
