using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game_of_the_YEAR.ViewModels
{
    class RuleViewModel : Base.BaseViewModel
    {
        public ICommand OkBtn { get; set; }

        public RuleViewModel()
        {

        }

        public void GoToStartGamePage()
        {
            Page page = new Views.StartGamePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
    }
}
