using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Game_of_the_YEAR.ViewModels
{
    class GamePageViewModel:Base.BaseViewModel
    {
        public int Points { get; set; } = 99999;
        public bool CountDown { get; set; } = true;
        public string Hint { get; set; }
        public ICommand OKCommand { get; set; }
        public GamePageViewModel()
        {
            OpenPage();
            OKCommand = new RelayCommand(StopCountDown);
        }

        #region Points Counter Methods

        public async void CountDownPoints()
        {
            while (Points > 0)
            {
                Points -= 43;
                await Task.Delay(1);
                if ( CountDown == false)
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
            
            CountDownPoints();
        }
    }
}
