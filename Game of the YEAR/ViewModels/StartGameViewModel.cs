using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using static Game_of_the_YEAR.ViewModels.Base.Navigation;

namespace Game_of_the_YEAR.ViewModels
{
    class StartGameViewModel : Base.BaseViewModel
    {
        public ICommand StartGameBtn { get; set; }
        public ICommand RulesBtn { get; set; }

        public StartGameViewModel()
        {
            StartGameBtn = new RelayCommand(GoToStartGameCountdownPage);
            RulesBtn = new RelayCommand(GoToRulePage);
        }      

    }
}
