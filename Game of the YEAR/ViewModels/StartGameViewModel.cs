using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game_of_the_YEAR.ViewModels
{
    class StartGameViewModel : Base.BaseViewModel
    {
        public ICommand StartGameBtn { get; set; }
        public ICommand RulesBtn { get; set; }

        public StartGameViewModel()
        {

        }

        public void GoToGamePage()
        {
            Page page = new Views.GamePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }

        public void GoToRulePage()
        {
            Page page = new Views.RulePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }

    }
}
